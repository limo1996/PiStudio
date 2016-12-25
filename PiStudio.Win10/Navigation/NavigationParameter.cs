namespace PiStudio.Win10.Navigation
{
    public class NavigationParameter
    {
        public object Extra { get; set; }
        public NavigationSource Source {get;set;}
        public EnumPage PrevPage { get; set; }
    }

    public enum NavigationSource
    {
        Click,
        Voice,
        CortanaForeground,
        CortanaBackground
    }

    public enum EnumPage
    {
        WelcomePage,
        GetStartedPage,
        HomePage,
        FiltersPage,
        DrawingPage
    }
}
