using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PCLStorage;


namespace PiStudio.Shared
{
    /// <summary>
    /// Class that stores all application settings through all platforms. 
    /// Should be loaded when app starts and saved before exiting app. 
    /// This class should not be used as storage for application resources during runtime.
    /// For this purpose see <see cref="AppResourcesBase"/> base class for app resources.
    /// </summary>
    public class AppSettings
    {
        //name of the settings file. 
        private const string m_filename = "AppSettings.xml";

        /// <summary>
        /// Creates new instance of <see cref="AppSettings"/>
        /// </summary>
        private AppSettings()
        {
            SupportedImageTypes.Add(".jpg");
            SupportedImageTypes.Add(".png");
            SupportedImageTypes.Add(".jpeg");
            SupportedImageTypes.Add(".gif");
            IsDarkTheme = false;
        }

        /// <summary>
        /// Asynchronously creates new instance of <see cref="AppSettings"/> class and loads its content from file named <c>AppSettings.xml</c>
        /// </summary>
        /// <returns></returns>
        private static async Task<AppSettings> Create()
        {
            if (await FileSystem.Current.LocalStorage.CheckExistsAsync(m_filename) == ExistenceCheckResult.NotFound)
                throw new FileNotFoundException("App settings file not found...");
            IFile file = await FileSystem.Current.LocalStorage.GetFileAsync(m_filename);

            using (var stream = await file.OpenAsync(FileAccess.Read))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                return (AppSettings)serializer.Deserialize(stream);
            }
        }

        private static AppSettings m_instance;

        /// <summary>
        /// The only instance of <see cref="AppSettings"/> class. Should be initialized on the beginning of app loading.
        /// </summary>
        public static AppSettings Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new AppSettings();
                return m_instance;
            }
        }

        private List<string> m_supportedImageTypes = new List<string>();

        /// <summary>
        /// Image types that are supoorted by the application.
        /// </summary>
        public IList<string> SupportedImageTypes
        {
            get { return m_supportedImageTypes; }
        }

        /// <summary>
        /// Indicates whether is this first launch of the application.
        /// </summary>
        public bool FirstLaunch { get; set; }

        /// <summary>
        /// Language lastly used by application.
        /// </summary>
        public Data.Language AppLanguage { get; set; }

        public bool AutoSave { get; set; }
        /// <summary>
        /// Indicates, whether is dark theme chosen.
        /// </summary>
        public bool IsDarkTheme { get; set; }

        #region Custom Colors
        /// <summary>
        /// Indicates, whether is custom theme chosen. Just in case that this property is
        /// set to <c>false</c> property IsDarkTheme should be read.
        /// </summary>
        public bool IsCustomTheme { get; set; }

        /// <summary>
        /// Color of the application content's (i.e. everything except panels) text, or color of some the controls.
        /// </summary>
        public int Foreground { get; set; }

        /// <summary>
        /// Color of the application's content's (i.e. everything except panels) background.
        /// </summary>
        public int Background { get; set; }

        /// <summary>
        /// Background color of the menu panel.
        /// </summary>
        public int PanelBackground { get; set; }

        /// <summary>
        /// Color of the application's borders.
        /// </summary>
        public int Borders { get; set; }

        /// <summary>
        /// Color of the panels foreground(icons, text, buttons).
        /// </summary>
        public int PanelForeground { get; set; }

        /// <summary>
        /// Main color of the application. Color of the window, menu panel's focused item.
        /// </summary>
        public int PanelItemFocused { get; set; }

        /// <summary>
        /// Color when is pointer over an clicable item.
        /// </summary>
        public int ClickableForeground { get; set; }

        /// <summary>
        /// Color of the upper panel background.
        /// </summary>
        public int UpperPanelBackground { get; set; }
        #endregion
    }
}
