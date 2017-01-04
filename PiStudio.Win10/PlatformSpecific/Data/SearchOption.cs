using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace PiStudio.Win10.Data
{
    public class SearchOption : INotifyPropertyChanged
    {
        private string m_text;
        private Symbol m_symbol;
        private Theme m_theme;

        public string Text
        {
            get
            {
                return m_text;
            }
            set
            {
                m_text = value;
                OnPropertyChanged("Text");
            }
        }

        public Symbol Symbol
        {
            get
            {
                return m_symbol;
            }
            set
            {
                m_symbol = value;
                OnPropertyChanged("Symbol");
            }
        }

        public Theme ApplicationTheme
        {
            get
            {
                return m_theme;
            }
            set
            {
                m_theme = value;
                OnPropertyChanged("ApplicationTheme");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
