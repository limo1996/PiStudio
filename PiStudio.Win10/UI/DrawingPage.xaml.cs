using PiStudio.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PiStudio.Win10.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DrawingPage : Page
    {
        public DrawingPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ImgPresenter.SizeChanged += (o, args) =>
            {
                DrawingCanvas.Width = args.NewSize.Width;
                DrawingCanvas.Height = args.NewSize.Height;
            };

            var storageFile = (StorageFile)AppResources.Instance.File;
            using (var stream = await storageFile.OpenAsync(FileAccessMode.Read))
            {
                BitmapImage image = new BitmapImage();
                await image.SetSourceAsync(stream);
                ImgPresenter.Source = image;
            }

        }
    }
}
