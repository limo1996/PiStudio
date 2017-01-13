using System.Threading.Tasks;

namespace PiStudio.Shared
{
    /// <summary>
    /// Every class that implements this interface have to be able to decode data from image and store them.
    /// </summary>
    public interface IImageEditor : ISaveable
	{
        /// <summary>
        /// Image resolution in X axis
        /// </summary>
        uint PixelWidth { get; }

        /// <summary>
        /// Image resolution in Y axis
        /// </summary>
        uint PixelHeight { get; }

        /// <summary>
        /// How many bytes are per one pixel
        /// </summary>
        byte PixelSize { get; }

        /// <summary>
        /// Image suffix. I.e. 'jpg'
        /// </summary>
        string MimeType { get; }

        /// <summary>
        /// Writes objects inner data into <see cref="IBitmapEncoder"/>
        /// </summary>
        /// <param name="encoder">encoder</param>
        Task WriteBytesToEncoder(IBitmapEncoder encoder);
    }
}
