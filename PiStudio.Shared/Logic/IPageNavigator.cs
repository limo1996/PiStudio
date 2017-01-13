using PiStudio.Shared.Data;
using System;
using System.Threading.Tasks;

namespace PiStudio.Shared
{
    /// <summary>
    /// Navigator between app screens.
    /// </summary>
    public interface IPageNavigator
    {
        /// <summary>
        /// Provides intialization and show file picker and stores image in app structures.
        /// </summary>
        Task GetStartedButtonClick();

        /// <summary>
        /// Navigates to the given type of the page with given navigation parameter.
        /// </summary>
        Task<bool> NavigateTo(Type pageType, NavigationParameter args);
    }
}
