using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.ServiceModel.DomainServices.EntityFramework;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;
using S7.Web.Models;

namespace S7.Web.Models
{
    public class c_atenciones_procesos_incidencias_gestiones
    {
        public c_atenciones_procesos_incidencias_gestiones() { }
        [Key]
        public int ate_pro_inc_idn { get; set; }
        public int pro_inc_idn{ get; set; }
        public string pro_inc_nombre { get; set; }
        public string ges_inc_nombre { get; set; }
        public DateTime ate_pro_inc_fecha_ingreso { get; set; }
        public int emp_usu_sed_idn { get; set; }
        public string usu_nombres { get; set; }

        



        //    public string inc_pro_ges_fecha_gestion { get; set; }

    }
}