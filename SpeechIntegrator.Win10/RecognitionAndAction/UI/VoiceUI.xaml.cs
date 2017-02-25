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

namespace SpeechIntegrator.RecognitionAndAction.UI
{
    public sealed partial class VoiceUI : UserControl
    {
        public VoiceUI()
        {
            this.InitializeComponent();
        }

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
