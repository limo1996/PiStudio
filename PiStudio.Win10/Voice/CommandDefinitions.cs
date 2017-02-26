using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStudio.Win10.Cortana
{
	/// <summary>
	/// Class that contains voice commands in string. Class is used during first launch to create files with content of this class.
	/// </summary>
	public class CommandDefinitions
	{	
		/// <summary>
		/// Content of the Navigator voice commnads file.
		/// </summary>
		public static readonly string PiStudioNavigatorVoiceCommands= @"<?xml version=""1.0"" encoding=""utf-8""?>
<VoiceCommands xmlns=""http://schemas.microsoft.com/voicecommands/1.2"">

  <CommandSet Name=""PiStudioVoiceCommandsEnUs"" xml:lang=""en-gb"">
    <CommandPrefix>Studio</CommandPrefix>
    <Example>Studio open last edited file</Example>
    <Command Name=""OpenLastEdited"">
      <Example>Studio Show me last edited image</Example>
      <ListenFor>Whats my name</ListenFor>
      <ListenFor>Hello world</ListenFor>
      <Feedback>Opening last edited file</Feedback>
      <Navigate Target=""SettingsPage""></Navigate>
    </Command>
  </CommandSet>
</VoiceCommands>
";

        /// <summary>
        /// Content of the cortana VCD file.
        /// </summary>
        public static readonly string PiStudioCortanaVoiceCommands= @"<?xml version=""1.0"" encoding=""utf-8""?>
<VoiceCommands xmlns=""http://schemas.microsoft.com/voicecommands/1.2"">

  <CommandSet Name=""PiStudioVoiceCommandsEnUs"" xml:lang=""en-gb"">
    <CommandPrefix>Studio</CommandPrefix>
    <Example>Studio open last edited file</Example>
    <Command Name=""OpenLastEdited"">
      <Example>Studio Show me last edited image</Example>
      <ListenFor>{ActionOpen} last [edited] {Target}</ListenFor>
      <ListenFor>{ActionOpen} the last one</ListenFor>
      <Feedback>Opening last edited file</Feedback>
      <Navigate/>
    </Command>

    <PhraseList Label=""ActionOpen"">
      <Item>Open</Item>
      <Item>Show</Item>
      <Item>Show me</Item>
      <Item>Display</Item>
    </PhraseList>

    <PhraseList Label=""Target"">
      <Item>Image</Item>
      <Item>File</Item>
      <Item>Picture</Item>
      <Item>Photo</Item>
    </PhraseList>
  </CommandSet>
</VoiceCommands>
";
		/// <summary>
		/// Name of the file where are Cortana Voice Commands Saved.
		/// </summary>
		public static readonly string PiStudioCortanaVoiceCommandsFileName= @"PiStudioCortanaVoiceCommands.xml";

		/// <summary>
		/// Name of the file where are Navigator Voice Commands Saved.
		/// </summary>
		public static readonly string PiStudioNavigatorVoiceCommandsFileName=@"PiStudioNavigatorVoiceCommands.xml";
	}
}
