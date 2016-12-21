using System;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Resco.InAppSpeechRecognition.RecognitionAndAction;
using Windows.Storage;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Linq;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ImageProcessing.Front_End
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            this.InitializeComponent();
            var path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
        }

        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            this.MainMenu.IsPaneOpen = !MainMenu.IsPaneOpen;
        }

        private async void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            AppSettings.Instance.SupportedImageTypes.Add(".jpg");
            AppSettings.Instance.SupportedImageTypes.Add(".png");
            FileOpenPicker picker = new FileOpenPicker();
            picker.CommitButtonText = "Select";
            foreach (var item in AppSettings.Instance.SupportedImageTypes)
                picker.FileTypeFilter.Add(item);
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            var file = await picker.PickSingleFileAsync();
            AppResources.Instance.InitializeImageEditor(file);
            this.Frame.Navigate(typeof(FiltersPage));
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FiltersPage));
        }


        private async Task<StorageFile> getFile()
        {
            const string content = @"
<VoiceCommands xmlns=""http://schemas.microsoft.com/voicecommands/1.2"">

	<!--CommandSet for English-->
	<CommandSet xml:lang=""en-us"" Name=""CRMCommandsSetEnUs"">
		<CommandPrefix>  </CommandPrefix>
		<Example>Show my active accounts</Example>

		<!--Shows view on current entity-->
		<Command Name=""showView"">
			<Example>Show my active accounts</Example>
			<ListenFor>Show [me] {viewName} </ListenFor>
			<ListenFor>Open {viewName} </ListenFor>
			<Navigate/>
		</Command>
		<PhraseList Label=""viewName"">
			<Item>Views</Item>
			<Item>Accounts</Item>
		</PhraseList>
	</CommandSet>
</VoiceCommands>";

            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("commands.xml", CreationCollisionOption.GenerateUniqueName);
            using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                await stream.WriteAsync(Encoding.UTF8.GetBytes(content).AsBuffer());
            }
            return file;
        }
    }
}
