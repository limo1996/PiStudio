using PiStudio.Shared.Data;
using System;
using Windows.UI.Xaml.Data;

namespace PiStudio.Win10.Data
{
    public class LanguageToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Language lang = (Language)value;
            if (lang == WinAppResources.Instance.ApplicationLanguage.Language)
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
