using System.Collections.Generic;
using PiStudio.Shared.Data;

namespace PiStudio.Shared
{
    /// <summary>
    /// Base abstract class for application resources on different platforms.
    /// </summary>
    public abstract class AppResourcesBase
    {
        private static AppResourcesBase m_instance = null;

        public AppResourcesBase()
        {
            SetLanguage(Language.English);
            Init_filters();
            TmpImageName = "tmp.png";
        }

        /// <summary>
        /// List of all filters available in the application
        /// </summary>
        public List<FilterSettings> Filters { get { return m_filters; } }
        private List<FilterSettings> m_filters;

        /// <summary>
        /// Currently used language
        /// </summary>
        public LanguagePack ApplicationLanguage { get; private set; }

        /// <summary>
        /// Sets the application language 
        /// </summary>
        /// <param name="lang"><see cref="Language"/> that will be set</param>
        /// <returns>LanguagePack in given language</returns>
        public LanguagePack SetLanguage(Language lang)
        {
            ApplicationLanguage = LanguageInitializer.Initialize(lang);
            if(m_filters != null)
                m_filters[0].FilterName = ApplicationLanguage.FilterNone;
            return ApplicationLanguage;
        }

        /// <summary>
        /// Path to loaded image
        /// </summary>
        public string LoadedFile { get; set; }

        /// <summary>
        /// Name of the tmp image stored in local application data
        /// </summary>
        public string TmpImageName { get; set; }

        //initialize filters
        private void Init_filters()
        {
            m_filters = new List<FilterSettings>();
            m_filters.Add(new FilterSettings(new Filter(ApplicationLanguage.FilterNone, new double[,] { { 0, 0, 0 },
                                                             { 0, 1, 0 },
                                                             { 0, 0, 0 } }, 1, 0), true));

            m_filters.Add(new FilterSettings(new Filter("Blur", new double[,] { { 0.0, 0.2,  0.0 },
                                                             { 0.2, 0.2,  0.2 },
                                                             { 0.0, 0.2,  0.0 } }), true));

            m_filters.Add(new FilterSettings(new Filter("Blur2", new double[,] { { 0, 0, 1, 0, 0 },
                                                             { 0, 1, 1, 1, 0 },
                                                             { 1, 1, 1, 1, 1 },
                                                             { 0, 1, 1, 1, 0 },
                                                             { 0, 0, 1, 0, 0 } }, 13, 0), false));

            m_filters.Add(new FilterSettings(new Filter("MotionBlur", new double[,] { { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                                 { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                                                                 { 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                                                                 { 0, 0, 0, 1, 0, 0, 0, 0, 0},
                                                                 { 0, 0, 0, 0, 1, 0, 0, 0, 0},
                                                                 { 0, 0, 0, 0, 0, 1, 0, 0, 0},
                                                                 { 0, 0, 0, 0, 0, 0, 1, 0, 0},
                                                                 { 0, 0, 0, 0, 0, 0, 0, 1, 0},
                                                                 { 0, 0, 0, 0, 0, 0, 0, 0, 1}}), false));

            m_filters.Add(new FilterSettings(new Filter("FindEdges", new double[,] { { 0,  0, -1,  0,  0 },
                                                                  { 0,  0, -1,  0,  0 },
                                                                  { 0,  0,  2,  0,  0 },
                                                                  { 0,  0,  0,  0,  0 },
                                                                  { 0,  0,  0,  0,  0 }}), true));

            m_filters.Add(new FilterSettings(new Filter("Sobel–Feldman", new double[,] { { 3, 10, 3},
                                                                      { 0, 0, 0 },
                                                                      { -3, -10, -3}}), false));

            m_filters.Add(new FilterSettings(new Filter("Sobel", new double[,] { { -1, -2, -1 },
                                                              { 0, 0, 0 },
                                                              { 1, 2, 1 } }), true));

            m_filters.Add(new FilterSettings(new Filter("Sharpen", new double[,] { { -1, -1, -1 },
                                                                { -1, 9, -1, },
                                                                { -1, -1, -1 } }), true));

            m_filters.Add(new FilterSettings(new Filter("Sharpen2", new double[,] { { -1, -1, -1, -1, -1 },
                                                                  { -1,  2,  2,  2, -1 },
                                                                  { -1,  2,  8,  2, -1 },
                                                                  { -1,  2,  2,  2, -1 },
                                                                  { -1, -1, -1, -1, -1 }}, 1 / 8, 0), false));

            m_filters.Add(new FilterSettings(new Filter("Sharpen3", new double[,] { { 1,  1,  1 },
                                                                 { 1, -7,  1 },
                                                                 { 1,  1,  1} }), false));
        }

        /// <summary>
        /// Copies content into <see cref="AppSettings"/> instance.
        /// </summary>
        /// <param name="settings"></param>
        public abstract void CopyTo(AppSettings settings);

        /// <summary>
        /// Loads content from <see cref="AppSettings"/> instance.
        /// </summary>
        /// <param name="settings"></param>
        public abstract void LoadFrom(AppSettings settings);

        /// <summary>
        /// Gets full path to given file name.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public abstract string GetStoragePath(string file);
    }
}
