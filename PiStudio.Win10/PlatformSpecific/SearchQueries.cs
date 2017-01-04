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
                if(m_options != null && m_options.Count() > 0)
                    m_options = value;
            }
        }

        IEnumerable<SearchOption> Search(string query)
        {
            //TODO
        }
    }
}
