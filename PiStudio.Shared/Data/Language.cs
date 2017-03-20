using System.ComponentModel;

namespace PiStudio.Shared.Data
{
    /// <summary>
    /// Contains text for whole application in one language.
    /// </summary>
    public class LanguagePack : INotifyPropertyChanged
    {
        private Language m_language;
        private string m_menuItem1;
        private string m_menuItem2;
        private string m_menuItem3;
        private string m_menuItem4;
        private string m_menuItem5;
        private string m_menuItem6;
        private string m_menuItem7;

        private string m_settings;
        private string m_placeholderSearch;

        private string m_shareHeader;
        private string m_shareDesc;

        private string m_settingsItem1;
        private string m_settingsItem2;
        private string m_settingsItem3;
        private string m_settingsItem4;

        private string m_settingsOptions;
        private string m_settingsChosLang;
        private string m_settingsAutoSave;
        private string m_settingsFilters;
        private string m_settingsChosFilt;
        private string m_settingsNote;

        private string m_themePredefined;
        private string m_themeEnableDark;
        private string m_themeCustom;

        private string m_aboutVersion;
        private string m_aboutSource;

        private string m_brighteness;
        private string m_drawingSize;
        private string m_drawingColor;
        private string m_drawingClear;
        private string m_drawingUndo;

        private string m_filterNone;
        private string m_saveAs;

        private string m_introTitle1;
        private string m_introTitle2;
        private string m_introBtn;

        private string m_applyingFilters;
        private string m_NoteBrightness;
        private string m_optional;

        public Language Language
        {
            get
            {
                return m_language;
            }
            set
            {
                m_language = value;
                OnPropertyChanged("Language");
            }
        }

        public string MenuItem1
        {
            get
            {
                return m_menuItem1;
            }
            set
            {
                m_menuItem1 = value;
                OnPropertyChanged("MenuItem1");
            }
        }

        public string MenuItem2
        {
            get
            {
                return m_menuItem2;
            }
            set
            {
                m_menuItem2 = value;
                OnPropertyChanged("MenuItem2");
            }
        }

        public string MenuItem3
        {
            get
            {
                return m_menuItem3;
            }
            set
            {
                m_menuItem3 = value;
                OnPropertyChanged("MenuItem3");
            }
        }

        public string MenuItem4
        {
            get
            {
                return m_menuItem4;
            }
            set
            {
                m_menuItem4 = value;
                OnPropertyChanged("MenuItem4");
            }
        }

        public string MenuItem5
        {
            get
            {
                return m_menuItem5;
            }
            set
            {
                m_menuItem5 = value;
                OnPropertyChanged("MenuItem5");
            }
        }

        public string MenuItem6
        {
            get
            {
                return m_menuItem6;
            }
            set
            {
                m_menuItem6 = value;
                OnPropertyChanged("MenuItem6");
            }
        }

        public string MenuItem7
        {
            get
            {
                return m_menuItem7;
            }
            set
            {
                m_menuItem7 = value;
                OnPropertyChanged("MenuItem7");
            }
        }

        public string ShareHeader
        {
            get
            {
                return m_shareHeader;
            }
            set
            {
                m_shareHeader = value;
                OnPropertyChanged("ShareHeader");
            }
        }

        public string ShareDescription
        {
            get
            {
                return m_shareDesc;
            }
            set
            {
                m_shareDesc = value;
                OnPropertyChanged("ShareDescription");
            }
        }

        public string Settings
        {
            get
            {
                return m_settings;
            }
            set
            {
                m_settings = value;
                OnPropertyChanged("Settings");
            }
        }

        public string PlaceholderSearch
        {
            get
            {
                return m_placeholderSearch;
            }
            set
            {
                m_placeholderSearch = value;
                OnPropertyChanged("PlaceholderSearch");
            }
        }

        public string SettingsItem1
        {
            get
            {
                return m_settingsItem1;
            }
            set
            {
                m_settingsItem1 = value;
                OnPropertyChanged("SettingsItem1");
            }
        }

        public string SettingsItem2
        {
            get
            {
                return m_settingsItem2;
            }
            set
            {
                m_settingsItem2 = value;
                OnPropertyChanged("SettingsItem2");
            }
        }

        public string SettingsItem3
        {
            get
            {
                return m_settingsItem3;
            }
            set
            {
                m_settingsItem3 = value;
                OnPropertyChanged("SettingsItem3");
            }
        }

        public string SettingsItem4
        {
            get
            {
                return m_settingsItem4;
            }
            set
            {
                m_settingsItem4 = value;
                OnPropertyChanged("SettingsItem4");
            }
        }

        public string SettingsOptions
        {
            get
            {
                return m_settingsOptions;
            }
            set
            {
                m_settingsOptions = value;
                OnPropertyChanged("SettingsOptions");
            }
        }

        public string SettingsChooseLang
        {
            get
            {
                return m_settingsChosLang;
            }
            set
            {
                m_settingsChosLang = value;
                OnPropertyChanged("SettingsChooseLang");
            }
        }

        public string SettingsAutoSave
        {
            get
            {
                return m_settingsAutoSave;
            }
            set
            {
                m_settingsAutoSave = value;
                OnPropertyChanged("SettingsAutoSave");
            }
        }

        public string SettingsFilters
        {
            get
            {
                return m_settingsFilters;
            }
            set
            {
                m_settingsFilters = value;
                OnPropertyChanged("SettingsFilters");
            }
        }

        public string SettingsChooseFilter
        {
            get
            {
                return m_settingsChosFilt;
            }
            set
            {
                m_settingsChosFilt = value;
                OnPropertyChanged("SettingsChooseFilter");
            }
        }

        public string SettingsNote
        {
            get
            {
                return m_settingsNote;
            }
            set
            {
                m_settingsNote = value;
                OnPropertyChanged("SettingsNote");
            }
        }

        public string ThemePredefined
        {
            get
            {
                return m_themePredefined;
            }
            set
            {
                m_themePredefined = value;
                OnPropertyChanged("ThemePredefined");
            }
        }

        public string ThemeEnableDark
        {
            get
            {
                return m_themeEnableDark;
            }
            set
            {
                m_themeEnableDark = value;
                OnPropertyChanged("ThemeEnableDark");
            }
        }

        public string ThemeCustom
        {
            get
            {
                return m_themeCustom;
            }
            set
            {
                m_themeCustom = value;
                OnPropertyChanged("ThemeCustom");
            }
        }

        public string AboutVersion
        {
            get
            {
                return m_aboutVersion;
            }
            set
            {
                m_aboutVersion = value;
                OnPropertyChanged("AboutVersion");
            }
        }

        public string AboutSource
        {
            get
            {
                return m_aboutSource;
            }
            set
            {
                m_aboutSource = value;
                OnPropertyChanged("AboutSource");
            }
        }

        public string Brightness
        {
            get
            {
                return m_brighteness;
            }
            set
            {
                m_brighteness = value;
                OnPropertyChanged("Brighteness");
            }
        }

        public string DrawingSize
        {
            get
            {
                return m_drawingSize;
            }
            set
            {
                m_drawingSize = value;
                OnPropertyChanged("DrawingSize");
            }
        }

        public string DrawingColor
        {
            get
            {
                return m_drawingColor;
            }
            set
            {
                m_drawingColor = value;
                OnPropertyChanged("DrawingColor");
            }
        }

        public string DrawingUndo
        {
            get
            {
                return m_drawingUndo;
            }
            set
            {
                m_drawingUndo = value;
                OnPropertyChanged("DrawingUndo");
            }
        }

        public string DrawingClear
        {
            get
            {
                return m_drawingClear;
            }
            set
            {
                m_drawingClear = value;
                OnPropertyChanged("DrawingClear");
            }
        }

        public string FilterNone
        {
            get
            {
                return m_filterNone;
            }
            set
            {
                m_filterNone = value;
                OnPropertyChanged("FilterNone");
            }
        }

        public string SaveAs
        {
            get
            {
                return m_saveAs;
            }
            set
            {
                m_saveAs = value;
                OnPropertyChanged("SaveAs");
            }
        }

        public string IntroTitle1
        {
            get
            {
                return m_introTitle1;
            }
            set
            {
                m_introTitle1 = value;
                OnPropertyChanged("IntroTitle1");
            }
        }

        public string IntroTitle2
        {
            get
            {
                return m_introTitle2;
            }
            set
            {
                m_introTitle2 = value;
                OnPropertyChanged("IntroTitle2");
            }
        }

        public string IntroButton
        {
            get
            {
                return m_introBtn;
            }
            set
            {
                m_introBtn = value;
                OnPropertyChanged("IntroButton");
            }
        }

        public string ApplyingFilters
        {
            get
            {
                return m_applyingFilters;
            }
            set
            {
                m_applyingFilters = value;
                OnPropertyChanged("ApplyingFilters");
            }
        }

        public string NoteBrightness
        {
            get
            {
                return m_NoteBrightness;
            }
            set
            {
                m_NoteBrightness = value;
                OnPropertyChanged("NoteBrightness");
            }
        }

        public string Optional
        {
            get
            {
                return m_optional;
            }
            set
            {
                m_optional = value;
                OnPropertyChanged("Optional");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void CopyTo(LanguagePack pack)
        {
            pack.Language = this.Language;
            pack.AboutSource = this.AboutSource;
            pack.AboutVersion = this.AboutVersion;
            pack.Brightness = this.Brightness;
            pack.DrawingClear = this.DrawingClear;
            pack.DrawingColor = this.DrawingColor;
            pack.DrawingSize = this.DrawingSize;
            pack.DrawingUndo = this.DrawingUndo;
            pack.FilterNone = this.FilterNone;
            pack.IntroButton = this.IntroButton;
            pack.IntroTitle1 = this.IntroTitle1;
            pack.IntroTitle2 = this.IntroTitle2;
            pack.MenuItem1 = this.MenuItem1;
            pack.MenuItem2 = this.MenuItem2;
            pack.MenuItem3 = this.MenuItem3;
            pack.MenuItem4 = this.MenuItem4;
            pack.MenuItem5 = this.MenuItem5;
            pack.MenuItem6 = this.MenuItem6;
            pack.MenuItem7 = this.MenuItem7;
            pack.PlaceholderSearch = this.PlaceholderSearch;
            pack.SaveAs = this.SaveAs;
            pack.Settings = this.Settings;
            pack.SettingsAutoSave = this.SettingsAutoSave;
            pack.SettingsChooseFilter = this.SettingsChooseFilter;
            pack.SettingsChooseLang = this.SettingsChooseLang;
            pack.SettingsFilters = this.SettingsFilters;
            pack.SettingsItem1 = this.SettingsItem1;
            pack.SettingsItem2 = this.SettingsItem2;
            pack.SettingsItem3 = this.SettingsItem3;
            pack.SettingsItem4 = this.SettingsItem4;
            pack.SettingsNote = this.SettingsNote;
            pack.SettingsOptions = this.SettingsOptions;
            pack.ShareDescription = this.ShareDescription;
            pack.ShareHeader = this.ShareHeader;
            pack.ThemeCustom = this.ThemeCustom;
            pack.ThemeEnableDark = this.ThemeEnableDark;
            pack.ThemePredefined = this.ThemePredefined;
            pack.ApplyingFilters = this.ApplyingFilters;
            pack.NoteBrightness = this.NoteBrightness;
            pack.Optional = this.Optional;
        }
    }

    /// <summary>
    /// Enumeration that contains names of suppered languages
    /// </summary>
    public enum Language
    {
        Slovensky,
        English,
        German
    }
}
