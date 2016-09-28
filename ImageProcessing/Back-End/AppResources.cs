using ImageProcessing.Back_End;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ImageProcessing
{
    public class AppResources
    {
        private static AppResources m_instance = null;
        public static AppResources Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new AppResources();
                return m_instance;
            }
        }

        private AppResources()
        {
            Init_filters();
        }

        public StorageFile LoadedImage { get; set; }

        public StorageFile WorkingImage { get; set; }

        private List<Filter> m_filters;
        public List<Filter> Filters { get { return m_filters; } }

        private void Init_filters()
        {
            m_filters = new List<Filter>();
            m_filters.Add(new Filter("None", new double[,] { { 0, 0, 0 },
                                                             { 0, 1, 0 },
                                                             { 0, 0, 0 } }));

            m_filters.Add(new Filter("Blur", new double[,] { { 0.0, 0.2,  0.0 },
                                                             { 0.2, 0.2,  0.2 },
                                                             { 0.0, 0.2,  0.0 } }));

            m_filters.Add(new Filter("Blur2", new double[,] { { 0, 0, 1, 0, 0 },
                                                             { 0, 1, 1, 1, 0 },
                                                             { 1, 1, 1, 1, 1 },
                                                             { 0, 1, 1, 1, 0 },
                                                             { 0, 0, 1, 0, 0 } }, 13, 0));

            m_filters.Add(new Filter("MotionBlur", new double[,] { { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                                 { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                                                                 { 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                                                                 { 0, 0, 0, 1, 0, 0, 0, 0, 0},
                                                                 { 0, 0, 0, 0, 1, 0, 0, 0, 0},
                                                                 { 0, 0, 0, 0, 0, 1, 0, 0, 0},
                                                                 { 0, 0, 0, 0, 0, 0, 1, 0, 0},
                                                                 { 0, 0, 0, 0, 0, 0, 0, 1, 0},
                                                                 { 0, 0, 0, 0, 0, 0, 0, 0, 1}}));

            m_filters.Add(new Filter("FindEdges", new double[,] { { 0,  0, -1,  0,  0 },
                                                                  { 0,  0, -1,  0,  0 },
                                                                  { 0,  0,  2,  0,  0 },
                                                                  { 0,  0,  0,  0,  0 },
                                                                  { 0,  0,  0,  0,  0 }}));

            m_filters.Add(new Filter("Sobel–Feldman", new double[,] { { 3, 10, 3},
                                                                      { 0, 0, 0 },
                                                                      { -3, -10, -3}}));

            m_filters.Add(new Filter("Sobel", new double[,] { { -1, -2, -1 },
                                                              { 0, 0, 0 },
                                                              { 1, 2, 1 } }));

            m_filters.Add(new Filter("Sharpen", new double[,] { { -1, -1, -1 },
                                                                { -1, 9, -1, },
                                                                { -1, -1, -1 } }));

            m_filters.Add(new Filter("Sharpen2", new double[,] { { -1, -1, -1, -1, -1 },
                                                                  { -1,  2,  2,  2, -1 },
                                                                  { -1,  2,  8,  2, -1 },
                                                                  { -1,  2,  2,  2, -1 },
                                                                  { -1, -1, -1, -1, -1 }}, 1 / 8, 0));

            m_filters.Add(new Filter("Sharpen3", new double[,] { { 1,  1,  1 },
                                                                 { 1, -7,  1 },
                                                                 { 1,  1,  1} }));
        }
    }
}
