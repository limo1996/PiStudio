using System;
using System.Xml.Serialization;

namespace Resco.InAppSpeechRecognition.Srgs
{
	/// <summary>
	/// Contains a string that a speech recognizer can use for recognition and optionally specifies the display 
	/// form of the string and the precise pronunciation that will trigger recognition.
	/// </summary>
	public class Token : RuleItem
	{
		/// <summary>
		/// Optional. Specifies the form of the word or phrase contained by the token element that should be displayed in the graphical user interface. 
		/// The token element contains the lexical form of a word, which is used for recognition unless a custom pronunciation is specified by the sapi:pron attribute. 
		/// The display form of a word is often the same as its lexical form. When using sapi:display in a token element, the grammar Element must include
		/// the following declaration: xmlns:sapi="http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions"
		/// </summary>
		[XmlAttribute("display")]
		public string Display { get; set; }

		/// <summary>
		/// Optional. Specifies an inline, custom pronunciation that the speech recognition engine can use to recognize the contents of the token element. 
		/// The value of sapi:pron must use phones from the phonetic alphabet specified in the sapi:alphabet attribute of the grammar element.
		/// When using sapi:pron in a token element, the grammar Element must include the sapi:alphabet attribute, and must also contain 
		/// the following declaration: xmlns:sapi="http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions"
		/// </summary>
		[XmlAttribute("pron")]
		public string Pronunciation { get; set; }

		/// <summary>
		/// Content of the <see cref="Token"/> element
		/// </summary>
		[XmlText]
		public string Text { get; set; }

		/// <summary>
		/// Creates new instance of <see cref="Token"/> element.
		/// </summary>
		public Token()
		{ }
	}
}