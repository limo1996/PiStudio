using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace PiStudio.Win10.Data
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var color = (Color)value;
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var brush = (SolidColorBrush)value;
            return brush.Color;
        }
    }
}
