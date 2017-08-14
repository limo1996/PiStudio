using System;
using System.IO;
using System.Threading.Tasks;
using Android.Graphics;
using PiStudio.Shared;
using PiStudio.Shared.Data;

namespace PiStudio.Droid
{
	/// <summary>
	/// Instance of this object is able to apply various kernel filters, change brightness of a image and rotate it.
	/// </summary>
	public class ImageEditor : BaseImageEditor
	{
		private Task m_initTask = null;
		private byte[] m_filterImageBytes;
		private byte[] m_brightnessImageBytes;

		/// <summary>
		/// Creates new instance of <see cref="ImageEditor"/>.
		/// </summary>
		/// <param name="decoder">Decoder that will be used for image decoding.</param>
		/// <param name="filePath">Path to the image that will be processed.</param>
		public ImageEditor(IBitmapDecoder decoder, string filePath) : base(filePath)
		{
			m_initTask = LoadFromStream(decoder);
			Filter = null;
		}

		/// <summary>
		/// Applies given filter on the image. Result is returned and saved in internal structure. If you want to commit this changes, then call 
		/// SaveChanges() method inherited form <see cref="BaseImageEditor"/>.
		/// </summary>
		/// <param name="filter">Valid <see cref="Filter"/> object.</param>
		/// <returns>Image after effect.</returns>
		public async Task<Bitmap> ApplyFilterAsync(Filter filter)
		{
			await m_initTask;
			var processedBytes = this.ApplyFilter(m_filterImageBytes, filter);
			Filter = filter;
			m_workingImageInBytes = processedBytes;
			m_brightnessImageBytes = processedBytes;
			return CreateBitmapFromByteArrayAsync(processedBytes, (int)PixelWidth, (int)PixelHeight);
		}

		/// <summary>
		/// Applies kernel filter on image stored in <see cref="ImageEditor"/> without any changes to editor's internal structure.
		/// This method should be used over classic apply filter method when you want to apply multiple filters at the same time.
		/// </summary>
		/// <param name="editor">Instance of <see cref="ImageEditor"/>.</param>
		/// <param name="filter">Valid <see cref="Filter"/> object.</param>
		/// <returns></returns>
		public static byte[] ApplyFilterThreadSafeAsync(ImageEditor editor, Filter filter)
		{
			return ImageToolkit.ApplyConvolutionMatrixFilter(editor.m_filterImageBytes, (int)editor.m_imageWidth,
				(int)editor.m_imageHeight, filter.Matrix, editor.m_bytePerPixel, editor.m_bytePerPixel != 1, filter.Factor, filter.Bias);
		}

		/// <summary>
		/// Rotates image 90 degrees to the right. Result is returned and saved in internal structure. If you want to commit this changes, then call 
		/// SaveChanges() method inherited form <see cref="BaseImageEditor"/>.
		/// </summary>
		/// <returns>Image after effect.</returns>
		public async Task<Bitmap> RotateAsync()
		{
			await m_initTask;
			var processedBytes = this.Rotate();
			return CreateBitmapFromByteArrayAsync(processedBytes, (int)PixelWidth, (int)PixelHeight);
		}

		/// <summary>
		/// Applies brightness to the image. Result is returned and saved in internal structure. If you want to commit this changes, then call 
		/// SaveChanges() method inherited form <see cref="BaseImageEditor"/>.
		/// </summary>
		/// <param name="brightness">Brightness level. Could be both positive and negative. Keep in mind that too large values
		/// can lead to byte overflow or underflow.
		/// </param>
		/// <returns>Image after effect.</returns>
		public async Task<Bitmap> ApplyBrightnessAsync(int brightness)
		{
			await m_initTask;
			var processedBytes = m_workingImageInBytes;
			if (brightness != 0)
			{
				processedBytes = this.ApplyBrightness(m_brightnessImageBytes, brightness);
				m_filterImageBytes = processedBytes;
				m_workingImageInBytes = processedBytes;
			}
			Brightness = brightness;
			return CreateBitmapFromByteArrayAsync(processedBytes, (int)PixelWidth, (int)PixelHeight);
		}

		/// <summary>
		/// Gets the working image.
		/// </summary>
		/// <value>The working image.</value>
		public Bitmap WorkingImage { get { return CreateBitmapFromByteArrayAsync(m_workingImageInBytes, (int)PixelWidth, (int)PixelHeight); } }

		/// <summary>
		/// Gets the current applied brightness.
		/// </summary>
		/// <value>The brightness.</value>
		public int Brightness { get; private set;}

		/// <summary>
		/// Gets the current applied filter. Returns null if none.
		/// </summary>
		/// <value>The filter.</value>
		public Filter Filter { get; private set; }

		/// <summary>
		/// Saves working image in a file with specified filename in a folder where original image is located.
		/// </summary>
		/// <param name="stream">Destination stream.</param>
		/// <param name="suffix">file type</param>
		public override async Task Save(Stream stream, string suffix)
		{
			await m_initTask;
			HasUnsavedChange = false;
			IBitmapEncoder encoder = new DroidBitmapEncoder(stream, suffix);
			await this.WriteBytesToEncoder(encoder);
		}

		//converts image to byte array with help of bitmap decoder.
		private async Task<byte[]> LoadFromStream(IBitmapDecoder decoder)
		{
			m_pixelFormat = (Shared.Data.PixelFormat)decoder.PixelFormat;
			var imageBytes = await decoder.GetPixelDataAsync();
			m_workingImageInBytes = m_filterImageBytes = m_brightnessImageBytes = imageBytes;
			m_imageHeight = decoder.PixelHeight;
			m_imageWidth = decoder.PixelWidth;
			m_dpiX = decoder.DpiX;
			m_dpiY = decoder.DpiY;
			m_bytePerPixel = ImageToolkit.ConvertBitmapPixelFormat(m_pixelFormat);

			return imageBytes;
		}

		/// <summary>
		/// Creates visual image from byte array.
		/// </summary>
		/// <param name="imagePixels">Source buffer of bytes.</param>
		/// <param name="pixelWidth">Image width in pixels.</param>
		/// <param name="pixelHeight">Image height in pixels.</param>
		/// <returns>Bitmap</returns>
		public Bitmap CreateBitmapFromByteArrayAsync(byte[] imagePixels, int pixelWidth, int pixelHeight)
		{
			return DroidBitmapEncoder.CreateBitmap(imagePixels, pixelWidth, pixelHeight, m_pixelFormat);
		}
	}
}
