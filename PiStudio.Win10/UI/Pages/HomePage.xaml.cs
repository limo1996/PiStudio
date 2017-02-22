using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using PiStudio.Win10.Data;
using PiStudio.Win10.UI.Controls;
using PiStudio.Shared.Data;
using PiStudio.Win10.Navigation;
using System;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using PiStudio.Shared;
using Windows.UI.Xaml.Media.Animation;
using Windows.Foundation;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;

namespace PiStudio.Win10.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            ApplicationTheme = new Theme();
            LanguagePack = new LanguagePack();
            WinAppResources.Instance.ApplicationTheme.CopyTo(ApplicationTheme);
            WinAppResources.Instance.ApplicationLanguage.CopyTo(LanguagePack);
            this.InitializeComponent();
            WinAppResources.Instance.InitializePage();
        }

        private ImageEditor m_editor;

        public Theme ApplicationTheme { get; set; }
        public LanguagePack LanguagePack { get; set; }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            PRing.IsActive = true;

            var param = e.Parameter as NavigationParameter;
            if (param != null && param.Extra != null)
                m_editor = (ImageEditor)param.Extra;
            else
                m_editor = await WinAppResources.Instance.GetImageEditorAsync();

            var image = await WinAppResources.Instance.GetWorkingImage();
            Navigator.Instance.Editor = m_editor;

            PRing.IsActive = false;
            ImageContent.Source = image;

            SavePop.SaveableObject = m_editor;
            SavePop.Started += (o1, args1) => Progress.IsActive = true;
            SavePop.Completed += (o2, args2) => Progress.IsActive = false;

            WinAppResources.Instance.SetImageStretch(ImageContent);
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
                Navigator.Instance.Share();
                return;
            }
            
            await Navigator.Instance.NavigateTo(pageType, parameter);
        }
        
        private bool odd = true;
        private void RotateBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //var prev = ((Windows.UI.Xaml.Media.PlaneProjection)ImageContent.Projection);
            Storyboard rotation = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = -90;
            animation.BeginTime = TimeSpan.FromSeconds(0);
            animation.Duration = TimeSpan.FromMilliseconds(100);
            if (odd)
            {
                var tmp = ImageContent.ActualHeight;
                ImageContent.Height = ImageContent.ActualWidth;
                ImageContent.Width = tmp;
                odd = false;
            }
            else
            {
                ImageContent.Height = ImageContent.Width = double.NaN;
                odd = true;
            }
            Storyboard.SetTarget(animation, ImageContent);
            Storyboard.SetTargetProperty(animation, "(UIElement.Projection).(PlaneProjection.Rotation" + "Z" + ")");
            rotation.Children.Add(animation);
            rotation.Begin();
            var rotationTask = m_editor.RotateAsync();
            rotation.Completed += async (o, ee) =>
            {
                ImageContent.Projection = new Windows.UI.Xaml.Media.PlaneProjection();
                ImageContent.Source = await rotationTask;
                ImageContent.Width = ImageContent.Height = double.NaN;

            };
        }

        private async void AddBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            PRing.IsActive = true;
            await Navigator.Instance.LoadNewImageWithUIAsync();
            m_editor = await WinAppResources.Instance.GetImageEditorAsync();
            ImageContent.Source = await WinAppResources.Instance.GetWorkingImage();
            WinAppResources.Instance.SetImageStretch(ImageContent);
            PRing.IsActive = false;
        }

        private void ImgWrapper_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            WinAppResources.Instance.SetImageStretch(ImageContent);
        }
    }
}
