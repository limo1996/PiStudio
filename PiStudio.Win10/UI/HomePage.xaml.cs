using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using PiStudio.Shared;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PiStudio.Win10.UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            PRing.IsActive = true;

            ImageEditor editor = (ImageEditor)AppResources.Instance.Editor;
            var image = await editor.ApplyFilterAsync(AppResources.Instance.Filters.First((i) => i.Name == "Sharpen"));

            PRing.IsActive = false;
            ImageContent.Source = image;
        }
    }
}
