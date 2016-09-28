using System.Collections.Generic;
using System.Xml.Serialization;

namespace Resco.InAppSpeechRecognition.Commands
{
    /// <summary>
    /// Base class for <see cref="PhraseTopic"/> and <see cref="PhraseList"/>.
    /// </summary>
    public abstract class Ref
    {
        /// <summary>
        /// A PhraseList requires the Label attribute, the value of which may appear—enclosed 
        /// by curly braces—inside ListenFor or Feedback elements, and is used to reference the PhraseList.
        /// </summary>
        [XmlAttribute("Label")]
        public string Label { get; set; }
    }

    /// <summary>
    /// Optional child of the CommandSet element. Specifies a topic for large vocabulary recognition. The topic may specify a single (0 or 1) Scenario attribute 
    /// and several (0 to 20) Subject child elements for the scenario, which may be used to improve the relevance of the recognition achieved. 
    /// A PhraseTopic requires the Label attribute, the value of which may appear—enclosed by curly braces—inside ListenFor or Feedback elements, and is used to reference the PhraseTopic.
    /// </summary>
    public class PhraseTopic : Ref
    {
		/// <summary>
		/// Creates new instance of <see cref="PhraseTopic"/> class.
		/// </summary>
        public PhraseTopic()
        {
            Scenario = Scenario.Dictation;
        }
        private List<Subjects> m_subjects = new List<Subjects>();

        /// <summary>
        /// The Scenario attribute (default "Dictation") specifies the desired scenario for this PhraseTopic, which may optimize the underlying speech recognition 
        /// of voice commands using the PhraseTopic to produce results that are better-suited to the desired context of the command. Valid values 
        /// are in <see cref="Scenario"/> enum.
        /// </summary>
        [XmlAttribute("Scenario")]
        public Scenario Scenario { get; set; }

        /// <summary>
        /// The Subject child elements specify a subject specific to the Scenario attribute of the parent PhraseTopic to further 
        /// refine the relevance of speech recognition results within spoken commands using the PhraseTopic. Subjects will be evaluated 
        /// in the order provided and, when appropriate, later-specified subjects will constrain earlier-specified ones. Valid inner 
        /// text values are "Date/Time", "Addresses", "City/State", "Person Names", "Movies", "Music", and "Phone Number". For example: <Subject>Phone Number</Subject>
        /// </summary>
        [XmlElement(ElementName = "Subject")]
        public List<Subjects> Subjects { get { return m_subjects; } }
    }
    
    /// <summary>
    /// Enum that specifies scenario options in <see cref="PhraseTopic"/> 
    /// </summary>
    public enum Scenario
    {
        [XmlEnum("Natural Language")]
        NaturalLanguage,

        Search,

        [XmlEnum("Short Message")]
        ShortMessage,

        Dictation,

        Commands,

        [XmlEnum("Form Filling")]
        FormFilling
    }

    /// <summary>
    /// Specifies valid values in <see cref="PhraseTopic"/> inner subject elements
    /// </summary>
    public enum Subjects
    {
        [XmlEnum("Date/Time")]
        DateTime,

        Addresses,

        [XmlEnum("City/State")]
        CityState,

        [XmlEnum("Person Names")]
        PersonNames,
        Movies,
        Music,

        [XmlEnum("Phone Number")]
        PhoneNumber
    }
}
