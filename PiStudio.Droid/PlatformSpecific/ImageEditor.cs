using System;
using System.IO;
using System.Threading.Tasks;
using PiStudio.Shared;
using PiStudio.Shared.Data;

namespace PiStudio.Droid
{
	public class ImageEditor : IImageEditor
	{
		public ImageEditor()
		{
		}

        public IBitmapDecoder Decoder
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IBitmapEncoder Encoder
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsUnsavedChange
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

        public string MimeType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public uint PixelHeight
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public byte PixelSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public uint PixelWidth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

		public Task SaveAsync(string filepath)
		{
			throw new NotImplementedException();
		}

		public void SaveChanges()
		{
			throw new NotImplementedException();
		}

        public Task WriteBytesToEncoder(byte[] imageBytes, uint pixelWidth, uint pixelHeight, IBitmapEncoder encoder)
        {
            throw new NotImplementedException();
        }

        public Task WriteBytesToStream(byte[] imageBytes, Stream stream, string fileFormat, IBitmapEncoder encoder)
		{
			throw new NotImplementedException();
		}
	}
}
