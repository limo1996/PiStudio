using PiStudio.Win10.Voice.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace PiStudio.Win10
{
    public class CompilerTest
    {
        private StackPanel m_display;
        private StorageFolder m_folder; 
        public CompilerTest(StackPanel output)
        {
            m_display = output;
        }

        public async Task Run()
        {
            m_folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Tests");
            await Run1();
            await Run2();
        }

        private async Task Run1()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test1VCD.xml"));
            }
            catch (UnauthorizedAccessException ex) { }
            catch (Exception e)
            {
                WriteLine("Test1 Failed: " + e.Message);
                return;
            }
            WriteLine("Test 1 succeeded!");
        }

        //multi-language support
        private async Task Run2()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"));
            }
            catch (Exception e)
            {
                WriteLine("Test2 Failed: " + e.Message);
                return;
            }
            WriteLine("Test 2 succeeded!");
        }

        private void WriteLine(string text)
        {
            var block = new TextBlock();
            block.FontSize = 12;
            block.Text = text;
            m_display.Children.Add(block);
        }
    }
}
