using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.Foundation;
using PiStudio.Shared.Data;

namespace PiStudio.Win10.Data
{
    /// <summary>
    /// Data class that holds data about single curve that is drawn on the canvas.
    /// </summary>
    public class SVGCurve
    {
        private List<Point> m_data = new List<Point>();

        /// <summary>
        /// Coordinates of pointer movement.
        /// </summary>
        public List<Point> Data { get { return m_data; } }

        /// <summary>
        /// Thickness of the curve
        /// </summary>
        public float Thickness { get; set; }

        /// <summary>
        /// Color of the curve.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Type of the drawn shape. Usually line.
        /// </summary>
        public ShapeType ShapeType { get; set; }
    }
}
