using ImageProcessing.Back_End;
using PiStudio.Shared;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PiStudio.Win10.UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrightnessPage : Page
    {
        public BrightnessPage()
        {
            this.InitializeComponent();
            BrightnessSlider.ValueChanged += BrightnessSlider_ValueChanged;
            this.SizeChanged += BrightnessPage_SizeChanged;
        }

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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
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

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ImageEditor editor = (ImageEditor)AppResources.Instance.Editor;
            ImageContent.Source = await editor.ApplyBrightnessAsync((int)BrightnessSlider.Value);
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            Type typeOfPage = typeof(HomePage);
            if (sender == BrightenessButton)
                typeOfPage = typeof(BrightnessPage);
            else if (sender == FiltersPageButton)
                typeOfPage = typeof(FiltersPage);
            var navigator = new PageNavigator(this.Frame, typeOfPage);
            navigator.NavigateTo(null);
        }
    }
}
