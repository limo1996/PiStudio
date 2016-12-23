using System.Collections.Generic;
using System.Xml.Serialization;

namespace Resco.InAppSpeechRecognition.Commands
{
    /// <summary>
    /// Optional child of the CommandSet element. One CommandSet element can contain no more than 2,000 Item elements, and 2,000 Item elements is the combined total limit across 
    /// all PhraseList elements in a CommandSet. Each Item specifies a word or phrase that can be recognized to initiate the command that references the PhraseList.
    /// The Items content may be programmatically updated from within your application.A PhraseList requires the Label attribute, the value of which may appear—enclosed
    /// by curly braces—inside ListenFor or Feedback elements, and is used to reference the PhraseList.
    /// </summary>
    public class PhraseList : Ref
    {
        private List<ListItem> m_items = new List<ListItem>();

        /// <summary>
        /// Optional default true. specifies whether this PhraseList will produce user disambiguation when multiple items from the list are simultaneously recognized. 
        /// When false, this PhraseList will also be unusable from within Feedback elements and will not produce parameters for your application. That's useful 
        /// for phrases that are alternative ways of saying the same thing, but do not require any specific action.
        /// </summary>
        [XmlAttribute("Disambiguate")]
        public bool Disambiguate { get; set; }

        /// <summary>
        /// Inner elements that specifies options that user can say
        /// </summary>
        [XmlElement(ElementName = "Item")]
        public List<ListItem> Items { get { return m_items; } }
    }

	/// <summary>
	/// Inner element of <see cref="PhraseList"/>. Each <see cref="ListItem"/> specifies a word or phrase that can be recognized 
	/// to initiate the command that references the <see cref="PhraseList"/>.
	/// </summary>
	public class ListItem
    {
		/// <summary>
		/// Optional attribute. Defaultly is displayed the content of the item element. 
		/// Example: Content will be "one" and display will be "1". So when item "one" is matched the value "1" will be returned by the 
		/// speech recognition engine. This is supported only in "In app speech recognition". In Cortana avoid to type Display attribute.
		/// </summary>
        [XmlAttribute("Display")]
        public string Display { get; set; }

		/// <summary>
		/// Content of the item element.
		/// </summary>
        [XmlText]
        public string Content { get; set; }

		/// <summary>
		/// Creates new instance of <see cref="ListItem"/> element.
		/// </summary>
		/// <param name="content">Content of the item element.</param>
		public ListItem(string content)
        {
            Content = content;
        }

		/// <summary>
		/// Creates new instance of <see cref="ListItem"/> element.
		/// </summary>
		public ListItem() { }
    }
}
