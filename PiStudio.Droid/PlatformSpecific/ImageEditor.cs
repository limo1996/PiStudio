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

		public bool IsUnsavedChanges
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

		public Task<IEditableBitmap> ApplyBrightnessAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IEditableBitmap> ApplyFilterAsync(Filter filter)
		{
			throw new NotImplementedException();
		}

		public Task<IEditableBitmap> CreateBitmapFromByteArrayAsync(byte[] imagePixels)
		{
			throw new NotImplementedException();
		}

		public Task<IEditableBitmap> RotateAsync()
		{
			throw new NotImplementedException();
		}

		public Task SaveAsync(string filepath)
		{
			throw new NotImplementedException();
		}

		public void SaveChanges()
		{
			throw new NotImplementedException();
		}

		public Task WriteBytesToStream(byte[] imageBytes, Stream stream, string fileFormat, IBitmapEncoder encoder)
		{
			throw new NotImplementedException();
		}
	}
}
