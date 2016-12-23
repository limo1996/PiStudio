using System.Collections.Generic;
using System.Xml.Serialization;

namespace Resco.InAppSpeechRecognition.Commands
{
    /// <summary>
    /// Required child element of the CommandSet element. Takes the Name attribute.Defines an app action that users can initiate by speaking 
    /// and what users can say to initiate the action. Each Command element can be associated with a specific page in your app. 
    /// Contains the following required child elements: Example (exactly 1), ListenFor(1 to 10), Feedback(exactly 1), 
    /// and Navigate(exactly 1). These child elements must occur in the order listed.
    /// </summary>
    public class Command
    {
        private List<ListenFor> m_listenForArray = new List<ListenFor>();

		/// <summary>
		/// Name of the command.
		/// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

		/// <summary>
		/// Example of command.
		/// </summary>
        [XmlElement(ElementName = "Example", Order = 1)]
        public string Example { get; set; }

		/// <summary>
		/// <see cref="List{ListenFor}"/> that contains phrases that will speech recognition engine listen for.
		/// </summary>
        [XmlElement(ElementName = "ListenFor", Order = 2)]
        public List<ListenFor> ListenFor { get { return m_listenForArray; } }

		/// <summary>
		/// Feedback that will be provided (said) after recognizing of this command
		/// </summary>
        [XmlElement(ElementName = "Feedback",Order = 3)]
        public Feedback Feedback { get; set; }

		/// <summary>
		/// Action that will be performed after recognizing of this command
		/// </summary>
		[XmlElement(ElementName = "Navigate", IsNullable = false, Type = typeof(Navigate), Order = 4)]
        [XmlElement(ElementName = "VoiceCommandService", IsNullable = false, Type = typeof(VoiceCommandService), Order = 4)]
        [XmlElement(ElementName = "ShowDialog", IsNullable = false, Type = typeof(ShowDialog), Order = 4)]
        [XmlElement(ElementName = "CustomAction", IsNullable = false, Type = typeof(CustomAction), Order = 4)]
        public VoiceAction VoiceAction { get; set; }

		/// <summary>
		/// Executes action according to given <see cref="RecognitionAndAction.SpeechRecognitionResult"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="result"></param>
        public void InvokeAction(object sender, RecognitionAndAction.SpeechRecognitionResult result)
        {
            if (VoiceAction != null)
                VoiceAction.Invoke(sender, result);
        }
    }
}
