﻿#pragma checksum "..\..\..\WinListadoDeVentas.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3C9C38FEBC5A2C950A6C3AC6C8CC3F2C2541F948"
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


namespace Vistas {
    
    
    /// <summary>
    /// WinListadoDeVentas
    /// </summary>
    public partial class WinListadoDeVentas : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\WinListadoDeVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgVentas;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\WinListadoDeVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFechaInicio;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\WinListadoDeVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFechaFin;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\WinListadoDeVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotal;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\WinListadoDeVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\WinListadoDeVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\WinListadoDeVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label3;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\WinListadoDeVentas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label4;
        
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
            System.Uri resourceLocater = new System.Uri("/Vistas;component/winlistadodeventas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WinListadoDeVentas.xaml"
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
            this.dgVentas = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.dpFechaInicio = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.dpFechaFin = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            
            #line 34 "..\..\..\WinListadoDeVentas.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AplicarFiltro_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 40 "..\..\..\WinListadoDeVentas.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BorrarFiltros_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 49 "..\..\..\WinListadoDeVentas.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Imprimir_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.label3 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.label4 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

