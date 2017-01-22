using PiStudio.Shared;
using PiStudio.Shared.Data;
using PiStudio.Win10.UI.Pages;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace PiStudio.Win10.Navigation
{
    public class PageNavigator : IPageNavigator
    {
        private Frame m_frame;
        private Type m_page;
        private object m_args;
        private ISaveable m_editor;
        public PageNavigator(Frame frame, ISaveable editor)
        {
            m_frame = frame;
            m_editor = editor;
        }

        public async Task LoadNewImage()
        {
            if (m_editor.IsUnsavedChange)
            {
                if(!await CreateAndDisplayChangesDialog())
                    return;
            }
            FileOpenPicker picker = new FileOpenPicker();
            picker.CommitButtonText = "Select";
            foreach (var item in AppSettings.Instance.SupportedImageTypes)
                picker.FileTypeFilter.Add(item);
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            var file = await picker.PickSingleFileAsync();
            if (file == null)
                return;
            var newFile = await file.CopyAsync(ApplicationData.Current.LocalFolder, WinAppResources.Instance.TmpImageName, NameCollisionOption.ReplaceExisting);
            WinAppResources.Instance.LoadedFile = file.Path;
        }
        public async Task GetStartedButtonClick()
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.CommitButtonText = "Select";
            foreach (var item in AppSettings.Instance.SupportedImageTypes)
                picker.FileTypeFilter.Add(item);
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            var file = await picker.PickSingleFileAsync();
            if (file == null)
                return;
            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                var decoder = await WinBitmapDecoder.CreateAsync(stream.AsStream());
                m_editor = new ImageEditor(decoder, file.Path);
            }
            
            await Saver.SaveTemp(m_editor);
            WinAppResources.Instance.LoadedFile = file.Path;

            m_frame.Navigate(typeof(HomePage));
        }

        public async Task<bool> NavigateTo(Type pageType, NavigationParameter args)
        {
            m_page = pageType;
            if (m_editor != null && m_editor.IsUnsavedChange)
            {
                m_args = args;
                return await CreateAndDisplayChangesDialog();
            }
            else
            {
                m_frame.Navigate(m_page, args);
                return true;
            }
        }

        private async Task<bool> CreateAndDisplayChangesDialog()
        {
            MessageDialog dialog = new MessageDialog("Do you want to save the unsaved changes?");
            dialog.Title = "PiStudio";
            dialog.Options = MessageDialogOptions.AcceptUserInputAfterDelay;
            var save = new UICommand("Save", new UICommandInvokedHandler(SaveAndContinue), 0);
            var dismiss = new UICommand("Dismiss", new UICommandInvokedHandler(DismissAndContinue), 1);
            var cancel = new UICommand("Cancel", null, 2); 

            dialog.Commands.Add(save);
            dialog.Commands.Add(dismiss);
            dialog.Commands.Add(cancel);

            dialog.DefaultCommandIndex = 2;
            await dialog.ShowAsync();
            return m_result;
        }

        private bool m_result = false;

        private async void SaveAndContinue(IUICommand command)
        {
            m_editor.SaveChanges();
            await Saver.SaveTemp(m_editor);
            m_result = true;
            if(m_frame != null)
                m_frame.Navigate(m_page, m_args);
        }

        private void DismissAndContinue(IUICommand command)
        {
            m_editor.Dismiss();
            if(m_frame != null)
                m_frame.Navigate(m_page, m_args);
            m_result = true;
        }

        private async Task<WriteableBitmap> CreateWriteableBitmapFromFileAsync(StorageFile file)
        {
            WriteableBitmap bitmap;
            using (var stream = await file.OpenReadAsync())
            {
                bitmap = new WriteableBitmap(1,1);
                await bitmap.SetSourceAsync(stream);
            }
            return bitmap;
        }
    }
}
