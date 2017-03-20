using PiStudio.Shared.Data;
using PiStudio.Shared;
using PiStudio.Win10.Data;
using PiStudio.Win10.Navigation;
using PiStudio.Win10.UI.Controls;
using System;
using System.Collections.Generic;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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

        private ImageEditor m_editor;
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            LoadVoiceCommands();

            var param = e.Parameter as NavigationParameter;
            if (param != null && param.Extra != null)
                m_editor = (ImageEditor)param.Extra;
            else
                m_editor = await WinAppResources.Instance.GetImageEditorAsync();
            Navigator.Instance.Editor = m_editor;
            SavePop.SaveableObject = m_editor;
            SavePop.Started += (o1, args1) => Progress.IsActive = true;
            SavePop.Completed += (o2, args2) => Progress.IsActive = false;
        }

        public Theme ApplicationTheme { get; set; }
        public AppSettings Settings { get; set; }
        public LanguagePack LanguagePack { get; set; }

        private void Hamburger_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MainMenu.IsPaneOpen = !MainMenu.IsPaneOpen;
        }

        public void EnableAutoSave(bool enable)
        {
            AutoSaveSwitch.IsOn = enable;
        }

        private async void MenuItem_Click(object sender, System.EventArgs e)
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
                Extra = m_editor,
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
                SavePop.IsOpen = !SavePop.IsOpen;

                return;
            }
            else if (tmp == SpeakItem)
            {
                //recognize and continue
                await Voice.VoiceRecognizer.Instance.RecognizeAndPerformActionWithUIAsync(Content, row: 2);
                return;
            }
            else if (tmp == ShareItem)
            {
                Navigator.Instance.Share();
                return;
            }
            await Navigator.Instance.NavigateTo(pageType, parameter);
        }

        private void SettingsSection_Clicked(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var textBlock = (TextBlock)sender;
            if (textBlock.FontWeight.Weight == FontWeights.SemiBold.Weight)
                return;

            General.Foreground = new SolidColorBrush(ApplicationTheme.ClickableForeground);
            General.FontWeight = FontWeights.Normal;

            About.Foreground = new SolidColorBrush(ApplicationTheme.ClickableForeground);
            About.FontWeight = FontWeights.Normal;

            Theme.Foreground = new SolidColorBrush(ApplicationTheme.ClickableForeground);
            Theme.FontWeight = FontWeights.Normal;

            Commands.Foreground = new SolidColorBrush(ApplicationTheme.ClickableForeground);
            Commands.FontWeight = FontWeights.Normal;

            textBlock.Foreground = new SolidColorBrush(ApplicationTheme.Foreground);
            textBlock.FontWeight = FontWeights.SemiBold;

            foreach (var column in MainGrid.ColumnDefinitions)
                column.Width = new Windows.UI.Xaml.GridLength(0);

            if (sender == General)
                MainGrid.ColumnDefinitions[0].Width = new Windows.UI.Xaml.GridLength(1, Windows.UI.Xaml.GridUnitType.Star);
            else if (sender == Theme)
                MainGrid.ColumnDefinitions[1].Width = new Windows.UI.Xaml.GridLength(1, Windows.UI.Xaml.GridUnitType.Star);
            else if (sender == Commands)
                MainGrid.ColumnDefinitions[2].Width = new Windows.UI.Xaml.GridLength(1, Windows.UI.Xaml.GridUnitType.Star);
            else
                MainGrid.ColumnDefinitions[3].Width = new Windows.UI.Xaml.GridLength(1, Windows.UI.Xaml.GridUnitType.Star);
            SlideAnimation.Begin();
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
            LoadVoiceCommands();
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
            LoadVoiceCommands();
        }

        //Displays all commands that can be currently used in the application 
        private async void LoadVoiceCommands()
        {
            CommandsPanel.Children.Clear();
            foreach (var set in (await Voice.VoiceRecognizer.Instance.GetVoiceCommands()).CommandSets)
            {
                foreach (var command in set.Commands)
                {
                    CommandsPanel.Children.Add(new TextBlock()
                    {
                        Text = command.Name,
                        Foreground = new SolidColorBrush(WinAppResources.Instance.ApplicationTheme.PanelItemFocused),
                        FontSize = 18,
                        Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 0)
                    });

                    foreach (var speakItem in command.ListenFor)
                    {
                        CommandsPanel.Children.Add(new TextBlock()
                        {
                            Text = speakItem.Content,
                            Foreground = new SolidColorBrush(WinAppResources.Instance.ApplicationTheme.Foreground),
                            FontSize = 16,
                            Margin = new Windows.UI.Xaml.Thickness(10, 0, 0, 0)
                        });
                    }
                }

                CommandsPanel.Children.Add(new Grid()
                {
                    Height = 0.5,
                    BorderThickness = new Windows.UI.Xaml.Thickness(0),
                    Background = new SolidColorBrush(WinAppResources.Instance.ApplicationTheme.Foreground),
                    Margin = new Windows.UI.Xaml.Thickness(0, 20, 30, 10)
                });

                foreach (var phraseList in set.PhraseLists)
                {
                    CommandsPanel.Children.Add(new TextBlock()
                    {
                        Text = "{" + phraseList.Label + "}:",
                        Foreground = new SolidColorBrush(WinAppResources.Instance.ApplicationTheme.PanelItemFocused),
                        FontSize = 18,
                        Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 0)
                    });

                    foreach (var item in phraseList.Items)
                    {
                        CommandsPanel.Children.Add(new TextBlock()
                        {
                            Text = "-" + item.Content,
                            Foreground = new SolidColorBrush(WinAppResources.Instance.ApplicationTheme.Foreground),
                            FontSize = 16,
                            Margin = new Windows.UI.Xaml.Thickness(40, 0, 0, 0)
                        });
                    }
                }

                CommandsPanel.Children.Add(new TextBlock()
                {
                    Text = "[...] - " + WinAppResources.Instance.ApplicationLanguage.Optional,
                    Foreground = new SolidColorBrush(WinAppResources.Instance.ApplicationTheme.PanelItemFocused),
                    FontSize = 18,
                    Margin = new Windows.UI.Xaml.Thickness(0, 15, 0, 15)
                });
            }
        }
    }
}
