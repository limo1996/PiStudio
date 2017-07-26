using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android.Graphics;

using PiStudio.Shared;
namespace PiStudio.Droid
{
	/// <summary>
	/// Static class that writes curves to the image.
	/// </summary>
	public static class SVGSaver
	{
		/// <summary>
		/// Writes paths into image. Stretches the paths if the image is smaller than its original size
		/// </summary>
		/// <param name="stream">Image stream</param>
		/// <param name="paths">Lines from canvas</param>
		/// <param name="inkWidth">width of the canvas</param>
		/// <param name="inkHeight">height of the canvas</param>
		/// <param name="suffix">file type</param>
		/// <returns></returns>
		public static async Task<byte[]> Save(byte[] pixels, double imgWidth, double imgHeight, IList<SVGCurve> paths, double inkWidth, double inkHeight, string suffix)
		{
			int i = pixels.Length;

			double translateX = imgWidth / inkWidth, translateY = imgHeight / inkHeight;
			var buffer = ImageToolkit.TransformPixels(pixels);
			foreach (var pathInfo in paths)
			{
				var points = pathInfo.Data;
				int color = ConvertColorToInt(pathInfo.Color);
				Point lastPoint = null;
				foreach (var p in points)
				{
					if (lastPoint != null)
					{
						ImagePathSaver.AAWidthLine((int)imgWidth, (int)imgHeight, buffer, (int)Math.Round(lastPoint.X * translateX),
							(int)Math.Round(lastPoint.Y * translateY), (int)Math.Round(p.X * translateX), (int)Math.Round(p.Y * translateY),
							(float)(pathInfo.Thickness * translateX), color);

						//By placing circles at the end of each line we create "smooth" effect of the curve
						ImagePathSaver.FillEllipseCentered((int)imgWidth, (int)imgHeight, buffer, (int)Math.Round(p.X * translateX), (int)Math.Round(p.Y * translateY),
							(int)(pathInfo.Thickness * translateX / 2), (int)(pathInfo.Thickness * translateX / 2), color);
					}
					lastPoint = p;
				}
			}

			return ImageToolkit.TransformPixelsBack(buffer);
		}

		private static int ConvertColorToInt(Color color)
		{
			return color.ToArgb();
		}
	}
}
