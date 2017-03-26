using System;
using System.IO;
using System.Threading.Tasks;
using PiStudio.Shared;
using PiStudio.Shared.Data;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace PiStudio.Win10
{
    /// <summary>
    /// <see cref="IBitmapDecoder"/> implementation on windows platform.
    /// </summary>
    public class WinBitmapDecoder : IBitmapDecoder
    {
        private Windows.Graphics.Imaging.BitmapDecoder decoder;
        private byte[] m_pixelData;

        private WinBitmapDecoder() { }

        private async Task InitializeAsync(IRandomAccessStream stream)
        {
            decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
            BitmapTransform transform = new BitmapTransform();
            PixelDataProvider provider = await decoder.GetPixelDataAsync(decoder.BitmapPixelFormat,
                                                                   BitmapAlphaMode.Straight,
                                                                   transform,
                                                                   ExifOrientationMode.IgnoreExifOrientation,
                                                                   ColorManagementMode.DoNotColorManage);
            m_pixelData = provider.DetachPixelData();
        }

        /// <summary>
        /// Returns pixel format of processed image.
        /// </summary>
        public PixelFormat PixelFormat
        {
            get
            {
                return (PixelFormat)decoder.BitmapPixelFormat;
            }
        }

        /// <summary>
        /// Returns how many pixels has image in one column.
        /// </summary>
        public uint PixelHeight
        {
            get
            {
                return decoder.PixelHeight;
            }
        }

        /// <summary>
        /// Returns how many pixels has image in one row.
        /// </summary>
        public uint PixelWidth
        {
            get
            {
                return decoder.PixelWidth;
            }
        }

        /// <summary>
        /// Dots per pixel in X axis.
        /// </summary>
        public double DpiX
        {
            get
            {
                return decoder.DpiX;
            }
        }

        /// <summary>
        /// Dots per pixel in Y axis.
        /// </summary>
        public double DpiY
        {
            get
            {
                return decoder.DpiY;
            }
        }

        /// <summary>
        /// Creates new instance of <see cref="IBitmapDecoder"/> asynchronously.
        /// </summary>
        /// <param name="stream">Image source stream.</param>
        /// <returns>New instance of <see cref="IBitmapDecoder"/> interface.</returns>
        public static async Task<IBitmapDecoder> CreateAsync(Stream stream)
        {
            WinBitmapDecoder decoder = new WinBitmapDecoder();
            await decoder.InitializeAsync(stream.AsRandomAccessStream());
            return decoder;
        }

        /// <summary>
        /// Asynchronously returns byte array of pixels.
        /// </summary>
        public async Task<byte[]> GetPixelDataAsync()
        {
            return m_pixelData;
        }
    }
}
