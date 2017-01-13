using PiStudio.Shared.Data;
using System.Threading.Tasks;

namespace PiStudio.Shared
{
    /// <summary>
    /// Every class that implements this interface is able to convert row data into compressed data in common image formats like 'jpeg', 'gif', 'png'
    /// </summary>
    public interface IBitmapEncoder
    {
        /// <summary>
        /// Encodes image data 
        /// </summary>
        /// <param name="format">Format of the pixels in the image</param>
        /// <param name="ignoreAlphaMode">Ignore alpha mode</param>
        /// <param name="pixelWidth">Image width in pixels</param>
        /// <param name="pixelHeight">Image height in pixels</param>
        /// <param name="dpiX">dpi in X axis</param>
        /// <param name="dpiY">dpi in Y axis</param>
        /// <param name="pixels">Raw pixel data</param>
        void SetPixelData(PixelFormat format, bool ignoreAlphaMode, uint pixelWidth, uint pixelHeight, double dpiX, double dpiY, byte[] pixels);

        /// <summary>
        /// Saves encoded data into given streams
        /// </summary>
        Task FlushAsync();
    }
}
