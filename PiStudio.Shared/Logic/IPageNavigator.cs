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
        /// Provides intialization, shows file picker and stores image into application resources.
        /// </summary>
        Task GetStartedButtonClick();

        /// <summary>
        /// Displays file picker and loads new image into application resources.
        /// </summary>
        Task LoadNewImage();

        /// <summary>
        /// Shares currently edited image to external apps.
        /// </summary>
        void Share();

        /// <summary>
        /// Navigates to given page with given navigation parameter.
        /// </summary>
        /// <param name="pageType">Type of the target page</param>
        /// <param name="args">Optional navigation parameters</param>
        /// <remarks>
        /// <see cref="IPageNavigator"/> should be used in every navigation between pages because it handles
        /// unsaved changes as well as auto save option.
        /// </remarks>
        Task<bool> NavigateTo(Type pageType, NavigationParameter args);
    }
}
