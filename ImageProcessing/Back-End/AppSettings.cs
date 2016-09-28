using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI;

/*
TODO:
From supported types of images to 2 dimensional byte array
*/
namespace ImageProcessing
{
    public class AppSettings
    {
        private AppSettings()
        {
           
        }

        private static AppSettings Create()
        {
            string filepath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "AppSettings.xml");
            if (File.Exists(filepath))
            {
                using (var stream = File.Open(filepath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    return (AppSettings)serializer.Deserialize(stream);
                }
            }
            return new AppSettings();
        }

        private static AppSettings m_instance;
        public static AppSettings Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = AppSettings.Create();
                return m_instance;
            }
        }

        public Color Color1
        {
            get;
            set;
        }

        public Color Color2
        {
            get;
            set;
        }
        public static readonly int MinWindowHeight = 600;
        public static readonly int MinWindowWidth = 500;

        private List<string> m_supportedImageTypes = new List<string>();
        public IList<string> SupportedImageTypes
        {
            get { return m_supportedImageTypes; }
        }

        public bool FirstLaunch { get; set; }
    }
}
