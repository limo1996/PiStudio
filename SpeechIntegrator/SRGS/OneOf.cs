using System.Collections.Generic;
using System.Xml.Serialization;

namespace Resco.InAppSpeechRecognition.Srgs
{
	/// <summary>
	/// A <one-of> element presents a list of alternatives. Only one can match. The alternative words or phrases must be enclosed in <item> tags.
	/// </summary>
	public class OneOf : RuleItem
	{
		private List<Item> m_items;

		/// <summary>
		/// List of alternatives. Only one can match.
		/// </summary>
		[XmlElement(ElementName = "item")]
		public List<Item> Items { get { return m_items; } }

		/// <summary>
		/// Creates new instance of <see cref="OneOf"/> element.
		/// </summary>
		/// <param name="items">Inner <see cref="Item"/>s of <see cref="OneOf"/> element.</param>
		public OneOf(IEnumerable<Item> items)
		{
			m_items = new List<Item>(items);
		}

		/// <summary>
		/// Creates new instance of <see cref="OneOf"/> element.
		/// </summary>
		public OneOf()
		{
			m_items = new List<Item>();
		}
	}
}