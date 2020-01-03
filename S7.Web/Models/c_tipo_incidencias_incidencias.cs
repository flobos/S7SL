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
    public class c_tipo_incidencias_incidencias
    {
        public c_tipo_incidencias_incidencias() { }
        [Key]
        public int inc_idn { get; set; }
        public string inc_nombre { get; set; }
        public string tip_inc_nombre { get; set; }
       





        //    public string inc_pro_ges_fecha_gestion { get; set; }

    }
}