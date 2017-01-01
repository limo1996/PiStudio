using PiStudio.Shared.Data;
using System;

namespace PiStudio.Shared
{
    public interface IPageNavigator
    {
        void GetStartedButtonClick();
        void NavigateTo(Type pageType, NavigationParameter args);
    }
}
