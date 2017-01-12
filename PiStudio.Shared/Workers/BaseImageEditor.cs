using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiStudio.Shared.Data;
using System.IO;

namespace PiStudio.Shared
{
    public abstract class BaseImageEditor : IImageEditor
    {
        protected byte[] m_workingImageInBytes = null;
        protected byte[] m_unsavedImageInBytes = null;

        protected uint m_imageWidth;
        protected uint m_imageHeight;

        protected byte m_bytePerPixel;
        protected double m_dpiX;
        protected double m_dpiY;

        protected PixelFormat m_pixelFormat;

        public BaseImageEditor(string filepath)
        {
            int index = filepath.LastIndexOf('.');
            MimeType = filepath.Substring(index + 1);
            IsUnsavedChange = false;
        }


        public IBitmapDecoder Decoder { get; set; }

        public IBitmapEncoder Encoder { get; set; }

        public bool IsUnsavedChange { get; protected set; }

        public uint PixelWidth
        {
            get { return m_imageWidth; }
        }

        public uint PixelHeight
        {
            get { return m_imageHeight; }
        }

        public string MimeType { get; private set; }

        public byte PixelSize
        {
            get { return m_bytePerPixel; }
        }

        protected byte[] ApplyBrightness(int brightness)
        {
            var brightnessBytes = ImageToolkit.ApplyBrightness(m_workingImageInBytes, m_bytePerPixel, brightness);
            m_unsavedImageInBytes = brightnessBytes;
            IsUnsavedChange = true;
            return brightnessBytes;
        }

        protected byte[] ApplyFilter(Filter filter)
        {
            byte[] tmpPixels = ImageToolkit.ApplyConvolutionMatrixFilter(this.m_workingImageInBytes, (int)this.m_imageWidth,
               (int)this.m_imageHeight, filter.Matrix, (byte)m_bytePerPixel, true);

            ImageConverter converter = new ImageConverter();
            byte[] resultPixels = tmpPixels;//converter.ConvertToRGBA(tmpPixels, this.m_pixelFormat);
            m_unsavedImageInBytes = resultPixels;
            IsUnsavedChange = false;
            return resultPixels;
        }

        protected byte[] Rotate()
        {
            var rotatedBytes = ImageToolkit.Rotate(m_workingImageInBytes, m_imageWidth, m_imageHeight, m_bytePerPixel);
            m_unsavedImageInBytes = rotatedBytes;
            IsUnsavedChange = true;
            return rotatedBytes;
        }

        public void SetSource(byte[] imageBytes)
        {
            if (imageBytes.Length != m_workingImageInBytes.Length)
                return;
            m_unsavedImageInBytes = imageBytes;
            IsUnsavedChange = true;
        }

        public void SaveChanges()
        {
            m_unsavedImageInBytes.CopyTo(m_workingImageInBytes, 0);
            IsUnsavedChange = false;
        }

        public async Task WriteBytesToEncoder(byte[] imageBytes, uint imageWidth, uint imageHeight, IBitmapEncoder encoder)
        {
            encoder.SetPixelData(m_pixelFormat, false,
                                imageWidth,
                                imageHeight,
                                m_dpiX,
                                m_dpiY,
                                imageBytes);
            await encoder.FlushAsync();
        }

        public abstract Task Save(Stream stream);

        public void Dismiss()
        {
            m_workingImageInBytes.CopyTo(m_unsavedImageInBytes, 0);
            IsUnsavedChange = false;
        }
    }
}
