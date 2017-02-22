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
		public static readonly string PiStudioNavigatorVoiceCommands=@"<?xml version=""1.0"" encoding=""utf-8""?>
<VoiceCommands xmlns=""http://schemas.microsoft.com/voicecommands/1.2"">

	<!--CommandSet for English-->
	<CommandSet xml:lang=""en-us"" Name=""CRMCommandsSetEnUs"">
		<CommandPrefix>  </CommandPrefix>
		<Example>Show my active accounts</Example>

		<!--Shows view on current entity-->
		<Command Name=""showView"">
			<Example>Show my active accounts</Example>
			<ListenFor>Show [me] {viewName} </ListenFor>
			<ListenFor>Open {viewName} </ListenFor>
			<Navigate/>
		</Command>

		<!--Adds new record on current entity-->
		<Command Name=""addNewRecord"">
			<Example> Add new record called Lorem Ipsum </Example>
   			<ListenFor>Add new record</ListenFor>
			<ListenFor>Add new item</ListenFor>
			<ListenFor>Create new record</ListenFor>
			<ListenFor>Create new item</ListenFor>
			<Navigate/>
		</Command>

		<!--Commands of acceptation-->
		<Command Name=""accepted"">
			<Example>Yes</Example>
			<ListenFor>Yes</ListenFor>
			<ListenFor>Ofcourse</ListenFor>
			<ListenFor>Yeah</ListenFor>
			<ListenFor>affirmative</ListenFor>
			<ListenFor>ok</ListenFor>
			<ListenFor>yea</ListenFor>
			<ListenFor>yep</ListenFor>
			<ListenFor>sure</ListenFor>
			<ListenFor>Accept[it]</ListenFor>
			<ListenFor>Allright</ListenFor>
			<Navigate/>
		</Command>

		<!--Commands of rejection-->
		<Command Name=""rejected"">
			<Example> No </Example>
			<ListenFor>No</ListenFor>
			<ListenFor>reject</ListenFor>
			<ListenFor>refuse</ListenFor>
			<ListenFor>nix</ListenFor>
			<ListenFor>nope</ListenFor>
			<ListenFor>no way</ListenFor>
			<ListenFor>negative</ListenFor>
			<ListenFor>Not yet</ListenFor>
			<Navigate/>
		</Command>

		<!--Shows entity after recognizing-->
		<Command Name=""showEntity"">
			<Example> Navigate to Accounts</Example>
			<ListenFor>Navigate [me] [to] {entityName}</ListenFor>
			<Navigate/>
		</Command>

		<PhraseList Label=""entityName"">
			<Item>Accounts</Item>
			<Item>Leads</Item>
			<Item>Appointment</Item>
		</PhraseList>
		<PhraseList Label=""viewName"">
			<Item>Views</Item>
			<Item>Accounts</Item>
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
