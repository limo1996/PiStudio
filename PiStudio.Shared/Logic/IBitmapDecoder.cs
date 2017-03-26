using PiStudio.Shared.Data;
using System.Threading.Tasks;

namespace PiStudio.Shared
{
    /// <summary>
    /// Interface that abstracts bitmap decoder. Capable of converting image to byte array.
    /// Should be implemented on every platform differently but has to provide functionality described below.
    /// </summary>
    public interface IBitmapDecoder
    {
        /// <summary>
        /// Asynchronously returns byte array of pixels.
        /// </summary>
        Task<byte[]> GetPixelDataAsync();

        /// <summary>
        /// Returns how many pixels has image in one column.
        /// </summary>
        uint PixelHeight { get; }

        /// <summary>
        /// Returns how many pixels has image in one row.
        /// </summary>
        uint PixelWidth { get; }

        /// <summary>
        /// Returns pixel format of processed image.
        /// </summary>
        PixelFormat PixelFormat { get; }

        /// <summary>
        /// Dots per pixel in X axis.
        /// </summary>
        double DpiX { get; }

        /// <summary>
        /// Dots per pixel in Y axis.
        /// </summary>
        double DpiY { get; }
    }
}
