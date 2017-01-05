using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using PCLStorage;


namespace PiStudio.Shared.Data
{
    public class AppSettings
    {
        private const string m_filename = "AppSettings.xml";
        private AppSettings()
        {
            SupportedImageTypes.Add(".jpg");
            SupportedImageTypes.Add(".png");
            SupportedImageTypes.Add(".jpeg");
            SupportedImageTypes.Add(".gif");
        }

        public static async Task<AppSettings> Create()
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
        public IList<string> SupportedImageTypes
        {
            get { return m_supportedImageTypes; }
        }

        public bool FirstLaunch { get; set; }
    }
}
