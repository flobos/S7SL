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
    public class c_usuarios_nombre
    {
        public c_usuarios_nombre() { }
        [Key]
        public int emp_usu_sed_idn{ get; set; }
        public string nombre { get; set; }
       
        
    }
}