using System.Collections.Generic;
using System.Xml.Serialization;

namespace Resco.InAppSpeechRecognition.Srgs
{
    /// <summary>
    /// Class that usually represents word or phrase that user must say once, more times or its optional. Can have inner elements or can be tagged.
    /// </summary>
    public class Item : RuleItem
    {
        private string m_repeat;
        private List<RuleItem> m_Elements = new List<RuleItem>();

		/// <summary>
		/// Creates new instance of <see cref="Item"/>
		/// </summary>
        public Item() 
        { }

		/// <summary>
		/// Creates new instance of <see cref="Item"/>
		/// </summary>
		/// <param name="tag">Item will be tagged with <see cref="Tag"/></param>
		public Item(Tag tag)
        {
            this.m_Elements.Add(tag);
        }

		/// <summary>
		/// Creates new instance of <see cref="Item"/>
		/// </summary>
		/// <param name="content">Content of the <see cref="Item"/> element</param>
		public Item(string content) 
        {
            this.Content = content;
        }

		/// <summary>
		/// Creates new instance of <see cref="Item"/>
		/// </summary>
		/// <param name="content">Content of the <see cref="Item"/> element</param>
		/// <param name="tag">Item will be tagged with <see cref="Tag"/></param>
		public Item(string content, Tag tag) : this(tag)
        {
            this.Content = content;
        }

		/// <summary>
		/// Creates new instance of <see cref="Item"/>
		/// </summary>
		/// <param name="content">Content of the <see cref="Item"/> element</param>
		/// <param name="repeat">Sets how many times must be item said.</param>
		public Item(string content, ItemRepeat repeat) : this(content)
        {
            SetRepeat(repeat);
        }

		/// <summary>
		/// Creates new instance of <see cref="Item"/>
		/// </summary>
		/// <param name="content">Content of the <see cref="Item"/> element.</param>
		/// <param name="repeat">Sets how many times must be item said. For common values use <see cref="ItemRepeat"/> enum.</param>
		public Item(string content, string repeat) : this(content)
        {
            Repeat = repeat;
        }

		/// <summary>
		/// Creates new instance of <see cref="Item"/>
		/// </summary>
		/// <param name="content">Content of the <see cref="Item"/> element.</param>
		/// <param name="repeat">Sets how many times must be item said.</param>
		/// <param name="tag">Item will be tagged with <see cref="Tag"/></param>
		public Item(string content, ItemRepeat repeat, Tag tag) : this(content, repeat)
        {
            this.m_Elements.Add(tag);
        }

		/// <summary>
		/// Creates new instance of <see cref="Item"/>
		/// </summary>
		/// <param name="content">Content of the <see cref="Item"/> element.</param>
		/// <param name="repeat">Sets how many times must be item said. For common values use <see cref="ItemRepeat"/> enum.</param>
		/// <param name="tag">Item will be tagged with <see cref="Tag"/></param>
		public Item(string content, string repeat, Tag tag) : this(content, repeat)
        {
            this.m_Elements.Add(tag);
        }

		/// <summary>
		/// Content of the item element. Text inside <item> ... </item>
		/// </summary>
        [XmlText]
        public string Content { get; set; }

        /// <summary>
        /// In <one-of> lists, the <item> elements can be weighted. Weights are positive numbers. 
        /// If weights are used, each <item> in the <one-of> list must be weighted. The relative 
        /// weight for each <item> is its contribution to the whole. For example:
        /// </summary>
        [XmlAttribute("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// Repeat tells recognition engine how many times must be the item spoken. Common values are stored in <see cref="ItemRepeat"/> enum. 
        /// Use SetRepeat(ItemRepeat) to set repeat to common values.
        /// Repeat must be in format 'n-m' where m must be greater that n and both must be positive integer numbers 
        /// or it can be in format 'n' where n is also positive integer number.
        /// </summary>
        [XmlAttribute("repeat")]
        public string Repeat { get { return m_repeat; }
            set
            {
                uint from = 0;
                if (uint.TryParse(value, out from))
                    SetRepeat(from);
                else
                {
                    var splited = value.Split('-');
                    if (splited.Length != 2)
                    {
                        throw new System.ArgumentException(@"Repeat must be in format 'n-m' where m must be greater that n and both must be positive integer numbers 
                                                                or it can be in format 'n' where n is also positive integer number");
                    }
                    uint to = 0;
                    if (uint.TryParse(splited[0], out from) && uint.TryParse(splited[1], out to))
                        SetRepeat(from, to);
                }
            }
        }

        /// <summary>
        /// Inner elements of this Item
        /// </summary>
        [XmlElement("item", Type = typeof(Item))]
        [XmlElement("ruleref", Type = typeof(RuleRef))]
        [XmlElement("tag", Type = typeof(Tag))]
        [XmlElement("token", Type = typeof(Token))]
        [XmlElement("one-of", Type = typeof(OneOf))]
        public List<RuleItem> Elements { get { return m_Elements; } }

        /// <summary>
        /// Sets some common repeat options
        /// </summary>
        public void SetRepeat(ItemRepeat repeat)
        {
            string r = string.Empty;
            switch (repeat)
            {
                case ItemRepeat.MoreThanOnce:
                    r = "1-";
                    break;
                case ItemRepeat.Once:
                    r = "1";
                    break;
                case ItemRepeat.OptionalOrMoreThenOnce:
                    r = "0-";
                    break;
                case ItemRepeat.Optional:
                    r = "0-1";
                    break;
            }
            m_repeat = r;
        }

        /// <summary>
        /// Sets the interval that indicates how many times can be this item spoken.
        /// </summary>
        /// <param name="from">Lowest number of times to repeat the item</param>
        /// <param name="to">Highest number of times to repeat the item</param>
        public void SetRepeat(uint from, uint to)
        {
            m_repeat = string.Format("{0}={1}", from, to);
        }

        /// <summary>
        /// Sets the number how many times must be item spoken
        /// </summary>
        public void SetRepeat(uint numOfTimes)
        {
            m_repeat = numOfTimes.ToString();
        }

        /// <summary>
        /// Represents some common repeat options
        /// </summary>
        public enum ItemRepeat
        {
			/// <summary>
			/// User can but do not have to say the item. Both variants are valid.
			/// </summary>
            Optional,

			/// <summary>
			/// User can say item x-times, x = {0, 1, 2...}
			/// </summary>
            OptionalOrMoreThenOnce,

			/// <summary>
			/// User can say item x-times, x = {1, 2, 3...}
			/// </summary>
			MoreThanOnce,

			/// <summary>
			/// User must say item once. No more no less. 
			/// </summary>
            Once
        }
    }
}