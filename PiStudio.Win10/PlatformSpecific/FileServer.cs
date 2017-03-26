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
    /// <summary>
    /// Class that should be used for all operations related to temporary image stored in app's local folder.
    /// </summary>
    public static class FileServer
    {
        /// <summary>
        /// Saves given object to given file thread safe.
        /// </summary>
        /// <param name="file">Destination <see cref="StorageFile"/></param>
        /// <param name="obj">Object that will be saved to file by calling Save(Stream) method.</param>
        /// <returns></returns>
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

            await file.CopyAsync(ApplicationData.Current.LocalFolder, WinAppResources.Instance.TmpImageName, NameCollisionOption.ReplaceExisting);
            // Let Windows know that we're finished changing the file so
            // the other app can update the remote version of the file.
            // Completing updates may require Windows to ask for user input.
            Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
            semaphore2.Release();
        }

        private static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private static SemaphoreSlim semaphore2 = new SemaphoreSlim(1,1);

        /// <summary>
        /// Gets temp file from application's folder thread safe.
        /// </summary>
        /// <returns>File from local folder.</returns>
        public static async Task<StorageFile> GetTempFileAsync()
        {
            await semaphore.WaitAsync();
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync(WinAppResources.Instance.TmpImageName);
            if (item == null)
                item = await ApplicationData.Current.LocalFolder.CreateFileAsync(WinAppResources.Instance.TmpImageName);
            semaphore.Release();
            return (StorageFile)item;
        }

        /// <summary>
        /// Saves object to temp file asynchronously and overrides file if needed.
        /// </summary>
        /// <param name="obj">Object that will be saved.</param>
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

        /// <summary>
        /// Saves given object to given stream of given file type.
        /// </summary>
        /// <remarks>
        /// File type is obtained by slicing the suffix of given file name.
        /// </remarks>
        private static async Task SaveToStreamAsync(IRandomAccessStream fileStream, ISaveable obj, string fileName)
        {
            var index = fileName.LastIndexOf(".");
            var suffix = "jpg";
            if (index > -1)
                suffix = fileName.Substring(index);
            await obj.Save(fileStream.AsStream(), suffix);
        }

        /// <summary>
        /// Gets the file containing app's logo.
        /// </summary>
        public static async Task<StorageFile> GetLogoAsync()
        {
            return await Package.Current.InstalledLocation.GetFileAsync("Assets\\StoreLogo.png");
        }
    }
}
