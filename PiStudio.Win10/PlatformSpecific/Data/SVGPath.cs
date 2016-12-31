using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.Foundation;

namespace PiStudio.Win10.Data
{
    public class SVGCurve
    {
        private List<Point> m_data = new List<Point>();
        public List<Point> Data { get { return m_data; } }
        public uint Thickness { get; set; }
        public Color Color { get; set; }
    }
}
