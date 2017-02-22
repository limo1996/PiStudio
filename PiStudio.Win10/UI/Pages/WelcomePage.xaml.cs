using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PiStudio.Shared.Data;
using PiStudio.Win10.Data;
using Windows.UI;
using PiStudio.Win10.Navigation;

namespace PiStudio.Win10.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            ApplicationTheme = new Theme();
            LanguagePack = new LanguagePack();
            this.InitializeComponent();

            WinAppResources.Instance.ApplicationTheme.CopyTo(ApplicationTheme);
            WinAppResources.Instance.ApplicationLanguage.CopyTo(LanguagePack);
            WinAppResources.Instance.InitializePage();
        }

        public Theme ApplicationTheme { get; set; }
        public LanguagePack LanguagePack { get; set; }

        private async void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            await Navigator.Instance.GetStartedButtonClick();
        }
    }
}
