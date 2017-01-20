using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStudio.Shared.Data
{
    /// <summary>
    /// Class that represents filter (kernel matrix) in image processing. 
    /// </summary>
    public class Filter
    {
        //private fields
        private double[,] m_matrix;
        private double m_factor;

        /// <summary>
        /// Filter's kernel metrix.
        /// </summary>
        public double[,] Matrix { get { return m_matrix; } }

        /// <summary>
        /// Name of the filter. I.e. Blur, Sharpen..
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Factor by which is kernel metrix multiplied.
        /// </summary>
        public double Factor
        {
            get { return m_factor; }
            set
            {
                if (value > 0)
                {
                    m_factor = value;
                }
            }
        }

        /// <summary>
        /// Number that is added to pixels of the processed image.
        /// </summary>
        public double Bias { get; set; }

        /// <summary>
        /// Rating of the filter. Rated by users.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Indicates how many users rated this filter.
        /// </summary>
        public int RatersCount { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="Filter"/>
        /// </summary>
        /// <param name="name">Name of the filter</param>
        /// <param name="matrix">Kernel matrix</param>
        public Filter(string name, double[,] matrix)
        {
            Factor = 1;
            Bias = 0;
            m_matrix = matrix;
            Name = name;
        }

        /// <summary>
        /// Creates new instance of <see cref="Filter"/>
        /// </summary>
        /// <param name="name">Name of the filter</param>
        /// <param name="matrix">Kernel matrix</param>
        /// <param name="factor"></param>
        /// <param name="bias"></param>
        public Filter(string name, double[,] matrix, double factor, double bias) : this(name, matrix)
        {
            Bias = bias;
            factor = Factor;
        }
    }
}
