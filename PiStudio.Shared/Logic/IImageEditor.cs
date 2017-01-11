using System.Threading.Tasks;

namespace PiStudio.Shared
{
    public interface IImageEditor : ISaveable
	{
        uint PixelWidth { get; }
        uint PixelHeight { get; }
        byte PixelSize { get; }
        string MimeType { get; }
		IBitmapDecoder Decoder { get; set; }
        IBitmapEncoder Encoder { get; set; }
        Task WriteBytesToEncoder(byte[] imageBytes, uint pixelWidth, uint pixelHeight, IBitmapEncoder encoder);
    }
}
