﻿#pragma checksum "C:\Users\Jakub Lichman\Source\Repos\Bachelor-Thesis\PiStudio.Win10\UI\BrightnessPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2EC11AFF157CBD392EB984CFA9F72843"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PiStudio.Win10.UI.Pages
{
    partial class BrightnessPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.MainMenu = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 2:
                {
                    this.HamburgerButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 3:
                {
                    this.BrightenessButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 29 "..\..\..\UI\BrightnessPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BrightenessButton).Click += this.NavigationButton_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.FiltersPageButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 5:
                {
                    this.HomePageButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 6:
                {
                    this.GridContent = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 7:
                {
                    this.LowerPanel = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 8:
                {
                    this.BrightnessText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.BrightnessSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 10:
                {
                    this.SliderValue = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.PRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 12:
                {
                    this.Wrapper = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 13:
                {
                    this.SaveBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 59 "..\..\..\UI\BrightnessPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SaveBtn).Click += this.SaveBtn_Click;
                    #line default
                }
                break;
            case 14:
                {
                    this.ImageContent = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 51 "..\..\..\UI\BrightnessPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.ImageContent).SizeChanged += this.ImageContent_SizeChanged;
                    #line default
                }
                break;
            case 15:
                {
                    this.BackgroundColor = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

