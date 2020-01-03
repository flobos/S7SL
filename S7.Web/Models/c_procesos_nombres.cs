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
    public class c_procesos_nombres
    {

        public c_procesos_nombres() { }
        [Key]
        public int inc_pro_idn { get; set; }
        public int pro_inc_idn { get; set; }
        public string pro_inc_nombre  { get; set; }
       
    }
}