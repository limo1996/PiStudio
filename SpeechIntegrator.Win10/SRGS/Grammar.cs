using System.Collections.Generic;
using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using PiStudio.Win10.Voice.Navigation;

namespace PiStudio.Win10.Voice.Srgs
{
	/// <summary>
	/// Specifies the highest level container for an XML grammar definition. This element is required to make a valid grammar.
	/// </summary>
	[XmlRoot(ElementName = "grammar", Namespace = "http://www.w3.org/2001/06/grammar")]
    public class Grammar
    {
		/// <summary>
		/// Creates new instance of <see cref="Grammar"/>
		/// </summary>
        public Grammar()
        {
            m_rules = new List<Rule>();
            Encoding = Encoding.UTF8;
            Language = "en-US";
            TagFormat = Semantics.StandardSemanticTagFormat;
            Version = "1.0";
            Mode = "voice";
        }

        [XmlIgnore]
        public Encoding Encoding { get; set; }

		/// <summary>
		/// Required if the value of the mode attribute is voice, optional if the value of the mode attribute is dtmf. 
		/// Declares the single language for the content of the containing grammar document. The value may contain either 
		/// a lower-case, two-letter language code, (such as "en" for English or "fr" for French) or may optionally include an upper-case, 
		/// country/region or other variation in addition to the language code. Examples with a county/region code include "es-US" 
		/// for Spanish as spoken in the US, or "fr-CA" for French as spoken in Canada. 
		/// </summary>
		[XmlAttribute("xml:lang")]
        public string Language { get; set; }

		/// <summary>
		/// Required if a grammar contains tag elements, this attribute specifies the content type of all tag elements contained within a grammar.
		/// This attribute takes one of the following values:
		/// semantics/1.0 declares that the content within tag elements is ECMAScript.
		/// semantics-ms/1.0 declares that the content within tag elements is ECMAScript as implemented by Microsoft.
		/// </summary>
		[XmlAttribute(AttributeName = "tag-format")]
        public string TagFormat { get; set; }

		/// <summary>
		/// Optional, but recommended.Specifies the name of the grammar rule that will be active when the grammar is loaded by a speech recognition engine. 
		/// If root is omitted, the grammar passes validation checks and compiles, but does not trigger recognition.The rule declared as the root rule
		/// must be defined within the scope of the grammar. The root rule can be scoped as either public or private.
		/// </summary>
        [XmlAttribute(AttributeName = "root")]
        public string Root { get; set; }

		/// <summary>
		/// Required. Specifies the version number of the Speech Recognition Grammar Specification used. The only accepted value is 1.0.
		/// </summary>
		[XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

		/// <summary>
		/// Description of the SRGS document
		/// </summary>
        [XmlElement("Metadata")]
        public Metadata Metadata { get; set; }

		/// <summary>
		/// Optional.Specifies the mode of the grammar.The mode can be one of the following values.
		/// voice for spoken input
		/// dtmf for dual tone multi-frequency (DTMF) input
		/// If omitted, the default value is voice.
	    /// </summary>
		[XmlAttribute("mode")]
        public string Mode { get; set; }

        private Rule m_rootRule = null;

		/// <summary>
		/// Reference to root rule element of grammar.
		/// </summary>
        [XmlIgnore]
        public Rule RootRule
        {
            get
            {
                return m_rootRule;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Root rule can not be null !");
                if (m_rules.Contains(value))
                {
                    m_rootRule = value;
                    Root = value.Id;
                }
                else
                    throw new GrammarException("Rules do not contains item " + value.Id + ". Please add this item first.");
            }
        }

        private List<Rule> m_rules;

		/// <summary>
		/// Inner elements of grammar. See <see cref="Rule"/> documentation for more information about elements.
		/// Only one of the <see cref="Rule"/>s in this List can be choosed as Root.
		/// </summary>
        [XmlElement("rule")]
        public List<Rule> Rules { get { return m_rules; }  }

		/// <summary>
		/// Wrapper class for constant strings that hold semantic tag format types
		/// </summary>
        public static class Semantics
        {
			/// <summary>
			/// Declares that the content within tag elements is ECMAScript.
			/// </summary>
			public static readonly string StandardSemanticTagFormat = "semantics/1.0";

			/// <summary>
			/// Declares that the content within tag elements is ECMAScript as implemented by Microsoft.
			/// </summary>
			public static readonly string MicrosoftSemanticTagFormat = "semantics-ms/1.0";
        }

		/// <summary>
		/// Wrapper class for constant strings that hold names of languages that are supported 
		/// </summary>
        public static class SpeechLanguage
        {
            public static readonly string AmericanEnglish = "en-us";
            public static readonly string BritishEnglish = "en-gb";
        }
    }
}