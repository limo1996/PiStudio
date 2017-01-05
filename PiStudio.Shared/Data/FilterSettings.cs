using System.ComponentModel;

namespace PiStudio.Shared.Data
{
    public class FilterSettings : INotifyPropertyChanged
    {
        private string m_filterName;
        private bool? m_isEnabled;
        private Filter m_filter;

        public FilterSettings(Filter filter, bool isEnabled)
        {
            m_filter = filter;
            m_filterName = filter.Name;
            m_isEnabled = isEnabled;
        }

        public string FilterName
        {
            get
            {
                return m_filterName;
            }
            set
            {
                m_filterName = value;
                OnPropertyChanged("FilterName");
            }
        }

        public bool? IsEnabled
        {
            get
            {
                return m_isEnabled;
            }
            set
            {
                m_isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        public Filter Filter
        {
            get
            {
                return m_filter;
            }
            set
            {
                m_filter = value;
                OnPropertyChanged("Filter");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
