using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Media.SpeechRecognition;
using Windows.Media.SpeechSynthesis;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using PiStudio.Win10.Voice.Commands;
using PiStudio.Win10.Voice.Srgs;
using Windows.UI.Xaml;
using System.Threading;
using Windows.UI;

namespace PiStudio.Win10.Voice.Navigation
{
	/// <summary>
	/// Class that recognizes speech commands and performs action when was command recognized.
	/// </summary>
	public class SpeechNavigator
	{
		private SpeechRecognizer m_constrainedRecognizer;
		private SpeechRecognizer m_freeSpeechRecognizer;
		private string m_location = null; 
		private const string m_commandsFilenameSuffix = ".grxml";
		private bool m_constrained = false;
		private VoiceCommands m_voiceCommands;
		private string m_filePath;
        private bool m_listening = false;
        private SemaphoreSlim m_semaphore = new SemaphoreSlim(1, 1);
		public static readonly uint HResultPrivacyStatementDeclined = 0x80045509;

		/// <summary>
		/// Creates new instance of <see cref="SpeechNavigator"/>.
		/// </summary>
		/// <param name="filepath">Path to the folder where are voice commands, and where will be compiled GRXML file stored.</param>
		private SpeechNavigator(string filepath)
		{
			m_constrainedRecognizer = new SpeechRecognizer();
			m_freeSpeechRecognizer = new SpeechRecognizer();
			m_location = filepath;
            SetHypGeneratedEvent();
		}

		/// <summary>
		/// Creates new instance of <see cref="SpeechNavigator"/>.
		/// </summary>
		/// <param name="filepath">Path to the folder where are voice commands, and where will be compiled GRXML file stored.</param>
		/// <param name="language"><see cref="Windows.Globalization.Language"/> in which will be recognizer recognizing.</param>
		private SpeechNavigator(string filepath, Windows.Globalization.Language language)
		{
			m_constrainedRecognizer = new SpeechRecognizer(language);
            m_freeSpeechRecognizer = new SpeechRecognizer(language);
			m_location = filepath;
            SetHypGeneratedEvent();
		}

        public VoiceCommands VoiceCommands
        {
            get
            {
                return m_voiceCommands;
            }
        }

        private void SetHypGeneratedEvent()
        {
            var dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
            m_constrainedRecognizer.HypothesisGenerated += async (o, e) =>
            {
                if (m_voiceUI != null)
                   await dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => m_voiceUI.Text = e.Hypothesis.Text);
            };
        }

		/// <summary>
		/// Initializes <see cref="SpeechNavigator"/> so it is ready to listen for user input.
		/// </summary>
		/// <returns><see cref="SpeechRecognitionCompilationResult"/></returns>
		private async Task<SpeechRecognitionCompilationResult> Initialize()
		{
			var result = await m_freeSpeechRecognizer.CompileConstraintsAsync();
			var result2 = await m_constrainedRecognizer.CompileConstraintsAsync();
			if (result.Status != SpeechRecognitionResultStatus.Success)
				return result;
			return result2;
		}

		/// <summary>
		/// Initializes <see cref="SpeechNavigator"/> so it is ready to listen for user input.
		/// </summary>
		/// <param name="file">File with VoiceCommands that will constrain recognizer to specific commands.</param>
		/// <returns><see cref="SpeechRecognitionCompilationResult"/></returns>
		public async Task<SpeechRecognitionCompilationResult> Initialize(StorageFile file)
		{
			var result = await m_freeSpeechRecognizer.CompileConstraintsAsync();
			await m_constrainedRecognizer.CompileConstraintsAsync();
			var result2 = await CompileConstraintAsync(file);

			if (result.Status != SpeechRecognitionResultStatus.Success)
				return result;
			return result2;
		}

		/// <summary>
		/// Asynchronously creates new instance of <see cref="SpeechNavigator"/>.
		/// </summary>
		/// <returns>Refernce to new instance of <see cref="SpeechNavigator"/></returns>
		public static async Task<SpeechNavigator> Create()
		{
			var navigator = new SpeechNavigator(ApplicationData.Current.LocalFolder.Path);
			await navigator.Initialize();
			return navigator;
		}

		/// <summary>
		/// Asynchronously creates new instance of <see cref="SpeechNavigator"/>.
		/// </summary>
		/// <param name="file"><see cref="StorageFile"/> where are VoiceCommands located.</param>
		/// <returns>Refernce to new instance of <see cref="SpeechNavigator"/></returns>
		public static async Task<SpeechNavigator> Create(StorageFile file)
		{
			string path = (await file.GetParentAsync()).Path;
			var navigator = new SpeechNavigator(path);
			await navigator.Initialize(file);
			return navigator;
		}

		/// <summary>
		/// Asynchronously creates new instance of <see cref="SpeechNavigator"/>.
		/// </summary>
		/// <param name="file"><see cref="StorageFile"/> where are VoiceCommands located.</param>
		/// <param name="language"><see cref="Windows.Globalization.Language"/> in which will user speak.</param>
		/// <returns>Refernce to new instance of <see cref="SpeechNavigator"/></returns>
		public static async Task<SpeechNavigator> Create(StorageFile file, Windows.Globalization.Language language)
		{
			string path = (await file.GetParentAsync()).Path;
			var navigator = new SpeechNavigator(path, language);
			await navigator.Initialize(file);
			return navigator;
		}

		/// <summary>
		/// Gives recognizer commands and improves its recognition capabilities.
		/// </summary>
		/// <param name="file">File with commands that will constrain recognizer.</param>
		/// <returns><see cref="SpeechRecognitionCompilationResult"/></returns>
		public async Task<SpeechRecognitionCompilationResult> CompileConstraintAsync(StorageFile file)
		{
			m_filePath = file.Path;
			m_location = (await file.GetParentAsync()).Path;
			var commands = await SpeechRecognitionManager.LoadCommandsFromFileAsync(file);
			if (commands == null)
				throw new SerializationException("File content can not be deserialized ! File content is probably in bad format..");
			this.m_voiceCommands = commands;
			return await CompileConstraintAsync(commands);
		}

		/// <summary>
		/// Gives recognizer commands and improves its recognition capabilities.
		/// </summary>
		/// <param name="commands">Commands that will constrain recognizer.</param>
		/// <returns><see cref="SpeechRecognitionCompilationResult"/></returns>
		public async Task<SpeechRecognitionCompilationResult> CompileConstraintAsync(VoiceCommands commands)
		{
			this.m_voiceCommands = commands;
			SpeechRecognitionCompilationResult result = null;
			foreach (var commandSet in commands.CommandSets)
			{
				Grammar grammar = SpeechRecognitionManager.CompileGrammar(commandSet, true);
				result = await CompileConstraintAsync(grammar, commandSet.Name);
				if (result.Status != SpeechRecognitionResultStatus.Success)
					return result;
				else
					m_constrained = true;
			}
			return result;
		}

		/// <summary>
		/// Saves given commands into file. Creates GrammarFileConstraint and adds it to speech recognition.
		/// </summary>
		private async Task<SpeechRecognitionCompilationResult> CompileConstraintAsync(Grammar commands, string commandsName)
		{
			StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(m_location);
			StorageFile file = await folder.CreateFileAsync(commandsName + m_commandsFilenameSuffix, CreationCollisionOption.ReplaceExisting);
			SpeechRecognitionManager.SaveGrammarToFile(file, commands);

			var grammarFileConstraint = new SpeechRecognitionGrammarFileConstraint(file, commandsName);
			this.m_constrainedRecognizer.Constraints.Add(grammarFileConstraint);
			return await this.m_constrainedRecognizer.CompileConstraintsAsync();
		}

		/// <summary>
		/// Recognizes speech constrined by SRGS grammar created from VoiceCommands that were passes in file. 
		/// </summary>
		/// <returns>Returns <see cref="SpeechRecognitionResult"/></returns>
		public async Task<SpeechRecognitionResult> RecognizeSpeechAsync()
		{
            await m_semaphore.WaitAsync();
            var result = await m_constrainedRecognizer.RecognizeAsync();
            m_semaphore.Release();
			
            if (m_voiceUI != null)
                m_voiceUI.Stop();
            if (m_constrained)
			{
				if (result.RulePath == null || result.Confidence == SpeechRecognitionConfidence.Rejected || result.RulePath.Count == 0)
				{
                    //nebolo nic povedane zvacsa
					return null;
				}
				var tmp = result.RulePath[0];
				if (!string.IsNullOrEmpty(tmp))
				{
					return new SpeechRecognitionResult(result, m_voiceCommands);
				}
				else
					return null;
			}
			else
				return new SpeechRecognitionResult(result);
		}

        private UI.VoiceUI m_voiceUI;
        public async Task<SpeechRecognitionResult> RecognizeSpeechWithUIAsync(Grid displayGrid, Color color,
            int row = 0, int column = 0, int rowSpan = 1, int columnSpan = 1)
        {
            m_voiceUI = new UI.VoiceUI();
            m_voiceUI.Fill = color;
            m_voiceUI.Text = "Listening...";
            Canvas.SetZIndex(m_voiceUI, 1000);
            Grid.SetColumn(m_voiceUI, column);
            Grid.SetRow(m_voiceUI, row);
            if(columnSpan > 0)
                Grid.SetColumnSpan(m_voiceUI, columnSpan);
            if(rowSpan > 0)
                Grid.SetRowSpan(m_voiceUI, rowSpan);
            displayGrid.Children.Add(m_voiceUI);
            m_voiceUI.Start();
            await System.Threading.Tasks.Task.Delay(1200);
            SayText("Listening");
            var result = await RecognizeSpeechAsync();
            displayGrid.Children.Remove(m_voiceUI);
            return result;
        }

        /// <summary>
        /// Recognizes free non constrained speech. 
        /// </summary>
        /// <returns><see cref="SpeechRecognitionResult"/></returns>
        public async Task<SpeechRecognitionResult> RecognizeFreeSpeechAsync()
		{
			var result = await this.m_freeSpeechRecognizer.RecognizeAsync();
			return new SpeechRecognitionResult(result);
		}

		/// <summary>
		/// Performs action according to given result. Actions must be first set.
		/// </summary>
		/// <param name="result">Result of speech recognition.</param>
		/// <returns></returns>
		private void PerformAction(SpeechRecognitionResult result)
		{
			if (result == null)
				throw new ArgumentNullException();
			var cmd = result.RecognizedCommand;
			var recognizedValues = result.ReconizedPhraseListsValues;
			if (cmd == null)
				return;
			string textToSpeak = null;
			if (cmd.Feedback != null)
				textToSpeak = cmd.Feedback.Content;
			if (string.IsNullOrWhiteSpace(textToSpeak))
				textToSpeak = null;
			var customAction = cmd.VoiceAction as CustomAction;
			var dialogAction = cmd.VoiceAction as ShowDialog;
			foreach (var key in recognizedValues.Keys)
			{
				if (textToSpeak != null)
					textToSpeak = textToSpeak.Replace("{" + key + "}", recognizedValues[key]);
				if (customAction != null)
				{
					customAction.ActionContent = customAction.ActionContent.Replace("{" + key + "}", recognizedValues[key]);
					customAction.ActionParameter = customAction.ActionParameter.Replace("{" + key + "}", recognizedValues[key]);
				}
				if (dialogAction != null)
					dialogAction.TextToDisplay = dialogAction.TextToDisplay.Replace("{" + key + "}", recognizedValues[key]);
			}

			//if(result.RecognizedCommand.Feedback != null)
			//	result.RecognizedCommand.Feedback.Content = textToSpeak;
			if (customAction != null)
				result.RecognizedCommand.VoiceAction = customAction;

			if (textToSpeak != null)
				SayText(textToSpeak);
			if (this.CommandRecognized == null)
				cmd.InvokeAction(this, result);
			else
			{
				var fn = this.CommandRecognized;
				fn(this, result);
			}
		}

		/// <summary>
		/// Starts listening to what user says. As soon as will be some command recognized it will trigger action set to this command.
		/// Does nothing if action was not set.
		/// </summary>
		/// <returns></returns>
		public async Task RecognizeAndPerformActionAsync()
		{
			var result = await RecognizeSpeechAsync();
			if (result != null)
				PerformAction(result);
		}

        public async Task RecognizeAndPerformActionWithUIAsync(Grid displayGrid, Color fill,
            int row = 0, int column = 0, int rowSpan = 0, int columnSpan = 0)
        {
            var result = await RecognizeSpeechWithUIAsync(displayGrid, fill, row, column, rowSpan, columnSpan);
            if (result != null)
                PerformAction(result);
        }

		/// <summary>
		/// Speeks given text asynchronously on the backgound. Can be awaited until speaking of the text finishes.
		/// </summary>
		/// <param name="textToSpeech">Text to be spoken</param>
		/// <returns><see cref="Task"/></returns>
		public static async Task SayTextAsync(string textToSpeech, Grid form)
		{
			if (string.IsNullOrWhiteSpace(textToSpeech))
				return;
			using (var synthesizer = new SpeechSynthesizer())
			{
				MediaElement audioPlayer = new MediaElement();
				var taskSource = new TaskCompletionSource<bool>();
				synthesizer.Voice = SpeechSynthesizer.AllVoices.First(
							i => (i.Gender == VoiceGender.Female));
				SpeechSynthesisStream ttsStream = await synthesizer.SynthesizeTextToStreamAsync(textToSpeech);

				form.Children.Add(audioPlayer);

				audioPlayer.MediaEnded += (o, e) => { taskSource.TrySetResult(true); };
				audioPlayer.PartialMediaFailureDetected += (o, e) => { taskSource.TrySetResult(true); };
				audioPlayer.MediaFailed += (o, e) => { taskSource.TrySetResult(true); };

				audioPlayer.SetSource(ttsStream, "");
				audioPlayer.Play();

				await taskSource.Task;
				((Grid)form).Children.Remove(audioPlayer);
			}
		}

		/// <summary>
		/// Speaks given text asynchronously on the backgound and can not be awaited.
		/// </summary>
		/// <param name="textToSpeech">Text to be spoken</param>
		public static async void SayText(string textToSpeech)
		{
			if (string.IsNullOrWhiteSpace(textToSpeech))
				return;
			using (var synthesizer = new SpeechSynthesizer())
			{
				MediaElement audioPlayer = new MediaElement();
				synthesizer.Voice = SpeechSynthesizer.AllVoices.First(
							i => (i.Gender == VoiceGender.Female));
				SpeechSynthesisStream ttsStream = await synthesizer.SynthesizeTextToStreamAsync(textToSpeech);

				audioPlayer.SetSource(ttsStream, "");
				audioPlayer.Play();
			}
		}

		/// <summary>
		/// Sets values to phrase list dynamically in runtime.
		/// </summary>
		/// <param name="commandSetName">CommandSet inside VCD voice commands.</param>
		/// <param name="phraseListName">Name of the phraseList inside CommandSet</param>
		/// <param name="phraseListValues">Values to be inserted into phraseList</param>
		/// <param name="clearOldValues">Indicated wheter clear old values in PhraseList or not.</param>
		/// <returns>Result of setting phrase list.</returns>
		public async Task<SpeechRecognitionCompilationResult> SetPhraseListAsync(string commandSetName, string phraseListName, IEnumerable<string> phraseListValues, bool clearOldValues = true)
		{
			if (string.IsNullOrEmpty(this.m_filePath))
				throw new InvalidOperationException("Can not set phrase list because no file or voice commands were loaded. Please load voice commands first...");
			var commandSet = this.m_voiceCommands.CommandSets.Where(i => i.Name == commandSetName).FirstOrDefault();
			if (commandSet == null)
				throw new ArgumentException("Voice commands does not contains Command Set with name " + commandSetName + " !");
			SpeechRecognitionManager.SetPhraseList(m_voiceCommands, phraseListName, phraseListValues, clearOldValues);
			var grammar = SpeechRecognitionManager.CompileGrammar(commandSet);
			return await this.CompileConstraintAsync(grammar, commandSet.Name);
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
				throw new ArgumentException("No file or voice commands were set so no callback can be set...");

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
		/// Deletes action for the specific command.
		/// </summary>
		/// <param name="commandSet">CommandsSet name inside which is command located..</param>
		/// <param name="command">Command after which recognition is triggered a specific event.</param>
		/// <param name="callback">Action that will be performed</param>
		public void DeleteAction(string commandSet, string command, EventHandler<SpeechRecognitionResult> callback)
		{
			if (m_voiceCommands == null)
				throw new ArgumentException("No file or voice commands were set so no callback can be set...");

			var cmdSet = m_voiceCommands.CommandSets.Where(i => i.Name == commandSet).FirstOrDefault();
			if (cmdSet != null)
			{
				var cmd = cmdSet.Commands.Where(i => i.Name == command).FirstOrDefault();
				if (cmd != null)
				{
					cmd.VoiceAction.CommandRecognized -= callback;
				}
				else
					throw new ArgumentException(commandSet + " does not contains commands with name '" + command + "'.");
			}
			else
				throw new ArgumentException("Voice commands does not contains commandSet with name '" + commandSet + "'.");
		}

		/// <summary>
		/// Stops current recognition asynchronously.
		/// </summary>
		public async Task StopRecognitionAsync()
		{
			await this.m_constrainedRecognizer.StopRecognitionAsync();
			await this.m_freeSpeechRecognizer.StopRecognitionAsync();
		}

		/// <summary>
		/// Global event. If is this event set it will be always called when any command will be recognized. The result
		/// and sender will be sent as parameter. Senders could be <see cref="CortanaIntegrator"/> or <see cref="RecognitionAndAction.SpeechNavigator"/>.
		/// </summary>
		public event EventHandler<SpeechRecognitionResult> CommandRecognized;

		public SpeechRecognizerTimeouts Timeouts
		{
			get { return m_constrainedRecognizer.Timeouts; }
		}
	}
}
