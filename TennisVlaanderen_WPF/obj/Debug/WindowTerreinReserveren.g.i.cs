﻿#pragma checksum "..\..\WindowTerreinReserveren.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "57175C4F7DC53AB03DC0B60560495604D71243846A70C3DB89BF7249CF6E547B"
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
    /// WindowTerreinReserveren
    /// </summary>
    public partial class WindowTerreinReserveren : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\WindowTerreinReserveren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbVeld;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\WindowTerreinReserveren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbGravel;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\WindowTerreinReserveren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbGras;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\WindowTerreinReserveren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnToevoegen;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\WindowTerreinReserveren.xaml"
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
            System.Uri resourceLocater = new System.Uri("/TennisVlaanderen_WPF;component/windowterreinreserveren.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowTerreinReserveren.xaml"
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
            this.cbVeld = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.rbGravel = ((System.Windows.Controls.RadioButton)(target));
            
            #line 39 "..\..\WindowTerreinReserveren.xaml"
            this.rbGravel.Checked += new System.Windows.RoutedEventHandler(this.RbGravel_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rbGras = ((System.Windows.Controls.RadioButton)(target));
            
            #line 41 "..\..\WindowTerreinReserveren.xaml"
            this.rbGras.Checked += new System.Windows.RoutedEventHandler(this.RbGras_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnToevoegen = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\WindowTerreinReserveren.xaml"
            this.btnToevoegen.Click += new System.Windows.RoutedEventHandler(this.BtnToevoegen_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnAnnuleren = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\WindowTerreinReserveren.xaml"
            this.btnAnnuleren.Click += new System.Windows.RoutedEventHandler(this.BtnAnnuleren_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

