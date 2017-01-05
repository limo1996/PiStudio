using System.Collections.Generic;

using PiStudio.Shared.Data;

namespace PiStudio.Shared
{
    public abstract class AppResourcesBase
    {
        private static AppResourcesBase m_instance = null;

        public AppResourcesBase()
        {
            Init_filters();
        }

        private IImageEditor m_editor = null;
        public IImageEditor Editor { get { return m_editor; } set { m_editor = value; } }

        private List<FilterSettings> m_filters;
        public List<FilterSettings> Filters { get { return m_filters; } }

        private void Init_filters()
        {
            m_filters = new List<FilterSettings>();
            m_filters.Add(new FilterSettings(new Filter("None", new double[,] { { 0, 0, 0 },
                                                             { 0, 1, 0 },
                                                             { 0, 0, 0 } }), true));

            m_filters.Add(new FilterSettings(new Filter("Blur", new double[,] { { 0.0, 0.2,  0.0 },
                                                             { 0.2, 0.2,  0.2 },
                                                             { 0.0, 0.2,  0.0 } }), true));

            m_filters.Add(new FilterSettings(new Filter("Blur2", new double[,] { { 0, 0, 1, 0, 0 },
                                                             { 0, 1, 1, 1, 0 },
                                                             { 1, 1, 1, 1, 1 },
                                                             { 0, 1, 1, 1, 0 },
                                                             { 0, 0, 1, 0, 0 } }, 13, 0), false));

            m_filters.Add(new FilterSettings(new Filter("MotionBlur", new double[,] { { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                                 { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                                                                 { 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                                                                 { 0, 0, 0, 1, 0, 0, 0, 0, 0},
                                                                 { 0, 0, 0, 0, 1, 0, 0, 0, 0},
                                                                 { 0, 0, 0, 0, 0, 1, 0, 0, 0},
                                                                 { 0, 0, 0, 0, 0, 0, 1, 0, 0},
                                                                 { 0, 0, 0, 0, 0, 0, 0, 1, 0},
                                                                 { 0, 0, 0, 0, 0, 0, 0, 0, 1}}), false));

            m_filters.Add(new FilterSettings(new Filter("FindEdges", new double[,] { { 0,  0, -1,  0,  0 },
                                                                  { 0,  0, -1,  0,  0 },
                                                                  { 0,  0,  2,  0,  0 },
                                                                  { 0,  0,  0,  0,  0 },
                                                                  { 0,  0,  0,  0,  0 }}), true));

            m_filters.Add(new FilterSettings(new Filter("Sobel–Feldman", new double[,] { { 3, 10, 3},
                                                                      { 0, 0, 0 },
                                                                      { -3, -10, -3}}), false));

            m_filters.Add(new FilterSettings(new Filter("Sobel", new double[,] { { -1, -2, -1 },
                                                              { 0, 0, 0 },
                                                              { 1, 2, 1 } }), true));

            m_filters.Add(new FilterSettings(new Filter("Sharpen", new double[,] { { -1, -1, -1 },
                                                                { -1, 9, -1, },
                                                                { -1, -1, -1 } }), true));

            m_filters.Add(new FilterSettings(new Filter("Sharpen2", new double[,] { { -1, -1, -1, -1, -1 },
                                                                  { -1,  2,  2,  2, -1 },
                                                                  { -1,  2,  8,  2, -1 },
                                                                  { -1,  2,  2,  2, -1 },
                                                                  { -1, -1, -1, -1, -1 }}, 1 / 8, 0), false));

            m_filters.Add(new FilterSettings(new Filter("Sharpen3", new double[,] { { 1,  1,  1 },
                                                                 { 1, -7,  1 },
                                                                 { 1,  1,  1} }), false));
        }
    }
}
