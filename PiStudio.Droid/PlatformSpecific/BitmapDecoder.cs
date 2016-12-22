using System;
using System.Threading.Tasks;
using PiStudio.Shared;
using PiStudio.Shared.Data;

namespace PiStudio.Droid
{
	public class BitmapDecoder : IBitmapDecoder
	{
		public BitmapDecoder()
		{
		}

		public double DpiX
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public double DpiY
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public PixelFormat PixelFormat
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

		public uint PixelWidth
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public Task<byte[]> GetPixelDataAsync()
		{
			throw new NotImplementedException();
		}
	}
}
