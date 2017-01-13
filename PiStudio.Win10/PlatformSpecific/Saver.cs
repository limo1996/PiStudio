using PiStudio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Foundation;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Graphics.Imaging;
using PiStudio.Shared.Data;
using Windows.Storage.Streams;
using PiStudio.Win10.UI.Controls;

namespace PiStudio.Win10
{
    public static class Saver
    {
        public static async Task SaveToFile(StorageFile file, ISaveable obj)
        {
            using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                await SaveToStream(fileStream, obj, file.Name);
            }
        }

        public static async Task<StorageFile> GetTempFile()
        {
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync(WinAppResources.Instance.TmpImageName);
            if (item != null)
            {
                return (StorageFile)item;
            }
            else
                return await ApplicationData.Current.LocalFolder.CreateFileAsync(WinAppResources.Instance.TmpImageName);
        }

        public static async Task SaveTemp(ISaveable obj)
        {
            var file = await GetTempFile();
            using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                await SaveToStream(fileStream, obj, file.Name);
            }
        }


        private static async Task SaveToStream(IRandomAccessStream fileStream, ISaveable obj, string fileName)
        {
            /*using (var stream = fileStream.CloneStream())
            {
                stream.Seek(0);*/
                await obj.Save(fileStream.AsStream());
            /*    stream.Seek(0);
                stream.AsStream().CopyTo(fileStream.AsStream());
            }
            */
            /*using (var rstream = new InMemoryRandomAccessStream())
            {
                //IRandomAccessStream rstream = output.AsRandomAccessStream();//await savefile.OpenAsync(FileAccessMode.ReadWrite);
                string suffix = null;
                int index = fileName.LastIndexOf('.');
                if (index == -1)
                    suffix = "jpeg";
                else
                    suffix = fileName.Substring(index);
                WinBitmapEncoder encoder = await WinBitmapEncoder.CreateAsync(rstream.AsStream(), suffix);
                // Get pixels of the WriteableBitmap object 
                byte[] pixels = null;
                using (Stream pixelStream = originalImage.PixelBuffer.AsStream())
                {
                    pixels = new byte[pixelStream.Length];
                    await pixelStream.ReadAsync(pixels, 0, pixels.Length);
                }
                // Save the image file with jpg extension 
                encoder.SetPixelData(PixelFormat.Bgra8, false, (uint)originalImage.PixelWidth, (uint)originalImage.PixelHeight, 96.0, 96.0, pixels);
                await encoder.FlushAsync();
                fileStream.Seek(0);
                await rstream.AsStream().CopyToAsync(fileStream.AsStream());
            }
            return originalImage;*/
        }
    }
}
