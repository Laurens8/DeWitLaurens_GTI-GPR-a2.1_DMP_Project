﻿#pragma checksum "..\..\WindowLessen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0F408A34CF25BE6E0FE34AFB2BDD221758AF362C0E3B4A0EC8337AA658055E78"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using TennisVlaanderen_WPF;


namespace TennisVlaanderen_WPF {
    
    
    /// <summary>
    /// WindowLessen
    /// </summary>
    public partial class WindowLessen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\WindowLessen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbClub;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\WindowLessen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbAanbod;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\WindowLessen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbTennis;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\WindowLessen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbPadel;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\WindowLessen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbTennisPadel;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\WindowLessen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnToevoegen;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\WindowLessen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnnuleren;
        
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
            System.Uri resourceLocater = new System.Uri("/TennisVlaanderen_WPF;component/windowlessen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowLessen.xaml"
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
            this.cbClub = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.cbAanbod = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.rbTennis = ((System.Windows.Controls.RadioButton)(target));
            
            #line 31 "..\..\WindowLessen.xaml"
            this.rbTennis.Checked += new System.Windows.RoutedEventHandler(this.rbTennis_Checked);
            
            #line default
            #line hidden
            
            #line 31 "..\..\WindowLessen.xaml"
            this.rbTennis.Click += new System.Windows.RoutedEventHandler(this.rbTennis_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rbPadel = ((System.Windows.Controls.RadioButton)(target));
            
            #line 32 "..\..\WindowLessen.xaml"
            this.rbPadel.Checked += new System.Windows.RoutedEventHandler(this.rbPadel_Checked);
            
            #line default
            #line hidden
            
            #line 32 "..\..\WindowLessen.xaml"
            this.rbPadel.Click += new System.Windows.RoutedEventHandler(this.rbPadel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rbTennisPadel = ((System.Windows.Controls.RadioButton)(target));
            
            #line 33 "..\..\WindowLessen.xaml"
            this.rbTennisPadel.Checked += new System.Windows.RoutedEventHandler(this.rbTennisPadel_Checked);
            
            #line default
            #line hidden
            
            #line 33 "..\..\WindowLessen.xaml"
            this.rbTennisPadel.Click += new System.Windows.RoutedEventHandler(this.rbTennisPadel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnToevoegen = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.btnAnnuleren = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
