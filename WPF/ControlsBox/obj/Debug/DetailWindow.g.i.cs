﻿#pragma checksum "..\..\DetailWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0ADCF6C838EF114906C3C746381FB842"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace ControlsBox {
    
    
    /// <summary>
    /// DetailWindow
    /// </summary>
    public partial class DetailWindow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid HancockDetails;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.TranslateTransform hcDetailTransform;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem hcBuildingTab;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock hcBuildingInfo;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem hcDepTab;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock hcDepInfo;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem hcPhoneTab;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock hcPhoneInfo;
        
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
            System.Uri resourceLocater = new System.Uri("/MaristMap;component/detailwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DetailWindow.xaml"
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
            this.HancockDetails = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.hcDetailTransform = ((System.Windows.Media.TranslateTransform)(target));
            return;
            case 3:
            this.hcBuildingTab = ((System.Windows.Controls.TabItem)(target));
            
            #line 24 "..\..\DetailWindow.xaml"
            this.hcBuildingTab.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TabItem_TouchDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.hcBuildingInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.hcDepTab = ((System.Windows.Controls.TabItem)(target));
            
            #line 31 "..\..\DetailWindow.xaml"
            this.hcDepTab.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TabItem_TouchDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.hcDepInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.hcPhoneTab = ((System.Windows.Controls.TabItem)(target));
            
            #line 38 "..\..\DetailWindow.xaml"
            this.hcPhoneTab.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.TabItem_TouchDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.hcPhoneInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
