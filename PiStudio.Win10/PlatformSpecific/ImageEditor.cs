using System;
using System.IO;
using System.Threading.Tasks;
using PiStudio.Shared.Data;
using PiStudio.Shared;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage;
using Windows.Storage.Streams;

namespace PiStudio.Win10
{
    public sealed class ImageEditor : BaseImageEditor
    {
        private Task m_initTask = null;

        public ImageEditor(IBitmapDecoder decoder, string filePath) : base(filePath)
        {
            m_initTask = LoadFromStream(decoder);
        }

        public async Task<WriteableBitmap> ApplyFilterAsync(Filter filter)
        {
            await m_initTask;
            var processedBytes = this.ApplyFilter(filter);
            return await CreateBitmapFromByteArrayAsync(processedBytes, (int)PixelWidth, (int)PixelHeight);
        }

        public static byte[] ApplyFilterThreadSafeAsync(ImageEditor editor, Filter filter)
        {
            return ImageToolkit.ApplyConvolutionMatrixFilter(editor.m_workingImageInBytes, (int)editor.m_imageWidth,
                (int)editor.m_imageHeight, filter.Matrix, editor.m_bytePerPixel, editor.m_bytePerPixel != 1, filter.Factor, filter.Bias);
        }

        public async Task<WriteableBitmap> RotateAsync()
        {
            await m_initTask;
            var processedBytes = this.Rotate();
            return await CreateBitmapFromByteArrayAsync(processedBytes, (int)PixelWidth, (int)PixelHeight);
        }

        public async Task<WriteableBitmap> ApplyBrightnessAsync(int brightness)
        {
            await m_initTask;
            if (brightness == 0)
                return await CreateBitmapFromByteArrayAsync(m_workingImageInBytes, (int)PixelWidth, (int)PixelHeight);
            await Task.Run(() =>
            {
                var processedBytes = this.ApplyBrightness(brightness);
                m_unsavedImageInBytes = processedBytes;
            });
            return await CreateBitmapFromByteArrayAsync(m_unsavedImageInBytes, (int)PixelWidth, (int)PixelHeight);
        }

        /// <summary>
        /// Saves working image in a file with specified filename in a folder where original image is located.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="suffix">file type</param>
        /// <returns></returns>
        public override async Task Save(Stream stream, string suffix)
        {
            await m_initTask;
            HasUnsavedChange = false;
            using (var rstream = new InMemoryRandomAccessStream())
            {
                var encoder = await WinBitmapEncoder.CreateAsync(rstream.AsStream(), suffix);
                await this.WriteBytesToEncoder(encoder);
                stream.Seek(0, SeekOrigin.Begin);
                stream.SetLength((long)rstream.Size);
                await rstream.AsStream().CopyToAsync(stream);
            }
        }

        private async Task<byte[]> LoadFromStream(IBitmapDecoder decoder)
        {
            m_pixelFormat = (PixelFormat)decoder.PixelFormat;
            BitmapTransform transform = new BitmapTransform();
            var imageBytes = await decoder.GetPixelDataAsync();

            m_workingImageInBytes = m_unsavedImageInBytes = imageBytes;
            m_imageHeight = decoder.PixelHeight;
            m_imageWidth = decoder.PixelWidth;
            m_dpiX = decoder.DpiX;
            m_dpiY = decoder.DpiY;
            m_bytePerPixel = ImageToolkit.ConvertBitmapPixelFormat(m_pixelFormat);

            return imageBytes;
        }

        public static async Task<WriteableBitmap> CreateBitmapFromByteArrayAsync(byte[] imagePixels, int pixelWidth, int pixelHeight)
        {
            WriteableBitmap bitmap = new WriteableBitmap(pixelWidth, pixelHeight);

            using (Stream stream = bitmap.PixelBuffer.AsStream())
            {
                await stream.WriteAsync(imagePixels, 0, imagePixels.Length);
            }

            return bitmap;
        }
    }
}