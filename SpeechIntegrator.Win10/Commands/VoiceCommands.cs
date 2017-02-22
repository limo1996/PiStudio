using System.Collections.Generic;
using System.Xml.Serialization;

namespace PiStudio.Win10.Voice.Commands
{

    /// <summary>
    /// Required element. The root element of a VCD file. The value of its xmlns attribute must be http://schemas.microsoft.com/voicecommands/1.2 (no uppercase characters). 
    /// Contains between 1 and 15 CommandSet elements, each of which represents the voice commands for a single language.
    /// </summary>
    [XmlRoot(ElementName = "VoiceCommands", Namespace = @"http://schemas.microsoft.com/voicecommands/1.2")]
    public class VoiceCommands
    {
        private List<CommandSet> m_commandSets = new List<CommandSet>();

        /// <summary>
        /// List of <see cref="CommandSet"/>s see documentation of <see cref="CommandSet"/> to find out more.
		/// Must contain at least one <see cref="CommandSet"/> but no more than 15.
        /// </summary>
        [XmlElement(Type = typeof(CommandSet), ElementName = "CommandSet")]
        public List<CommandSet> CommandSets { get { return m_commandSets; } }
    }
}
