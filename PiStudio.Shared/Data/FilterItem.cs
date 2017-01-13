using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStudio.Shared.Data
{
    /// <summary>
    /// Filter item that is used in data binding.
    /// </summary>
    public class FilterItem
    {
        /// <summary>
        /// Image that has already been processed by the filter.
        /// </summary>
        public object Source { get; set; }

        /// <summary>
        /// Filter text. Usually its name.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Rating of the filter
        /// </summary>
        public int Rating { get; set; }
    }
}
