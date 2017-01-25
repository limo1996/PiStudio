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
using System.Threading;

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

        private static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        public static async Task<StorageFile> GetTempFile()
        {
            await semaphore.WaitAsync();
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync(WinAppResources.Instance.TmpImageName);
            if (item == null)
                item = await ApplicationData.Current.LocalFolder.CreateFileAsync(WinAppResources.Instance.TmpImageName);
            semaphore.Release();
            return (StorageFile)item;
        }

        public static async Task SaveTemp(ISaveable obj)
        {
            var file = await GetTempFile();
            await semaphore.WaitAsync();
            using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                await SaveToStream(fileStream, obj, file.Name);
            }
            semaphore.Release();
        }


        private static async Task SaveToStream(IRandomAccessStream fileStream, ISaveable obj, string fileName)
        {
                await obj.Save(fileStream.AsStream());
        }
    }
}
