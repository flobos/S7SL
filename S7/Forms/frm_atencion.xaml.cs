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
using System.Windows.Data;
using S7.ViewModels;
using S7.Libs;




namespace S7.Forms
{
    public partial class frm_atencion : Page
    {
        List<l_productos_incidencias> lista = new List<l_productos_incidencias>();


        public frm_atencion()
        {
            InitializeComponent();


        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           

        }

        private void _Async_usuarios(LoadOperation<c_usuarios_nombre_cuenta_productos> _async_objeto)
        {

           
          
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            ChildWindow _cw_usaurios = new frm_atencion_cw_usuarios();
            _cw_usaurios.Closed += new EventHandler(_cw_usaurios_Closed);

            _cw_usaurios.Show();
        }


        void _cw_usaurios_Closed(object sender, EventArgs e)
        {



            var _hijo = sender as frm_atencion_cw_usuarios;


            if (_hijo.DialogResult == true)
            {
                this.txt_id.Text = _hijo._usu_idn.ToString().Trim();
                this.txt_nombres.Text = _hijo._nombre;
                this.txt_rut.Text = _hijo._usu_id_nacional;
            }

            this.bi_generico.IsBusy = true;
            ds_siete _db = new ds_siete();

            var _query = _db.Getc_usuario_productos_nombresQuery(int.Parse(this.txt_id.Text.Trim()));
            _db.Load(_query, async_cb_productos, null);
              
        }


        private void async_cb_productos(LoadOperation<c_usuario_productos_nombres> _async_objeto)
        {

            this.cb_productos.ItemsSource = _async_objeto.Entities;
            ds_siete _db = new ds_siete();
            var _query = _db.Get_c_tipo_incidencias_incidenciasQuery();
            _db.Load(_query, async_abc_incidencias, null);
      
        }

        private void async_abc_incidencias(LoadOperation<c_tipo_incidencias_incidencias> _async_objeto)
        {

            //this.dg_tipo_incidencia.ItemsSource = _async_objeto.Entities;

            PagedCollectionView taskListView = new PagedCollectionView(_async_objeto.Entities);

            this.dg_tipo_incidencia.ItemsSource = taskListView;

            taskListView.GroupDescriptions.Add(new PropertyGroupDescription("tip_inc_nombre"));

            PagedCollectionView pcv = dg_tipo_incidencia.ItemsSource as PagedCollectionView;

            foreach (CollectionViewGroup group in pcv.Groups)
            {
               
                dg_tipo_incidencia.CollapseRowGroup(group, true);
            }


            this.bi_generico.IsBusy = false;


        }







        private void btn_agrega_inc_Click(object sender, RoutedEventArgs e)
        {

           
             l_productos_incidencias _l_productos_incidencias = new l_productos_incidencias();

             c_usuario_productos_nombres _productos = (c_usuario_productos_nombres)this.cb_productos.SelectedItem;
             c_tipo_incidencias_incidencias _incidencias = (c_tipo_incidencias_incidencias)this.dg_tipo_incidencia.SelectedItem;

             _l_productos_incidencias.inc_idn = _incidencias.inc_idn;
             _l_productos_incidencias.usu_pro_idn = _productos.usu_pro_idn;
             _l_productos_incidencias.inc_nombre = _incidencias.inc_nombre;
             _l_productos_incidencias.pro_nombre = _productos.pro_nombre;
             _l_productos_incidencias.ate_inc_observacion = txt_observacion.Text.Trim();

             lista.Add(_l_productos_incidencias);

             this.dg_incidencias.ItemsSource = null;
             this.dg_incidencias.ItemsSource = lista;



        }

        private void btn_guadar_Click(object sender, RoutedEventArgs e)
        {
            this.bi_generico.IsBusy = true;

            atenciones _atenciones = new atenciones();
           




            foreach (var objeto in lista)
            {


                atenciones_incidencias _atenciones_incidencias = new atenciones_incidencias();
                atenciones_procesos_incidencias _atenciones_procesos_incidencias = new atenciones_procesos_incidencias();

                _atenciones_incidencias.ate_inc_fecha_ingreso = DateTime.Now;
                _atenciones_incidencias.ate_inc_observacion = objeto.ate_inc_observacion;
                _atenciones_incidencias.inc_idn = objeto.inc_idn;
                _atenciones_incidencias.usu_pro_idn = objeto.usu_pro_idn;
                _atenciones_incidencias.ate_inc_resuelta = false;

             //   _atenciones_procesos_incidencias.ate_pro_inc_fecha_ingreso = DateTime.Now;
             //   _atenciones_procesos_incidencias.pro_ges_inc_idn = 19;
              //  _atenciones_procesos_incidencias.emp_usu_sed_idn = Global._g_emp_usu_sed_idn;
              

//                _atenciones_incidencias.atenciones_procesos_incidencias.Add(_atenciones_procesos_incidencias);

               _atenciones.atenciones_incidencias.Add(_atenciones_incidencias);

            }


            _atenciones.ate_fecha_ingreso = DateTime.Now;
            _atenciones.usu_idn = int.Parse(txt_id.Text.Trim());
            _atenciones.ate_cerrada = false;
            _atenciones.emp_usu_sed_idn = Global._g_emp_usu_sed_idn;


            ds_siete _db_incidencias = new ds_siete();

            _db_incidencias.atenciones.Add(_atenciones);

            _db_incidencias.SubmitChanges();

         //   SubmitOperation _so = _db_incidencias.SubmitChanges();
            //_so.Completed += new EventHandler(async_summit_db_gestiones);
            


        }



        private void async_summit_db_gestiones(object sender, EventArgs e)
        {


            this.bi_generico.IsBusy = true;
            MessageBox.Show("Gestion realizada exitosamente");

       
        }
        


    }
}
