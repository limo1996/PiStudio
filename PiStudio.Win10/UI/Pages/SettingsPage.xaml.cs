using PiStudio.Shared.Data;
using PiStudio.Win10.Data;
using PiStudio.Win10.Navigation;
using PiStudio.Win10.UI.Controls;
using System;
using System.Collections.Generic;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

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

            List<SearchOption> options = new List<SearchOption>();
            options.Add(new SearchOption()
            {
                ApplicationTheme = ApplicationTheme,
                Symbol = Symbol.Microphone,
                Text = "Text1"
            });

            options.Add(new SearchOption()
            {
                ApplicationTheme = ApplicationTheme,
                Symbol = Symbol.Microphone,
                Text = "Text2"
            });

            options.Add(new SearchOption()
            {
                ApplicationTheme = ApplicationTheme,
                Symbol = Symbol.Microphone,
                Text = "Text3"
            });

            options.Add(new SearchOption()
            {
                ApplicationTheme = ApplicationTheme,
                Symbol = Symbol.Microphone,
                Text = "Text4"
            });

            options.Add(new SearchOption()
            {
                ApplicationTheme = ApplicationTheme,
                Symbol = Symbol.Microphone,
                Text = "Text5"
            });
            Bar.ItemsSource = options;
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

        private void SettingsSection_Clicked(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            General.Foreground = new SolidColorBrush(ApplicationTheme.ClickableForeground);
            General.FontWeight = FontWeights.Normal;

            About.Foreground = new SolidColorBrush(ApplicationTheme.ClickableForeground);
            About.FontWeight = FontWeights.Normal;

            Theme.Foreground = new SolidColorBrush(ApplicationTheme.ClickableForeground);
            Theme.FontWeight = FontWeights.Normal;

            ((TextBlock)sender).Foreground = new SolidColorBrush(ApplicationTheme.Foreground);
            ((TextBlock)sender).FontWeight = FontWeights.SemiBold;
        }

        private void TextBlock_Entered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            ((TextBlock)sender).Foreground = new SolidColorBrush(ApplicationTheme.Foreground);
        }

        private void TextBlock_Exited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if(((TextBlock)sender).FontWeight.Weight != FontWeights.SemiBold.Weight)
                ((TextBlock)sender).Foreground = new SolidColorBrush(ApplicationTheme.ClickableForeground);
        }
    }
}
