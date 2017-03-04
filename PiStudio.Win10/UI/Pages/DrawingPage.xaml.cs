using PiStudio.Shared.Data;
using PiStudio.Win10.Data;
using PiStudio.Win10.Navigation;
using PiStudio.Win10.UI.Controls;
using System;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PiStudio.Win10.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DrawingPage : Page
    {
        public DrawingPage()
        {
            ApplicationTheme = new Theme();
            LanguagePack = new LanguagePack();
            WinAppResources.Instance.ApplicationTheme.CopyTo(ApplicationTheme);
            WinAppResources.Instance.ApplicationLanguage.CopyTo(LanguagePack);
            this.InitializeComponent();
            WinAppResources.Instance.InitializePage();
            ToolBox.BrushThicknessChanged += (o, e) => DrawingCanvas.BrushThickness = (uint)e;
            ToolBox.BrushColorChanged += (o, e) => DrawingCanvas.BrushColor = e;
            ToolBox.ClearClicked += (o, e) => DrawingCanvas.Clear();
            ToolBox.UndoClicked += (o, e) => DrawingCanvas.Undo();
            DrawingCanvas.BrushThickness = 1;
        }

        public Theme ApplicationTheme { get; set; }
        public LanguagePack LanguagePack { get; set; }
        
        public PiCanvas Canvas { get { return DrawingCanvas; } }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ImgPresenter.SizeChanged += (o, args) =>
            {
                DrawingCanvas.Width = args.NewSize.Width;
                DrawingCanvas.Height = args.NewSize.Height;
            };

            PRing.IsActive = true;

            Navigator.Instance.Editor = DrawingCanvas;
            var image = await WinAppResources.Instance.GetWorkingImage();
            ImgPresenter.Source = image;
            WinAppResources.Instance.SetImageStretch(ImgPresenter);

            SavePop.SaveableObject = DrawingCanvas;
            SavePop.Started += (o1, args1) => Progress.IsActive = true;
            SavePop.Completed += (o2, args2) => Progress.IsActive = false;

            PRing.IsActive = false;
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
                PrevPage = EnumPage.DrawingPage,
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

        private void Grid_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            WinAppResources.Instance.SetImageStretch(ImgPresenter);
        }
    }
}
