using System.Threading.Tasks;
using Android.Graphics;
using Java.Nio;
using PiStudio.Shared;

namespace PiStudio.Droid
{
	/// <summary>
	/// <see cref="IBitmapDecoder"/> implementation on android platform.
	/// </summary>
	public class DroidBitmapDecoder : IBitmapDecoder
	{
		private Bitmap m_decoder;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PiStudio.Droid.DroidBitmapDecoder"/> class.
		/// </summary>
		/// <param name="bitmap">Bitmap.</param>
		public DroidBitmapDecoder(Bitmap bitmap)
		{
			m_decoder = bitmap;
		}

		/// <summary>
		/// Dots per pixel in X axis.
		/// </summary>
		public double DpiX
		{
			get
			{
				return 300; //TODO
			}
		}

		/// <summary>
		/// Dots per pixel in Y axis.
		/// </summary>
		public double DpiY
		{
			get
			{
				return 300; //TODO
			}
		}

		/// <summary>
		/// Returns pixel format of processed image.
		/// </summary>
		public PiStudio.Shared.Data.PixelFormat PixelFormat
		{
			get
			{
				var config = m_decoder.GetConfig();
				if (config == null || config == Bitmap.Config.Alpha8)
					return Shared.Data.PixelFormat.Gray8;
				else if (config == Bitmap.Config.Argb8888)
					return Shared.Data.PixelFormat.Argb8888;
				else if (config == Bitmap.Config.Rgb565)
					return Shared.Data.PixelFormat.Rgb565;
				else
					return Shared.Data.PixelFormat.Unknown;
			}
		}

		/// <summary>
		/// Returns how many pixels has image in one column.
		/// </summary>
		public uint PixelHeight
		{
			get
			{
				return (uint)m_decoder.Height;
			}
		}

		/// <summary>
		/// Returns how many pixels has image in one row.
		/// </summary>
		public uint PixelWidth
		{
			get
			{
				return (uint)m_decoder.Width;
			}
		}

		/// <summary>
		/// Asynchronously returns byte array of pixels.
		/// </summary>
		public async Task<byte[]> GetPixelDataAsync()
		{
			ByteBuffer bf = ByteBuffer.Allocate(m_decoder.ByteCount);
			System.Diagnostics.Debug.WriteLine(m_decoder.ByteCount);
			await m_decoder.CopyPixelsToBufferAsync(bf);
			bf.Rewind();
			byte[] array = new byte[m_decoder.ByteCount];
			bf.Get(array);
			return array;
		}
	}
}
