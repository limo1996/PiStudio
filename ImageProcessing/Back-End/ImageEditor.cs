using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace ImageProcessing.Back_End
{
    public class ImageEditor
    {
        private StorageFile m_imageToProcess = null;
        private byte[] m_workingImageInBytes = null;
        private byte[] m_unsavedImageInBytes = null;

        private uint m_imageWidth;
        private uint m_imageHeight;

        private uint m_pixelWidth;
        private double m_dpiX;
        private double m_dpiY;

        private Task m_initTask = null;
        private BitmapPixelFormat m_pixelFormat;

        public ImageEditor(StorageFile imageFile)
        {
            this.m_imageToProcess = imageFile;
            m_initTask = Initialize();
        }

        public bool IsUnsavedChanges
        {
            get
            {
                if (m_workingImageInBytes == null || m_unsavedImageInBytes == null)
                    return false;
                if (m_unsavedImageInBytes.Length != m_workingImageInBytes.Length)
                    return false;
                for (int i = 0; i < m_workingImageInBytes.Length; i++)
                    if (m_workingImageInBytes[i] != m_unsavedImageInBytes[i])
                        return true;
                return false;
            }
        }

        public async Task<WriteableBitmap> ApplyFilterAsync(Filter filter)
        {
            await m_initTask;

            byte[] tmpPixels = this.ApplyConvolutionMatrixFilter(this.m_workingImageInBytes, (int)this.m_imageWidth,
                (int)this.m_imageHeight, filter.Matrix, (byte)m_pixelWidth, true);

            ImageConverter converter = new ImageConverter();
            byte[] resultPixels = converter.ConvertToRGBA(tmpPixels, this.m_pixelFormat);
            m_unsavedImageInBytes = resultPixels;

            return await CreateBitmapFromByteArrayAsync(resultPixels);
        }

        public async Task<WriteableBitmap> RotateAsync()
        {
            await m_initTask;


            throw new NotImplementedException();
        }

        public async Task<WriteableBitmap> ApplyBrightnessAsync(int brightness)
        {
            await m_initTask;
            ImageConverter converter = new ImageConverter();
            ushort[] hslBytes = null;
            var tmp2 = converter.ConvertFromHSLToRGBA(converter.ConvertFromRGBAtoHSL(m_workingImageInBytes)); ;

            int max = 0;
            for (int i = 0; i < m_workingImageInBytes.Length; i++)
            {
                int tmp33 = Math.Abs(tmp2[i] - m_workingImageInBytes[i]);
                if (tmp33 > 1)
                    max = tmp33;

            }
            System.Diagnostics.Debug.WriteLine(max);

            /*await Task.Run(() =>
            {
                hslBytes = converter.ConvertFromRGBAtoHSL(m_workingImageInBytes);
                for (int i = 0; i < hslBytes.Length; i += 4)
                {
                    int tmp = hslBytes[i + 2] + brightness / 400;
                    tmp = tmp < 0 ? 0 : tmp;
                    tmp = tmp > 100 ? 100 : tmp;
                    hslBytes[i + 2] = (ushort)tmp;
                }
            });*/

            return await CreateBitmapFromByteArrayAsync(tmp2);
        }

        public void SaveChanges()
        {

        }

        /// <summary>
        /// Saves working image in a file with folder picker.
        /// </summary>
        /// <returns></returns>
        public async Task SaveWithFolderPickerAsync()
        {
            await m_initTask;

            FileSavePicker picker = new FileSavePicker();
            picker.CommitButtonText = "Save";
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeChoices.Add("Images", AppSettings.Instance.SupportedImageTypes);
            picker.SuggestedFileName = m_imageToProcess.Name;
            StorageFile file = await picker.PickSaveFileAsync();

            string fileType = GetFileType(file.Name);
            using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                byte[] bytes = m_workingImageInBytes;
                await WriteBytesToStream(bytes, fileStream, fileType);
            }
        }

        //FIXME: not always work
        private string GetFileType(string filename)
        {
            return null;
        }

        /// <summary>
        /// Saves working image in a file with specified filename in a folder where original image is located.
        /// </summary>
        /// <param name="filename">Name of the new file.</param>
        /// <returns></returns>
        public async Task SaveAsync(string filename)
        {
            await m_initTask;

            StorageFolder folder = await m_imageToProcess.GetParentAsync();
            StorageFile file = await folder.CreateFileAsync(filename);
            using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                byte[] bytes = m_workingImageInBytes;
                await fileStream.WriteAsync(bytes.AsBuffer());
            }
        }

        private async Task Initialize()
        {
            BitmapDecoder decoder = null;
            byte[] imageBytes = null;

            using (IRandomAccessStream fileStream = await m_imageToProcess.OpenAsync(FileAccessMode.Read))
            {
                decoder = await BitmapDecoder.CreateAsync(fileStream);
                m_pixelFormat = decoder.BitmapPixelFormat;

                BitmapTransform transform = new BitmapTransform();
                PixelDataProvider pixelData = await decoder.GetPixelDataAsync(BitmapPixelFormat.Unknown,
                                                                        BitmapAlphaMode.Straight,
                                                                        transform,
                                                                        ExifOrientationMode.IgnoreExifOrientation,
                                                                        ColorManagementMode.DoNotColorManage);
                imageBytes = pixelData.DetachPixelData();
                m_workingImageInBytes = imageBytes;
                m_imageHeight = decoder.PixelHeight;
                m_imageWidth = decoder.PixelWidth;
                m_dpiX = decoder.DpiX;
                m_dpiX = decoder.DpiY;
                m_pixelWidth = ConvertBitmapPixelFormat(m_pixelFormat);

            }
        }

        private byte ConvertBitmapPixelFormat(BitmapPixelFormat format)
        {
            if (format == BitmapPixelFormat.Bgra8 || format == BitmapPixelFormat.Rgba8)
                return 4;
            if (format == BitmapPixelFormat.Gray16)
                return 2;
            if (format == BitmapPixelFormat.Gray8)
                return 1;
            if (format == BitmapPixelFormat.Rgba16)
                return 8;
            return 1;
        }

        private async Task<WriteableBitmap> CreateBitmapFromByteArrayAsync(byte[] imagePixels)
        {
            WriteableBitmap bitmap = new WriteableBitmap((int)this.m_imageWidth, (int)this.m_imageHeight);

            using (Stream stream = bitmap.PixelBuffer.AsStream())
            {
                await stream.WriteAsync(imagePixels, 0, imagePixels.Length);
            }

            return bitmap;
        }

        private byte[] ApplyConvolutionMatrixFilter(byte[] imageBytes, int imageWidth,
            int imageHeight, double[,] kernelMatrix, byte bytePerPixel, bool isAlpha,
            double factor = 1, double bias = 0)
        {
            int kernelWidth = kernelMatrix.GetLength(1);
            int kernelHeight = kernelMatrix.GetLength(0);

            if (kernelWidth % 2 == 0 || kernelHeight % 2 == 0)
                throw new ArgumentException("Sizes of kernel matrix must be odd number!");
            if (kernelWidth != kernelHeight)
                throw new ArgumentException("Sizes of kernel matrix must be the same!");
            byte[] resultBuffer = new byte[imageHeight * imageWidth * bytePerPixel];

            double[] sum = new double[bytePerPixel];
            int halfKernelSize = (int)Math.Floor((double)(kernelHeight / 2));

            byte[] newImageBytes = new byte[imageHeight * imageWidth * bytePerPixel];
            imageBytes.CopyTo(newImageBytes, 0);


            int realBytePerPixel;
            if (isAlpha)
                realBytePerPixel = bytePerPixel - 1;
            else
                realBytePerPixel = bytePerPixel;

            for (int i = 0; i < imageHeight; i++)
            {
                for (int j = 0; j < (imageWidth * bytePerPixel); j += bytePerPixel)
                {
                    for (int sumIt = 0; sumIt < realBytePerPixel; sumIt++)
                        sum[sumIt] = 0;

                    for (int ii = 0; ii < kernelHeight; ii++)
                    {
                        for (int jj = 0; jj < kernelWidth; jj++)
                        {
                            for (int sumIt = 0; sumIt < realBytePerPixel; sumIt++)
                            {
                                int x = Math.Min(Math.Max(i + ii - halfKernelSize, 0), imageHeight - 1);
                                int y = Math.Min(Math.Max(j + ((jj - halfKernelSize) * bytePerPixel), 0),
                                    (imageWidth - 1) * bytePerPixel) + sumIt;

                                sum[sumIt] += (imageBytes[x * imageWidth * bytePerPixel + y] * kernelMatrix[ii, jj] * factor + bias);

                            }
                        }
                    }
                    for (int sumIt = 0; sumIt < realBytePerPixel; sumIt++)
                        newImageBytes[i * imageWidth * bytePerPixel + j + sumIt] = (byte)(Math.Min(Math.Max(sum[sumIt], 0), 255));
                }
            }
            return newImageBytes;
        }

        private async Task WriteBytesToStream(byte[] imageBytes, IRandomAccessStream stream, string fileFormat)
        {
            fileFormat.TrimEnd('.');
            string FileName = "MyFile." + fileFormat;

            var WB = await CreateBitmapFromByteArrayAsync(imageBytes);
            Guid BitmapEncoderGuid = BitmapEncoder.JpegEncoderId;
            switch (fileFormat)
            {
                case "jpeg":
                    BitmapEncoderGuid = BitmapEncoder.JpegEncoderId;
                    break;

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
            }

            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoderGuid, stream);
            Stream pixelStream = WB.PixelBuffer.AsStream();
            byte[] pixels = new byte[pixelStream.Length];
            await pixelStream.ReadAsync(pixels, 0, pixels.Length);

            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore,
                                (uint)WB.PixelWidth,
                                (uint)WB.PixelHeight,
                                m_dpiX,
                                m_dpiY,
                                pixels);
            await encoder.FlushAsync();
        }
    }
}
