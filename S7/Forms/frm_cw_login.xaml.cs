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
using S7.Libs;




namespace S7.Forms
{

    public partial class frm_cw_login : ChildWindow
    {
        public frm_cw_login()
        {
            InitializeComponent();
            this.txt_usuario.Focus();
        }

   

        private void btn_entrar_Click(object sender, RoutedEventArgs e)
        {



            ds_siete _db = new ds_siete();


            var _consulta = _db.Get_usuario_loginQuery(this.txt_usuario.Text.Trim(), this.pb_clave.Password.Trim());
            _db.Load(_consulta, _Async_Get_usuario_loginQuery, null);


        }


        private void _Async_Get_usuario_loginQuery(LoadOperation<c_usuarios_empresas_cargos> _async_objeto)
        {

            //  c_incidencias_usuarios _objetos = _async_objeto.Entities.First();


            int _conta;
            _conta = _async_objeto.Entities.Count();

            if (_conta == 0)
            {
                MessageBox.Show("Email o clave mal ingresado o no existen");
                this.txt_usuario.Text = "";
                this.pb_clave.Password = "";

            }
            else {

                c_usuarios_empresas_cargos _obj = _async_objeto.Entities.Last();


                Global._g_usu_email = _obj.usu_email;
                Global._g_usu_idn = _obj.usu_idn;
                Global._g_emp_usu_sed_idn = _obj.emp_usu_sed_idn;

                this.DialogResult = true;

            
            }
           
            
        }
    }
}

