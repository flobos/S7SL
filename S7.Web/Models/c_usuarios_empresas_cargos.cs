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
    public class c_usuarios_empresas_cargos
    {
        public c_usuarios_empresas_cargos() { }
        [Key]
        public int usu_idn { get; set; }
        public string usu_email { get; set; }
        public string usu_clave { get; set; }
        public int emp_usu_sed_idn { get; set; }


    }
}