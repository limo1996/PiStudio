using System.Collections.Generic;
using System;
using System.Xml.Serialization;

namespace Resco.InAppSpeechRecognition.Srgs
{
	/// <summary>
	/// The rule element defines a grammar rule. A rule element contains text or XML elements that define what speakers can say, and the order in which they can say it. 
	/// The rule element associates a valid rule definition with a rule name and sets the scope of the rule definition. A valid rule element must contain at least 
	/// one piece of recognizable text or one rule reference. A valid grammar must contain at least one rule element.
	/// </summary>
	public class Rule
    {
		/// <summary>
		/// Creates new instance of <see cref="Rule"/> element. 
		/// </summary>
		/// <param name="id">Unique name of rule element.</param>
        public Rule(string id)
        {
            m_Elements = new List<RuleItem>();
            m_examples = new List<Example>();
            Id = id;
        }

		/// <summary>
		/// Creates new instance of <see cref="Rule"/> element. And generates unique name. Do not recommended to use automatically generated id.
		/// </summary>
		public Rule() : this(Guid.NewGuid().ToString("N"))
		{ }

		/// <summary>
		/// Creates new instance of <see cref="Rule"/> element.
		/// </summary>
		/// <param name="id">Unique name of rule element.</param>
		/// <param name="examples"><see cref="Example"/>s for this rule.</param>
		public Rule(string id, IEnumerable<Example> examples)
        {
            Id = id;
            m_examples = new List<Example>(examples);
        }

		/// <summary>
		/// Creates new instance of <see cref="Rule"/> element.
		/// </summary>
		/// <param name="id">Unique name of rule element.</param>
		/// <param name="elements">Inner items of the rule element.</param>
		public Rule(string id, IEnumerable<RuleItem> elements)
        {
            Id = id;
            m_Elements = new List<RuleItem>(elements);
        }

		/// <summary>
		/// Creates new instance of <see cref="Rule"/> element.
		/// </summary>
		/// <param name="id">Unique name of rule element.</param>
		/// <param name="examples"><see cref="Example"/>s for this rule.</param>
		/// <param name="elements">Inner items of the rule element.</param>
		public Rule(string id, IEnumerable<Example> examples, IEnumerable<RuleItem> elements) : this(id, examples)
        {
            m_Elements = new List<RuleItem>(elements);
        }


        private List<RuleItem> m_Elements;

        /// <summary>
        /// Children that can be of type: Item, RuleRef, Tag, Token, OneOf. All children will be stored in order that have been added
        /// </summary>
        [XmlElement("item", Type = typeof(Item),Order = 2)]
        [XmlElement("ruleref", Type = typeof(RuleRef), Order = 2)]
        [XmlElement("tag", Type = typeof(Tag), Order = 2)]
        [XmlElement("token", Type = typeof(Token), Order = 2)]
        [XmlElement("one-of", Type = typeof(OneOf), Order = 2)]
        public List<RuleItem> Elements { get { return m_Elements; } }

        private string m_id;

        /// <summary>
        /// The id is simply the name of the rule. For example, id="topRule". It is a required attribute.
        /// </summary>
        [XmlAttribute("id")]
        public string Id
        {
            get { return m_id; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Id can not be null.");
                if (value == string.Empty)
                    throw new ArgumentException("Id can not be empty string.");
                m_id = value;
            }
        }

        private string m_scope = null;
        /// <summary>
        /// The scope of a rule may be public or private. If the scope is not explicitly declared in a rule definition, 
        /// then it defaults to private. A public-scoped rule can be referenced in the rule definitions of other grammars 
        /// in the VoiceXML application. A private-scoped rule can be referenced only by other rules within the same grammar. 
        /// </summary>
        [XmlAttribute("scope")]
        public string Scope
        {
            get { return m_scope; }
            set
            {
                if (value == "private" || value == "public")
                    m_scope = value;
                else
                    throw new ArgumentException(@"Scope can only be ""public"" or ""private"".");
            }
        }

        private List<Example> m_examples;

        /// <summary>
        /// List of Examples that can be creted from this rule. Helps the search engine with recognition.
        /// </summary>
        [XmlElement("example", Order = 1)]
        public List<Example> Examples { get { return m_examples; } }

        /// <summary>
        /// Inner Text in the rule. Recommended is to wrap it into <see cref="Item">element</see>
        /// </summary>
        [XmlText]
        public string Content { get; set; }
    }

    public class RuleScope
    {
        /// <summary>
        /// A public-scoped rule can be referenced in the rule definitions of other grammars 
        /// in the VoiceXML application.
        /// </summary>
        public static readonly string PublicScope = "public";

        /// <summary>
        /// A private-scoped rule can be referenced only by other rules within the same grammar.
        /// </summary>
        public static readonly string PrivateScope = "private";
    }
}