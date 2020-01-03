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
    public class c_semaforo_parametros
    {
        public c_semaforo_parametros() { }
        [Key]
        public int sem_per_idn { get; set; }
        public string Proceso { get; set; }
        public string sem_color { get; set; }
        public int sem_per_dias_desde { get; set; }
        public int sem_per_dias_hasta { get; set; }
 



        //    public string inc_pro_ges_fecha_gestion { get; set; }

    }
}