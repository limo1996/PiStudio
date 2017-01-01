using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStudio.Shared
{
    public interface ISaveable
    {
        bool IsUnsavedChange { get; }
        void SaveChanges();
    }
}
