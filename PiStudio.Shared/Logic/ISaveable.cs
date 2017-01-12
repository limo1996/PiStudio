using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStudio.Shared
{
    public interface ISaveable
    {
        bool IsUnsavedChange { get; }
        void SaveChanges();
        Task Save(Stream stream);
        void Dismiss();
    }
}
