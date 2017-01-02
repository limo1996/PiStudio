using PiStudio.Win10.Data;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PiStudio.Win10.UI.Controls
{
    public sealed partial class Toolbox : UserControl
    {
        public Toolbox()
        {
            this.InitializeComponent();
            this.BorderThickness = 0;
            this.BrushThickness = -1;
            this.BrushColor = Colors.Black;
        }

        private double m_borderThickness;
        private bool m_focused = false;

        #region EventHandlers
        private void SizeButton_Click(object sender, RoutedEventArgs e)
        {
            SizePopup.IsOpen = !SizePopup.IsOpen;
            ColorPopup.IsOpen = false;
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            ColorPopup.IsOpen = !ColorPopup.IsOpen;
            SizePopup.IsOpen = false;
        }

        private void ColorSelector_Click(object sender, RoutedEventArgs e)
        {
            BrushColor = ((SolidColorBrush)((Button)sender).Background).Color;
            ColorPopup.IsOpen = false;
            if (IsShadowEnabled)
                Shadow.Visibility = Visibility.Visible;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ColorPopup.IsOpen = false;
            SizePopup.IsOpen = false;
            var fn = ClearClicked;
            if (fn != null)
                fn(this, EventArgs.Empty);
        }

        private void Sizes_Click(object sender, RoutedEventArgs e)
        {
            var rectangle = (Rectangle)((Button)sender).Content;
            BrushThickness = rectangle.Height;
            SizePopup.IsOpen = false;
            if (IsShadowEnabled)
                Shadow.Visibility = Visibility.Visible;
        }
        private void MainGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (!m_isShadowEnabled)
                return;
            Shadow.Visibility = Visibility.Collapsed;
            MainGrid.BorderThickness = new Thickness(m_borderThickness);
            m_focused = true;
        }

        private void MainGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            if (ColorPopup.IsOpen || SizePopup.IsOpen || !m_isShadowEnabled)
                return;
            Shadow.Visibility = Visibility.Visible;
            MainGrid.BorderThickness = new Thickness(0);
            m_focused = false;
        }
        #endregion

        #region Events
        public event EventHandler<Color> BrushColorChanged;
        public event EventHandler<double> BrushThicknessChanged;
        public event EventHandler ClearClicked;
        #endregion

        #region Properties

        public Theme ApplicationTheme { get; set; }

        public new double BorderThickness
        {
            get { return (double)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderWidth.  This enables animation, styling, binding, etc...
        public static readonly new DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(double), typeof(Toolbox), new PropertyMetadata(1, BorderThicknessPropertyChanged));

        private static void BorderThicknessPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Toolbox)d).BorderThicknessChanged(e);
        }

        private void BorderThicknessChanged(DependencyPropertyChangedEventArgs e)
        {
            MainGrid.ColumnDefinitions[1].Width = new GridLength((double)e.NewValue);
            MainGrid.ColumnDefinitions[3].Width = new GridLength((double)e.NewValue);
            if (m_focused)
                MainGrid.BorderThickness = new Thickness((double)e.NewValue);
            ((Border)SizePopup.Child).BorderThickness = new Thickness((double)e.NewValue / 2);
            //((Border)ColorPopup.Child).BorderThickness = new Thickness((double)e.NewValue / 2);
            m_borderThickness = (double)e.NewValue;
        }

        public new Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderBrush.  This enables animation, styling, binding, etc...
        public static readonly new DependencyProperty BorderBrushProperty =
            DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(Toolbox), new PropertyMetadata(new SolidColorBrush(Colors.Black), BorderBrushPropertyChanged));

        private static void BorderBrushPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Toolbox)d).BorderBrushChanged(e);
        }

        private void BorderBrushChanged(DependencyPropertyChangedEventArgs e)
        {
            Brush brush = (Brush)e.NewValue;
            Separator1.Background = brush;
            Separator2.Background = brush;
            MainGrid.BorderBrush = brush;
        }

        public Brush PopupBorderBrush
        {
            get { return (Brush)GetValue(PopupBorderBrushProperty); }
            set { SetValue(PopupBorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupBorderBrushProperty =
            DependencyProperty.Register("PopupBorderBrush", typeof(Brush), typeof(Toolbox), new PropertyMetadata(new SolidColorBrush(Colors.Gray), PopupBorderBrushPropertyChanged));

        private static void PopupBorderBrushPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Toolbox)d).PopupBorderBrushChanged(e);
        }

        private void PopupBorderBrushChanged(DependencyPropertyChangedEventArgs e)
        {
            Brush brush = (Brush)e.NewValue;
            ((Border)SizePopup.Child).BorderBrush = brush;
            Border b = (Border)ColorPopup.Child;
            b.BorderBrush = brush;
            foreach (var item in ((Grid)b.Child).Children)
            {
                var btn = (Button)item;
                btn.BorderBrush = brush;
            }
        }

        public double BrushThickness
        {
            get { return (double)GetValue(BrushThicknessProperty); }
            set { SetValue(BrushThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BrushThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BrushThicknessProperty =
            DependencyProperty.Register("BrushThickness", typeof(double), typeof(Toolbox), new PropertyMetadata(1, BrushThicknessPropertyChanged));

        private static void BrushThicknessPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Toolbox)d).BrushThicknessValueChanged(e);
        }

        private void BrushThicknessValueChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = (double)e.NewValue;
            bool matched = false;
            foreach (var item in LineSizes.Children)
            {
                Button btn = (Button)item;
                if (((Rectangle)btn.Content).Height == value)
                {
                    btn.Background = new SolidColorBrush(Colors.Gray);
                    matched = true;
                }
                else
                    btn.Background = new SolidColorBrush(Colors.Transparent);
            }

            if (!matched)
                ((Button)LineSizes.Children[0]).Background = new SolidColorBrush(Colors.Gray);

            var fn = BrushThicknessChanged;
            if (fn != null)
                fn(this, value);
        }



        public Color BrushColor
        {
            get { return (Color)GetValue(BrushColorProperty); }
            set { SetValue(BrushColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BrushColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BrushColorProperty =
            DependencyProperty.Register("BrushColor", typeof(Color), typeof(Toolbox), new PropertyMetadata(Colors.Black, BrushColorPropertyChanged));

        private static void BrushColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Toolbox)d).BrushColorValueChanged(e);
        }

        private void BrushColorValueChanged(DependencyPropertyChangedEventArgs e)
        {
            Color color = (Color)e.NewValue;
            ColorPreview.Background = new SolidColorBrush(color);
            bool matched = false;
            foreach (var item in ColorPalette.Children)
            {
                Button btn = (Button)item;
                if (((SolidColorBrush)btn.Background).Color == color)
                {
                    btn.BorderThickness = new Thickness(2);
                    btn.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 00, 158, 225));
                    matched = true;
                }
                else
                {
                    btn.BorderThickness = new Thickness(1);
                    btn.BorderBrush = BorderBrush;
                }
            }

            if (!matched)
            {
                var btn = (Button)ColorPalette.Children[0];
                btn.BorderThickness = new Thickness(2);
                color = Color.FromArgb(255, 00, 158, 225);
                btn.BorderBrush = new SolidColorBrush(color);
            }
            var fn = BrushColorChanged;
            if (fn != null)
                fn(this, color);
        }



        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Background.  This enables animation, styling, binding, etc...
        public static readonly new DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(Toolbox), new PropertyMetadata(new SolidColorBrush(Colors.Transparent), BackgroundPropertyChanged));

        private static void BackgroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Toolbox)d).BackgroundChanged(e);
        }

        private void BackgroundChanged(DependencyPropertyChangedEventArgs e)
        {
            MainGrid.Background = (Brush)e.NewValue;
        }

        private bool m_isShadowEnabled = true;
        public bool IsShadowEnabled
        {
            get { return m_isShadowEnabled; }
            set
            {
                m_isShadowEnabled = value;
                if (!value)
                {
                    Shadow.Visibility = Visibility.Collapsed;
                    MainGrid.BorderThickness = new Thickness(m_borderThickness);
                }
            }
        }
        #endregion

    }
}
