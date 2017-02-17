using PiStudio.Shared;
using PiStudio.Win10.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PiStudio.Win10.UI.Controls
{
    public sealed partial class SavePopup : UserControl
    {
        public SavePopup()
        {
            this.InitializeComponent();
        }

        public event EventHandler<EventArgs> Started;
        public event EventHandler<EventArgs> Completed;

        public ISaveable SaveableObject { get; set; }

        private bool m_isOpen;
        public bool IsOpen
        {
            get
            {
                return m_isOpen;
            }
            set
            {
                m_isOpen = value;
                PopupBase.IsOpen = value;
                if(value)
                    HeightAnimation.Begin();
            }
        }

        public Theme ApplicationTheme { get; set; }

        public string Text1
        {
            get { return (string)GetValue(TextProperty1); }
            set { SetValue(TextProperty1, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty1 =
            DependencyProperty.Register("Text1", typeof(string), typeof(SavePopup), new PropertyMetadata("Save"));

        public string Text2
        {
            get { return (string)GetValue(TextProperty2); }
            set { SetValue(TextProperty2, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty2 =
            DependencyProperty.Register("Text2", typeof(string), typeof(SavePopup), new PropertyMetadata("Save As"));

        private async void OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender == Button2 || WinAppResources.Instance.FinalStorage == null)
            {
                await WinAppResources.Instance.PickFinalStorage();
            }

            var finalStorage = WinAppResources.Instance.FinalStorage;
            if (finalStorage == null)
                return;

            Started?.Invoke(this, EventArgs.Empty);
            // write to file
            if (SaveableObject != null)
            {
                SaveableObject.SaveChanges();
                await FileServer.SaveToFileAsync(finalStorage, SaveableObject);
            }
            Completed?.Invoke(this, EventArgs.Empty);
            PopupBase.IsOpen = false;
        }

        private void OnPointPress(object sender, PointerRoutedEventArgs e)
        {
            var wrapper = (Grid)sender;
            wrapper.Background = new SolidColorBrush(Color.FromArgb(120, 255, 255, 255));
        }

        private void OnPointExit(object sender, PointerRoutedEventArgs e)
        {
            var wrapper = (Grid)sender;
            wrapper.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void OnPointReleased(object sender, PointerRoutedEventArgs e)
        {
            var wrapper = (Grid)sender;
            wrapper.Background = new SolidColorBrush(Color.FromArgb(80, 255, 255, 255));
        }

        private void OnPointEnter(object sender, PointerRoutedEventArgs e)
        {
            var wrapper = (Grid)sender;
            wrapper.Background = new SolidColorBrush(Color.FromArgb(80, 255, 255, 255));
        }
    }
}
