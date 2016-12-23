using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileCrm.Data;
using Resco.InAppSpeechRecognition.RecognitionAndAction;
using MobileCrm.Controllers;
using Resco.Cortana;
using Windows.Storage;
using System.IO;

namespace MobileCrm
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
			m_initTask = InitializeAsync();
			m_installCortanaCommandsTask = InstallCortanaCommands();
		}

		//we must save tasks because of async initialization in constructor 
		//also when is some functions called we must ensure wait till object is asynchronously initilaized
		Task m_initTask;
		Task m_installCortanaCommandsTask;

		//initialized cortana for action and navigator
		private async Task InitializeAsync()
		{
			var cortanaCommandsPath = Configuration.Instance.GetStoragePath("CRMCortanaVoiceCommands.xml");
			var navigatorCommandsPath = Configuration.Instance.GetStoragePath("CRMNavigatorVoiceCommands.xml");

			WriteToFileIfDoNotExists(cortanaCommandsPath, CommandDefinitions.CRMCortanaVoiceCommands);
			WriteToFileIfDoNotExists(navigatorCommandsPath, CommandDefinitions.CRMNavigatorVoiceCommands);

			m_integrator = new CortanaIntegrator(cortanaCommandsPath);
			StorageFile navigatorCommandsFile = await StorageFile.GetFileFromPathAsync(navigatorCommandsPath);
			m_navigator = await SpeechNavigator.Create(navigatorCommandsFile);
			m_navigator.Timeouts.InitialSilenceTimeout = new TimeSpan(0, 0, 10);
		}

		//installs cortana commands, if was not yet installed
		private async Task InstallCortanaCommands()
		{
			var tmpFilePath = Configuration.Instance.GetStoragePath("InstalledCommands.xml");
			if (!File.Exists(tmpFilePath))
			{
				await m_initTask;
				var cortanaCommandsPath = Configuration.Instance.GetStoragePath("CRMCortanaVoiceCommands.xml");
				StorageFile cortanaCommandsFile = await StorageFile.GetFileFromPathAsync(cortanaCommandsPath);
				var success = await m_integrator.Install(cortanaCommandsPath);
				if (success)
					WriteToFileIfDoNotExists(tmpFilePath, "1");
			}
			SetActionsForCortana();
		}

		private void WriteToFileIfDoNotExists(string filepath, string contentOfFile)
		{
			if (!File.Exists(filepath))
			{
				using (var stream = File.Create(filepath))
				{
					byte[] content = System.Text.UTF8Encoding.UTF8.GetBytes(contentOfFile);
					stream.Write(content, 0, content.Length);
				}
			}
		}


		//set cortanas actions
		private void SetActionsForCortana()
		{
			m_integrator.SetAction("CRMCommandsSetEnUs", "showEntity", OpenEntityList);
			m_integrator.SetAction("CRMCommandsSetEnUs", "openTasks", OpenTask);
			m_integrator.SetAction("CRMCommandsSetEnUs", "createRecord", CreateRecord);
			m_integrator.SetAction("CRMCommandsSetEnUs", "createAppointment", CreateAppointment);
			m_integrator.SetAction("CRMCommandsSetEnUs", "createPhoneCall", CreatePhoneCall);
			m_integrator.SetAction("CRMCommandsSetEnUs", "createTask", CreateTask);
			m_integrator.SetAction("CRMCommandsSetEnUs", "showEntityView", OpenEntityView);
			m_integrator.SetAction("CRMCommandsSetEnUs", "findRecord", FindRecord);
			m_integrator.SetAction("CRMCommandsSetEnUs", "createRecord2", CreateRecord);
		}

		/// <summary>
		/// Gets the name of the selected home item (which is the name of the entity for EntityList homeItem).
		/// </summary>
		/// <returns>The home item name.</returns>
		public string GetHomeItemEntity()
		{
			var sel = HomeForm.Instance.SelectedItem;
			if (sel != null)
				return sel.Name;
			return null;
		}

		/// <summary>
		/// Returns the list of available views for the selected home item.
		/// You can pass an item from the list to the <see cref="SelectHomeItemView(string)"/> method.
		/// </summary>
		/// <returns>The list of view titles or null.</returns>
		public List<string> GetHomeItemViews()
		{
			var sel = HomeForm.Instance.SelectedItem;
			if (sel != null)
			{
				var entityForm = sel.Form as UI.EntityListForm;
				if (entityForm != null)
					return entityForm.AvailableViews;
			}
			return null;
		}

		/// <summary>
		/// Changes the view of the currently opened home item.
		/// </summary>
		/// <param name="viewName">The desired view title.</param>
		/// <returns>The title of the view.</returns>
		public string SelectHomeItemView(string viewName)
		{
			var sel = HomeForm.Instance.SelectedItem;
			if (sel != null)
			{
				var entityForm = sel.Form as UI.EntityListForm;
				if (entityForm != null)
				{
					entityForm.CurrentView = viewName;
					return entityForm.CurrentView;
				}
			}
			return null;
		}

		/// <summary>Shows the home item by title (human readable name) (does nothing if no such item exists or is not enabled).</summary>
		/// <param name="title">The name of the home item to open.</param>
		/// <returns>The caption of the opened home item (might contain additional information) or null if not found.</returns>
		public string ShowHomeItemByTitle(string title)
		{
			var item = HomeForm.Instance.Items.FirstOrDefault(hi => string.Compare(hi.Title, title, StringComparison.CurrentCultureIgnoreCase) == 0);
			if (item != null && item.IsEnabled)
			{
				HomeForm.Instance.ShowHomeItem(item);
				var entityForm = item.Form as UI.EntityListForm;
				if (entityForm != null && !string.IsNullOrEmpty(entityForm.CurrentView))
					return entityForm.CurrentView;
				return item.Title;
			}
			return null;
		}

		/// <summary>
		/// Gets the list of titles in the home form.
		/// </summary>
		/// <returns>the list or null if not loaded.</returns>
		public List<string> GetHomeItemTitles()
		{
			var items = HomeForm.Instance.Items;
			if (items != null)
				return items.Select(c => c.Title).ToList();
			return null;
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

		/// <summary>
		/// Handler for action that opens list of given entity
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/> or <see cref="CortanaIntegrator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/></param>
		public async void OpenEntityList(object sender, SpeechRecognitionResult result)
		{
			var entityName = result.ReconizedPhraseListsValues["entityName"];
			await ShowHomeItem(entityName);
			await m_initTask;

			//Disabled
			/*m_navigator.SetAction("CRMCommandsSetEnUs", "showView", OpenViewOnCurrentEntity);
			m_navigator.SetAction("CRMCommandsSetEnUs", "addNewRecord", AddNewRecord);
			await RecognizeAndPerformAction();
			m_navigator.DeleteAction("CRMCommandsSetEnUs", "showView", OpenViewOnCurrentEntity);
			m_navigator.DeleteAction("CRMCommandsSetEnUs", "addNewRecord", AddNewRecord);*/
		}

		/// <summary>
		/// Handler for action that opens list of given entity and view on the list
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/> or <see cref="CortanaIntegrator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/></param>
		public async void OpenEntityView(object sender, SpeechRecognitionResult result)
		{
			var entityName = result.ReconizedPhraseListsValues["entityName"];
			var viewName = result.ReconizedPhraseListsValues["viewName"];

			var title = ShowHomeItemByTitle(entityName);
			if (string.IsNullOrEmpty(title))
				await SayText(title + " not found");
			else
			{
				title = SelectHomeItemView(viewName);

				string message;
				if (!string.IsNullOrEmpty(title))
					message = "Here is " + entityName + " view of " + entityName;
				else
					message = entityName + " displayed but " + viewName + " is not found";
				await SayText(message);

				//disabled
				/*m_navigator.SetAction("CRMCommandsSetEnUs", "showView", OpenViewOnCurrentEntity);
				m_navigator.SetAction("CRMCommandsSetEnUs", "addNewRecord", AddNewRecord);
				await RecognizeAndPerformAction();
				m_navigator.DeleteAction("CRMCommandsSetEnUs", "showView", OpenViewOnCurrentEntity);
				m_navigator.DeleteAction("CRMCommandsSetEnUs", "addNewRecord", AddNewRecord);*/
			}
		}

		/// <summary>
		/// Handler for action that searches mobilecrm for given keyword
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/> or <see cref="CortanaIntegrator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/></param>
		public async void FindRecord(object sender, SpeechRecognitionResult result)
		{
			// TODO
			var recordName = result.RecognizedPhraseTopicsValues["recordName"];
			string entityName = string.Empty;
			if (result.RecognizedPhraseTopicsValues.ContainsKey("entityName"))
				entityName = result.ReconizedPhraseListsValues["entityName"];

			if (entityName == string.Empty)
			{
				// search all entities
			}
			else
			{
				// search in entity with name "entityName"
			}
		}

		/// <summary>
		/// Handler for action of acceptation. E.g. "Yes", "Affirmative", "Sure", "Yeah"
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/> or <see cref="CortanaIntegrator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/></param>
		public async void AcceptCommand(object sender, SpeechRecognitionResult result)
		{
			//TODO: save form 
			var form = MobileCrm.UI.FormManager.Instance.FindTopForm();
			if (form != null)
			{
				var command = form.SecondaryCommand;
				if (command != null && command.Name == "Save")
					command.Execute();
			}
			await SayText("OK record saved");
		}

		/// <summary>
		/// Handler for action of rejection. E.g. "No", "Nope", "Reject"
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/> or <see cref="CortanaIntegrator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/></param>
		public async void RefuseCommand(object sender, SpeechRecognitionResult result)
		{
			//TODO: do nothing or help to fill fields			
			await SayText("Sure lets fill the other fields.");
		}

		/// <summary>
		/// Handler for action that open dialog for new record.
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/></param>
		public async void AddNewRecord(object sender, SpeechRecognitionResult result)
		{
			var entityName = GetHomeItemEntity();
			if (string.IsNullOrEmpty(entityName))
				await SayText(entityName + "not found.");
			else
			{
				if (!Metadata.CanCreateEntity(entityName) || !UI.ControllerFactory.Instance.HasEditor(entityName))
				{
					await SayText("Can not create new record or entity have no editor.");
					return;
				}
				UI.FormManager.Instance.ShowNewDialog(entityName, null);
				await SayText("New record added. Lets fill some fields !");
			}
		}

		/// <summary>
		/// Handler for action that opens calendar.
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/> or <see cref="CortanaIntegrator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/></param>
		public async void OpenTask(object sender, SpeechRecognitionResult result)
		{
			// Lets show the calendar here
			var homeItem = "Calendar";
			await ShowHomeItem(homeItem);
		}

		/// <summary>
		/// Shows home Item and says text of success or error.
		/// </summary>
		/// <param name="homeItem">homeItem to open</param>
		/// <returns><see cref="Task"/></returns>
		private async Task ShowHomeItem(string homeItem)
		{
			var title = ShowHomeItemByTitle(homeItem);
			string message;
			if (!string.IsNullOrEmpty(title))
				message = "Showing " + title;
			else
				message = homeItem + " not found";
			await SayText(message);
		}

		/// <summary>
		/// Handler for action that open view on current entity. If user have no entity opened a error message will be spoken
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/> or <see cref="CortanaIntegrator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/></param>
		public async void OpenViewOnCurrentEntity(object sender, SpeechRecognitionResult result)
		{
			// Phrase: Show "Active Accounts", Open "Active Accounts" Select "Active Accounts"
			var viewName = result.ReconizedPhraseListsValues["viewName"];
			var title = SelectHomeItemView(viewName);

			string message;
			if (!string.IsNullOrEmpty(title))
				message = "Showing " + title;
			else
				message = viewName + " not found";
			await SayText(message);
		}

		/// <summary>
		/// Calls when is HomeForm loaded. Installs titles and creatable entities names  into cortana
		/// </summary>
		public async void OnHomeLoaded()
		{
			var tmpFilePath = Configuration.Instance.GetStoragePath("InstalledCommands.xml");
			if (!File.Exists(tmpFilePath))
				await m_installCortanaCommandsTask;

			var titles = GetHomeItemTitles();
			if (titles != null)
				await m_integrator.SetPhraseListAsync("CRMCommandsSetEnUs", "entityName", titles);

			var createEntities = CreatableEntites().Select(e => Localization.Get(e));
			await m_integrator.SetPhraseListAsync("CRMCommandsSetEnUs", "createName", createEntities);
		}

		/// <summary>
		/// Gets the list of entities that can be created by user.
		/// </summary>
		/// <returns>Entities</returns>
		private IEnumerable<string> CreatableEntites()
		{
			return Metadata.Entities.Values.Where(e => Metadata.CanCreateEntity(e.Name)).Select(e => e.Name);
		}

		/// <summary>
		/// Calls when is home item selected. Install viewNames of the entity into navigator and cortana
		/// </summary>
		public async void OnHomeItemSelected()
		{ 
			await m_initTask;
			var views = GetHomeItemViews();
			if (views != null && views.Count != 0)
			{
				await m_navigator.SetPhraseListAsync("CRMCommandsSetEnUs", "viewName", views);
				await m_installCortanaCommandsTask;
				await m_integrator.SetPhraseListAsync("CRMCommandsSetEnUs", "viewName", views);
			}
			
		}

		/// <summary>
		/// Performs action according to given result
		/// </summary>
		/// <param name="speechResult">Result of recognition</param>
		public void PerformAction(Windows.Media.SpeechRecognition.SpeechRecognitionResult speechResult)
		{
			m_integrator.PerformAction(speechResult);
		}

		/// <summary>
		/// Creates record in given entity and with given primary field value.
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/> of recognition.</param>
		public async void CreateRecord(object sender, SpeechRecognitionResult result)
		{
			string entityLabel = null;
			if(result.ReconizedPhraseListsValues.ContainsKey("createName"))
				entityLabel = result.ReconizedPhraseListsValues["createName"];
			var entityName = CreatableEntites().FirstOrDefault(e => string.Compare(Localization.Get(e), entityLabel, StringComparison.CurrentCultureIgnoreCase) == 0);

			await CreateRecord(entityLabel, entityName, result);
		}

		/// <summary>
		/// Creates phone call to {...}
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/> of recognition.</param>
		public async void CreatePhoneCall(object sender, SpeechRecognitionResult result)
		{
			var entityName = "phonecall";
			var entityLabel = Localization.Get(entityName);

			await CreateRecord(entityLabel, entityName, result);
		}

		/// <summary>
		/// Creates task with primary field value
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/> of recognition.</param>
		public async void CreateTask(object sender, SpeechRecognitionResult result)
		{
			var entityName = "task";
			var entityLabel = Localization.Get(entityName);

			await CreateRecord(entityLabel, entityName, result);
		}

		/// <summary>
		/// Creates appointment with primary field value
		/// </summary>
		/// <param name="sender"><see cref="SpeechNavigator"/></param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/> of recognition</param>
		public async void CreateAppointment(object sender, SpeechRecognitionResult result)
		{
			var entityName = "appointment";
			var entityLabel = Localization.Get(entityName);

			await CreateRecord(entityLabel, entityName, result);
		}

		/// <summary>
		/// Helper function for creating records.
		/// </summary>
		/// <param name="entityLabel">Display name of entity to create.</param>
		/// <param name="entityName">Real name of entity to create.</param>
		/// <param name="result"><see cref="SpeechRecognitionResult"/> of recognition.</param>
		private async Task CreateRecord(string entityLabel, string entityName, SpeechRecognitionResult result)
		{
			if (entityName == null)
			{
				entityName = GetHomeItemEntity();
				if (entityName == null)
				{
					string message = "You have no opened entity or you are trying to open wrong one. ";
					var entities = GetHomeItemTitles();
					if (entities != null)
					{
						message += "You can say for example ";
						int min = entities.Count > 4 ? 4 : entities.Count;
						for (int i = 0; i < min; i++)
						{
							if (i == (min - 2))
								message += entities[i] + " or ";
							else
								message += entities[i] + ", ";
						}
					}
					await SayText(message);
					return;
				}
				entityLabel = Localization.Get(entityName);
			}

			if (!Metadata.CanCreateEntity(entityName) || !UI.ControllerFactory.Instance.HasEditor(entityName))
			{
				await SayText("Can not create new " + entityLabel + " or entity have no editor.");
				return;
			}

				var field = string.Empty;
			if (result.RecognizedPhraseTopicsValues.ContainsKey("primaryFieldValue"))
				field = result.RecognizedPhraseTopicsValues["primaryFieldValue"];


			var form = UI.FormManager.Instance.ShowNewDialog(entityName, null);
			if (form != null && form.EntityInstance != null && !string.IsNullOrEmpty(field))
			{
				form.EntityInstance.TrySetValue(form.EntityInstance.Meta.PrimaryFieldName, field);
				await m_initTask;
				m_navigator.SetAction("CRMCommandsSetEnUs", "accepted", AcceptCommand);
				m_navigator.SetAction("CRMCommandsSetEnUs", "rejected", RefuseCommand);
				await SayText(entityLabel + " called " + field + " created. Would you like to save it ?");
				await RecognizeAndPerformAction();
				m_navigator.DeleteAction("CRMCommandsSetEnUs", "accepted", AcceptCommand);
				m_navigator.DeleteAction("CRMCommandsSetEnUs", "rejected", RefuseCommand);
			}
			else
			{
				await SayText(entityLabel + " created");
			}
		}

		//reads given text
		private async Task SayText(string text)
		{
			await SpeechNavigator.SayText(text, HomeForm.Instance.m_form);
		}

		//recognizes and performs action. Catches exceptions...
		private async Task RecognizeAndPerformAction()
		{
			try
			{
				await m_navigator.RecognizeAndPerformAction();
			}
			catch (Exception ex)
			{
				if ((uint)ex.HResult == SpeechNavigator.HResultPrivacyStatementDeclined)
				{
					//notice user to accept privacy settings
					LaunchUri(new Uri(@"https://privacy.microsoft.com/en-us/privacystatement"));
					LaunchUri(new Uri("ms-settings:privacy-microphone"));
					//Todo display user Privacy settings 
					Program.OnUnhandledException("HResultPrivacyStatementDeclined raised", false);
				}
				else if (ex.GetType() == typeof(UnauthorizedAccessException))
				{
					LaunchUri(new Uri("ms-settings:privacy-microphone"));
				}
				else
				{
					//catch another exception
					Program.OnUnhandledException(ex.Message, false);
				}
			}
		}

		//launches given uri in the background
		private async void LaunchUri(Uri uri)
		{
			await Windows.System.Launcher.LaunchUriAsync(uri);
		}
	}
}
