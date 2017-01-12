using PiStudio.Win10.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI;

namespace PiStudio.Win10
{
    public static class SVGSaver
    {
        /// <summary>
        /// Writes paths into image. Stretches the paths if image, the paths were drawn on, was smaller than its original size
        /// </summary>
        /// <param name="stream">Image stream</param>
        /// <param name="paths">Lines from canvas</param>
        /// <param name="inkWidth">width of the canvas</param>
        /// <param name="inkHeight">height of the canvas</param>
        /// <returns></returns>
        public static async Task Save(IRandomAccessStream stream, IList<SVGCurve> paths, double inkWidth, double inkHeight)
        {
            byte[] pixels = null;
            double imgWidth = 0, imgHeight = 0;
            var decoder = await BitmapDecoder.CreateAsync(stream);
            stream.Seek(0);//decoder.DecoderInformation.
            pixels = (await decoder.GetPixelDataAsync()).DetachPixelData();
            imgWidth = decoder.PixelWidth;
            imgHeight = decoder.PixelHeight;

            int i = pixels.Length;

            double translateX = imgWidth / inkWidth, translateY = imgHeight / inkHeight;
            var buffer = TransformPixels(pixels);
            foreach (var pathInfo in paths)
            {
                var points = pathInfo.Data;
                int color = ConvertColorToInt(pathInfo.Color);
                Point? lastPoint = null;
                foreach (var p in points)
                {
                    if (lastPoint.HasValue)
                        AAWidthLine((int)imgWidth, (int)imgHeight, buffer, (int)Math.Round(lastPoint.Value.X * translateX),
                            (int)Math.Round(lastPoint.Value.Y * translateY), (int)Math.Round(p.X * translateX), (int)Math.Round(p.Y * translateY),
                            (float)(pathInfo.Thickness * translateX), color);
                    lastPoint = p;
                }
            }

            pixels = TransformPixelsBack(buffer);

            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
            encoder.SetPixelData(decoder.BitmapPixelFormat, decoder.BitmapAlphaMode, (uint)imgWidth, (uint)imgHeight, decoder.DpiX, decoder.DpiY, pixels);
            await encoder.FlushAsync();
        }

        private static int ConvertColorToInt(Color color)
        {
            return (color.A << 24) | (color.R << 16) | (color.G << 8) | (color.B << 0);
        }

        private static readonly int[] leftEdgeX = new int[8192];
        private static readonly int[] rightEdgeX = new int[8192];

        /// <summary>
        /// Bitfields used to partition the space into 9 regions
        /// </summary>
        private const byte INSIDE = 0; // 0000
        private const byte LEFT = 1;   // 0001
        private const byte RIGHT = 2;  // 0010
        private const byte BOTTOM = 4; // 0100
        private const byte TOP = 8;    // 1000
        internal static bool CohenSutherlandLineClipWithViewPortOffset(Rect viewPort, ref float xi0, ref float yi0, ref float xi1, ref float yi1, int offset)
        {
            var viewPortWithOffset = new Rect(viewPort.X - offset, viewPort.Y - offset, viewPort.Width + 2 * offset, viewPort.Height + 2 * offset);

            return CohenSutherlandLineClip(viewPortWithOffset, ref xi0, ref yi0, ref xi1, ref yi1);
        }

        internal static bool CohenSutherlandLineClip(Rect extents, ref float xi0, ref float yi0, ref float xi1, ref float yi1)
        {
            // Fix #SC-1555: Log(0) issue
            // CohenSuzerland line clipping algorithm returns NaN when point has infinity value
            double x0 = ClipToInt(xi0);
            double y0 = ClipToInt(yi0);
            double x1 = ClipToInt(xi1);
            double y1 = ClipToInt(yi1);

            var isValid = CohenSutherlandLineClip(extents, ref x0, ref y0, ref x1, ref y1);

            // Update the clipped line
            xi0 = (float)x0;
            yi0 = (float)y0;
            xi1 = (float)x1;
            yi1 = (float)y1;

            return isValid;
        }

        private static float ClipToInt(float d)
        {
            if (d > int.MaxValue)
                return int.MaxValue;

            if (d < int.MinValue)
                return int.MinValue;

            return d;
        }

        internal static bool CohenSutherlandLineClip(Rect extents, ref int xi0, ref int yi0, ref int xi1, ref int yi1)
        {
            double x0 = xi0;
            double y0 = yi0;
            double x1 = xi1;
            double y1 = yi1;

            var isValid = CohenSutherlandLineClip(extents, ref x0, ref y0, ref x1, ref y1);

            // Update the clipped line
            xi0 = (int)x0;
            yi0 = (int)y0;
            xi1 = (int)x1;
            yi1 = (int)y1;

            return isValid;
        }

        /// <summary>
        /// Compute the bit code for a point (x, y) using the clip rectangle
        /// bounded diagonally by (xmin, ymin), and (xmax, ymax)
        /// ASSUME THAT xmax , xmin , ymax and ymin are global constants.
        /// </summary>
        /// <param name="extents">The extents.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        private static byte ComputeOutCode(Rect extents, double x, double y)
        {
            // initialized as being inside of clip window
            byte code = INSIDE;

            if (x < extents.Left)           // to the left of clip window
                code |= LEFT;
            else if (x > extents.Right)     // to the right of clip window
                code |= RIGHT;
            if (y > extents.Bottom)         // below the clip window
                code |= BOTTOM;
            else if (y < extents.Top)       // above the clip window
                code |= TOP;

            return code;
        }

        /// <summary>
        /// Cohen–Sutherland clipping algorithm clips a line from
        /// P0 = (x0, y0) to P1 = (x1, y1) against a rectangle with 
        /// diagonal from (xmin, ymin) to (xmax, ymax).
        /// </summary>
        /// <remarks>See http://en.wikipedia.org/wiki/Cohen%E2%80%93Sutherland_algorithm for details</remarks>
        /// <returns>a list of two points in the resulting clipped line, or zero</returns>
        internal static bool CohenSutherlandLineClip(Rect extents, ref double x0, ref double y0, ref double x1, ref double y1)
        {
            // compute outcodes for P0, P1, and whatever point lies outside the clip rectangle
            byte outcode0 = ComputeOutCode(extents, x0, y0);
            byte outcode1 = ComputeOutCode(extents, x1, y1);

            // No clipping if both points lie inside viewport
            if (outcode0 == INSIDE && outcode1 == INSIDE)
                return true;

            bool isValid = false;

            while (true)
            {
                // Bitwise OR is 0. Trivially accept and get out of loop
                if ((outcode0 | outcode1) == 0)
                {
                    isValid = true;
                    break;
                }
                // Bitwise AND is not 0. Trivially reject and get out of loop
                else if ((outcode0 & outcode1) != 0)
                {
                    break;
                }
                else
                {
                    // failed both tests, so calculate the line segment to clip
                    // from an outside point to an intersection with clip edge
                    double x, y;

                    // At least one endpoint is outside the clip rectangle; pick it.
                    byte outcodeOut = (outcode0 != 0) ? outcode0 : outcode1;

                    // Now find the intersection point;
                    // use formulas y = y0 + slope * (x - x0), x = x0 + (1 / slope) * (y - y0)
                    if ((outcodeOut & TOP) != 0)
                    {   // point is above the clip rectangle
                        x = x0 + (x1 - x0) * (extents.Top - y0) / (y1 - y0);
                        y = extents.Top;
                    }
                    else if ((outcodeOut & BOTTOM) != 0)
                    { // point is below the clip rectangle
                        x = x0 + (x1 - x0) * (extents.Bottom - y0) / (y1 - y0);
                        y = extents.Bottom;
                    }
                    else if ((outcodeOut & RIGHT) != 0)
                    {  // point is to the right of clip rectangle
                        y = y0 + (y1 - y0) * (extents.Right - x0) / (x1 - x0);
                        x = extents.Right;
                    }
                    else if ((outcodeOut & LEFT) != 0)
                    {   // point is to the left of clip rectangle
                        y = y0 + (y1 - y0) * (extents.Left - x0) / (x1 - x0);
                        x = extents.Left;
                    }
                    else
                    {
                        x = double.NaN;
                        y = double.NaN;
                    }

                    // Now we move outside point to intersection point to clip
                    // and get ready for next pass.
                    if (outcodeOut == outcode0)
                    {
                        x0 = x;
                        y0 = y;
                        outcode0 = ComputeOutCode(extents, x0, y0);
                    }
                    else
                    {
                        x1 = x;
                        y1 = y;
                        outcode1 = ComputeOutCode(extents, x1, y1);
                    }
                }
            }

            return isValid;
        }

        public static int[] TransformPixels(byte[] data)
        {
            int[] pixels = new int[data.Length / 4];
            for (var i = 0; i < pixels.Length; i++)
            {
                pixels[i] = (data[i * 4 + 3] << 24)
                          | (data[i * 4 + 2] << 16)
                          | (data[i * 4 + 1] << 8)
                          | data[i * 4 + 0];
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

        public static void AAWidthLine(int width, int height, int[] buffer, float x1, float y1, float x2, float y2, float lineWidth, int color)
        {
            // Perform cohen-sutherland clipping if either point is out of the viewport
            if (!CohenSutherlandLineClip(new Rect(0, 0, width, height), ref x1, ref y1, ref x2, ref y2)) return;
            if (lineWidth <= 0) return;

            if (y1 > y2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }

            if (x1 == x2)
            {
                x1 -= (int)lineWidth / 2;
                x2 += (int)lineWidth / 2;

                if (x1 < 0)
                    x1 = 0;
                if (x2 < 0)
                    return;

                if (x1 >= width)
                    return;
                if (x2 >= width)
                    x2 = width - 1;

                if (y1 >= height || y2 < 0)
                    return;

                if (y1 < 0)
                    y1 = 0;
                if (y2 >= height)
                    y2 = height - 1;

                for (var x = (int)x1; x <= x2; x++)
                {
                    for (var y = (int)y1; y <= y2; y++)
                    {
                        var a = (byte)((color & 0xff000000) >> 24);
                        var r = (byte)((color & 0x00ff0000) >> 16);
                        var g = (byte)((color & 0x0000ff00) >> 8);
                        var b = (byte)((color & 0x000000ff) >> 0);

                        byte rs, gs, bs;
                        byte rd, gd, bd;

                        int d;

                        rs = r;
                        gs = g;
                        bs = b;

                        d = buffer[y * width + x];

                        rd = (byte)((d & 0x00ff0000) >> 16);
                        gd = (byte)((d & 0x0000ff00) >> 8);
                        bd = (byte)((d & 0x000000ff) >> 0);

                        rd = (byte)((rs * a + rd * (0xff - a)) >> 8);
                        gd = (byte)((gs * a + gd * (0xff - a)) >> 8);
                        bd = (byte)((bs * a + bd * (0xff - a)) >> 8);

                        buffer[y * width + x] = (0xff << 24) | (rd << 16) | (gd << 8) | (bd << 0);
                    }
                }

                return;
            }
            if (y1 == y2)
            {
                if (x1 > x2) Swap(ref x1, ref x2);

                y1 -= (int)lineWidth / 2;
                y2 += (int)lineWidth / 2;

                if (y1 < 0) y1 = 0;
                if (y2 < 0) return;

                if (y1 >= height) return;
                if (y2 >= height) x2 = height - 1;

                if (x1 >= width || y2 < 0) return;

                if (x1 < 0) x1 = 0;
                if (x2 >= width) x2 = width - 1;

                for (var x = (int)x1; x <= x2; x++)
                {
                    for (var y = (int)y1; y <= y2; y++)
                    {
                        var a = (byte)((color & 0xff000000) >> 24);
                        var r = (byte)((color & 0x00ff0000) >> 16);
                        var g = (byte)((color & 0x0000ff00) >> 8);
                        var b = (byte)((color & 0x000000ff) >> 0);

                        Byte rs, gs, bs;
                        Byte rd, gd, bd;

                        Int32 d;

                        rs = r;
                        gs = g;
                        bs = b;

                        d = buffer[y * width + x];

                        rd = (byte)((d & 0x00ff0000) >> 16);
                        gd = (byte)((d & 0x0000ff00) >> 8);
                        bd = (byte)((d & 0x000000ff) >> 0);

                        rd = (byte)((rs * a + rd * (0xff - a)) >> 8);
                        gd = (byte)((gs * a + gd * (0xff - a)) >> 8);
                        bd = (byte)((bs * a + bd * (0xff - a)) >> 8);

                        buffer[y * width + x] = (a << 24) | (rd << 16) | (gd << 8) | (bd << 0);
                    }
                }

                return;
            }

            y1 += 1;
            y2 += 1;

            float slope = (y2 - y1) / (x2 - x1);
            float islope = (x2 - x1) / (y2 - y1);

            float m = slope;
            float w = lineWidth;

            float dx = x2 - x1;
            float dy = y2 - y1;

            var xtot = (float)(w * dy / Math.Sqrt(dx * dx + dy * dy));
            var ytot = (float)(w * dx / Math.Sqrt(dx * dx + dy * dy));

            float sm = dx * dy / (dx * dx + dy * dy);

            // Center it.

            x1 += xtot / 2;
            y1 -= ytot / 2;
            x2 += xtot / 2;
            y2 -= ytot / 2;

            //
            //

            float sx = -xtot;
            float sy = +ytot;

            var ix1 = (int)x1;
            var iy1 = (int)y1;

            var ix2 = (int)x2;
            var iy2 = (int)y2;

            var ix3 = (int)(x1 + sx);
            var iy3 = (int)(y1 + sy);

            var ix4 = (int)(x2 + sx);
            var iy4 = (int)(y2 + sy);

            if (lineWidth == 2)
            {
                if (Math.Abs(dy) < Math.Abs(dx))
                {
                    if (x1 < x2)
                    {
                        iy3 = iy1 + 2;
                        iy4 = iy2 + 2;
                    }
                    else
                    {
                        iy1 = iy3 + 2;
                        iy2 = iy4 + 2;
                    }
                }
                else
                {
                    ix1 = ix3 + 2;
                    ix2 = ix4 + 2;
                }
            }

            int starty = Math.Min(Math.Min(iy1, iy2), Math.Min(iy3, iy4));
            int endy = Math.Max(Math.Max(iy1, iy2), Math.Max(iy3, iy4));

            if (starty < 0) starty = -1;
            if (endy >= height) endy = height + 1;

            for (int y = starty + 1; y < endy - 1; y++)
            {
                leftEdgeX[y] = -1 << 16;
                rightEdgeX[y] = 1 << 16 - 1;
            }


            AALineQ1(width, height, buffer, ix1, iy1, ix2, iy2, color, sy > 0, false);
            AALineQ1(width, height, buffer, ix3, iy3, ix4, iy4, color, sy < 0, true);

            if (lineWidth > 1)
            {
                AALineQ1(width, height, buffer, ix1, iy1, ix3, iy3, color, true, sy > 0);
                AALineQ1(width, height, buffer, ix2, iy2, ix4, iy4, color, false, sy < 0);
            }

            if (x1 < x2)
            {
                if (iy2 >= 0 && iy2 < height) rightEdgeX[iy2] = Math.Min(ix2, rightEdgeX[iy2]);
                if (iy3 >= 0 && iy3 < height) leftEdgeX[iy3] = Math.Max(ix3, leftEdgeX[iy3]);
            }
            else
            {
                if (iy1 >= 0 && iy1 < height) rightEdgeX[iy1] = Math.Min(ix1, rightEdgeX[iy1]);
                if (iy4 >= 0 && iy4 < height) leftEdgeX[iy4] = Math.Max(ix4, leftEdgeX[iy4]);
            }

            //return;

            for (int y = starty + 1; y < endy - 1; y++)
            {
                leftEdgeX[y] = Math.Max(leftEdgeX[y], 0);
                rightEdgeX[y] = Math.Min(rightEdgeX[y], width - 1);

                for (int x = leftEdgeX[y]; x <= rightEdgeX[y]; x++)
                {
                    var a = (byte)((color & 0xff000000) >> 24);
                    var r = (byte)((color & 0x00ff0000) >> 16);
                    var g = (byte)((color & 0x0000ff00) >> 8);
                    var b = (byte)((color & 0x000000ff) >> 0);

                    Byte rs, gs, bs;
                    Byte rd, gd, bd;

                    Int32 d;

                    rs = r;
                    gs = g;
                    bs = b;

                    d = buffer[y * width + x];

                    rd = (byte)((d & 0x00ff0000) >> 16);
                    gd = (byte)((d & 0x0000ff00) >> 8);
                    bd = (byte)((d & 0x000000ff) >> 0);

                    rd = (byte)((rs * a + rd * (0xff - a)) >> 8);
                    gd = (byte)((gs * a + gd * (0xff - a)) >> 8);
                    bd = (byte)((bs * a + bd * (0xff - a)) >> 8);

                    buffer[y * width + x] = (a << 24) | (rd << 16) | (gd << 8) | (bd << 0);
                }
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        private static void AALineQ1(int width, int height, int[] buffer, int x1, int y1, int x2, int y2, Int32 color, bool minEdge, bool leftEdge)
        {
            Byte off = 0;

            if (minEdge) off = 0xff;

            if (x1 == x2) return;
            if (y1 == y2) return;

            if (y1 > y2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }

            int deltax = (x2 - x1);
            int deltay = (y2 - y1);

            if (x1 > x2) deltax = (x1 - x2);

            int x = x1;
            int y = y1;

            UInt16 m = 0;

            if (deltax > deltay) m = (ushort)(((deltay << 16) / deltax));
            else m = (ushort)(((deltax << 16) / deltay));

            UInt16 e = 0;

            var a = (byte)((color & 0xff000000) >> 24);
            var r = (byte)((color & 0x00ff0000) >> 16);
            var g = (byte)((color & 0x0000ff00) >> 8);
            var b = (byte)((color & 0x000000ff) >> 0);

            Byte rs, gs, bs;
            Byte rd, gd, bd;

            Int32 d;

            Byte ta = a;

            e = 0;

            if (deltax >= deltay)
            {
                while (deltax-- != 0)
                {
                    if ((UInt16)(e + m) <= e) // Roll
                    {
                        y++;
                    }

                    e += m;

                    if (x1 < x2) x++;
                    else x--;

                    if (y < 0 || y >= height) continue;

                    if (leftEdge) leftEdgeX[y] = Math.Max(x + 1, leftEdgeX[y]);
                    else rightEdgeX[y] = Math.Min(x - 1, rightEdgeX[y]);

                    if (x < 0 || x >= width) continue;

                    //

                    ta = (byte)((a * (UInt16)(((((UInt16)(e >> 8))) ^ off))) >> 8);

                    rs = r;
                    gs = g;
                    bs = b;

                    d = buffer[y * width + x];

                    rd = (byte)((d & 0x00ff0000) >> 16);
                    gd = (byte)((d & 0x0000ff00) >> 8);
                    bd = (byte)((d & 0x000000ff) >> 0);

                    rd = (byte)((rs * ta + rd * (0xff - ta)) >> 8);
                    gd = (byte)((gs * ta + gd * (0xff - ta)) >> 8);
                    bd = (byte)((bs * ta + bd * (0xff - ta)) >> 8);

                    buffer[y * width + x] = (0xff << 24) | (rd << 16) | (gd << 8) | (bd << 0);

                    //
                }
            }
            else
            {
                off ^= 0xff;

                while (--deltay != 0)
                {
                    if ((UInt16)(e + m) <= e) // Roll
                    {
                        if (x1 < x2) x++;
                        else x--;
                    }

                    e += m;

                    y++;

                    if (x < 0 || x >= width) continue;
                    if (y < 0 || y >= height) continue;

                    //

                    ta = (byte)((a * (UInt16)(((((UInt16)(e >> 8))) ^ off))) >> 8);

                    rs = r;
                    gs = g;
                    bs = b;

                    d = buffer[y * width + x];

                    rd = (byte)((d & 0x00ff0000) >> 16);
                    gd = (byte)((d & 0x0000ff00) >> 8);
                    bd = (byte)((d & 0x000000ff) >> 0);

                    rd = (byte)((rs * ta + rd * (0xff - ta)) >> 8);
                    gd = (byte)((gs * ta + gd * (0xff - ta)) >> 8);
                    bd = (byte)((bs * ta + bd * (0xff - ta)) >> 8);

                    buffer[y * width + x] = (0xff << 24) | (rd << 16) | (gd << 8) | (bd << 0);

                    if (leftEdge) leftEdgeX[y] = x + 1;
                    else rightEdgeX[y] = x - 1;
                }
            }
        }

    }
}
