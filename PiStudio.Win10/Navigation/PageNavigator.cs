using PiStudio.Shared;
using PiStudio.Shared.Data;
using PiStudio.Win10.UI;
using System;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace PiStudio.Win10.Navigation
{
    public class PageNavigator
    {
        private Frame m_frame;
        private Type m_page;
        private object m_args;
        public PageNavigator(Frame frame)
        {
            m_frame = frame;
        }

        public async void GetStartedButtonClick()
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.CommitButtonText = "Select";
            foreach (var item in AppSettings.Instance.SupportedImageTypes)
                picker.FileTypeFilter.Add(item);
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            var file = await picker.PickSingleFileAsync();
            await AppResources.Instance.InitializeImageEditor(file);
            m_frame.Navigate(typeof(BrightnessPage));
        }

        public async void NavigateTo(Type pageType, NavigationParameter args)
        {
            m_page = pageType;
            if (!AppResources.Instance.Editor.IsUnsavedChanges)
            {
                m_args = args;
                await CreateAndDisplayChangesDialog();
            }
            else
                m_frame.Navigate(m_page, args);
        }

        private async Task CreateAndDisplayChangesDialog()
        {
            MessageDialog dialog = new MessageDialog("Do you want to save the unsaved changes?");
            dialog.Title = "PiStudio";
            dialog.Options = MessageDialogOptions.AcceptUserInputAfterDelay;
            var save = new UICommand("Save", new UICommandInvokedHandler(SaveAndContinue), 0);
            var dismiss = new UICommand("Dismiss", new UICommandInvokedHandler(DismissAndContinue), 1);
            var cancel = new UICommand("Cancel", null, 2);
            dialog.DefaultCommandIndex = 0;

            await dialog.ShowAsync();
        }

        private void SaveAndContinue(IUICommand command)
        {
            AppResources.Instance.Editor.SaveChanges();
            m_frame.Navigate(m_page, m_args);
        }

        private void DismissAndContinue(IUICommand command)
        {
            m_frame.Navigate(m_page, m_args);
        }
    }
}
