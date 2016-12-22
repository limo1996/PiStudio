using System;
using System.Threading.Tasks;
using PiStudio.Shared.Data;
using System.IO;

namespace PiStudio.Shared
{
	public interface IImageEditor
	{
		bool IsUnsavedChanges { get; set; }
		Task<IEditableBitmap> ApplyFilterAsync(Filter filter);
		Task<IEditableBitmap> RotateAsync();
		Task<IEditableBitmap> ApplyBrightnessAsync();
		void SaveChanges();
		Task SaveAsync(string filepath);
		Task<IEditableBitmap> CreateBitmapFromByteArrayAsync(byte[] imagePixels);
		Task WriteBytesToStream(byte[] imageBytes, Stream stream, string fileFormat, IBitmapEncoder encoder);
	}
}
