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
        private WinAppResources() : base()
        {
            ApplicationTheme = new Theme()
            {
                PanelBackground = Color.FromArgb(200, 0, 0, 0),
                PanelItemFocused = Colors.Red,
                PanelForeground = Colors.White,
                Background = Colors.Black,
                Foreground = Colors.Red,
                Borders = Colors.Black
            };

            MinimumPageSize = new Size(300, 400);
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

        public StorageFile LoadedFile { get; set; }
        public WriteableBitmap WorkingImage { get; set; }
        public Theme ApplicationTheme { get; set; }
        public Size MinimumPageSize { get; private set; }
        public void InitializePage()
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(Instance.MinimumPageSize);
            ApplicationView.GetForCurrentView().Title = "PiStudio";
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
