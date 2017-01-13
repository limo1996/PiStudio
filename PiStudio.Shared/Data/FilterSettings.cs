using System.ComponentModel;

namespace PiStudio.Shared.Data
{
    /// <summary>
    /// Wrapper class for <see cref="Data.Filter"/>. Used for data binding both in settings and filter page.
    /// </summary>
    public class FilterSettings : INotifyPropertyChanged
    {
        //private fields
        private string m_filterName;
        private bool? m_isEnabled;
        private Filter m_filter;

        /// <summary>
        /// Creates new instance of <see cref="FilterSettings"/> class.
        /// </summary>
        /// <param name="filter">Kernel filter</param>
        /// <param name="isEnabled">Indicates whether should be filter displayed.</param>
        public FilterSettings(Filter filter, bool isEnabled)
        {
            m_filter = filter;
            m_filterName = filter.Name;
            m_isEnabled = isEnabled;
        }

        /// <summary>
        /// Name of the filter
        /// </summary>
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

        /// <summary>
        /// Indicates whether the filter will be displayed.
        /// </summary>
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

        /// <summary>
        /// Kernel Filter
        /// </summary>
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

        /// <summary>
        /// From INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        //when property value changes
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
