namespace PiStudio.Shared.Data
{
    /// <summary>
    /// Parameter that is passed between pages.
    /// </summary>
    public class NavigationParameter
    {
        /// <summary>
        /// Extra information.
        /// </summary>
        public object Extra { get; set; }

        /// <summary>
        /// What caused navigation action.
        /// </summary>
        public NavigationSource Source { get; set; }

        /// <summary>
        /// Page that is navigated from.
        /// </summary>
        public EnumPage PrevPage { get; set; }

        /// <summary>
        /// Default navigation parameter
        /// </summary>
        public static NavigationParameter Default
        {
            get
            {
                return new NavigationParameter()
                {
                    Source = NavigationSource.Click,
                    PrevPage = EnumPage.HomePage,
                    Extra = null
                };
            }
        }
    }

    /// <summary>
    /// Source of the navigation action.
    /// </summary>
    public enum NavigationSource
    {
        /// <summary>
        /// User input was by mouse or touch.
        /// </summary>
        Click,

        /// <summary>
        /// User input was by voice command.
        /// </summary>
        Voice,

        /// <summary>
        /// Page was loaded because of cortana foreground task.
        /// </summary>
        CortanaForeground,

        /// <summary>
        /// Page was loaded from cortana background task.
        /// </summary>
        CortanaBackground
    }

    /// <summary>
    /// 
    /// </summary>
    public enum EnumPage
    {
        WelcomePage,
        HomePage,
        FiltersPage,
        BrightnessPage,
        DrawingPage,
        SettingsPage
    }
}
