using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;

namespace ImageProcessing.Back_End
{
    public class ImageConverter
    {
        public ImageConverter()
        {

        }

        public byte[] ConvertToARGB(byte[] imageBytes, BitmapPixelFormat pixelFormat)
        {
            if (pixelFormat == BitmapPixelFormat.Rgba8)
                return this.ConvertFromRGBA8ToARGB8(imageBytes);
            if (pixelFormat == BitmapPixelFormat.Rgba16)
                return this.ConvertFromRGBA16ToARGB16(imageBytes);
            if (pixelFormat == BitmapPixelFormat.Bgra8)
                return this.ConvertFromBGRA8ToARGB8(imageBytes);
            else
                return null;
        }

        public double[] ConvertFromRGBAtoHSL(byte[] imageBytes)
        {
            double[] returned = new double[imageBytes.Length];
            for(int i = 0; i < imageBytes.Length; i+=4)
            {
                double[] tmp = Convert1PixelFromRGBAtoHSL(imageBytes[i], imageBytes[i + 1], imageBytes[i + 2]);
                for (int j = 0; j < 3; j++)
                    returned[i + j] = tmp[j];
                returned[i + 3] = imageBytes[i + 3];
            }
            return returned;
        }

        public byte[] ConvertFromHSLToRGBA(double[] imageBytes)
        {
            byte[] returned = new byte[imageBytes.Length];
            for (int i = 0; i < imageBytes.Length; i += 4)
            {
                byte[] tmp = Convert1PixelFromHSLToRGB(imageBytes[i], imageBytes[i + 1], imageBytes[i + 2]);
                for (int j = 0; j < 3; j++)
                    returned[i + j] = tmp[j];
                returned[i + 3] =(byte)imageBytes[i + 3];
            }
            return returned;
        }

        private double[] Convert1PixelFromRGBAtoHSL(byte r, byte g, byte b)
        {
            double rDot = ((double)r) / 255;
            double gDot = ((double)g) / 255;
            double bDot = ((double)b) / 255;
            double Cmax = Math.Max(rDot, Math.Max(gDot, bDot));
            double Cmin = Math.Min(rDot, Math.Min(gDot, bDot));
            double delta = Cmax - Cmin;

            double h;
            if (delta == 0)
                h = 0;
            else if (rDot == Cmax)
                h = 60 * (((gDot - bDot) / delta) % 6);
            else if (gDot == Cmax)
                h = (bDot - rDot) / delta + 2;
            else
                h = (rDot - gDot) / delta + 4;

            double l = (Cmax + Cmin) / 2;
            double s;
            if (delta == 0)
                s = 0;
            else
                s = delta / (1 - Math.Abs(2 * l - 1));
            return new double[3] { h, s, l };
        }

        private byte[] Convert1PixelFromHSLToRGB(double h, double s, double l)
        {
            double C = (1 - Math.Abs(2 * l - 1)) * s;
            double X = C * (1 - Math.Abs((((double)h / 60) % 2) - 1));
            double m = l - C / 2;

            double rDot = 0, gDot = 0, bDot = 0;
            if(0 <= h && h < 60)
            {
                rDot = C;
                gDot = X;
                bDot = 0;
            }
            else if (60 <= h && h < 120)
            {
                rDot = X;
                gDot = C;
                bDot = 0;
            }
            else if(120 <= h && h < 180)
            {
                rDot = 0;
                gDot = C;
                bDot = X;
            }
            else if(180 <= h && h < 240)
            {
                rDot = 0;
                gDot = X;
                bDot = C;
            }
            else if(240 <= h && h < 300)
            {
                rDot = X;
                gDot = 0;
                bDot = C;
            }
            else if(300 <= h && h < 360)
            {
                rDot = C;
                gDot = 0;
                bDot = X;
            }
            double R = ((rDot + m) * 255);
            double G = ((gDot + m) * 255);
            double B = ((bDot + m) * 255);

            R = R > 255 ? 255 : R;
            R = R < 0 ? 0 : R;

            G = G > 255 ? 255 : G;
            G = G < 0 ? 0 : G;

            B = B > 255 ? 255 : B;
            B = B < 0 ? 0 : B;

            return new byte[3] { (byte)R, (byte)G, (byte)B };
        }

        public byte[] ConvertToRGBA(byte[] imageBytes, BitmapPixelFormat pixelFormat)
        {
            if (pixelFormat == BitmapPixelFormat.Bgra8)
                return this.ConvertFromBGRA8ToRGBA8(imageBytes);
            return null;
        }

        private byte[] ConvertFromRGBA8ToARGB8(byte[] imagePixels)
        {
            byte[] newImageBytes = new byte[imagePixels.Length];
            for (int i = 0; i < imagePixels.Length; i += 4)
            {
                newImageBytes[i] = imagePixels[i + 3];
                newImageBytes[i + 1] = imagePixels[i];
                newImageBytes[i + 2] = imagePixels[i + 1];
                newImageBytes[i + 3] = imagePixels[i + 2];
            }
            return newImageBytes;
        }

        private byte[] ConvertFromRGBA16ToARGB16(byte[] imagePixels)
        {
            byte[] newImageBytes = new byte[imagePixels.Length];
            for (int i = 0; i < imagePixels.Length; i += 4)
            {
                newImageBytes[i] = imagePixels[i + 6];
                newImageBytes[i + 1] = imagePixels[i + 7];
                newImageBytes[i + 2] = imagePixels[i];
                newImageBytes[i + 3] = imagePixels[i + 1];
                newImageBytes[i + 4] = imagePixels[i + 2];
                newImageBytes[i + 5] = imagePixels[i + 3];
                newImageBytes[i + 6] = imagePixels[i + 4];
                newImageBytes[i + 7] = imagePixels[i + 5];
            }
            return newImageBytes;
        }

        private byte[] ConvertFromBGRA8ToARGB8(byte[] imagePixels)
        {
            byte[] newImageBytes = new byte[imagePixels.Length];
            for (int i = 0; i < imagePixels.Length; i += 4)
            {
                newImageBytes[i] = imagePixels[i + 3];
                newImageBytes[i + 1] = imagePixels[i + 2];
                newImageBytes[i + 2] = imagePixels[i + 1];
                newImageBytes[i + 3] = imagePixels[i];
            }
            return newImageBytes;
        }

        private byte[] ConvertFromBGRA8ToRGBA8(byte[] imagePixels)
        {
            byte[] newImageBytes = new byte[imagePixels.Length];
            for (int i = 0; i < imagePixels.Length; i += 4)
            {
                newImageBytes[i] = imagePixels[i + 2];
                newImageBytes[i + 1] = imagePixels[i + 1];
                newImageBytes[i + 2] = imagePixels[i];
                newImageBytes[i + 3] = imagePixels[i + 3];
            }
            return newImageBytes;
        }
    }
}
