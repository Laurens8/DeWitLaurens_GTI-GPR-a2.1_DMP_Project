﻿#pragma checksum "..\..\WindowTornooi.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7DF08C2C268F6331519C38B1F4077CF5DA8331450501706AEEC2A7DB72B06A36"
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
    /// WindowTornooi
    /// </summary>
    public partial class WindowTornooi : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\WindowTornooi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbCircuit;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\WindowTornooi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTornooi;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\WindowTornooi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTornooi;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\WindowTornooi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCircuit;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\WindowTornooi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDatum;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\WindowTornooi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTypeCompetitie;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\WindowTornooi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnToevoegen;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\WindowTornooi.xaml"
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
            System.Uri resourceLocater = new System.Uri("/TennisVlaanderen_WPF;component/windowtornooi.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowTornooi.xaml"
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
            this.cbCircuit = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\WindowTornooi.xaml"
            this.cbCircuit.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbCircuit_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbTornooi = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\WindowTornooi.xaml"
            this.cbTornooi.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbTornooi_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblTornooi = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblCircuit = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblDatum = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblTypeCompetitie = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btnToevoegen = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\WindowTornooi.xaml"
            this.btnToevoegen.Click += new System.Windows.RoutedEventHandler(this.BtnToevoegen_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAnnuleren = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\WindowTornooi.xaml"
            this.btnAnnuleren.Click += new System.Windows.RoutedEventHandler(this.BtnAnnuleren_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

