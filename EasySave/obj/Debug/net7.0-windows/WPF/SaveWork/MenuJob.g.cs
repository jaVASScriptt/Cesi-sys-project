﻿#pragma checksum "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E5B927FB2E9610B6FC06C9B7CBC2E37BC13EE961"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
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


namespace Easysave {
    
    
    /// <summary>
    /// MenuJob
    /// </summary>
    public partial class MenuJob : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 68 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock title_job_menu;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl Measure;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_job_button;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button del_job_button;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EasySave;component/wpf/savework/menujob.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            this.title_job_menu = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Measure = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 6:
            this.add_job_button = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
            this.add_job_button.Click += new System.Windows.RoutedEventHandler(this.Add_job_button_OnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.del_job_button = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
            this.del_job_button.Click += new System.Windows.RoutedEventHandler(this.DeleteAllJobs);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 47 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.doSave);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
            ((System.Windows.Controls.Button)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.setAddTool);
            
            #line default
            #line hidden
            break;
            case 2:
            
            #line 48 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.editSave);
            
            #line default
            #line hidden
            
            #line 48 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
            ((System.Windows.Controls.Button)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.setEditTool);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 49 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\..\..\WPF\SaveWork\MenuJob.xaml"
            ((System.Windows.Controls.Button)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.setDelTool);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

