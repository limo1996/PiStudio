using System.IO;
using System.Threading.Tasks;
using Android.Graphics;
using PiStudio.Shared;

namespace PiStudio.Droid
{
	/// <summary>
	/// <see cref="IBitmapEncoder"/> implementation on android platform.
	/// </summary>
	public class DroidBitmapEncoder : IBitmapEncoder
	{
		private Stream m_stream;
		private string m_suffix;
		private Task m_compressTask;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PiStudio.Droid.DroidBitmapEncoder"/> class.
		/// </summary>
		/// <param name="stream">Stream.</param>
		/// <param name="suffix">Suffix.</param>
		public DroidBitmapEncoder(Stream stream, string suffix)
		{
			m_stream = stream;
			m_suffix = suffix;
		}

		/// <summary>
		/// Saves encoded data into given stream.
		/// </summary>
		public async Task FlushAsync()
		{
			await m_compressTask;
		}

		/// <summary>
		/// Creates new instance of <see cref="WinBitmapEncoder"/> asynchronously.
		/// </summary>
		/// <param name="stream">Image source stream.</param>
		/// <param name="fileFormat">File format. (i.e. 'jpg', 'jpeg', 'png')</param>
		/// <returns></returns>
		public void SetPixelData(PiStudio.Shared.Data.PixelFormat format, bool ignoreAlphaMode, uint pixelWidth, uint pixelHeight, double dpiX, double dpiY, byte[] pixels)
		{
			Bitmap bitmap = CreateBitmap(pixels, (int)pixelWidth, (int)pixelHeight, format);
			var compressFormat = Bitmap.CompressFormat.Png;
			if (m_suffix == "jpg" || m_suffix == "jpeg")
				compressFormat = Bitmap.CompressFormat.Jpeg;

			m_compressTask = bitmap.CompressAsync(compressFormat, 100, m_stream);
		}

		private static void SetBitmapContent(Bitmap bitmap, int pixelWidth, int pixelHeight, byte[] pixels)
		{

		}

		/// <summary>
		/// Creates the bitmap from provided pixels.
		/// </summary>
		/// <returns>The bitmap.</returns>
		/// <param name="pixels">Pixels.</param>
		/// <param name="pixelWidth">Pixel width.</param>
		/// <param name="pixelHeight">Pixel height.</param>
		/// <param name="format">Pixel format.</param>
		public static Bitmap CreateBitmap(byte[] pixels, int pixelWidth, int pixelHeight, PiStudio.Shared.Data.PixelFormat format)
		{
			var config = Bitmap.Config.Alpha8;
			if (format == Shared.Data.PixelFormat.Argb8888)
				config = Bitmap.Config.Argb8888;
			else if (format == Shared.Data.PixelFormat.Rgb565)
				config = Bitmap.Config.Rgb565;

			var bitmap = Bitmap.CreateBitmap(pixelWidth, pixelHeight, config);
			int[] array = ImageToolkit.TransformPixels(pixels, format);
			bitmap.SetPixels(array, 0, pixelWidth, 0, 0, pixelWidth, pixelHeight);

			return bitmap;
		}
	}
}
