using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.Foundation;
using Windows.UI.Xaml.Media;
using Windows.UI;
using System;
using Windows.UI.Xaml;

namespace ImageProcessing
{
    public class Rater : Grid
    {
        private int m_numOfStars;
        private Grid m_grid;
        private Polygon[] m_polygons;

        public Rater() : this(5)
        {
        }

        public Rater(int numOfStars) : base()
        {
            m_grid = new Grid();
            m_numOfStars = numOfStars;
            m_selectedFill = new SolidColorBrush(Colors.Yellow);

            Rated = false;
            Rating = 0;

            //Points="0,5 5,5 7,0 9,5 14,5 10,9 12,14 7,11 2,14 4,9"
            Point[] points = new Point[]
            {
                new Point(0, 5),
                new Point(5, 5),
                new Point(7, 0),
                new Point(9, 5),
                new Point(14, 5),
                new Point(10, 9),
                new Point(12, 14),
                new Point(7, 11),
                new Point(2, 14),
                new Point(4, 9)
            };

            m_grid.Height = 14;
            m_grid.Width = 17 * m_numOfStars;
            m_grid.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;
            m_grid.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;

            Polygon[] polygons = new Polygon[m_numOfStars];
            for (int i = 0; i < m_numOfStars; i++)
            {
                polygons[i] = new Polygon();
                polygons[i].Fill = new SolidColorBrush(Colors.Black);
                for (int j = 0; j < points.Length; j++)
                {
                    Point p = points[j];
                    p.X += i * 17;
                    polygons[i].Points.Add(p);
                }
                m_grid.Children.Add(polygons[i]);

                polygons[i].PointerEntered += Rater_PointerEntered;
                polygons[i].PointerExited += Rater_PointerExited;
                polygons[i].Tapped += Rater_Tapped;
            }

            this.Children.Add(m_grid);
            m_polygons = polygons;

            Fill = new SolidColorBrush(Colors.Gray);
        }

        private void Rater_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Rated = true;
            bool paint = true;
            int counter = 0;
            foreach (var polygon in m_polygons)
            {
                counter++;
                if (paint)
                    polygon.Fill = SelectedFill;
                else
                    polygon.Fill = Fill;

                if (polygon == sender)
                {
                    paint = false;
                    Rating = counter;
                }
            }
        }

        private void Rater_PointerExited(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            for (int i = 0; i < Rating; i++)
                m_polygons[i].Fill = SelectedFill;
            for (int i = Rating; i < m_numOfStars; i++)
                m_polygons[i].Fill = this.Fill;
        }

        private void Rater_PointerEntered(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var senderPolygon = (Polygon)sender;
            bool paint = true;
            foreach (var polygon in m_polygons)
            {
                if (paint)
                    polygon.Fill = SelectedFill;
                else
                    polygon.Fill = Fill;

                if (polygon == senderPolygon)
                    paint = false;
            }
        }

        private Brush m_fill;
        public Brush Fill
        {
            get
            {
                return m_fill;
            }

            set
            {
                if (value == null)
                    return;
                m_fill = value;
                for (int i = Rating; i < m_numOfStars; i++)
                    m_polygons[i].Fill = value;
            }
        }

        private Brush m_selectedFill;
        public Brush SelectedFill
        {
            get
            {
                return m_selectedFill;
            }

            set
            {
                m_selectedFill = value;
                for (int i = 0; i < Rating; i++)
                {
                    m_polygons[i].Fill = value;
                }
            }
        }

        private Brush m_borderBrush;
        public new Brush BorderBrush
        {
            get
            {
                return m_borderBrush;
            }
            set
            {
                if (value == null)
                    return;
                foreach (var pol in m_polygons)
                    pol.Stroke = value;
            }
        }

        public bool Rated
        {
            get;
            private set;
        }

        private int m_rating;

        public int Rating
        {
            get { return (int)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Rating.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register("Rating", typeof(int), typeof(Rater), new PropertyMetadata(0,
                new PropertyChangedCallback((DependencyObject o, DependencyPropertyChangedEventArgs e) =>
                {
                    Rater rater = (Rater)o;
                    rater.PerformRating(e);
                })));

        public void PerformRating(DependencyPropertyChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            if (value >= 0 && value <= m_numOfStars)
            {
                Rated = true;
                m_rating = value;
                var fn = RatingChanged;
                if (fn != null)
                    fn(this, value);

                for (int i = 0; i < m_numOfStars; i++)
                {
                    if (i < value)
                        m_polygons[i].Fill = SelectedFill;
                    else
                        m_polygons[i].Fill = Fill;
                }
            }
            else if ((int)e.OldValue != 0)
                Rating = (int)e.OldValue;
        }

        public event EventHandler<int> RatingChanged;
    }
}
