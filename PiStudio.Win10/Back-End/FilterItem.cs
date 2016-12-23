using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ImageProcessing
{
    public class FilterItem
    {
        public WriteableBitmap Source { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
    }
}
