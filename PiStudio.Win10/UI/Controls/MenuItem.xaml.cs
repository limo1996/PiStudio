using PiStudio.Win10.Data;
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

namespace PiStudio.Win10.UI.Controls
{
    public sealed partial class MenuItem : UserControl
    {
        public MenuItem()
        {
            ApplicationTheme = new Theme();
            this.InitializeComponent();
        }

        public event EventHandler<EventArgs> Click;
        public Theme ApplicationTheme { get; set; }

        public Symbol Symbol
        {
            get { return (Symbol)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Symbol.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(Symbol), typeof(MenuItem), new PropertyMetadata(Symbol.Home));


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MenuItem), new PropertyMetadata("HomeItem"));




        public bool IsSelectionEnabled
        {
            get { return (bool)GetValue(IsSelectionEnabledProperty); }
            set { SetValue(IsSelectionEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelectionEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectionEnabledProperty =
            DependencyProperty.Register("IsSelectionEnabled", typeof(bool), typeof(MenuItem), new PropertyMetadata(true));



        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(MenuItem), new PropertyMetadata(false, IsSelectedPropertyChanged));

        private static void IsSelectedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MenuItem)d).IsSelectedChanged(e);
        }

        private void IsSelectedChanged(DependencyPropertyChangedEventArgs e)
        {
            if (!IsSelectionEnabled)
                return;
            bool newValue = (bool)e.NewValue;
            if (newValue)
                FocusedRect.Visibility = Visibility.Visible;
            else
                FocusedRect.Visibility = Visibility.Collapsed;
        }

        private void OnTapped(object sender, TappedRoutedEventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        private void OnPointPress(object sender, PointerRoutedEventArgs e)
        {
            Wrapper.Background = new SolidColorBrush(Color.FromArgb(120, 255, 255, 255));
        }

        private void OnPointExit(object sender, PointerRoutedEventArgs e)
        {
            Wrapper.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void OnPointReleased(object sender, PointerRoutedEventArgs e)
        {
            Wrapper.Background = new SolidColorBrush(Color.FromArgb(80, 255, 255, 255));
        }

        private void OnPointEnter(object sender, PointerRoutedEventArgs e)
        {
            Wrapper.Background = new SolidColorBrush(Color.FromArgb(80, 255, 255, 255));
        }
    }
}
