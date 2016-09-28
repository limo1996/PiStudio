using System.Collections.Generic;
using System.Xml.Serialization;

namespace Resco.InAppSpeechRecognition.Commands
{
    /// <summary>
    /// Required child element of the VoiceCommands element. A container for all the voice commands that an app will accept in the language specified 
    /// by the required xml:lang attribute. The value of the xml:lang attribute must be unique in the VoiceCommand document, and it is a single, 
    /// specific language, specified in language name form, that corresponds to a language that is available in the Speech control panel. 
    /// The Name attribute is optional and can be any arbitrary string; however, the Name attribute is required in order to reference and update 
    /// a CommandSet element's PhraseList programmatically. The CommandSet element contains the following child elements: CommandPrefix (0 or 1) or 
    /// AppName (0 or 1), Example (exactly 1), Command (1 to 100), PhraseList elements (0 to 10), and PhraseTopic elements (0 to 10). These child 
    /// elements must occur in the order listed.
    /// </summary>
    public class CommandSet
    {
        private List<Command> m_commands = new List<Command>();
        private List<PhraseList> m_list = new List<PhraseList>();
        private List<PhraseTopic> m_topics = new List<PhraseTopic>();

        /// <summary>
        /// The value of the xml:lang attribute must be unique in the VoiceCommand document, and it is a single, specific language, 
        /// specified in language name form, that corresponds to a language that is available in the Speech control panel. 
        /// </summary>
        [XmlAttribute("xml:lang")]
        public string Language { get; set; }

        /// <summary>
        /// The Name attribute is optional and can be any arbitrary string; however, the Name attribute is required 
        /// in order to reference and update a CommandSet element's PhraseList programmatically.
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Command set can contain as prefix CommandPrefix or AppName. Check their documentation for more information.
        /// </summary>
        [XmlElement(ElementName = "CommandPrefix", Type = typeof(CommandPrefix), Order = 1)]
        [XmlElement(ElementName = "AppName", Type = typeof(AppName), Order = 1)]
        public Prefix Prefix { get; set; }

        /// <summary>
        /// Gives a representative example of what a user can say for a CommandSet as a whole, and for an individual command. 
        /// These examples will be will be visible to a user while viewing the What can I say screen on the phone.
        /// </summary>
        [XmlElement(ElementName = "Example", Order = 2)]
        public string Example { get; set; }

        /// <summary>
        /// List of elements that defines an app action that users can initiate by speaking and what users can say to initiate the action. 
        /// Each Command element can be associated with a specific page in your app...
        /// </summary>
        [XmlElement(ElementName = "Command", Order = 3)]
        public List<Command> Commands { get { return m_commands; } }

        /// <summary>
        /// Elements that contains list of items from which one need to be recognized
        /// </summary>
        [XmlElement(ElementName = "PhraseList", Order = 4)]
        public List<PhraseList> PhraseLists { get { return m_list; } }

        /// <summary>
        /// When the set of words is too large (hundreds of words, for example), or shouldn’t be constrained at all, 
        /// use the PhraseTopic element and a Subject element to refine the relevance of speech-recognition results to improve scalability.
        /// </summary>
        [XmlElement(ElementName = "PhraseTopic", Order = 5)]
        public List<PhraseTopic> PhraseTopics { get { return m_topics; } }
    }
}
