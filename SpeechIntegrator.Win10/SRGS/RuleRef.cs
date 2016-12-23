using System;
using System.Xml.Serialization;
namespace Resco.InAppSpeechRecognition.Srgs
{
	/// <summary>
	/// The ruleref element specifies a reference by the containing rule to another rule, either in the same grammar or in an external grammar. 
	/// The referenced rule defines user input that must be matched for successful recognition of the containing rule. This element is especially 
	/// useful for reusing rules and grammars that contain content which does not change frequently, such as a list of cities or a rule for recognizing phone numbers.
	/// </summary>
	public class RuleRef : RuleItem
	{
		private string m_uri = null;
		private string m_special;
		private Rule m_reference = null;

		/// <summary>
		/// Create new instance of <see cref="RuleRef"/> object with reference to rule passed as argument.
		/// </summary>
		/// <param name="rule"></param>
		public RuleRef(Rule rule)
		{
			Reference = rule;
		}

		/// <summary>
		/// Default constructor needed in serialization
		/// </summary>
		public RuleRef()
		{

		}

		/// <summary>
		/// Create new instance of <see cref="RuleRef"/> object with reference to an external grammar.
		/// </summary>
		/// <param name="uri"></param>
		public RuleRef(Uri uri)
		{
			Uri = uri.ToString();
		}

		/// <summary>
		/// Create new instance of <see cref="RuleRef"/> object with special functions. (NULL, VOID, GARBAGE)
		/// </summary>
		/// <param name="special"></param>
		public RuleRef(string special)
		{
			Special = special;
		}

		/// <summary>
		/// <see cref="Rule"/> where shoul <see cref="RuleRef"/> point.
		/// </summary>
		[XmlIgnore]
		public Rule Reference
		{
			get { return m_reference; }
			set
			{
				if (value != null)
				{
					m_reference = value;
					Uri = "#" + value.Id;
				}
			}
		}

		/// <summary>
		/// Link or reference to another rule. It can be in format #rulename, grammarUri#rulename, http://tmp.com/rules.grxml
		/// Either the special or the uri attribute is required, but both cannot be used together.
		/// </summary>
		[XmlAttribute("uri")]
		public string Uri
		{
			get { return m_uri; }
			set
			{
				if (m_special != null)
					throw new ArgumentException("Only one from 'Special' or 'Uri' can be filled! Consider assigning Special to null first.");

				m_uri = value;
			}
		}

		/// <summary>
		/// Optional. Specifies a reference to a rule that has specific interpretation and processing by a speech recognizer. 
		/// A grammar must not redefine these special rule names. The special rule names are as follows:
		/// NULL: Defines a rule that is automatically matched, meaning that the rule is matched without the user speaking any word.
		/// VOID: Defines a rule that can never be spoken.Inserting VOID into a sequence automatically makes that sequence unspeakable.
		/// GARBAGE: Defines a rule that can match any speech up until the next rule match, the content of the next token element, or until the end of spoken input.
		/// Either the special or the uri attribute is required, but both cannot be used together.
		/// </summary>
		[XmlAttribute("special")]
		public string Special
		{
			get { return m_special; }
			set
			{
				if (value == "NULL" || value == "VOID" || value == "GARBAGE")
				{
					if (m_uri == null)
						m_special = value;
					else
						throw new ArgumentException("Only one from 'Special' or 'Uri' can be filled! Consider assigning Uri to null first.");
				}
				else
					throw new ArgumentException("Special can only be 'NULL' 'VOID' 'GARBAGE'.");
			}
		}

		/// <summary>
		/// The optional type attribute specifies the media type of the grammar containing the reference.
		/// The media type "application/srgs+xml" has been requested for XML Form grammars. See Appendix G for details on media types for grammars.
		/// </summary>
		[XmlAttribute("type")]
		public string Type { get; set; }

		/// <summary>
		/// Defines a rule that is automatically matched, meaning that the rule is matched without the user speaking any word.
		/// </summary>
		public static readonly string SpecialVOID = "VOID";

		/// <summary>
		/// Defines a rule that can never be spoken. Inserting VOID into a sequence automatically makes that sequence unspeakable.
		/// </summary>
		public static readonly string SpecialNULL = "NULL";

		/// <summary>
		/// Defines a rule that can match any speech up until the next rule match, the content of the next token element, or until the end of spoken input.
		/// </summary>
		public static readonly string SpecialGARBAGE = "GARBAGE";
	}
}