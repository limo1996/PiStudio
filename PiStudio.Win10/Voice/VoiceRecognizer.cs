using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;
using PiStudio.Win10.Voice.Navigation;
using PiStudio.Win10.Cortana;
using PiStudio.Win10.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using PiStudio.Shared;
using PiStudio.Win10.Navigation;
using PiStudio.Win10.UI.Pages;

namespace PiStudio.Win10.Voice
{
	/*********
	// In app speech recognition and navigation is disabled 
	// TODO: Add some button for enabling recognition
	*********/


	/// <summary>
	/// Integrates cortana and in app speech recognition into MobileCRM
	/// </summary>
	public class VoiceRecognizer
	{
		private SpeechNavigator m_navigator;
		private CortanaIntegrator m_integrator;

		/// <summary>
		/// Creates new instance of <see cref="VoiceRecognizer"/>
		/// </summary>
		public VoiceRecognizer()
		{
            var cortanaCommandsPath = WinAppResources.Instance.GetStoragePath(CommandDefinitions.PiStudioCortanaVoiceCommandsFileName);
            var navigatorCommandsPath = WinAppResources.Instance.GetStoragePath(CommandDefinitions.PiStudioNavigatorVoiceCommandsFileName);

            WriteToFileIfDoNotExists(cortanaCommandsPath, CommandDefinitions.PiStudioCortanaVoiceCommands);
            WriteToFileIfDoNotExists(navigatorCommandsPath, CommandDefinitions.PiStudioNavigatorVoiceCommands);

            m_integrator = new CortanaIntegrator(cortanaCommandsPath);

            m_initTask = InitializeAsync(navigatorCommandsPath);
			m_installCortanaCommandsTask = InstallCortanaCommands();
		}

		//we must save tasks because of async initialization in constructor 
		//also when is some functions called we must ensure wait till object is asynchronously initilaized
		Task m_initTask;
		Task m_installCortanaCommandsTask;

		//initialized cortana for action and navigator
		private async Task InitializeAsync(string navigatorCommandsPath)
		{
			StorageFile navigatorCommandsFile = await StorageFile.GetFileFromPathAsync(navigatorCommandsPath);
			m_navigator = await SpeechNavigator.Create(navigatorCommandsFile);
			m_navigator.Timeouts.InitialSilenceTimeout = new TimeSpan(0, 0, 10);
            SetActionsForNavigator();
		}

		//installs cortana commands, if was not yet installed
		private async Task InstallCortanaCommands()
		{
			if (AppSettings.Instance.CortanaVoiceCommandsVersion != 1)
			{
				await m_initTask;
				var cortanaCommandsPath = WinAppResources.Instance.GetStoragePath(CommandDefinitions.PiStudioCortanaVoiceCommandsFileName);
				var success = await m_integrator.Install(cortanaCommandsPath);
                if (success)
                    AppSettings.Instance.CortanaVoiceCommandsVersion = 1;
			}
			SetActionsForCortana();
		}

		private void WriteToFileIfDoNotExists(string filepath, string contentOfFile)
		{
			if (!File.Exists(filepath))
			{
				using (var stream = File.Create(filepath))
				{
					byte[] content = System.Text.Encoding.UTF8.GetBytes(contentOfFile);
					stream.Write(content, 0, content.Length);
				}
			}
		}


		//sets cortanas actions
		private void SetActionsForCortana()
		{
			m_integrator.SetAction("PiStudioVoiceCommandsEnUs", "OpenLastEdited", OpenLastEdited);
		}

        //sets voice navigator actions
        private void SetActionsForNavigator()
        {
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "OpenLastEdited", NavigateToSettingsPage);
        }

        /// <summary>
        /// Gets the singleton <see cref="VoiceRecognizer"/> Instance
        /// </summary>
        public static VoiceRecognizer Instance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new VoiceRecognizer();
				}
				return _Instance;
			}
		}
		private static VoiceRecognizer _Instance;

        public async void HandleLaunch(Windows.ApplicationModel.Activation.VoiceCommandActivatedEventArgs args)
        {
            await m_initTask;
            m_integrator.PerformAction(args.Result);
        }

        //reads given text
        public async Task SayText(string text)
		{
            var frame = Window.Current.Content as Frame;
            if(frame != null)
                await SpeechNavigator.SayTextAsync(text, (Grid)((Page)frame.Content).Content);
        }

		//recognizes and performs action. Catches exceptions...
		public async Task RecognizeAndPerformActionAsync()
		{
			try
			{
				await m_navigator.RecognizeAndPerformActionAsync();
			}
			catch (Exception ex)
			{
				if ((uint)ex.HResult == SpeechNavigator.HResultPrivacyStatementDeclined)
				{
					//notice user to accept privacy settings
					LaunchUri(new Uri(@"https://privacy.microsoft.com/en-us/privacystatement"));
					LaunchUri(new Uri("ms-settings:privacy-microphone"));
					//Todo display user Privacy settings 
					//Program.OnUnhandledException("HResultPrivacyStatementDeclined raised", false);
				}
				else if (ex.GetType() == typeof(UnauthorizedAccessException))
				{
					LaunchUri(new Uri("ms-settings:privacy-microphone"));
				}
				else
				{
					//catch another exception
					//Program.OnUnhandledException(ex.Message, false);
				}
			}
		}

        public async Task RecognizeAndPerformActionWithUIAsync(Grid mainDisplay, int row = 0, int column = 0, int rowSpan = 1, int columnSpan = 1)
        {
            try
            {
                await m_navigator.RecognizeAndPerformActionWithUIAsync(mainDisplay, 
                    WinAppResources.Instance.ApplicationTheme.PanelItemFocused, row, column, rowSpan, columnSpan);
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == SpeechNavigator.HResultPrivacyStatementDeclined)
                {
                    //notice user to accept privacy settings
                    LaunchUri(new Uri(@"https://privacy.microsoft.com/en-us/privacystatement"));
                    LaunchUri(new Uri("ms-settings:privacy-microphone"));
                    //Todo display user Privacy settings 
                    //Program.OnUnhandledException("HResultPrivacyStatementDeclined raised", false);
                }
                else if (ex.GetType() == typeof(UnauthorizedAccessException))
                {
                    LaunchUri(new Uri("ms-settings:privacy-microphone"));
                }
                else
                {
                    //catch another exception
                    //Program.OnUnhandledException(ex.Message, false);
                }
            }
        }

        //launches given uri in the background
        private async void LaunchUri(Uri uri)
		{
			await Windows.System.Launcher.LaunchUriAsync(uri);
		}

        #region Cortana Actions
        /// <summary>
        /// Opens last edited image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OpenLastEdited(object sender, SpeechRecognitionResult e)
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
                await Navigator.Instance.NavigateTo(typeof(HomePage), null);
        }

        #endregion

        #region Navigator actions

        /// <summary>
        /// Navigates to settings page
        /// </summary>
        /// <param name="sender"><see cref="SpeechNavigator"/></param>
        /// <param name="e">voice result</param>
        private async void NavigateToSettingsPage(object sender, SpeechRecognitionResult e)
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
                await Navigator.Instance.NavigateTo(typeof(SettingsPage), null);
        }
        #endregion
    }
}
