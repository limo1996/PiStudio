using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PiStudio.Win10.Voice.UI
{
    public sealed partial class VoiceUI : UserControl
    {
        public VoiceUI()
        {
            this.InitializeComponent();
        }


        private Color m_fill = Colors.Red;
        public Color Fill
        {
            get { return m_fill; }
            set
            {
                if(value != null)
                {
                    var newColor = Color.FromArgb(224, value.R, value.G, value.B);
                    InnerCircle.Fill = new SolidColorBrush(newColor);
                    m_fill = newColor;
                    newColor.A = 144;
                    OuterCircle.Fill = new SolidColorBrush(newColor);
                }
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(VoiceUI), new PropertyMetadata(""));



        public void Stop()
        {
            Content.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            InnerCircleAnimation.Stop();
            OuterCircleAnimation.Stop();
            InnerCircle.Visibility = Visibility.Collapsed;
            OuterCircle.Visibility = Visibility.Collapsed;
            Display.Visibility = Visibility.Collapsed;
        }

        public void Start()
        {
            Stop();
            Content.Background = new SolidColorBrush(Color.FromArgb(180, 0,0,0));

            InnerCircle.Visibility = Visibility.Visible;
            OuterCircle.Visibility = Visibility.Visible;

            InnerCircle.Height = InnerCircle.Width = 25;
            OuterCircle.Height = OuterCircle.Width = 50;
            Fall1.Completed += (o, wq) =>
            {
                Launch1.Begin();
                Launch2.Begin();
            };
            Launch1.Completed += (o, qw) =>
            {
                InnerCircleAnimation.Begin();
                OuterCircleAnimation.Begin();
                Display.Visibility = Visibility.Visible;
            };
            Fall1.Begin();
            Fall2.Begin();

        }
    }
}
