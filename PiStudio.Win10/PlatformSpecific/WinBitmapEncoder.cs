using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiStudio.Shared;
using PiStudio.Shared.Data;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;
using System.IO;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;

namespace PiStudio.Win10
{
    /// <summary>
    /// <see cref="IBitmapEncoder"/> implementation on windows platform.
    /// </summary>
    public class WinBitmapEncoder : IBitmapEncoder
    {
        private BitmapEncoder encoder;
        private WinBitmapEncoder() { }
        private async Task Initialize(Guid BitmapEncoderGuid, IRandomAccessStream stream)
        {
            encoder = await BitmapEncoder.CreateAsync(BitmapEncoderGuid, stream);
        }

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
        public void SetPixelData(PixelFormat format, bool ignoreAlphaMode, uint pixelWidth, uint pixelHeight, double dpiX, double dpiY, byte[] pixels)
        {
            encoder.SetPixelData((BitmapPixelFormat)format,
                                 ignoreAlphaMode ? BitmapAlphaMode.Ignore : BitmapAlphaMode.Straight,
                                 pixelWidth,
                                 pixelHeight,
                                 dpiX,
                                 dpiY,
                                 pixels);
        }

        /// <summary>
        /// Creates new instance of <see cref="WinBitmapEncoder"/> asynchronously.
        /// </summary>
        /// <param name="stream">Image source stream.</param>
        /// <param name="fileFormat">File format. (i.e. 'jpg', 'jpeg', 'png')</param>
        /// <returns></returns>
        public static async Task<WinBitmapEncoder> CreateAsync(Stream stream, string fileFormat)
        {
            fileFormat = fileFormat.Replace(".", "");
            WinBitmapEncoder encoder = new WinBitmapEncoder();
            Guid BitmapEncoderGuid = BitmapEncoder.JpegEncoderId;
            switch (fileFormat)
            {
                case "png":
                    BitmapEncoderGuid = BitmapEncoder.PngEncoderId;
                    break;

                case "bmp":
                    BitmapEncoderGuid = BitmapEncoder.BmpEncoderId;
                    break;

                case "tiff":
                    BitmapEncoderGuid = BitmapEncoder.TiffEncoderId;
                    break;

                case "gif":
                    BitmapEncoderGuid = BitmapEncoder.GifEncoderId;
                    break;
                case "jpeg":
                case "jpg":
                default:
                    BitmapEncoderGuid = BitmapEncoder.JpegEncoderId;
                    break;
            }
            await encoder.Initialize(BitmapEncoderGuid, stream.AsRandomAccessStream());
            return encoder;
        }

        /// <summary>
        /// Saves encoded data into given stream.
        /// </summary>
        public async Task FlushAsync()
        {
            await encoder.FlushAsync();
        }
    }
}
