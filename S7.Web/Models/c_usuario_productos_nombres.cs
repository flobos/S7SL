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
    public class c_usuario_productos_nombres
    {
        public c_usuario_productos_nombres() { }
        [Key]
        public int usu_pro_idn { get; set; }
        public string pro_nombre { get; set; }

    }
}