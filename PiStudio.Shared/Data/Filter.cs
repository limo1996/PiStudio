using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStudio.Shared.Data
{
    public class Filter
    {
        private double[,] m_matrix;
        private double m_factor;
        public double[,] Matrix { get { return m_matrix; } }

        public string Name { get; }
        public double Factor
        {
            get { return m_factor; }
            set
            {
                if (m_matrix != null)
                {
                    for (int i = 0; i < m_matrix.GetLength(0); i++)
                        for (int j = 0; j < m_matrix.GetLength(1); j++)
                            m_matrix[i, j] *= value;

                    m_factor = value;
                }
            }
        }
        public double Bias { get; set; }
        public double Rating { get; set; }
        public int RatersCount { get; set; }

        public Filter(string name, double[,] matrix)
        {
            m_matrix = matrix;
            Name = name;
        }

        public Filter(string name, double[,] matrix, double factor, double bias)
        {
            m_matrix = matrix;
            Name = name;
            Bias = bias;
            factor = Factor;
        }
    }
}
