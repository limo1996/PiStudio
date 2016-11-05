using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ImageProcessing.Front_End
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
        }

        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            this.MainMenu.IsPaneOpen = !MainMenu.IsPaneOpen;
        }

        private async void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            AppSettings.Instance.SupportedImageTypes.Add(".jpg");
            AppSettings.Instance.SupportedImageTypes.Add(".png");
            FileOpenPicker picker = new FileOpenPicker();
            picker.CommitButtonText = "Select";
            foreach (var item in AppSettings.Instance.SupportedImageTypes)
                picker.FileTypeFilter.Add(item);
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            var file = await picker.PickSingleFileAsync();
            AppResources.Instance.InitializeImageEditor(file);
            this.Frame.Navigate(typeof(FiltersPage));
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FiltersPage));
        }
    }
}
