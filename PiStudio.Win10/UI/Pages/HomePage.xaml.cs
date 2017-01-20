using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using PiStudio.Win10.Data;
using PiStudio.Win10.UI.Controls;
using PiStudio.Shared.Data;
using PiStudio.Win10.Navigation;
using System;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using PiStudio.Shared;

namespace PiStudio.Win10.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            ApplicationTheme = new Theme();
            LanguagePack = new LanguagePack();
            WinAppResources.Instance.ApplicationTheme.CopyTo(ApplicationTheme);
            WinAppResources.Instance.ApplicationLanguage.CopyTo(LanguagePack);
            this.InitializeComponent();
            WinAppResources.Instance.InitializePage();
        }

        private ImageEditor m_editor;

        public Theme ApplicationTheme { get; set; }
        public LanguagePack LanguagePack { get; set; }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            PRing.IsActive = true;

            var image = await WinAppResources.Instance.GetWorkingImage();

            var file = await Saver.GetTempFile();
            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                var decoder = await WinBitmapDecoder.CreateAsync(stream.AsStream());
                m_editor = new ImageEditor(decoder, file.Path);
            }

            PRing.IsActive = false;
            ImageContent.Source = image;
        }

        private void Hamburger_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MainMenu.IsPaneOpen = !MainMenu.IsPaneOpen;
        }

        private async void MenuItem_Click(object sender, System.EventArgs e)
        {
            var tmp = sender as MenuItem;
            if (tmp != null && !tmp.IsSelectionEnabled)
                return;
            foreach (var item in ItemsWrapper.Children)
            {
                var menuItem = item as MenuItem;
                if (menuItem != null && menuItem != sender)
                    menuItem.IsSelected = false;
            }

            NavigationParameter parameter = new NavigationParameter()
            {
                PrevPage = EnumPage.HomePage,
                Source = NavigationSource.Click
            };

            Type pageType = typeof(SettingsPage);
            if (tmp == HomeItem)
                pageType = typeof(HomePage);
            else if (tmp == FilterItem)
                pageType = typeof(FiltersPage);
            else if (tmp == BrightnessItem)
                pageType = typeof(BrightnessPage);
            else if (tmp == DrawItem)
                pageType = typeof(DrawingPage);
            else if(tmp == SaveItem)
            {
                //save and continue

                return;
            }
            else if(tmp == SpeakItem)
            {
                //recognize and continue

                return;
            }
            PageNavigator navigator = new PageNavigator(this.Frame, m_editor);
            await navigator.NavigateTo(pageType, parameter);
        }

        private async void RotateBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var res = Shared.ImageToolkit.Rotate(new byte[] { 1,1, 2,2, 3,3, 4,4, 5,5, 6,6}, 2, 3, 2);
            ImageContent.Source = await m_editor.RotateAsync();
        }

        private async void AddBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            PRing.IsActive = true;
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
            ImageContent.Source = await WinAppResources.Instance.GetWorkingImage();

            PRing.IsActive = false;
        }
    }
}
