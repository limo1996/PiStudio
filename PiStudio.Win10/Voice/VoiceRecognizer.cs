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
	// TODO: PREVENT FROM SAYING RESPONSE 
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
        private async void SetActionsForNavigator()
        {
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "NavigateToPage", NavigateTo);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "Rotate", Rotate);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "Save", Save);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "SaveAs", SaveAs);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "AddNewImage", AddNewImage);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "ClearCanvas", ClearCanvas);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "Share", Share);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "Undo", Undo);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "ApplyFilter", ApplyFilter);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "About", About);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "EnableLight", EnableLight);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "EnableDark", EnableDark);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "EnableAutoSave", EnableAutoSave);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "DisableAutoSave", DisableAutoSave);
            m_navigator.SetAction("PiStudioVoiceCommandsEnUs", "ChangeLanguage", ChangeLanguage);
            await m_navigator.SetPhraseListAsync("PiStudioVoiceCommandsEnUs", "Filter", 
                WinAppResources.Instance.Filters.Where(i => i.IsEnabled == true).Select(i => i.FilterName));
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

        /// <summary>
        /// Reads given text. Runs asynchronously but can be awaited.
        /// </summary>
        /// <param name="text">Text to be read.</param>
        /// <returns></returns>
        public async Task SayText(string text)
		{
            var frame = Window.Current.Content as Frame;
            if(frame != null)
                await SpeechNavigator.SayTextAsync(text, (Grid)((Page)frame.Content).Content);
        }

		/// <summary>
        /// Immidiately starts listening to user. If microphone permission is not enabled, launches microphone settings.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Recognizes 
        /// </summary>
        /// <param name="mainDisplay"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="rowSpan"></param>
        /// <param name="columnSpan"></param>
        /// <returns></returns>
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

        private async void NavigateTo(object sender, SpeechRecognitionResult e)
        {
            var page = e.ReconizedPhraseListsValues["PageType"].ToLower().Replace(" ", "");
            Type pageType = null;
            switch (page)
            {
                case "homepage": pageType = typeof(HomePage);
                    break;
                case "filterspage": pageType = typeof(FiltersPage);
                    break;
                case "brightnesspage": pageType = typeof(BrightnessPage);
                    break;
                case "drawingpage": pageType = typeof(DrawingPage);
                    break;
                case "settingspage": pageType = typeof(SettingsPage);
                    break;
            }
            if (pageType != null)
                await Navigator.Instance.NavigateTo(pageType);
        }

        private async void Rotate(object sender, SpeechRecognitionResult e)
        {
            var frame = Window.Current.Content as Frame;
            if(frame != null)
            {
                if (frame.SourcePageType != typeof(HomePage))
                {
                    await Navigator.Instance.NavigateTo(typeof(HomePage));
                    var homePage = (HomePage)frame.Content;
                    homePage.NavigationCompleted += (o, ee) => homePage.Rotate();
                }
                else
                    ((HomePage)frame.Content).Rotate();
            }
        }

        private async void Save(object sender, SpeechRecognitionResult e)
        {
            await Navigator.Instance.SaveImage(false);
        }

        private async void SaveAs(object sender, SpeechRecognitionResult e)
        {
            await Navigator.Instance.SaveImage(true);
        }

        private void Share(object sender, SpeechRecognitionResult e)
        {
            Navigator.Instance.Share();
        }

        private async void AddNewImage(object sender, SpeechRecognitionResult e)
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                if (frame.SourcePageType != typeof(HomePage))
                {
                    await Navigator.Instance.NavigateTo(typeof(HomePage));
                    var homePage = (HomePage)frame.Content;
                    homePage.NavigationCompleted += async (o, ee) => await homePage.AddImage();
                }
                else
                    await ((HomePage)frame.Content).AddImage();
            }
        }

        private async void ClearCanvas(object sender, SpeechRecognitionResult e)
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                if (frame.SourcePageType != typeof(DrawingPage))
                    await Navigator.Instance.NavigateTo(typeof(DrawingPage));
                else
                    ((DrawingPage)frame.Content).Canvas.Clear();
            }
        }

        private async void Undo(object sender, SpeechRecognitionResult e)
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                if (frame.SourcePageType != typeof(DrawingPage))
                    await Navigator.Instance.NavigateTo(typeof(DrawingPage));
                else
                    ((DrawingPage)frame.Content).Canvas.Undo();
            }
        }

        private async void ApplyFilter(object sender, SpeechRecognitionResult e)
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                var filter = e.ReconizedPhraseListsValues["Filter"];
                if (frame.SourcePageType != typeof(FiltersPage))
                {
                    await Navigator.Instance.NavigateTo(typeof(FiltersPage));
                    var filtersPage = (FiltersPage)frame.Content;
                    filtersPage.NavigationCompleted += (o, ee) => filtersPage.SelectFilter(filter);
                }
                else
                    ((FiltersPage)frame.Content).SelectFilter(filter);
            }
        }
        private void ChangeLanguage(object sender, SpeechRecognitionResult e)
        {
            var lang = e.ReconizedPhraseListsValues["Language"];
            var language = Shared.Data.Language.Slovensky;
            if (lang == "English")
                language = Shared.Data.Language.English;
            else if (lang == "German")
                language = Shared.Data.Language.German;
            WinAppResources.Instance.SetLanguage(language);
            ReloadCurrentPage();
        }

        private void DisableAutoSave(object sender, SpeechRecognitionResult e)
        {
            RefreshAutoSave(false);
        }

        private void RefreshAutoSave(bool enable)
        {
            AppSettings.Instance.AutoSave = enable;
            var frame = (Frame)Window.Current.Content;
            if (frame.SourcePageType == typeof(SettingsPage))
            {
                var page = (SettingsPage)frame.Content;
                page.EnableAutoSave(enable);
            }
        }

        private void EnableAutoSave(object sender, SpeechRecognitionResult e)
        {
            RefreshAutoSave(true);
        }

        private void EnableDark(object sender, SpeechRecognitionResult e)
        {
            WinAppResources.Instance.SetTheme(true);
            ReloadCurrentPage();
        }

        private void EnableLight(object sender, SpeechRecognitionResult e)
        {
            WinAppResources.Instance.SetTheme(false);
            ReloadCurrentPage();
        }

        private async void ReloadCurrentPage()
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
                await Navigator.Instance.NavigateTo(frame.SourcePageType);
        }

        private void About(object sender, SpeechRecognitionResult e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
