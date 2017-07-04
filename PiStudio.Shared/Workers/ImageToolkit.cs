using System;
using PiStudio.Shared.Data;

namespace PiStudio.Shared
{
	public static class ImageToolkit
	{
		/// <summary>
		/// Applies kernel matrix on pixel data.
		/// </summary>
		/// <param name="imageBytes">Raw pixel data.</param>
		/// <param name="imageWidth">Image resolution in X axis.</param>
		/// <param name="imageHeight">Image resolution in Y axis.</param>
		/// <param name="kernelMatrix">Kernel matrix that will be applied on image pixels.</param>
		/// <param name="bytePerPixel">Size of the one pixel.</param>
		/// <param name="isAlpha">Specifies whether image bytes have alpha color. Alpha pixel is considered to be the last pixel.</param>
		/// <param name="factor">Number which will be used in multiplication each pixel (except alpha) with it. </param>
		/// <param name="bias">Number that will be added to each pixel except aplha pixel.</param>
		/// <returns></returns>
		public static byte[] ApplyConvolutionMatrixFilter(byte[] imageBytes, int imageWidth, int imageHeight, double[,] kernelMatrix,
														  byte bytePerPixel, bool isAlpha, double factor = 1, double bias = 0)
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

		public static byte ConvertBitmapPixelFormat(PixelFormat format)
		{
			if (format == PixelFormat.Bgra8 || format == PixelFormat.Rgba8 || format == PixelFormat.Argb8888)
				return 4;
			if (format == PixelFormat.Gray16)
				return 2;
			if (format == PixelFormat.Gray8)
				return 1;
			if (format == PixelFormat.Rgba16)
				return 8;
			return 1;
		}

		/// <summary>
		/// Rotates given pixel data to the right.
		/// </summary>
		/// <param name="imageBytes">Raw pixel data.</param>
		/// <param name="imageWidth">Image resolution in X axis.</param>
		/// <param name="imageHeight">Image resolution in Y axis.</param>
		/// <param name="bytePerPixel">Size of the one pixel.</param>
		public static byte[] Rotate(byte[] imageBytes, uint imageWidth, uint imageHeight, byte bytePerPixel)
		{
			byte[] returned = new byte[imageWidth * imageHeight * bytePerPixel];
			var i = 0;
			for (int x = 0; x < imageWidth; ++x)
			{
				for (int y = (int)(imageHeight - 1); y >= 0; --y)
				{
					var srcInd = y * imageWidth + x;
					for (int k = 0; k < bytePerPixel; k++)
						returned[i * bytePerPixel + k] = imageBytes[srcInd * bytePerPixel + k];
					i++;
				}
			}
			/*for (int i = 0; i < imageHeight; i++)
			{
				for (int j = 0; j < imageWidth ; j++)
				{
                    for(int k =0; k < bytePerPixel; k++)
					    returned[((i * imageWidth) + j) * bytePerPixel + k] = imageBytes[((imageHeight - 1 - i) * imageWidth + j) * bytePerPixel + k];
				}
			}*/
			return returned;
		}

		/// <summary>
		/// Changes brightness of the image.
		/// </summary>
		/// <param name="imageBytes"></param>
		/// <param name="bytePerPixel"></param>
		/// <param name="brightness"></param>
		/// <returns></returns>
		public static byte[] ApplyBrightness(byte[] imageBytes, byte bytePerPixel, bool isAplha, int brightness)
		{
			byte[] imageBytes2 = new byte[imageBytes.Length];
			for (int i = 0; i < imageBytes.Length; i++)
			{
				if ((i + 1) % bytePerPixel != 0 || !isAplha)
				{
					int tmp = imageBytes[i] + brightness;
					imageBytes2[i] = (byte)(Math.Min(Math.Max(tmp, 0), 255));
				}
				else
					imageBytes2[i] = imageBytes[i];
			}
			return imageBytes2;
		}

		public static int[] TransformPixels(byte[] data, PixelFormat format = PixelFormat.Rgba8)
		{
			var indexes = new[] { 3, 2, 1, 0 };
			if (format == PixelFormat.Argb8888)
				indexes = new[] { 3, 0, 1, 2};
			int[] pixels = new int[data.Length / 4];
			for (var i = 0; i < pixels.Length; i++)
			{
				pixels[i] = (data[i * 4 + indexes[0]] << 24)
						  | (data[i * 4 + indexes[1]] << 16)
						  | (data[i * 4 + indexes[2]] << 8)
						  | data[i * 4 + indexes[3]];
			}
			return pixels;
		}

		public static byte[] TransformPixelsBack(int[] data)
		{
			byte[] pixels = new byte[data.Length * 4];
			for (var i = 0; i < pixels.Length; i += 4)
			{
				var d = data[i / 4];
				pixels[i] = (byte)((d & 0x000000ff) >> 0); //b
				pixels[i + 1] = (byte)((d & 0x0000ff00) >> 8); //g
				pixels[i + 2] = (byte)((d & 0x00ff0000) >> 16); //r
				pixels[i + 3] = (byte)((d & 0xff000000) >> 24); //a
			}
			return pixels;
		}
	}
}

//111 2 3      7 4 111
//4 5 6  =>  8 5 2
//7 8 9		 9 6 3

//(0,0) => (0,2)
//(0,1) => (1,2)
//(0,2) => (2,2)
//(1,0) => (0,1)
//(1,1) => (1,1)
//(1,2) => (2,1)
//(2,0) => (0,0)
//(2,1) => (1,0)
//(2,2) => (2,0)

//(x,y) => (y,max-x)



//1 2	 5 3 1
//3 4 => 6 4 2
//5 6

//(0,0) => (0,2)
//(0,1) => (1,2)
//(1,0) => (0,1)
//(1,1) => (1,1)
//(2,0) => (0,0)
//(2,1) => (1,0)
