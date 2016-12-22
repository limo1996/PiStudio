using System;
using System.Threading.Tasks;
using PiStudio.Shared;
using PiStudio.Shared.Data;

namespace PiStudio.Droid
{
	public class BitmapEncoder : IBitmapEncoder
	{
		public BitmapEncoder()
		{
		}

		public Task FlushAsync()
		{
			throw new NotImplementedException();
		}

		public Task SetPixelData(PixelFormat format, bool ignoreAlphaMode, uint pixelWidth, uint pixelHeight, double dpiX, double dpiY, byte[] pixels)
		{
			throw new NotImplementedException();
		}
	}
}
