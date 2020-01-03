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
    public partial class frm_incidencias_popup_incidencias : ChildWindow
    {

        public int _ate_inc_idn;
        public string _inc_nombre;
        public string _nombre;
        public string _pro_nombre;


        public frm_incidencias_popup_incidencias(int emp_usu_sed_idn )
        {
            ds_siete _db = new ds_siete();

            InitializeComponent();

            var _consulta = _db.Getc_incidencias_usuariosQuery(emp_usu_sed_idn);
            _db.Load(_consulta, _Async_datos_incidencias, null);
       
        
        }

        private void _Async_datos_incidencias(LoadOperation<c_incidencias_usuarios> _async_objeto)
        {

            //  c_incidencias_usuarios _objetos = _async_objeto.Entities.First();



            this.dg_incidencias.ItemsSource = _async_objeto.Entities;
           



        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void dg_incidencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            c_incidencias_usuarios _incidencias = (c_incidencias_usuarios)this.dg_incidencias.SelectedItem;

            _ate_inc_idn = _incidencias.ate_inc_idn;
            _inc_nombre = _incidencias.inc_nombre;
            _nombre = _incidencias.nombre;
            _pro_nombre = _incidencias.pro_nombre;
            this.DialogResult = true;
        }
    }
}

