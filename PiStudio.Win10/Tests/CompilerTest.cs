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
            var lang = new Windows.Globalization.Language("en-us");

            await Run1();
            await Run2();
            await Run3();
            await Run4();
            await Run5();
            await Run6();
            await Run7();
            await Run8();
            await Run9();
            await Run10();
            await Run11();
            await Run12();
        }

        private async Task Run1()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test1VCD.xml"), new Windows.Globalization.Language("en-us"));
            }
            catch (UnauthorizedAccessException ex) { }
            catch (Exception e)
            {
                WriteLine("Test1 Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 1 succeeded!");
        }

        //multi-language support
        private async Task Run2()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"), new Windows.Globalization.Language("en-US"));
            }
            catch (Exception e)
            {
                WriteLine("Test2-en-US Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 2(en-us) succeeded!");
        }

        //multi-language support
        private async Task Run3()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"), new Windows.Globalization.Language("en-gb"));
            }
            catch (Exception e)
            {
                WriteLine("Test3-en-gb Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 3(en-gb) succeeded!");
        }

        //multi-language support
        private async Task Run4()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"), new Windows.Globalization.Language("en-au"));
            }
            catch (Exception e)
            {
                WriteLine("Test4-en-au Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 4(en-au) succeeded!");
        }

        //multi-language support
        private async Task Run5()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"), new Windows.Globalization.Language("en-in"));
            }
            catch (Exception e)
            {
                WriteLine("Test5-en-in Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 5(en-in) succeeded!");
        }

        //multi-language support
        private async Task Run6()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"), new Windows.Globalization.Language("en-ca"));
            }
            catch (Exception e)
            {
                WriteLine("Test6-en-ca Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 6(en-ca) succeeded!");
        }

        //multi-language support
        private async Task Run7()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"), new Windows.Globalization.Language("fr-fr"));
            }
            catch (Exception e)
            {
                WriteLine("Test7-fr-fr Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 7(fr-fr) succeeded!");
        }

        //multi-language support
        private async Task Run8()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"), new Windows.Globalization.Language("it-it"));
            }
            catch (Exception e)
            {
                WriteLine("Test8-it-it Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 8(it-it) succeeded!");
        }

        //multi-language support
        private async Task Run9()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"), new Windows.Globalization.Language("de-de"));
            }
            catch (Exception e)
            {
                WriteLine("Test9-de-de Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 9(de-de) succeeded!");
        }

        //multi-language support
        private async Task Run10()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"), new Windows.Globalization.Language("es-es"));
            }
            catch (Exception e)
            {
                WriteLine("Test10-es-es Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 10(es-es) succeeded!");
        }
        //multi-language support
        private async Task Run11()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"), new Windows.Globalization.Language("zh-ch"));
            }
            catch (Exception e)
            {
                WriteLine("Tes11-zh-ch Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 11(zh-ch) succeeded!");
        }

        private async Task Run12()
        {
            try
            {
                var navigator = await SpeechNavigator.Create(await m_folder.GetFileAsync("Test2VCD.xml"), new Windows.Globalization.Language("en-gb"));
                await navigator.SetLanguageAsync(new Windows.Globalization.Language("en-gb"));
            }
            catch (Exception e)
            {
                WriteLine("Tes12-language-switch Failed: " + e.Message.Trim());
                return;
            }
            WriteLine("Test 12(language switch) succeeded!");
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
