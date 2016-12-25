using PiStudio.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ImageProcessing
{
    public class UIManager
    {

        private SplitView m_mainView;
        private Grid m_content;
        private Grid m_imageGrid;
        private Grid m_filterGrid;

        /// <summary>
        /// Creates <see cref="SplitView"/> menu with button names from "titles" list.
        /// </summary>
        /// <param name="titles">Names of the buttons. Icons must be named exactly as titles and suffix must be .png</param>
        /// <param name="localFolderName">Folder with icons.</param>
        /// <returns>Reference to menu of type <see cref="SplitView"/></returns>
        public async Task<SplitView> CreateMainMenu(IEnumerable<string> titles, string localFolderName)
        {
            SplitView view = new SplitView();
            view.IsPaneOpen = false;
            StackPanel hamburgerMenuPaneContent = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Name = "hamburgerMenuPaneContent"
            };
            StorageFolder folder = await ApplicationData.Current.LocalFolder.GetFolderAsync(localFolderName);
            if (folder != null)
            {
                var files = await folder.GetFilesAsync();
                foreach (var title in titles)
                {
                    var file = await folder.GetFileAsync(titles + ".png");
                    hamburgerMenuPaneContent.Children.Add(await CreateHamburgerMenuIcon(file, file.DisplayName));
                }
            }
            view.Pane = hamburgerMenuPaneContent;
            view.Content = new Grid();
            return view;
        }

        private async Task<UIElement> CreateHamburgerMenuIcon(StorageFile icon, string text)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            Button btn1 = new Button();
            btn1.Background = new SolidColorBrush(Colors.Transparent);
            btn1.Width = 50;
            btn1.Height = 50;
            BitmapImage img = new BitmapImage();
            await img.SetSourceAsync(await icon.OpenAsync(FileAccessMode.Read));
            btn1.Content = img;
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.FontSize = 18;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            panel.Children.Add(btn1);
            panel.Children.Add(textBlock);
            return panel;
        }

        public void WindowSizeChanged(SizeChangedEventArgs args, Grid splitViewContent)
        {


        }

        private void ImageFiltersWindowSizeChanged(SizeChangedEventArgs args)
        {
            
        }

        private DataTemplate CreateFiltersGridViewTemplate(int fontSize, string fontColor)
        {
            DataTemplate template = (DataTemplate)XamlReader.LoadWithInitialTemplateValidation(@"
                                <DataTemplate
                                    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                    xmlns:custom=""using:ImageProcessing"">
                                    <StackPanel Orientation=""Vertical""
                                            BorderThickness=""1""
                                            BorderBrush=""Black""
                                            HorizontalAlignment=""Center"">
                                        <Image Source=""{Binding Image}"" Stretch=""Uniform"" />
                                        <TextBlock Text=""{Binding Text}"" FontSize=""" + fontSize + @""" Foreground=""" + fontColor + @""" FontStyle=""Normal"" />
                                        <custom:Rater BorderBrush=""Black"" Rating=""{Binding Rating}"" />
                                    </StackPanel>
                                </DataTemplate>");
            return template;
        }

        private GridView CreateFiltersView(int viewHeight, int fontSize, string FontColor)
        {
            GridView view = new GridView();
            view.Height = viewHeight;
            view.ItemTemplate = CreateFiltersGridViewTemplate(fontSize, FontColor);
            view.IsItemClickEnabled = true;
            view.IsSwipeEnabled = true;
            view.SelectionMode = ListViewSelectionMode.Single;
            return view;
        }

        public GridView SetFiltersPage(IEnumerable<FilterItem> filterItems, Size newSize, Size oldSize)
        {
            int templateFontSize = 14;
            int filtersViewHeight = 350;

            if (newSize.Height < 800)
            {
                templateFontSize = 10;
                filtersViewHeight = 250;
            }
            else if (newSize.Height < 500)
            {
                filtersViewHeight = 0;
            }


            GridView filtersView = this.CreateFiltersView(filtersViewHeight, templateFontSize, "Black");
            filtersView.ItemsSource = filterItems;
            return filtersView;
        }
    }


    public enum ScreenType
    {
        WelcomeScreen,
        ImageFiltersScreen,
        DrawingScreen
    }

    public enum ScreenSize
    {
        TabletSize,
        PhoneSize,
        DesktopSize
    }
}
