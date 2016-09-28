using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resco.Cortana
{
	/// <summary>
	/// Class that contains voice commands in string. Class is used during first launch to create files with content of this class.
	/// </summary>
	public class CommandDefinitions
	{	
		/// <summary>
		/// Content of the Navigator voice commnads file.
		/// </summary>
		public static readonly string CRMNavigatorVoiceCommands=@"<?xml version=""1.0"" encoding=""utf-8""?>
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
		public static readonly string CRMCortanaVoiceCommands=@"<?xml version=""1.0"" encoding=""utf-8""?>
<VoiceCommands xmlns=""http://schemas.microsoft.com/voicecommands/1.2"">

	<!--CommandSet for English-->
	<CommandSet xml:lang=""en-us"" Name=""CRMCommandsSetEnUs"">
		<CommandPrefix> CRM</CommandPrefix>
		<Example> Show my active accounts</Example>

		<!--Opens CRM and opens entity list-->
		<Command Name=""showEntity"">
			<Example> Show me active accounts</Example>
			<ListenFor>Show [me] {entityName}</ListenFor>
			<ListenFor>Open [me] {entityName}</ListenFor>
			<Feedback>Opening {entityName}</Feedback>
			<Navigate/>
		</Command>

		<!--Opens CRM and opens entity list on given view-->
		<Command Name=""showEntityView"">
			<Example> Show accounts view my connections</Example>
   			<ListenFor>Show [me] {entityName} view {viewName}</ListenFor>
			<ListenFor>Show[me] {entityName} list {viewName}</ListenFor>
			<ListenFor>Open {entityName} view {viewName}</ListenFor>
			<ListenFor>Open {entityName} list {viewName}</ListenFor>
			<ListenFor>Show [me] view {viewName}</ListenFor>
			<ListenFor>Open [me] view {viewName}</ListenFor>
			<Feedback>Opening {viewName}</Feedback>
			<Navigate/>
		</Command>

		<!--Finds record in CRM-->
		<Command Name=""findRecord"">
			<Example> Find Contoso</Example>
			<ListenFor>Find {recordName}</ListenFor>
			<ListenFor>Search [for] {recordName}</ListenFor>
			<ListenFor>Find {recordName} in {entityName}</ListenFor>
			<ListenFor>Search [for] {recordName} in {entityName}</ListenFor>
			<Feedback>Searching for {recordName}</Feedback>
			<Navigate/>
		</Command>

		<!--Creates record with given primaryFieldValue-->
		<Command Name=""createRecord"">
			<Example> Create account called Lorem Ipsum</Example>
   			<ListenFor>Create {createName}</ListenFor>
			<ListenFor>Add new {createName}</ListenFor>
			<ListenFor>Create {createName} called {primaryFieldValue}</ListenFor>
			<ListenFor>Create {createName} named {primaryFieldValue}</ListenFor>
			<ListenFor>Add new {createName} named {primaryFieldValue}</ListenFor>
			<ListenFor>Add new {createName} called {primaryFieldValue}</ListenFor>
			<Feedback>Creating {createName}</Feedback>
			<Navigate/>
		</Command>

		<!--Creates record with given primaryFieldValue on already opened entity list.-->
		<Command Name=""createRecord2"">
			<Example> Add new record called Lorem</Example>
			<ListenFor>Create new [record] called {primaryFieldValue}</ListenFor>
			<ListenFor>Add new [record] called {primaryFieldValue}</ListenFor>
			<ListenFor>Create new [record] named {primaryFieldValue}</ListenFor>
			<ListenFor>Add new [record] named {primaryFieldValue}</ListenFor>
			<Feedback>Creating new record called {primaryFieldValue}</Feedback>
			<Navigate/>
		</Command>

		<!--Creates phone call to someone-->
		<Command Name=""createPhoneCall"">
			<Example> Remind me to call Peter</Example>
   			<ListenFor>Remind me to call {primaryFieldValue}</ListenFor>
			<Feedback>Creating phone call to {primaryFieldValue}</Feedback>
			<Navigate/>
		</Command>

		<!--Creates task with given primaryFieldValue on already opened entity list.-->
		<Command Name=""createTask"">
			<Example> Remind me to follow up with Lorem Ipsum</Example>
			<ListenFor>Remind me to {primaryFieldValue}</ListenFor>
			<ListenFor>Follow up with {primaryFieldValue}</ListenFor>
			<ListenFor>Follow up on {primaryFieldValue}</ListenFor>
			<Feedback>Creating task</Feedback>
			<Navigate/>
		</Command>

		<!--Creates appointment with given primaryFieldValue on already opened entity list.-->
		<Command Name=""createAppointment"">
			<Example> Schedule meeting to discuss Lorem Ipsum</Example>
			<ListenFor>Schedule meeting {primaryFieldValue}</ListenFor>
			<ListenFor>Create meeting {primaryFieldValue}</ListenFor>
			<ListenFor>Set up meeting {primaryFieldValue}</ListenFor>
			<Feedback>Creating appointment</Feedback>
			<Navigate/>
		</Command>

		<!--Creates task with given primaryFieldValue on already opened entity list.-->
		<Command Name=""openTasks"">
			<Example> What should I do next?</Example>
			<ListenFor>What should I do next</ListenFor>
			<Feedback>Opening calendar</Feedback>
			<Navigate/>
		</Command>

		<PhraseList Label=""viewName"">
			<Item>Views</Item>
		</PhraseList>

		<PhraseList Label=""entityName"">
			<Item>Accounts</Item>
			<Item>Leads</Item>
		</PhraseList>

		<PhraseList Label=""createName"">
			<Item>Accounts</Item>
			<Item>Leads</Item>
		</PhraseList>

		<PhraseTopic Label=""recordName"" Scenario=""Search"">
			<Subject>Date/Time</Subject>
		</PhraseTopic>

		<PhraseTopic Label=""primaryFieldValue"" Scenario=""Search"">
			<Subject>Phone Number</Subject>
			<Subject>Person Names</Subject>
			<Subject>City/State</Subject>
			<Subject>Date/Time</Subject>
			<Subject>Addresses</Subject>
		</PhraseTopic>
	</CommandSet>
</VoiceCommands>
";
		/// <summary>
		/// Name of the file where are Cortana Voice Commands Saved.
		/// </summary>
		public static readonly string CRMCortanaVoiceCommandsFileName=@"CRMCortanaVoiceCommands.xml";

		/// <summary>
		/// Name of the file where are Navigator Voice Commands Saved.
		/// </summary>
		public static readonly string CRMNavigatorVoiceCommandsFileName=@"CRMNavigatorVoiceCommands.xml";
	}
}
