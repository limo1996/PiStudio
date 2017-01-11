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
            Settings = AppSettings.Instance;
            ApplicationTheme = new Theme();
            LanguagePack = new LanguagePack();
            WinAppResources.Instance.ApplicationTheme.CopyTo(ApplicationTheme);
            WinAppResources.Instance.ApplicationLanguage.CopyTo(LanguagePack);
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
            FiltersBox.ItemsSource = WinAppResources.Instance.Filters;

            if (LanguagesBox.SelectedIndex != -1)
                return;

            int j = 0;
            foreach(var i in LanguagesBox.Items)
            {
                var item = (ComboBoxItem)i;
                if (item.Content.ToString() == WinAppResources.Instance.ApplicationLanguage.Language.ToString())
                    LanguagesBox.SelectedIndex = j;
                j++;
            }
        }

        public Theme ApplicationTheme { get; set; }
        public AppSettings Settings { get; set; }
        public LanguagePack LanguagePack { get; set; }

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

            foreach (var column in MainGrid.ColumnDefinitions)
                column.Width = new Windows.UI.Xaml.GridLength(0);

            if (sender == General)
                MainGrid.ColumnDefinitions[0].Width = new Windows.UI.Xaml.GridLength(1, Windows.UI.Xaml.GridUnitType.Star);
            else if (sender == Theme)
                MainGrid.ColumnDefinitions[1].Width = new Windows.UI.Xaml.GridLength(1, Windows.UI.Xaml.GridUnitType.Star);
            else
                MainGrid.ColumnDefinitions[2].Width = new Windows.UI.Xaml.GridLength(1, Windows.UI.Xaml.GridUnitType.Star);
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

        private void General_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {

        }

        private void EnableDarkSwitch_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            WinAppResources.Instance.SetTheme(EnableDarkSwitch.IsOn);
            WinAppResources.Instance.ApplicationTheme.CopyTo(ApplicationTheme);
            ItemsWrapper.Background = new SolidColorBrush(ApplicationTheme.PanelBackground);
            if(AppSettings.Instance.IsDarkTheme != EnableDarkSwitch.IsOn)
                SettingsSection_Clicked(Theme, null);
            AppSettings.Instance.IsDarkTheme = EnableDarkSwitch.IsOn;
           // Bar.Foreground = new SolidColorBrush(WinAppResources.Instance.ApplicationTheme.Foreground);
        }

        private void LanguagesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PiStudio.Shared.Data.Language lang;
            switch(LanguagesBox.SelectedIndex)
            {
                case 0: lang = Shared.Data.Language.English;
                    break;
                case 1: lang = Shared.Data.Language.Slovensky;
                    break;
                default: lang = Shared.Data.Language.German;
                    break;
            }
            if (lang == WinAppResources.Instance.ApplicationLanguage.Language)
                return;
            WinAppResources.Instance.SetLanguage(lang).CopyTo(LanguagePack);
            Bar.PlaceholderText = LanguagePack.PlaceholderSearch;
            Bar.Text = LanguagePack.Settings;
            HomeItem.Text = LanguagePack.MenuItem1;
            FilterItem.Text = LanguagePack.MenuItem2;
            BrightnessItem.Text = LanguagePack.MenuItem3;
            DrawItem.Text = LanguagePack.MenuItem4;
            SaveItem.Text = LanguagePack.MenuItem5;
            SpeakItem.Text = LanguagePack.MenuItem6;
            SettingsItem.Text = LanguagePack.Settings;
        }
    }
}
