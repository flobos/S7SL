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
    public class c_seis_campos
    {
        public c_seis_campos() { }
        [Key]
        public String campo_uno { get; set; }
        public string campo_dos { get; set; }
        public string campo_tres { get; set; }
        public string campo_cuatro { get; set; }
        public string campo_cinco { get; set; }
        public string campo_seis { get; set; }
        //    public string inc_pro_ges_fecha_gestion { get; set; }

    }
}