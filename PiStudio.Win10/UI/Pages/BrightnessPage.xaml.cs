using PiStudio.Shared;
using PiStudio.Shared.Data;
using PiStudio.Win10.Data;
using PiStudio.Win10.Navigation;
using PiStudio.Win10.UI.Controls;
using System;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;
using System.IO;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PiStudio.Win10.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrightnessPage : Page
    {
        private ImageEditor m_editor;
        public BrightnessPage()
        {
            ApplicationTheme = new Theme();
            LanguagePack = new LanguagePack();
            WinAppResources.Instance.ApplicationTheme.CopyTo(ApplicationTheme);
            WinAppResources.Instance.ApplicationLanguage.CopyTo(LanguagePack);
            this.InitializeComponent();
            BrightnessSlider.ValueChanged += BrightnessSlider_ValueChanged;
            this.SizeChanged += BrightnessPage_SizeChanged;
            WinAppResources.Instance.InitializePage();
        }

        public Theme ApplicationTheme { get; set; }
        public LanguagePack LanguagePack { get; set; }

        private void BrightnessPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //850
            if(LowerPanel.ColumnDefinitions.Count == 1 && e.NewSize.Width > 850)
            {
                LowerPanel.ColumnDefinitions.Clear();
                LowerPanel.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                LowerPanel.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1,GridUnitType.Auto) });
                LowerPanel.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                BrightnessText.Visibility = Visibility.Visible;
                SliderValue.Visibility = Visibility.Visible;
            }
            else if(LowerPanel.ColumnDefinitions.Count == 3 && e.NewSize.Width < 850)
            {
                LowerPanel.ColumnDefinitions.Clear();
                LowerPanel.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                BrightnessText.Visibility = Visibility.Collapsed;
                SliderValue.Visibility = Visibility.Collapsed;
            }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            PRing.IsActive = true;
            m_editor = await WinAppResources.Instance.GetImageEditorAsync();
            ImageContent.Source = await WinAppResources.Instance.GetWorkingImage();
            WinAppResources.Instance.SetImageStretch(ImageContent);

            SavePop.SaveableObject = m_editor;
            SavePop.Started += (o1, args1) => Progress.IsActive = true;
            SavePop.Completed += (o2, args2) => Progress.IsActive = false;

            PRing.IsActive = false;
        }

        private void BrightnessSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (e.NewValue == 0)
                m_editor.HasUnsavedChange = false;
            else
                m_editor.HasUnsavedChange = true;
           if (e.NewValue < 0 && e.OldValue >= 0)
                BackgroundColor.Fill = new SolidColorBrush(Colors.Black);
            else if (e.NewValue >= 0 && e.OldValue < 0)
                BackgroundColor.Fill = new SolidColorBrush(Colors.White);
            double value = Math.Abs(e.NewValue * 1.4) / 200;
            BackgroundColor.Opacity = value;

            SliderValue.Text = e.NewValue.ToString();
        }

        private void ImageContent_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.IsEmpty)
                return;
            BackgroundColor.Width = e.NewSize.Width;
            BackgroundColor.Height = e.NewSize.Height;
        }

        private void Hamburger_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MainMenu.IsPaneOpen = !MainMenu.IsPaneOpen;
        }

        private async void MenuItem_Click(object sender, System.EventArgs e)
        {
            var tmp = sender as MenuItem;
            if (tmp != null && !tmp.IsSelectionEnabled)
                return;

            if(m_editor.HasUnsavedChange)
                await m_editor.ApplyBrightnessAsync((int)BrightnessSlider.Value);
            NavigationParameter parameter = new NavigationParameter()
            {
                PrevPage = EnumPage.BrightnessPage,
                Source = NavigationSource.Click
            };

            Type pageType = typeof(SettingsPage);
            PageNavigator navigator = new PageNavigator(this.Frame, m_editor);

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
                SavePop.IsOpen = !SavePop.IsOpen;

                return;
            }
            else if (tmp == SpeakItem)
            {
                //recognize and continue

                return;
            }
            else if (tmp == ShareItem)
            {
                navigator.Share();
                return;
            }
            await navigator.NavigateTo(pageType, parameter);
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            WinAppResources.Instance.SetImageStretch(ImageContent);
        }
    }
}
