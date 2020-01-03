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
using System.Windows.Navigation;
using S7.Web.Models;
using S7.Web.Services;
using System.ServiceModel.DomainServices.Client;
using S7.Libs;




namespace S7.Forms
{
    public partial class frm_incidencias : Page
    {

        
        public frm_incidencias()
        {
            InitializeComponent();
        }

        ds_siete _db = new ds_siete();
        ds_siete _db_usuarios = new ds_siete();
        
        public int _pro_inc_idn;
        public int _ate_inc_idn;
        public int _emp_usu_sed_idn;

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

           
        }

      



       


        private void _Async_datos_combo_usuarios(LoadOperation<c_usuarios_nombre> _obj)
        {


            try
            {

                this.cb_funcionarios.ItemsSource = _obj.Entities;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void btn_ver_incidecias_Click(object sender, RoutedEventArgs e)
        {


               ChildWindow _cw_incidencia = new frm_incidencias_popup_incidencias(3);


               _cw_incidencia.Closed += new EventHandler(_cw_incidencias_Closed);

            _cw_incidencia.Show();
       

        }

        void _cw_incidencias_Closed(object sender, EventArgs e) {


            
            var _hijo = sender as frm_incidencias_popup_incidencias;
           
            
            if (_hijo.DialogResult == true){
            
                this.txt_incidencia_id.Text = _hijo._ate_inc_idn.ToString().Trim();
                this.txt_incidencia_nombre.Text = _hijo._inc_nombre;
                this.txt_usu_nombre.Text = _hijo._nombre;
                this.txt_pro_nombre.Text = _hijo._pro_nombre;

                this.bi_incidencias.IsBusy = true;


                f_refresca_grid();
                
            }
        }



        private void _Async_Getc_procesos_gestiones_nombresQuery(LoadOperation<c_procesos_gestiones_nombres> _async_objeto)
        {

            //  c_incidencias_usuarios _objetos = _async_objeto.Entities.First();



            this.cb_gestiones.ItemsSource = _async_objeto.Entities;


            

            ds_siete _db3 = new ds_siete();


            var _consulta = _db3.Getc_usuarios_nombreQuery();
            _db3.Load(_consulta, _Async_Getc_usuarios_nombreQuery, null);

        }

        private void _Async_Getc_usuarios_nombreQuery(LoadOperation<c_usuarios_nombre> _async_objeto)
        {

            //  c_incidencias_usuarios _objetos = _async_objeto.Entities.First();



            this.cb_funcionarios.ItemsSource = _async_objeto.Entities;


            this.bi_incidencias.IsBusy = false;

        }




        private void f_refresca_grid() {

            ds_siete _db2 = new ds_siete();


            var _consulta = _db2.Getc_atenciones_procesos_incidencias_gestionesQuery(int.Parse(txt_incidencia_id.Text.Trim()));
            _db2.Load(_consulta, _Async_Getc_atenciones_procesos_incidencias_gestionesQuery, null);
        }




        private void _Async_Getc_atenciones_procesos_incidencias_gestionesQuery(LoadOperation<c_atenciones_procesos_incidencias_gestiones> _async_objeto)
        {

             c_atenciones_procesos_incidencias_gestiones _objeto = _async_objeto.Entities.Last();

             this.txt_etapa_proceso.Text = _objeto.pro_inc_nombre;
             this.txt_id_proceso.Text = _objeto.pro_inc_idn.ToString();
             _emp_usu_sed_idn = _objeto.emp_usu_sed_idn;


            this.dg_gestiones.ItemsSource = _async_objeto.Entities;

            ds_siete _db1 = new ds_siete();


            var _consulta = _db1.Getc_procesos_gestiones_nombresQuery(int.Parse(this.txt_id_proceso.Text.Trim()));
            _db1.Load(_consulta, _Async_Getc_procesos_gestiones_nombresQuery, null);

           
           

            

        }






        private void btn_guardar_Click_1(object sender, RoutedEventArgs e)
        {
            this.bi_incidencias.IsBusy = true;
            c_procesos_gestiones_nombres _gestion = (c_procesos_gestiones_nombres)this.cb_gestiones.SelectedItem;



            ds_siete _db_gestiones = new ds_siete();
            var _consulta = _db_gestiones.Getprocesos_gestiones_incidencias_saltos_x_idQuery(_gestion.pro_ges_inc_idn);
            _db_gestiones.Load(_consulta, async_Getprocesos_gestiones_incidencias_saltos_x_idQuery, null);
                
       
        }



        private void async_Getprocesos_gestiones_incidencias_saltos_x_idQuery(LoadOperation<procesos_gestiones_incidencias_saltos> _async_objeto)
        {

           


            int _conta;
            _conta = _async_objeto.Entities.Count();


            
            ds_siete _db_gestiones = new ds_siete();
            c_procesos_gestiones_nombres _gestion = (c_procesos_gestiones_nombres)this.cb_gestiones.SelectedItem;
            
            c_usuarios_nombre _usuario = (c_usuarios_nombre)this.cb_funcionarios.SelectedItem;
            atenciones_procesos_incidencias v_atenciones_procesos_incidencias = new atenciones_procesos_incidencias();

            v_atenciones_procesos_incidencias.ate_inc_idn = int.Parse(this.txt_incidencia_id.Text.Trim());
            v_atenciones_procesos_incidencias.pro_ges_inc_idn = _gestion.pro_ges_inc_idn;
            v_atenciones_procesos_incidencias.ate_pro_inc_observacion = this.txt_observacion.Text.Trim();
            v_atenciones_procesos_incidencias.ate_pro_inc_fecha_ingreso = DateTime.Now;
            v_atenciones_procesos_incidencias.emp_usu_sed_idn = _emp_usu_sed_idn;



            _db_gestiones.atenciones_procesos_incidencias.Add(v_atenciones_procesos_incidencias);


            if (_conta == 1)
            {
                procesos_gestiones_incidencias_saltos _objeto = _async_objeto.Entities.First();
                atenciones_procesos_incidencias v_atenciones_procesos_incidencias_siguiente = new atenciones_procesos_incidencias();



                v_atenciones_procesos_incidencias_siguiente.ate_inc_idn = int.Parse(this.txt_incidencia_id.Text.Trim());
                v_atenciones_procesos_incidencias_siguiente.pro_ges_inc_idn = _objeto.pro_ges_inc_idn_salta;
                v_atenciones_procesos_incidencias_siguiente.ate_pro_inc_observacion = " " ;
                v_atenciones_procesos_incidencias_siguiente.ate_pro_inc_fecha_ingreso = DateTime.Now;
                v_atenciones_procesos_incidencias_siguiente.emp_usu_sed_idn = _usuario.emp_usu_sed_idn;

                _db_gestiones.atenciones_procesos_incidencias.Add(v_atenciones_procesos_incidencias_siguiente);

           }

            SubmitOperation _so = _db_gestiones.SubmitChanges();
            _so.Completed += new EventHandler(async_summit_db_gestiones);


        }



        private void async_summit_db_gestiones(object sender, EventArgs e)
        {


            this.bi_incidencias.IsBusy = false;
            f_limpia();
            MessageBox.Show("Gestion realizada exitosamente");

       
        }

     






        private void f_limpia() {


            this.dg_gestiones.ItemsSource = null;
            this.txt_incidencia_id.Text = "";
            this.txt_etapa_proceso.Text = "";
            this.txt_id_proceso.Text = "";
            this.txt_incidencia_nombre.Text = "";
            this.txt_observacion.Text = "";
            this.txt_pro_nombre.Text = "";
            this.txt_usu_nombre.Text = "";
            _ate_inc_idn = 0;
            _pro_inc_idn = 0;
            this.cb_funcionarios.SelectedIndex = -1;
            this.cb_gestiones.SelectedIndex = -1;
           

        
        }

        private void cb_gestiones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            c_procesos_gestiones_nombres _gestion = (c_procesos_gestiones_nombres)this.cb_gestiones.SelectedItem;


          /* if (_gestion.nombre != null)
            {

                switch (_gestion.pro_ges_inc_idn)
                {
                    case 6:
                        this.cb_funcionarios.IsEnabled = true;
                        break;
                    case 10:
                        this.cb_funcionarios.IsEnabled = true;
                        break;
                    case 13:
                        this.cb_funcionarios.IsEnabled = true;
                        break;
                }

            }*/

        }


    }
}
