using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiStudio.Win10.Data;

namespace PiStudio.Win10
{
    public class SearchQueries
    {
        private IEnumerable<SearchOption> m_options;
        public SearchQueries(IEnumerable<SearchOption> options)
        {
            m_options = options;
        }

        public IEnumerable<SearchOption> Options
        {
            get
            {
                return m_options;
            }
            set
            {
                if(value != null && value.Count() > 0)
                    m_options = value;
            }
        }

        public IEnumerable<SearchOption> Search(string query)
        {
            return m_options.Where(item => item.Text.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) > -1)
                .OrderByDescending(c => c.Text.StartsWith(query, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
