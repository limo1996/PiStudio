using System.Collections.Generic;
using System.Xml.Serialization;
using Windows.UI.Popups;
using System;
using PiStudio.Win10.Voice.Navigation;

namespace PiStudio.Win10.Voice.Commands
{
    /// <summary>
    /// Base class for <see cref="VoiceCommandService"/> and <see cref="Navigate"/> classes when iteracting with cortana 
    /// otherwise it can be base class for any action that user want to perform. Specifies action performed after recognizing the command.
    /// </summary>
    public abstract class VoiceAction
    {
        /// <summary>
        /// Default constructor needed in serialization. Creates new instance of <see cref="VoiceAction"/>.
        /// </summary>
        public VoiceAction()
        { }

        /// <summary>
        /// Event is raised when is parent <see cref="Command"/> of <see cref="VoiceAction"/> recognized by speech rec. engine
        /// </summary>
        public event System.EventHandler<SpeechRecognitionResult> CommandRecognized = null;
        public void Invoke(object sender, SpeechRecognitionResult result)
        {
             var fn = CommandRecognized;
             if (fn != null)
                 fn(sender, result);            
        }
    }

    /// <summary>
    /// Required child element of the Command element, unless the Command element has a Navigate child element. This element specifies 
    /// that the voice command is handled through an app service (see Windows.ApplicationModel.AppService) with feedback displayed on the Cortana canvas. 
    /// The Target attribute is mandatory and must match the value of the Name attribute of the AppService element in the app package manifest.
    /// </summary>
    public class VoiceCommandService : VoiceAction
    {
        /// <summary>
        /// Target where should app navigate when command is recognized.
        /// </summary>
        [XmlAttribute("Target")]
        public string Target { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="VoiceCommandService"/>
        /// </summary>
        /// <param name="target">Target where should app navigate when command is recognized.</param>
        public VoiceCommandService(string target)
        {
            Target = target;
        }

        /// <summary>
        /// Creates new instance of <see cref="VoiceCommandService"/>
        /// </summary>
        public VoiceCommandService() { }
    }

    /// <summary>
    /// Required child element of the Command element, unless the Command element has a VoiceCommandService child element. 
    /// The Target attribute is optional and is typically used to specify the page that the app should navigate to when it launches. 
    /// You can obtain the value of the Target attribute (or the empty string if you omit the Target attribute) 
    /// from the SpeechRecognitionSemanticInterpretation.Properties dictionary using the "NavigationTarget" key.
    /// </summary>
    public class Navigate : VoiceAction
    {
		/// <summary>
		/// Creates new instance of <see cref="Navigate"/>.
		/// </summary>
        public Navigate()
        { }

        /// <summary>
        /// Creates new instance of <see cref="Navigate"/>
        /// </summary>
        /// <param name="target">Target where should app navigate when command is recognized.</param>
        public Navigate(string target)
        {
            Target = target;
        }

		/// <summary>
		/// Navigation parameter. Supported only in "In app speech recognition."
		/// </summary>
        [XmlAttribute("NavigationParameter")]
        public string NavigationParameter { get; set; }

        /// <summary>
        /// Target where should app navigate when command is recognized.
        /// </summary>
        [XmlAttribute("Target")]
        public string Target { get; set; }
    }

	/// <summary>
	/// This action shows dialog with TextToDisplay message. Supported only in "In app speech recognition."
	/// </summary>
	public class ShowDialog : VoiceAction
    {
		/// <summary>
		/// Text that will be displayed on the screen.
		/// </summary>
        [XmlAttribute("TextToDisplay")]
        public string TextToDisplay { get; set; }

		/// <summary>
		/// Creates new instance of <see cref="ShowDialog"/>.
		/// </summary>
        public ShowDialog()
        {
            this.CommandRecognized += async (sender, cmd) =>
            {
                MessageDialog dialog = new MessageDialog(TextToDisplay, cmd.RecognizedCommand.Name);
                await dialog.ShowAsync();
            };
        }
    }

	/// <summary>
	/// Custom action that can do everything and can have one parameter and content. Is handeled in the code. Supported only in "In app speech recognition."
	/// </summary>
	public class CustomAction : VoiceAction
    {
		/// <summary>
		/// Navigation parameter.
		/// </summary>
		[XmlAttribute("Parameter")]
        public string ActionParameter { get; set; }

		/// <summary>
		/// Navigation content.
		/// </summary>
        [XmlText]
        public string ActionContent { get; set; }
    }
}
