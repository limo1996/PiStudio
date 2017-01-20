using PiStudio.Win10.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class PiBar : UserControl
    {
        private SearchQueries m_search;
        public PiBar()
        {
            ApplicationTheme = new Theme();
            this.InitializeComponent();
            m_search = new SearchQueries(new List<Data.SearchOption>());
        }
        #region Properties
        public Theme ApplicationTheme { get; set; }


        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceholderText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register("PlaceholderText", typeof(string), typeof(PiBar), new PropertyMetadata("."));



        public object ItemsSource
        {
            get { return (object)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(object), typeof(PiBar), new PropertyMetadata(null, ItemsSourcePropertyChanged));

        private static void ItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PiBar)d).ItemSourceChanged(e);
        }

        private void ItemSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            m_search.Options = (IEnumerable<Data.SearchOption>)e.NewValue;
        }

        private void ShowOptions_Click(object sender, RoutedEventArgs e)
        {
            SpeakOptions.IsOpen = !SpeakOptions.IsOpen;
        }
        #endregion

        #region Events
        public event EventHandler<Data.SearchOption> ItemSelected;
        #endregion

        private void SuggestBoxPresenter_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                SuggestBoxPresenter.ItemsSource = m_search.Search(SuggestBoxPresenter.Text).ToList();
            }
        }

        private void SuggestBoxPresenter_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                OnItemSelected(args.ChosenSuggestion as Data.SearchOption);
            }
            else
            {
                var matchingOptions = m_search.Search(args.QueryText);
                if (matchingOptions.Count() >= 1)
                {
                    OnItemSelected(matchingOptions.FirstOrDefault());
                }
            }
        }

        private void SuggestBoxPresenter_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            SpeakOptions.IsOpen = false;
            SuggestBoxPresenter.Text = string.Format("{0}", ((Data.SearchOption)args.SelectedItem).Text);
        }

        private void ListBoxPresenter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem listItem = ListBoxPresenter.ContainerFromItem(e.AddedItems[0]) as ListViewItem;
            listItem.IsSelected = false;
            OnItemSelected(e.AddedItems[0] as Data.SearchOption);
        }

        private void OnItemSelected(Data.SearchOption option)
        {
            SpeakOptions.IsOpen = false;
            SuggestBoxPresenter.Text = string.Format("{0}", option.Text);
            ItemSelected?.Invoke(this, option);
        }
    }
}
