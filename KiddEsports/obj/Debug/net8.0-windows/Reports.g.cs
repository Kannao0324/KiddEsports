﻿#pragma checksum "..\..\..\Reports.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70F18523191D89C883F9E588C218650EF22F351C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KiddEsports;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace KiddEsports {
    
    
    /// <summary>
    /// Reports
    /// </summary>
    public partial class Reports : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvReports;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSearch;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFilter;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblExport;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboExport;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExport;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KiddEsports;component/reports.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Reports.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dgvReports = ((System.Windows.Controls.DataGrid)(target));
            
            #line 30 "..\..\..\Reports.xaml"
            this.dgvReports.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgvReports_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblSearch = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txtFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\Reports.xaml"
            this.txtFilter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtFilter_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblExport = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.cboExport = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\..\Reports.xaml"
            this.cboExport.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cboExport_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnExport = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Reports.xaml"
            this.btnExport.Click += new System.Windows.RoutedEventHandler(this.btnExport_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

