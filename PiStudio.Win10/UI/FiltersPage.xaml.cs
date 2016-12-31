using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using PiStudio.Shared;
using PiStudio.Shared.Data;
using Windows.UI.Xaml.Media.Imaging;

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
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            PRing.IsActive = true;

            ImageEditor editor = (ImageEditor)AppResources.Instance.Editor;

            var filter = AppResources.Instance.Filters.FirstOrDefault(i => i.Name == "None");
            ImageContent.Source = await editor.ApplyFilterAsync(filter); ;

            await LoadItems(editor);
            PRing.IsActive = false;
        }

        private async Task LoadItems(ImageEditor editor)
        {
            ObservableCollection<FilterItem> items = new ObservableCollection<FilterItem>();            

            FilterGridView.ItemsSource = items;

            foreach(var filter in AppResources.Instance.Filters)
            {
                var item = new FilterItem();
                item.Text = filter.Name;
                item.Source = await editor.ApplyFilterAsync(filter);
                items.Add(item);
            }

            FilterGridView.ItemClick += (o, e) =>
            {
                var filterItem = (FilterItem)e.ClickedItem;
                ImageContent.Source = (WriteableBitmap)filterItem.Source;
            };
        }
    }
}
