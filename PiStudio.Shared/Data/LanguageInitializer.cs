using System;

namespace PiStudio.Shared.Data
{
    /// <summary>
    /// Creates <see cref="LanguagePack"/>s for application.
    /// </summary>
    public static class LanguageInitializer
    {
        /// <summary>
        /// Initialized <see cref="LanguagePack"/> for language passed as parameter.
        /// </summary>
        /// <param name="lang">Language for which will be pack created.</param>
        /// <returns><see cref="LanguagePack"/> in given language.</returns>
        public static LanguagePack Initialize(Language lang)
        {
            switch(lang)
            {
                case Language.Slovensky: return InitializeSlovak();
                case Language.English: return InitializeEnglish();
                case Language.German: return InitializeGerman();
                default: throw new NotImplementedException(string.Format("Language {0} is not yet translated!", lang.ToString()));
            }
        }

        /// <summary>
        /// Initialized <see cref="LanguagePack"/> for English.
        /// </summary>
        /// <returns></returns>
        private static LanguagePack InitializeEnglish()
        {
            LanguagePack pack = new LanguagePack()
            {
                AboutSource = "Source Code",
                AboutVersion = "Version 1.1.0.0",
                Brightness = "Brighteness",
                DrawingClear = "Clear",
                DrawingColor = "Color",
                DrawingSize = "Size",
                DrawingUndo = "Undo",
                FilterNone = "None",
                IntroButton = "Load",
                IntroTitle1 = "Edit, draw and share your photos",
                IntroTitle2 = "Start by uploading image",
                Language = Language.English,
                MenuItem1 = "Home",
                MenuItem2 = "Filters",
                MenuItem3 = "Brightness",
                MenuItem4 = "Draw",
                MenuItem5 = "Save",
                MenuItem6 = "Speak",
                PlaceholderSearch = "Search",
                Settings = "Settings",
                SettingsAutoSave = "Auto save before moving to another effect",
                SettingsChooseFilter = "Choose filters",
                SettingsChooseLang = "Choose language",
                SettingsFilters = "Filters",
                SettingsItem1 = "General",
                SettingsItem2 = "Theme",
                SettingsItem3 = "About",
                SettingsNote = "*Note: Selecting too much filters lead to their longer loading time.",
                SettingsOptions = "Options",
                ThemeCustom = "Custom",
                ThemeEnableDark = "Enable dark theme",
                ThemePredefined = "Predefined"
            };
            return pack;
        }

        /// <summary>
        /// Initialized <see cref="LanguagePack"/> for Slovak
        /// </summary>
        /// <returns></returns>
        private static LanguagePack InitializeSlovak()
        {
            LanguagePack pack = new LanguagePack()
            {
                AboutSource = "Zdrojový kód",
                AboutVersion = "Verzia 1.1.0.0",
                Brightness = "Jas",
                DrawingClear = "Vyčisti",
                DrawingColor = "Farba",
                DrawingSize = "Veľkosť",
                DrawingUndo = "Späť",
                FilterNone = "Žiadny",
                IntroButton = "Načítaj",
                IntroTitle1 = "Upravuj, pokresli a zdieľaj svoje fotky",
                IntroTitle2 = "Začni načítaním obrázka",
                Language = Language.Slovensky,
                MenuItem1 = "Domov",
                MenuItem2 = "Filtre",
                MenuItem3 = "Jas",
                MenuItem4 = "Kreslenie",
                MenuItem5 = "Ulož",
                MenuItem6 = "Rozprávaj",
                PlaceholderSearch = "Hľadaj",
                Settings = "Nastavenia",
                SettingsAutoSave = "Automatické ukladanie pred opustením stránky",
                SettingsChooseFilter = "Vyber efekty",
                SettingsChooseLang = "Vyber jazyk",
                SettingsFilters = "Filtre",
                SettingsItem1 = "Všeobecné",
                SettingsItem2 = "Téma",
                SettingsItem3 = "O aplikácii",
                SettingsNote = "*Pozor: Vybratím veľkého množstva filtrov spomalíte ich načítaciu dobu.",
                SettingsOptions = "Možnosti",
                ThemeCustom = "Vlastné",
                ThemeEnableDark = "Povoľ tmavú tému",
                ThemePredefined = "Prednastavené"
            };
            return pack;
        }

        /// <summary>
        /// Initialized <see cref="LanguagePack"/> for German.
        /// </summary>
        /// <returns></returns>
        private static LanguagePack InitializeGerman()
        {
            return null;
        }
    }
}
