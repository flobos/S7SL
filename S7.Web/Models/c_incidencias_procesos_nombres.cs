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
    public class c_incidencias_procesos_nombres
    {
        public c_incidencias_procesos_nombres() { }
        [Key]
        public int Id { get; set; }
        public string Proceso  { get; set; }
        public string Observacion { get; set; }
        public bool Cerrada { get; set; }
        public Nullable<DateTime> Inicio  { get; set; }
        public Nullable<DateTime> Termino { get; set; }
        public string usu_nombre { get; set; }
       
    
        
        //    public string inc_pro_ges_fecha_gestion { get; set; }
   
    }
}