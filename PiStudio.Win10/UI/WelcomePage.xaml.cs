using System;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
using PiStudio.Shared.Data;
using PiStudio.Shared;
using PiStudio.Win10.Data;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PiStudio.Win10.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            this.InitializeComponent();
            var path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            ApplicationTheme = new Theme() { PanelBackground = Colors.Red, PanelForeground = Colors.Black };
        }

        public Theme ApplicationTheme { get; set; }

        private async void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.CommitButtonText = "Select";
            foreach (var item in AppSettings.Instance.SupportedImageTypes)
                picker.FileTypeFilter.Add(item);
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            var file = await picker.PickSingleFileAsync();
            await AppResources.Instance.InitializeImageEditor(file);
            AppResources.Instance.File = file;
            this.Frame.Navigate(typeof(DrawingPage));
        }
    }
}
