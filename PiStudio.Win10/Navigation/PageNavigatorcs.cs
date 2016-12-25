using PiStudio.Shared;
using PiStudio.Shared.Data;
using System;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace PiStudio.Win10.UI
{
    public class PageNavigator
    {
        private Frame m_frame;
        private Type m_page;
        private object m_args;
        public PageNavigator(Frame frame, Type page)
        {
            m_frame = frame;
            m_page = page;
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

        public async void NavigateTo(object args)
        {
            if (!AppResources.Instance.Editor.IsUnsavedChanges)
            {
                m_args = args;
                await CreateAndDisplayDialog();
            }
            else
                m_frame.Navigate(m_page, args);
        }

        private async Task CreateAndDisplayDialog()
        {
            MessageDialog dialog = new MessageDialog("Do you want to change the unsaved changes?");
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
