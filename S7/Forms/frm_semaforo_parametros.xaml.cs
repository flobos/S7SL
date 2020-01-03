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

using System.Collections.ObjectModel;
using System.Windows.Data;




namespace S7.Forms
{
    public partial class frm_semaforo_parametros : Page
    {
        public frm_semaforo_parametros()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            ds_siete _db = new ds_siete();



            var _consulta = _db.Getc_semaforo_parametrosQuery();
            _db.Load(_consulta, _Async_datos, null);
        }

        private void _Async_datos(LoadOperation<c_semaforo_parametros> _async_objeto)
        {

            //  c_incidencias_usuarios _objetos = _async_objeto.Entities.First();


           

            PagedCollectionView taskListView = new PagedCollectionView(_async_objeto.Entities);
            this.dg_semaforo.ItemsSource = taskListView;

            taskListView.GroupDescriptions.Add(new PropertyGroupDescription("Proceso"));




        }

    }
}
