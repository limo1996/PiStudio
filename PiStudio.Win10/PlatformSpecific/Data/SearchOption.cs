using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace PiStudio.Win10.Data
{
    /// <summary>
    /// Data class for binding data to search box
    /// </summary>
    public class SearchOption : INotifyPropertyChanged
    {
        private string m_text;
        private Symbol m_symbol;
        private Theme m_theme;

        /// <summary>
        /// Text that will be displayed in the row
        /// </summary>
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

        /// <summary>
        /// Icon that is displayed on the left side.
        /// </summary>
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

        /// <summary>
        /// Style of the row.
        /// </summary>
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

        public override string ToString()
        {
            return m_text;
        }
    }
}
