using System.Xml.Serialization;
using System.Collections.Generic;

namespace Resco.InAppSpeechRecognition.Commands
{
    /// <summary>
    /// Contains a word or phrase that your app will recognize for this command. This may include or be a reference to a PhraseList (or PhraseTopic) 
    /// element's Label attribute, which appears in the ListenFor element enclosed in curly braces, for example: {myList}, or {myTopic}.
    /// The content of any ListenFor elements can be recognized to activate the command.
    /// </summary>
    public class ListenFor
    {
        public ListenFor() { }

        /// <summary>
        /// Creates new instance of <see cref="ListenFor"/>
        /// </summary>
        /// <param name="content">Inner text. Can not be null. Specifies words (optinal), references to lists and topics that must be said so command will be recognized.</param>
        public ListenFor(string content)
        {
            m_content = content;
        }

        /// <summary>
        /// Creates new instance of <see cref="ListenFor"/>
        /// </summary>
        /// <param name="content">Inner text. Can not be null. Specifies words (optinal), references to lists and topics that must be said so command will be recognized.</param>
        /// <param name="requirement">An optional RequireAppName attribute can be specified to indicate whether the value 
        /// of the AppName element can be prepended, appended, or used inline with the ListenFor element.</param>
        public ListenFor(string content, AppNameRequirement requirement) : this(content)
        {
            RequireAppName = requirement;
        }

        private string m_content;

        /// <summary>
        /// Inner text. Can not be null. Specifies words (optinal), references to lists and topics that must be said so command will be recognized.
        /// </summary>
        [XmlText]
        public string Content
        {
            get { return m_content; }
            set { m_content = value; }
        }

        /// <summary>
        /// Adds text inside <see cref="ListenFor"/> elements text as optional or normal
        /// </summary>
        /// <param name="text">text user should say</param>
        /// <param name="isOptional">Specifies whether text must be said or not so command will be recognized</param>
        public void Append(string text, bool isOptional)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            if (isOptional)
                m_content += " [" + text + "]";
            else
                m_content += " " + text;
        }

        /// <summary>
        /// Adds reference to <see cref="PhraseList"/> or <see cref="PhraseTopic"/> inside <see cref="ListenFor"/> elements text
        /// </summary>
        /// <param name="phraseRef">Reference to <see cref="PhraseList"/> or <see cref="PhraseTopic"/></param>
        public void Append(Ref phraseRef)
        {
            if (string.IsNullOrWhiteSpace(phraseRef.Label))
            {
                var name = phraseRef is PhraseList ? "PhraseLists" : "PhraseTopics";
                throw new System.ArgumentException(name + " Label can not be null, empty or white space when you want to reference it !");
            }

            m_content += " {" + phraseRef.Label + "}";
        }

        /// <summary>
        /// An optional RequireAppName attribute can be specified to indicate whether the value 
        /// of the AppName element can be prepended, appended, or used inline with the ListenFor element.
        /// </summary>
        [XmlAttribute("RequireAppName")]
        public AppNameRequirement RequireAppName { get; set; }
    }

    /// <summary>
    /// Options for <see cref="ListenFor"/> RequireAppName Property
    /// </summary>
    public enum AppNameRequirement
    {
        /// <summary>
        /// The user must say the AppName before the ListenFor phrase.
        /// </summary>
        BeforePhrase = 0,

        /// <summary>
        /// The user must say "In|On|Using|With" AppName after the ListenFor phrase.
        /// </summary>
        AfterPhrase = 1,

        /// <summary>
        /// The user must say the AppName before or after the ListenFor phrase.
        /// </summary>
        BeforeOrAfterPhrase = 2,

        /// <summary>
        /// The AppName is explicitly referenced in the ListenFor, using {builtin:AppName}. The user is not required to say the AppName before or after the ListenFor phrase.
        /// </summary>
        ExplicitlySpecified = 3
    }
}
