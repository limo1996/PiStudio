using System.IO;
using System.Threading.Tasks;

namespace PiStudio.Shared
{
    /// <summary>
    /// Class that implements this interface is able to track its unsaved changes and is able to store its content into stream.
    /// </summary>
    public interface ISaveable
    {
        /// <summary>
        /// Gets whether object has some unsaved changes
        /// </summary>
        bool IsUnsavedChange { get; }

        /// <summary>
        /// Saves inner unsaved changes
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Save content into given stream
        /// </summary>
        /// <param name="stream"></param>
        Task Save(Stream stream);

        /// <summary>
        /// Dismiss unsaved changes.
        /// </summary>
        void Dismiss();
    }
}
