using PiStudio.Shared;
using PiStudio.Shared.Data;
using PiStudio.Win10.Data;
using PiStudio.Win10.Navigation;
using PiStudio.Win10.UI.Controls;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PiStudio.Win10.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrightnessPage : Page
    {
        public BrightnessPage()
        {
            ApplicationTheme = new Theme();
            WinAppResources.Instance.ApplicationTheme.CopyTo(ApplicationTheme);
            this.InitializeComponent();
            BrightnessSlider.ValueChanged += BrightnessSlider_ValueChanged;
            this.SizeChanged += BrightnessPage_SizeChanged;
            WinAppResources.Instance.InitializePage();
        }

        public Theme ApplicationTheme { get; set; }

        private void BrightnessPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //850
            if(LowerPanel.ColumnDefinitions.Count == 1 && e.NewSize.Width > 850)
            {
                LowerPanel.ColumnDefinitions.Clear();
                LowerPanel.Children.Clear();
                LowerPanel.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                LowerPanel.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1,GridUnitType.Auto) });
                LowerPanel.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                Grid.SetColumn(BrightnessText, 0);
                Grid.SetColumn(BrightnessSlider, 1);
                Grid.SetColumn(SliderValue, 2);
                LowerPanel.Children.Add(BrightnessText);
                LowerPanel.Children.Add(BrightnessSlider);
                LowerPanel.Children.Add(SliderValue);
            }
            else if(LowerPanel.ColumnDefinitions.Count == 3 && e.NewSize.Width < 850)
            {
                LowerPanel.ColumnDefinitions.Clear();
                LowerPanel.Children.Clear();
                LowerPanel.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                Grid.SetColumn(BrightnessSlider, 0);
                LowerPanel.Children.Add(BrightnessSlider);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            /*var file = AppResources.Instance.LoadedImage;
            BitmapImage image = new BitmapImage();

            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                await image.SetSourceAsync(stream);
            }

            ImageContent.Source = image;*/
        }

        private void BrightnessSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (e.NewValue < 0 && e.OldValue >= 0)
                BackgroundColor.Fill = new SolidColorBrush(Colors.Black);
            else if (e.NewValue >= 0 && e.OldValue < 0)
                BackgroundColor.Fill = new SolidColorBrush(Colors.White);
            double value = Math.Abs(e.NewValue) / 200;
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
