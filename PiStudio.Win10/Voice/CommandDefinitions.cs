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
    <CommandPrefix></CommandPrefix>
    <Example>Navigate to Settings page</Example>
    <Command Name=""NavigateToPage"">
      <Example>Navigate to Settings page</Example>
      <ListenFor>Navigate to {PageType}</ListenFor>
      <ListenFor>Go to {PageType}</ListenFor>
      <ListenFor>Show [me] {PageType}</ListenFor>
      <Feedback>Opening {PageType}</Feedback>
      <Navigate />
    </Command>

    <Command Name=""Rotate"">
      <Example>Rotate image</Example>
      <ListenFor>Rotate {Image}</ListenFor>
      <ListenFor>Spin {Image}</ListenFor>
      <ListenFor>Rotate currently edited {Image}</ListenFor>
      <ListenFor>Go to Home page and rotate [currently] [edited] {Image}</ListenFor>
      <ListenFor>Navigate to Home page and rotate  [currently] [edited] {Image}</ListenFor>
      <Feedback>Rotating image</Feedback>
      <Navigate/>
    </Command>

    <Command Name=""Save"">
      <Example>Save image</Example>
      <ListenFor>Save [currently] [edited] {Image}</ListenFor>
      <ListenFor>Store [currently] [edited] {Image}</ListenFor>
      <ListenFor>Save my work</ListenFor>
      <Feedback>Saving {Image}</Feedback>
      <Navigate />
    </Command>

    <Command Name=""SaveAs"">
      <Example>Save image as</Example>
      <ListenFor>Save [currently] [edited] {Image} as</ListenFor>
      <ListenFor>Store [currently] [edited] {Image} as</ListenFor>
      <ListenFor>Save my work as</ListenFor>
      <ListenFor>Save {Image} to [specified] location</ListenFor>
      <Feedback>Saving {Image}</Feedback>
      <Navigate />
    </Command>

    <Command Name=""Share"">
      <Example>Share image</Example>
      <ListenFor>Share [currently] [edited] {Image}</ListenFor>
      <Feedback>Sharing currently edited image</Feedback>
      <Navigate />
    </Command>
    
    <Command Name=""AddNewImage"">
      <Example>Add new image</Example>
      <ListenFor>Add [new] {Image}</ListenFor>
      <ListenFor>Pick [new] {Image}</ListenFor>
      <ListenFor>Open [new] {Image}</ListenFor>
      <Feedback>Opening new image</Feedback>
      <Navigate/>
    </Command>

    <Command Name=""ClearCanvas"">
      <Example>Clear canvas</Example>
      <ListenFor>Clear canvas</ListenFor>
      <ListenFor>Undo all changes</ListenFor>
      <ListenFor>Delete all curves</ListenFor>
      <ListenFor>Remove all lines</ListenFor>
      <Feedback>Clearing canvas</Feedback>
      <Navigate />
    </Command>

    <Command Name=""Undo"">
      <Example>Undo last change</Example>
      <ListenFor>Undo</ListenFor>
      <ListenFor>Undo last change</ListenFor>
      <Feedback>Sure</Feedback>
      <Navigate/>
    </Command>

    <Command Name=""ApplyFilter"">
      <Example>Apply blur filter</Example>
      <ListenFor>Apply {Filter} filter</ListenFor>
      <Feedback>Applying {Filter} filter</Feedback>
      <Navigate/>
    </Command>

    <Command Name=""About"">
      <Example>Show me about application</Example>
      <ListenFor>Show me about</ListenFor>
      <ListenFor>Show me about {Me}</ListenFor>
      <ListenFor>Navigate to about [section]</ListenFor>
      <Feedback>Showing about section</Feedback>
      <Navigate/>
    </Command>

    <Command Name=""EnableDark"">
      <Example>Enable dark theme</Example>
      <ListenFor>Enable dark [theme]</ListenFor>
      <ListenFor>Switch to dark [theme]</ListenFor>
      <ListenFor>Change [theme] to dark</ListenFor>
      <Feedback>Switching to dark theme</Feedback>
      <Navigate/>
    </Command>

    <Command Name=""EnableLight"">
      <Example>Enable light theme</Example>
      <ListenFor>Enable light [theme]</ListenFor>
      <ListenFor>Switch to light [theme]</ListenFor>
      <ListenFor>Change [theme] to light</ListenFor>
      <Feedback>Switching to light theme</Feedback>
      <Navigate/>      
    </Command>

    <Command Name=""EnableAutoSave"">
      <Example>Enable auto save</Example>
      <ListenFor>Enable auto save</ListenFor>
      <Feedback>Enabling auto save</Feedback>
      <Navigate/>
    </Command>

    <Command Name=""DisableAutoSave"">
      <Example>Disable auto save</Example>
      <ListenFor>Disable auto save</ListenFor>
      <Feedback>Disabling auto save</Feedback>
      <Navigate/>
    </Command>

    <Command Name=""ChangeLanguage"">
      <Example>Switch to Slovak Language</Example>
      <ListenFor>Switch to {Language} language</ListenFor>
      <ListenFor>Change language to {Language}</ListenFor>
      <Feedback>Switching to {Language}</Feedback>
      <Navigate/>
    </Command>

    <PhraseList Label=""Language"">
      <Item>Slovak</Item>
      <Item>English</Item>
      <Item>German</Item>
    </PhraseList>

    <PhraseList Label=""Me"">
      <Item>Application</Item>
      <Item>App</Item>
      <Item>Pi Studio</Item>
      <Item>Studio</Item>
    </PhraseList>

    <PhraseList Label=""Filter"">
      
    </PhraseList>

    <PhraseList Label=""PageType"">
      <Item>Home Page</Item>
      <Item>Filters Page</Item>
      <Item>Brightness Page</Item>
      <Item>Drawing Page</Item>
      <Item>Settings Page</Item>
    </PhraseList>

    <PhraseList Label=""Image"">
      <Item>image</Item>
      <Item>picture</Item>
      <Item>photo</Item>
    </PhraseList>
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
