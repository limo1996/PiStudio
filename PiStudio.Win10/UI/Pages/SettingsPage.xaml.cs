using PiStudio.Shared.Data;
using PiStudio.Win10.Data;
using PiStudio.Win10.Navigation;
using PiStudio.Win10.UI.Controls;
using System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PiStudio.Win10.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            ApplicationTheme = new Theme();
            WinAppResources.Instance.ApplicationTheme.CopyTo(ApplicationTheme);
            this.InitializeComponent();
            WinAppResources.Instance.InitializePage();
        }

        public Theme ApplicationTheme { get; set; }

        private void Hamburger_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MainMenu.IsPaneOpen = !MainMenu.IsPaneOpen;
        }

        private void MenuItem_Click(object sender, System.EventArgs e)
        {
            var tmp = sender as MenuItem;
            if (tmp != null && !tmp.IsSelectionEnabled)
                return;
            foreach (var item in ItemsWrapper.Children)
            {
                var menuItem = item as MenuItem;
                if (menuItem != null && menuItem != sender)
                    menuItem.IsSelected = false;
            }

            NavigationParameter parameter = new NavigationParameter()
            {
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
                //save and continue

                return;
            }
            else if (tmp == SpeakItem)
            {
                //recognize and continue

                return;
            }
            PageNavigator navigator = new PageNavigator(this.Frame, WinAppResources.Instance.Editor);
            navigator.NavigateTo(pageType, parameter);
        }
    }
}
