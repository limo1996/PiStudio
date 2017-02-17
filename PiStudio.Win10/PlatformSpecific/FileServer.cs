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
using Windows.ApplicationModel;

namespace PiStudio.Win10
{
    public static class FileServer
    {
        public static async Task SaveToFileAsync(StorageFile file, ISaveable obj)
        {
            await semaphore2.WaitAsync();

            // Prevent updates to the remote version of the file until
            // we finish making changes and call CompleteUpdatesAsync.
            CachedFileManager.DeferUpdates(file);
            using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                await SaveToStreamAsync(fileStream, obj, file.Name);
            }

            // Let Windows know that we're finished changing the file so
            // the other app can update the remote version of the file.
            // Completing updates may require Windows to ask for user input.
            Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
            semaphore2.Release();
        }

        private static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private static SemaphoreSlim semaphore2 = new SemaphoreSlim(1,1);
        public static async Task<StorageFile> GetTempFileAsync()
        {
            await semaphore.WaitAsync();
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync(WinAppResources.Instance.TmpImageName);
            if (item == null)
                item = await ApplicationData.Current.LocalFolder.CreateFileAsync(WinAppResources.Instance.TmpImageName);
            semaphore.Release();
            return (StorageFile)item;
        }

        public static async Task SaveTempAsync(ISaveable obj)
        {
            var file = await GetTempFileAsync();
            await semaphore.WaitAsync();
            using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                await SaveToStreamAsync(fileStream, obj, file.Name);
            }
            semaphore.Release();
        }

        private static async Task SaveToStreamAsync(IRandomAccessStream fileStream, ISaveable obj, string fileName)
        {
            var index = fileName.LastIndexOf(".");
            var suffix = "jpg";
            if (index > -1)
                suffix = fileName.Substring(index);
            await obj.Save(fileStream.AsStream(), suffix);
        }

        public static async Task<StorageFile> GetLogoAsync()
        {
            return await Package.Current.InstalledLocation.GetFileAsync("Assets\\StoreLogo.png");
        }
    }
}
