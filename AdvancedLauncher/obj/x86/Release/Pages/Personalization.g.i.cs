﻿#pragma checksum "..\..\..\..\Pages\Personalization.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "10F975A1F88F1E6E4A53678574B3FD6F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18051
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AdvancedLauncher.Environment;
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


namespace AdvancedLauncher.Pages {
    
    
    /// <summary>
    /// Personalization
    /// </summary>
    public partial class Personalization : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 161 "..\..\..\..\Pages\Personalization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\..\Pages\Personalization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SelectBtn;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\..\Pages\Personalization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SelecterHelp;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\..\Pages\Personalization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Selected_Image;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\..\Pages\Personalization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBtn;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\..\Pages\Personalization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Current_Image;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\..\Pages\Personalization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CurrentHelp;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\..\Pages\Personalization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnApply;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\..\Pages\Personalization.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ItemsComboBox;
        
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
            System.Uri resourceLocater = new System.Uri("/AdvancedLauncher;component/pages/personalization.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Personalization.xaml"
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
            this.SelectBtn = ((System.Windows.Controls.Button)(target));
            
            #line 170 "..\..\..\..\Pages\Personalization.xaml"
            this.SelectBtn.Click += new System.Windows.RoutedEventHandler(this.Select_Picture_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SelecterHelp = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Selected_Image = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.SaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 181 "..\..\..\..\Pages\Personalization.xaml"
            this.SaveBtn.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Current_Image = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.CurrentHelp = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.BtnApply = ((System.Windows.Controls.Button)(target));
            
            #line 192 "..\..\..\..\Pages\Personalization.xaml"
            this.BtnApply.Click += new System.Windows.RoutedEventHandler(this.BtnApply_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ItemsComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 194 "..\..\..\..\Pages\Personalization.xaml"
            this.ItemsComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ItemsComboBox_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
