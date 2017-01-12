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
        private StorageFile m_imageToProcess;

        public ImageEditor(string filepath, IBitmapDecoder decoder) : base(filepath)
        {
            m_initTask = Initialize(filepath, decoder);
        }

        public ImageEditor(StorageFile file, IBitmapDecoder decoder) : base(file.Path)
        {
            m_initTask = Initialize(file, decoder);
        }

        public async Task<WriteableBitmap> ApplyFilterAsync(Filter filter)
        {
            await m_initTask;
            var processedBytes = this.ApplyFilter(filter);
            return await CreateBitmapFromByteArrayAsync(processedBytes);
        }

        public async Task<WriteableBitmap> RotateAsync()
        {
            await m_initTask;
            var processedBytes = this.Rotate();
            return await CreateBitmapFromByteArrayAsync(processedBytes);
        }

        public async Task<WriteableBitmap> ApplyBrightnessAsync(int brightness)
        {
            await m_initTask;
            var processedBytes = this.ApplyBrightness(brightness);
            return await CreateBitmapFromByteArrayAsync(processedBytes);
        }

        /// <summary>
        /// Saves working image in a file with specified filename in a folder where original image is located.
        /// </summary>
        /// <param name="filename">Name of the new file.</param>
        /// <returns></returns>
        public override async Task Save(Stream stream)
        {
            await m_initTask;
            IsUnsavedChange = false;
            using (var rstream = new InMemoryRandomAccessStream())
            {
                var encoder = await WinBitmapEncoder.CreateAsync(rstream.AsStream(), this.MimeType);
                await this.WriteBytesToEncoder(this.m_workingImageInBytes, PixelWidth, PixelHeight, encoder);
                stream.Seek(0, SeekOrigin.Begin);
                stream.SetLength((long)rstream.Size);
                await rstream.AsStream().CopyToAsync(stream);
            }
        }

        private async Task Initialize(string filepath, IBitmapDecoder decoder)
        {
            this.m_imageToProcess = await StorageFile.GetFileFromPathAsync(filepath);
            byte[] imageBytes = null;

            using (var fileStream = await m_imageToProcess.OpenAsync(FileAccessMode.Read))
            {
                imageBytes = await LoadFromStream(decoder, fileStream);
            }
        }

        private async Task Initialize(StorageFile file, IBitmapDecoder decoder)
        {
            m_imageToProcess = file;
            byte[] imageBytes = null;
            using (var fileStream = await file.OpenAsync(FileAccessMode.Read))
            {
                imageBytes = await LoadFromStream(decoder, fileStream);
            }
        }

        private async Task<byte[]> LoadFromStream(IBitmapDecoder decoder, IRandomAccessStream fileStream)
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

        private async Task<WriteableBitmap> CreateBitmapFromByteArrayAsync(byte[] imagePixels)
        {
            WriteableBitmap bitmap = new WriteableBitmap((int)PixelWidth, (int)PixelHeight);

            using (Stream stream = bitmap.PixelBuffer.AsStream())
            {
                await stream.WriteAsync(imagePixels, 0, imagePixels.Length);
            }

            return bitmap;
        }
    }
}