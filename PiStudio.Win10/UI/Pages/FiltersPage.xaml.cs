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
using System.Threading;

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

            var param = e.Parameter as NavigationParameter;
            if (param != null && param.Extra != null)
                m_editor = (ImageEditor)param.Extra;
            else
                m_editor = await WinAppResources.Instance.GetImageEditorAsync();

            Navigator.Instance.Editor = m_editor;
            ImageContent.Source = await WinAppResources.Instance.GetWorkingImage();

            LoadItems(m_editor);
            WinAppResources.Instance.SetImageStretch(ImageContent);

            SavePop.SaveableObject = m_editor;
            SavePop.Started += (o1, args1) => Progress.IsActive = true;
            SavePop.Completed += (o2, args2) => Progress.IsActive = false;

            PRing.IsActive = false;
            FiltersLoading.IsActive = true;
        }

        private void LoadItems(ImageEditor editor)
        {
            ObservableCollection<FilterItem> items = new ObservableCollection<FilterItem>();

            FilterGridView.ItemsSource = items;
            int i = 0;
            var selectedCount = WinAppResources.Instance.Filters.Where((ee) => ee.IsEnabled == true).Count();
            foreach (var filter in WinAppResources.Instance.Filters)
            {
                if (filter.IsEnabled == true)
                {
                    var last = selectedCount == i + 1;
                    AddItem(items, filter, editor, last);
                    i++;
                }
            }

            FilterGridView.ItemClick += (o, ee) =>
            {
                var filterItem = (FilterItem)ee.ClickedItem;
                ImageContent.Source = (WriteableBitmap)filterItem.Source;
            };
        }

        private SemaphoreSlim m_semaphore = new SemaphoreSlim(1, 1);

        private async void AddItem(ObservableCollection<FilterItem> items, FilterSettings filter, ImageEditor editor, bool last)
        {
            var dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
            await Task.Run(async () =>
            {
                var item = new FilterItem();
                item.Text = filter.Filter.Name;
                var result = ImageEditor.ApplyFilterThreadSafeAsync(editor, filter.Filter);
                await dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    async () =>
                    {
                        item.Source = await ImageEditor.CreateBitmapFromByteArrayAsync(result, (int)editor.PixelWidth, (int)editor.PixelHeight);
                        await m_semaphore.WaitAsync();
                        items.Add(item);
                        m_semaphore.Release();
                        System.Diagnostics.Debug.WriteLine(Task.CurrentId);
                        if (last)
                            FiltersLoading.IsActive = false;
                    });
            });
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
                Extra = m_editor,
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
                SavePop.IsOpen = !SavePop.IsOpen;

                return;
            }
            else if(tmp == SpeakItem)
            {
                //recognize and continue
                await Voice.VoiceRecognizer.Instance.RecognizeAndPerformActionWithUIAsync(Content, row: 1, rowSpan: 2);
                return;
            }
            else if (tmp == ShareItem)
            {
                Navigator.Instance.Share();
                return;
            }
            await Navigator.Instance.NavigateTo(pageType, parameter);
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

        private void Grid_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            WinAppResources.Instance.SetImageStretch(ImageContent);
        }
    }
}
