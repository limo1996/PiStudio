using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStudio.Shared.Data
{
    /// <summary>
    /// Specifies the pixel format of pixel data. Each enumeration value defines 
    /// a channel ordering, bit depth, and data type.
    /// </summary>
    public enum PixelFormat
    {
        /// <summary>
        /// The pixel format is unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The pixel format is R16B16G16A16 unsigned integer.
        /// </summary>
        Rgba16 = 12,

        /// <summary>
        /// The pixel format is R8G8B8A8 unsigned integer.
        /// </summary>
        Rgba8 = 30,

        /// <summary>
        /// The pixel format is B8G8R8A8 unsigned integer.
        /// </summary>
        Bgra8 = 87,

        /// <summary>
        /// The pixel format is 16 bpp grayscale.
        /// </summary>
        Gray16 = 57,

        /// <summary>
        /// The pixel format is 8 bpp grayscale.
        /// </summary>
        Gray8 = 62,

        /// <summary>
        /// The pixel format is NV12.
        /// </summary>
        Nv12 = 103,

        /// <summary>
        /// The pixel format is YUY2.
        /// </summary>
        Yuy2 = 107
    }
}
