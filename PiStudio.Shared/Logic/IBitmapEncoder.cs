using PiStudio.Shared.Data;
using System.Threading.Tasks;

namespace PiStudio.Shared
{
    public interface IBitmapEncoder
    {
        Task SetPixelDataAsync(PixelFormat format, bool ignoreAlphaMode, uint pixelWidth, uint pixelHeight, double dpiX, double dpiY, byte[] pixels);
        Task FlushAsync();
    }
}
