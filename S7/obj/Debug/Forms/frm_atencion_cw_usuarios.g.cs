﻿#pragma checksum "C:\S7\S7\Forms\frm_atencion_cw_usuarios.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "59C6D5215150AC52A6D547DD53057F6D"
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
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace S7.Forms {
    
    
    public partial class frm_atencion_cw_usuarios : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid cb_criterio;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Button OKButton;
        
        internal System.Windows.Controls.DataGrid dg_usuarios;
        
        internal System.Windows.Controls.TextBox txt_criterio;
        
        internal System.Windows.Controls.Button btn_buscar;
        
        internal System.Windows.Controls.BusyIndicator bi_usaurios;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/S7;component/Forms/frm_atencion_cw_usuarios.xaml", System.UriKind.Relative));
            this.cb_criterio = ((System.Windows.Controls.Grid)(this.FindName("cb_criterio")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
            this.dg_usuarios = ((System.Windows.Controls.DataGrid)(this.FindName("dg_usuarios")));
            this.txt_criterio = ((System.Windows.Controls.TextBox)(this.FindName("txt_criterio")));
            this.btn_buscar = ((System.Windows.Controls.Button)(this.FindName("btn_buscar")));
            this.bi_usaurios = ((System.Windows.Controls.BusyIndicator)(this.FindName("bi_usaurios")));
        }
    }
}

