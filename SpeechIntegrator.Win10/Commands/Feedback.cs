using System.Xml.Serialization;
using System.Collections.Generic;


namespace PiStudio.Win10.Voice.Commands
{
    /// <summary>
    /// Required child element of the Command element. Specifies the text that will be displayed and read back to the user when the command is recognized. 
    /// If the Feedback element includes a reference to a Label attribute of a PhraseList (or PhraseTopic) element, then every ListenFor element in the containing Command 
    /// element must also reference the same Label attribute of the PhraseList (or PhraseTopic) element.
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Creates new instance of <see cref="Feedback"/>
        /// </summary>
        public Feedback() { }

        /// <summary>
        /// Creates new instance of <see cref="Feedback"/>
        /// </summary>
        /// <param name="content">Inner text. Can not be null. Will be said after command will be matched</param>
        public Feedback(string content)
        {
            Content = content;
        }

        private List<Ref> m_refs = new List<Ref>();
        private List<string> m_list = new List<string>();
        private string m_content;

        /// <summary>
        /// Inner text. Can not be null. Will be said after command will be matched
        /// </summary>
        [XmlText]
        public string Content
        {
            get { return m_content; }
            set
            {
                string tmp = value;
                while (tmp.Length > 1 && tmp.IndexOf('{') != -1 && tmp.IndexOf('{') + 1 != tmp.Length)
                {
                    tmp = tmp.Substring(tmp.IndexOf('{') + 1);
                    if (tmp.IndexOf('}') == -1)
                        throw new System.ArgumentException("Phrase topics or list reference was not properly closed. Missing '}'");
                    m_list.Add(tmp.Substring(0, tmp.IndexOf('}')));
                }

                tmp = value;
                while (tmp.Length > 1 && tmp.IndexOf('[') != -1 && tmp.IndexOf('[') + 1 != tmp.Length)
                {
                    tmp = tmp.Substring(tmp.IndexOf('[') + 1);
                    if (tmp.IndexOf(']') == -1)
                        throw new System.ArgumentException("Deklaration of optional word error. Missing ']'");
                    m_list.Add(tmp.Substring(0, tmp.IndexOf(']')));
                }

                m_content = value;
            }
        }

        /// <summary>
        /// Add text to Feedback response
        /// </summary>
        /// <param name="text">text to append</param>
        public void Append(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            m_content += " " + text;
        }

        /// <summary>
        /// Add reference to phrase list or phrase topics to Feedback response. 
        /// </summary>
        /// <param name="phraseRef"><see cref="PhraseList"/> or <see cref="PhraseTopic"/></param>
        public void Append(Ref phraseRef)
        {
            if (string.IsNullOrWhiteSpace(phraseRef.Label))
            {
                var name = phraseRef is PhraseList ? "PhraseLists" : "PhraseTopics";
                throw new System.ArgumentException(name + " Label can not be null, empty or white space when you want to reference it !");
            }

            m_content += " {" + phraseRef.Label + "}";
            m_refs.Add(phraseRef);
        }
    }
}
