using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using S7.Web.Models;
using S7.Web.Services;

using System.ServiceModel.DomainServices.Client;


namespace S7.Forms
{
    public partial class frm_atencion_cw_usuarios : ChildWindow
    {
        public string _nombre;
        public string _usu_id_nacional;
        public int _usu_idn;

        public frm_atencion_cw_usuarios()
        {
            InitializeComponent();
        }
       

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {

            this.bi_usaurios.IsBusy = true;
            ds_siete _db = new ds_siete();
            var _consulta = _db.c_usuarios_nombre_cuenta_productos_x_usu_apellidosQuery(txt_criterio.Text.Trim());
           _db.Load(_consulta, _Async_dg_usuarios, null);
            
        }


        private void _Async_dg_usuarios(LoadOperation<c_usuarios_nombre_cuenta_productos> _async_objeto)
      {

          this.dg_usuarios.ItemsSource = _async_objeto.Entities;
          this.bi_usaurios.IsBusy = false;
       }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void dg_usuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c_usuarios_nombre_cuenta_productos _usuario = (c_usuarios_nombre_cuenta_productos)this.dg_usuarios.SelectedItem;

            this._usu_idn = _usuario.usu_idn;
            this._nombre = _usuario.nombre;
            this._usu_id_nacional = _usuario.usu_id_nacional;
            this.DialogResult = true;
       


        }

        
    }
}

