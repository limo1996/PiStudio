using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using PiStudio.Shared.Data;
using Windows.UI.Xaml.Media.Imaging;
using PiStudio.Win10.Data;
using PiStudio.Win10.UI.Controls;
using PiStudio.Win10.Navigation;
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PiStudio.Win10.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FiltersPage : Page
    {
        public FiltersPage()
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

            m_editor = await WinAppResources.Instance.GetImageEditorAsync();
            ImageContent.Source = await WinAppResources.Instance.GetWorkingImage();

            await LoadItems(m_editor);

            PRing.IsActive = false;
        }

        private async Task LoadItems(ImageEditor editor)
        {
            ObservableCollection<FilterItem> items = new ObservableCollection<FilterItem>();

            FilterGridView.ItemsSource = items;
            foreach (var filter in WinAppResources.Instance.Filters)
            {
                if (filter.IsEnabled == true)
                {
                    var item = new FilterItem();
                    item.Text = filter.Filter.Name;
                    item.Source = await editor.ApplyFilterAsync(filter.Filter);
                    items.Add(item);
                }
            }

            FilterGridView.ItemClick += (o, ee) =>
            {
                var filterItem = (FilterItem)ee.ClickedItem;
                ImageContent.Source = (WriteableBitmap)filterItem.Source;
            };
        }

        private void Hamburger_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MainMenu.IsPaneOpen = !MainMenu.IsPaneOpen;
        }

        private async void MenuItem_Click(object sender, System.EventArgs e)
        {
            var tmp = sender as MenuItem;
            
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
            else if (tmp == SaveItem)
            {
                //save and continue
                Progress.IsActive = true;
                m_editor.SaveChanges();
                await Saver.SaveTemp(m_editor);
                Progress.IsActive = false;
                return;
            }
            else if(tmp == SpeakItem)
            {
                //recognize and continue

                return;
            }
            PageNavigator navigator = new PageNavigator(this.Frame, m_editor);
            var result = await navigator.NavigateTo(pageType, parameter);
            if (tmp != null && !result)
                return;
            foreach (var item in ItemsWrapper.Children)
            {
                var menuItem = item as MenuItem;
                if (menuItem == null)
                    continue;
                if(menuItem != sender)
                    menuItem.IsSelected = false;
                else
                    menuItem.IsSelected = true;
            }
        }

        private async void FilterGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (FilterItem)e.AddedItems[0];
            var img = (WriteableBitmap)item.Source;
            using (Stream pixelStream = img.PixelBuffer.AsStream())
            {
                byte[] pixels = new byte[pixelStream.Length];
                await pixelStream.ReadAsync(pixels, 0, pixels.Length);
                m_editor.SetSource(pixels);
            }
        }
    }
}
