using ImageProcessing.Back_End;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ImageProcessing.Front_End
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

            ImageEditor editor = AppResources.Instance.Editor;

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
                ImageContent.Source = filterItem.Source;
            };
        }
    }
}
