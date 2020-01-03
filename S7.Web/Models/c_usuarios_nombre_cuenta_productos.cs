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
    public class c_usuarios_nombre_cuenta_productos
    {
        public c_usuarios_nombre_cuenta_productos() { }
        [Key]
        public int usu_idn { get; set; }
        public string usu_id_nacional { get; set; }
        public string nombre { get; set; }
        public int contador { get; set; }

    }
}