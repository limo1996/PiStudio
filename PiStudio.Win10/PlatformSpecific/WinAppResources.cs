using PiStudio.Shared;
using PiStudio.Win10.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PiStudio.Win10
{
    /// <summary>
    /// Class that has only one instance. Contains all resources that app needs during running.
    /// </summary>
    public class WinAppResources : AppResourcesBase
    {
        //dark theme
        private Theme m_darkTheme = new Theme()
        {
            PanelBackground = Color.FromArgb(210, 0, 0, 0),
            PanelItemFocused = Color.FromArgb(255, 209, 52, 56),
            PanelForeground = Colors.White,
            Background = Colors.Black,
            Foreground = Colors.White,
            Borders = Color.FromArgb(255, 31, 31, 31),
            ClickableForeground = Color.FromArgb(255, 122, 122, 122),
            UpperPanelBackground = Color.FromArgb(255, 31, 31, 31)
        };

        //light theme
        private Theme m_lightTheme = new Theme()
        {
            Foreground = Colors.Black,
            Background = Colors.White,
            PanelForeground = Colors.Black,
            PanelBackground = Color.FromArgb(220, 173, 173, 180),
            PanelItemFocused = Color.FromArgb(255, 209, 52, 56),
            Borders = Color.FromArgb(255, 31, 31, 31),
            ClickableForeground = Color.FromArgb(255, 122, 122, 122),
            UpperPanelBackground = Color.FromArgb(255, 242, 242, 242)
        };

        //private constructor. Important in singleton pattern !
        private WinAppResources() : base()
        {
            ApplicationTheme = m_lightTheme;

            RegisterForSharing();
            MinimumPageSize = new Size(550, 700);
            FinalStorage = null;
        }

        /// <summary>
        /// Current application theme.
        /// </summary>
        public Theme ApplicationTheme { get; set; }

        /// <summary>
        /// Minimum allowed page size.
        /// </summary>
        public Size MinimumPageSize { get; private set; }

        /// <summary>
        /// Location where is and will be final image stored.
        /// </summary>
        public StorageFile FinalStorage { get; set; }

        private static WinAppResources m_instance;

        /// <summary>
        /// Only instance of <see cref="WinAppResources"/> class.
        /// </summary>
        public static WinAppResources Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new WinAppResources();
                return m_instance;
            }
        }
        
        /// <summary>
        /// Gets image from temporary storage.
        /// </summary>
        /// <returns>Visual image object.</returns>
        public async Task<WriteableBitmap> GetWorkingImage()
        {
            var file = await FileServer.GetTempFileAsync();
            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                var bitmap = new WriteableBitmap(1, 1);
                await bitmap.SetSourceAsync(stream);
                return bitmap;
            }
        }

        /// <summary>
        /// Initializes and returns <see cref="ImageEditor"/> from temporary storage.
        /// </summary>
        /// <returns>Initialized <see cref="ImageEditor"/> object.</returns>
        public async Task<ImageEditor> GetImageEditorAsync()
        {
            ImageEditor editor;
            var file = await FileServer.GetTempFileAsync();
            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                var decoder = await WinBitmapDecoder.CreateAsync(stream.AsStream());
                editor = new ImageEditor(decoder, file.Path);
            }
            
            return editor;
        }
        
        /// <summary>
        /// Sets image stretch in content area. 
        /// </summary>
        /// <param name="img">Image that's stretch will be set.</param>
        /// <remarks>
        /// Logic of stretch is as follows:
        /// If image is bigger than available space, then stretch is set to uniform.
        /// If image is smaller than available space, then stretch is set to none.
        /// </remarks>
        public void SetImageStretch(Image img)
        {
            int width = (int)Window.Current.Bounds.Width - 90,  height = (int)Window.Current.Bounds.Height - 90;
            var bmp = img.Source as WriteableBitmap;
            if (bmp == null) return;
            if (bmp.PixelHeight < height && bmp.PixelWidth < width)
                img.Stretch = Stretch.None;
            else
                img.Stretch = Stretch.Uniform;
        }

        /// <summary>
        /// Sets dark or light theme.
        /// </summary>
        /// <param name="isDarkTheme">Whether to set dark theme. If not then light theme is set.</param>
        public void SetTheme(bool isDarkTheme)
        {
            if (isDarkTheme)
                ApplicationTheme = m_darkTheme;
            else
                ApplicationTheme = m_lightTheme;
            AppSettings.Instance.IsDarkTheme = isDarkTheme;
        }

        /// <summary>
        /// Initializes current page. Should be called in constructor of every page.
        /// </summary>
        public void InitializePage()
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(Instance.MinimumPageSize);
#if !MOBILE
            // PC customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                if (titleBar != null)
                {
                    titleBar.ButtonBackgroundColor = Instance.ApplicationTheme.PanelItemFocused;
                    titleBar.ButtonForegroundColor = Instance.ApplicationTheme.PanelForeground;
                    titleBar.BackgroundColor = Instance.ApplicationTheme.PanelItemFocused;
                    titleBar.ForegroundColor = Instance.ApplicationTheme.PanelForeground;
                }
            }
#endif
#if MOBILE
            //Mobile customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {

                var statusBar = StatusBar.GetForCurrentView();
                if (statusBar != null)
                {
                    statusBar.BackgroundOpacity = 0.7;
                    statusBar.BackgroundColor = Instance.ApplicationTheme.PanelItemFocused;
                    statusBar.ForegroundColor = Instance.ApplicationTheme.PanelForeground;
                }
            }
#endif
        }

        private static uint ColorToUint(Color c)
        {
            return (uint)((c.A << 24) | (c.R << 16) | (c.G << 8) | (c.B << 0));
        }

        private static Color UintToColor(uint c)
        {
            var a = (byte)(c >> 24);
            var r = (byte)(c >> 16);
            var g = (byte)(c >> 8);
            var b = (byte)(c >> 0);
            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// Copies application state saved in instance of this class into serializable and cross-platform <see cref="AppSettings"/>
        /// </summary>
        /// <param name="settings">Single instance of <see cref="AppSettings"/>.</param>
        public override void CopyTo(AppSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException();

            settings.AppLanguage = this.ApplicationLanguage.Language;
            settings.Background = ColorToUint(this.ApplicationTheme.Background);
            settings.Borders = ColorToUint(this.ApplicationTheme.Borders);
            settings.ClickableForeground = ColorToUint(this.ApplicationTheme.ClickableForeground);
            settings.Foreground = ColorToUint(this.ApplicationTheme.Foreground);
            settings.PanelBackground = ColorToUint(this.ApplicationTheme.PanelBackground);
            settings.PanelForeground = ColorToUint(this.ApplicationTheme.PanelForeground);
            settings.PanelItemFocused = ColorToUint(this.ApplicationTheme.PanelItemFocused);
            settings.UpperPanelBackground = ColorToUint(this.ApplicationTheme.UpperPanelBackground);
        }

        /// <summary>
        /// Loads all necessary properties from <see cref="AppSettings"/> instance.
        /// </summary>
        /// <param name="settings"></param>
        public override void LoadFrom(AppSettings settings)
        {
            this.SetLanguage(settings.AppLanguage);
            if (settings.IsPredefinedTheme)
                SetTheme(settings.IsDarkTheme);
            else
            {
                this.ApplicationTheme.Background = UintToColor(settings.Background);
                this.ApplicationTheme.Borders = UintToColor(settings.Borders);
                this.ApplicationTheme.ClickableForeground = UintToColor(settings.ClickableForeground);
                this.ApplicationTheme.Foreground = UintToColor(settings.Foreground);
                this.ApplicationTheme.PanelBackground = UintToColor(settings.PanelBackground);
                this.ApplicationTheme.PanelForeground = UintToColor(settings.PanelForeground);
                this.ApplicationTheme.PanelItemFocused = UintToColor(settings.PanelItemFocused);
                this.ApplicationTheme.UpperPanelBackground = UintToColor(settings.UpperPanelBackground);
            }
        }

        private void RegisterForSharing()
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.ShareImageHandler);
        }

        private async void ShareImageHandler(DataTransferManager sender,  DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;
            request.Data.Properties.Title = WinAppResources.Instance.ApplicationLanguage.ShareHeader;
            request.Data.Properties.Description = WinAppResources.Instance.ApplicationLanguage.ShareDescription;

            // Because we are making async calls in the DataRequested event handler,
            // we need to get the deferral first.
            DataRequestDeferral deferral = request.GetDeferral();

            // Make sure we always call Complete on the deferral.
            try
            {
                StorageFile thumbnailFile = await FileServer.GetLogoAsync();
                request.Data.Properties.Thumbnail = RandomAccessStreamReference.CreateFromFile(thumbnailFile);
                RandomAccessStreamReference.CreateFromFile(thumbnailFile);
                StorageFile imageFile = await FileServer.GetTempFileAsync();
                request.Data.SetBitmap(RandomAccessStreamReference.CreateFromFile(imageFile));
            }
            finally
            {
                deferral.Complete();
            }
        }

        /// <summary>
        /// Returns full path of given file name.
        /// </summary>
        public override string GetStoragePath(string name)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, name);
        }
    }
}
