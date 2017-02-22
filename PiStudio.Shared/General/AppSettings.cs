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
        private static string m_filename = "AppSettings.xml";

        /// <summary>
        /// Creates new instance of <see cref="AppSettings"/>
        /// </summary>
        private AppSettings()
        {
            IsPredefinedTheme = true;
            SupportedImageTypes.Clear();
            SupportedImageTypes.Add(".jpg");
            SupportedImageTypes.Add(".png");
            SupportedImageTypes.Add(".jpeg");
            SupportedImageTypes.Add(".gif");
        }

        /// <summary>
        /// Asynchronously creates new instance of <see cref="AppSettings"/> class and loads its content from file named <c>AppSettings.xml</c>
        /// </summary>
        /// <returns></returns>
        public static async Task CreateAsync()
        {
            AppSettings s = new AppSettings();
            if (await FileSystem.Current.LocalStorage.CheckExistsAsync(m_filename) != ExistenceCheckResult.NotFound)
            {
                IFile file = await FileSystem.Current.LocalStorage.GetFileAsync(m_filename);
                
                using (var stream = await file.OpenAsync(FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    try { s = (AppSettings)serializer.Deserialize(stream); }
                    catch { s = new AppSettings(); }
                }
            }
            AppSettings.Instance = s;
        }

        /// <summary>
        /// Asynchronously saves <see cref="AppSettings"/> object to app's local storage.
        /// </summary>
        public static async Task SaveAsync()
        {
            IFile file = await FileSystem.Current.LocalStorage.CreateFileAsync(m_filename, CreationCollisionOption.OpenIfExists);
            await file.WriteAllTextAsync("");
            using (var stream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                serializer.Serialize(stream, AppSettings.Instance);
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
            private set { m_instance = value; }
        }

        private HashSet<string> m_supportedImageTypes = new HashSet<string>();

        /// <summary>
        /// Image types that are supoorted by the application.
        /// </summary>
        public HashSet<string> SupportedImageTypes
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
        /// Indicates whether is set one of the predefined themes (dark and light)
        /// </summary>
        public bool IsDarkTheme { get; set; }

        /// <summary>
        /// Indicates whether is predefined or custom theme
        /// </summary>
        public bool IsPredefinedTheme { get; set; }

        /// <summary>
        /// Zero means that commands were not yet installed
        /// </summary>
        public int CortanaVoiceCommandsVersion { get; set; }

        #region Colors

        /// <summary>
        /// Color of the application content's (i.e. everything except panels) text, or color of some the controls.
        /// </summary>
        public uint Foreground { get; set; }

        /// <summary>
        /// Color of the application's content's (i.e. everything except panels) background.
        /// </summary>
        public uint Background { get; set; }

        /// <summary>
        /// Background color of the menu panel.
        /// </summary>
        public uint PanelBackground { get; set; }

        /// <summary>
        /// Color of the application's borders.
        /// </summary>
        public uint Borders { get; set; }

        /// <summary>
        /// Color of the panels foreground(icons, text, buttons).
        /// </summary>
        public uint PanelForeground { get; set; }

        /// <summary>
        /// Main color of the application. Color of the window, menu panel's focused item.
        /// </summary>
        public uint PanelItemFocused { get; set; }

        /// <summary>
        /// Color when is pointer over an clicable item.
        /// </summary>
        public uint ClickableForeground { get; set; }

        /// <summary>
        /// Color of the upper panel background.
        /// </summary>
        public uint UpperPanelBackground { get; set; }
        #endregion
    }
}
