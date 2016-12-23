using System;
using System.Threading.Tasks;
using PiStudio.Shared.Data;
using System.IO;

namespace PiStudio.Shared
{
	public interface IImageEditor
	{
		bool IsUnsavedChanges { get; }
        uint PixelWidth { get; }
        uint PixelHeight { get; }
        byte PixelSize { get; }
        string MimeType { get; }
        Task SaveAsync(string filepath);
		void SaveChanges(); 
		IBitmapDecoder Decoder { get; set; }
        IBitmapEncoder Encoder { get; set; }
        Task WriteBytesToEncoder(byte[] imageBytes, uint pixelWidth, uint pixelHeight, IBitmapEncoder encoder);
    }
}
