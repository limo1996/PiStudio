using PiStudio.Shared;
using PiStudio.Win10.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media.Imaging;

namespace PiStudio.Win10
{
    public class WinAppResources : AppResourcesBase
    {
        private Theme m_darkTheme = new Theme()
        {
            PanelBackground = Color.FromArgb(200, 0, 0, 0),
            PanelItemFocused = Color.FromArgb(255, 209, 52, 56),
            PanelForeground = Colors.White,
            Background = Colors.Black,
            Foreground = Colors.White,
            Borders = Color.FromArgb(255, 31, 31, 31),
            ClickableForeground = Color.FromArgb(255, 122, 122, 122),
            UpperPanelBackground = Color.FromArgb(255, 31, 31, 31)
        };

        private Theme m_lightTheme = new Theme()
        {
            Foreground = Colors.Black,
            Background = Colors.White,
            PanelForeground = Colors.Black,
            PanelBackground = Color.FromArgb(255, 173, 173, 180),
            PanelItemFocused = Color.FromArgb(255, 209, 52, 56),
            Borders = Color.FromArgb(255, 31, 31, 31),
            ClickableForeground = Color.FromArgb(255, 122, 122, 122),
            UpperPanelBackground = Color.FromArgb(255, 242, 242, 242)
        };

        private WinAppResources() : base()
        {
            ApplicationTheme = m_lightTheme;

            MinimumPageSize = new Size(550, 700);
        }

        private static WinAppResources m_instance;
        public static WinAppResources Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new WinAppResources();
                return m_instance;
            }
        }
        
        public async Task<WriteableBitmap> GetWorkingImage()
        {
            var file = await Saver.GetTempFile();
            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                return await BitmapFactory.New(1, 1).FromStream(stream);
            }
        }

        public Theme ApplicationTheme { get; set; }
        public Size MinimumPageSize { get; private set; }

        public void SetTheme(bool isDarkTheme)
        {
            if (isDarkTheme)
                ApplicationTheme = m_darkTheme;
            else
                ApplicationTheme = m_lightTheme;
        }

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
    }
}
