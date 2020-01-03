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
    public class c_incidencias_usuarios
    {
        public c_incidencias_usuarios() { }
        [Key]
        public int ate_inc_idn { get; set; }
        public string inc_nombre { get; set; }
        public string nombre { get; set; }
        public string pro_nombre { get; set; }
        public DateTime ate_inc_fecha_ingreso { get; set; }
    }
}