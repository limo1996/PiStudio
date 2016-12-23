using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.ApplicationModel.VoiceCommands;
using Resco.InAppSpeechRecognition.RecognitionAndAction;

namespace Resco.Cortana
{
	/// <summary>
	/// Class that manage integration with Cortana.
	/// </summary>
	public class CortanaIntegrator
	{
		private bool m_commandsSuccessfullyInstalled = false;
		/// <summary>
		/// Creates new instance of <see cref="CortanaIntegrator"/>. But do not install any commands into cortana.
		/// </summary>
		public CortanaIntegrator()
		{ }

		/// <summary>
		/// Installs command definition from the file given as argument.
		/// </summary>
		/// <param name="path">Path to the file where is VCD file.</param>
		/// <returns></returns>
		public async Task<bool> Install(string path)
		{
			var cortanaCommandsFile = await StorageFile.GetFileFromPathAsync(path);
			return await InstallCommandDefinitionAsync(cortanaCommandsFile);
		}

		/// <summary>
		/// Creates new instance of <see cref="CortanaIntegrator"/>. But do not install any commands into cortana.
		/// </summary>
		/// <param name="commandsFilePath">Path to VCD </param>
		public CortanaIntegrator(string commandsFilePath)
		{
			this.m_voiceCommands = SpeechRecognitionManager.LoadCommandsFromFile(commandsFilePath);
		}

		private InAppSpeechRecognition.Commands.VoiceCommands m_voiceCommands = null;

		/// <summary>
		/// Creates new instance of <see cref="CortanaIntegrator"/> class ans install commands into cortana.
		/// </summary>
		/// <param name="file"><see cref="StorageFile"/> where is VCD commands saved.</param>
		/// <returns>Reference to <see cref="CortanaIntegrator"/> object.</returns>
		public static async Task<CortanaIntegrator> Create(StorageFile file)
		{
			var integrator = new CortanaIntegrator();
			await integrator.InstallCommandDefinitionAsync(file);
			return integrator;
		}

		/// <summary>
		/// Installs and integrates VCD commands into cortana.
		/// </summary>
		/// <param name="file"><see cref="StorageFile"/> where is VCD commands saved.</param>
		public async Task<bool> InstallCommandDefinitionAsync(StorageFile file)
		{
			try
			{
				m_voiceCommands = await SpeechRecognitionManager.LoadCommandsFromFileAsync(file);
				await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(file);
				m_commandsSuccessfullyInstalled = true;
				return true;
			}
			catch (Exception ex)
			{ 
				System.Diagnostics.Debug.WriteLine(ex.ToString());
				m_commandsSuccessfullyInstalled = false;
				return false;
			}

		}

		/// <summary>
		/// Sets values to phrase list dynamically in runtime.
		/// </summary>
		/// <param name="commandSetName">CommandSet inside VCD voice commands.</param>
		/// <param name="phraseListName">Name of the phraseList inside CommandSet</param>
		/// <param name="phraseListValues">Values to be inserted into phraseList</param>
		public async Task SetPhraseListAsync(string commandSetName, string phraseListName, IEnumerable<string> phraseListValues)
		{
			if (!m_commandsSuccessfullyInstalled)
				return;
			VoiceCommandDefinition commandSetEnUs;

			if (VoiceCommandDefinitionManager.InstalledCommandDefinitions.TryGetValue(
					commandSetName, out commandSetEnUs))
			{
				await commandSetEnUs.SetPhraseListAsync(phraseListName, phraseListValues);
			}
			else
				throw new ArgumentException("Given commandSet name is incorrent !");
		}

		/// <summary>
		/// Performs action according to given result but actions should be first set.
		/// </summary>
		/// <param name="speechResult">Result of a cortana speech recognition.</param>
		public void PerformAction(Windows.Media.SpeechRecognition.SpeechRecognitionResult speechResult)
		{
			if (speechResult == null)
				throw new ArgumentNullException();
			var result = new SpeechRecognitionResult(speechResult, m_voiceCommands);

			if (result == null || result.RecognizedCommand == null)
				throw new NullReferenceException("Result or result.recognizedcommand is null...");

			if (CommandRecognized == null)
				result.RecognizedCommand.InvokeAction(this, result);
			else
			{
				var fn = CommandRecognized;
				if (fn != null)
					fn(this, result);
			}
		}

		/// <summary>
		/// Sets the action to the specific commands.
		/// </summary>
		/// <param name="commandSet">CommandsSet name inside which is command located..</param>
		/// <param name="command">Command after which recognition is triggered a specific event.</param>
		/// <param name="callback">Action that will be performed</param>
		public void SetAction(string commandSet, string command, EventHandler<SpeechRecognitionResult> callback)
		{
			if (m_voiceCommands == null)
				return;
			var cmdSet = m_voiceCommands.CommandSets.Where(i => i.Name == commandSet).FirstOrDefault();
			if (cmdSet != null)
			{
				var cmd = cmdSet.Commands.Where(i => i.Name == command).FirstOrDefault();
				if (cmd != null)
				{
					cmd.VoiceAction.CommandRecognized += callback;
				}
				else
					throw new ArgumentException(commandSet + " does not contains commands with name '" + command + "'.");
			}
			else
				throw new ArgumentException("Voice commands does not contains commandSet with name '" + commandSet + "'.");
		}

		/// <summary>
		/// Global event. If is this event set it will be always called when any command will be recognized. The result
		/// and sender will be sent as parameter. Senders could be <see cref="CortanaIntegrator"/> or <see cref="RecognitionAndAction.SpeechNavigator"/>.
		/// </summary>
		public event EventHandler<SpeechRecognitionResult> CommandRecognized;
	}
}