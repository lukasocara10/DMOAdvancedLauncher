﻿#pragma checksum "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "33CE94D3185756A9300D0812BEBB257B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18051
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AdvancedLauncher.Controls;
using AdvancedLauncher.Environment;
using AdvancedLauncher.Service;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AdvancedLauncher.Controls {
    
    
    /// <summary>
    /// TDBlock
    /// </summary>
    public partial class TDBlock : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 61 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border CommRoot;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer CommScroll;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid NewsWrap;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Tamers;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Digimons;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AdvancedLauncher;component/controls/tdblock/tdblock.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.CommRoot = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.CommScroll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 4:
            this.NewsWrap = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.Tamers = ((System.Windows.Controls.ListBox)(target));
            
            #line 72 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            this.Tamers.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Tamers_MouseLeftButtonDown_1);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Digimons = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 85 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.TamerHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 86 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.TamerHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 87 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.TamerHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 88 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.TamerHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 89 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.TamerHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 90 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.TamerHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 136 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DigimonHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            case 14:
            
            #line 137 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DigimonHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 138 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DigimonHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            case 16:
            
            #line 139 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DigimonHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            case 17:
            
            #line 140 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DigimonHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            case 18:
            
            #line 141 "..\..\..\..\..\Controls\TDBlock\TDBlock.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DigimonHeader_Loaded_1);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
