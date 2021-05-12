using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_tpos.Models
{
    public class Sesion
    {
        public string tipo_sesion { get; set; }
        public string imei { get; set; }
        public decimal latitud { get; set; }
        public decimal longitud { get; set; }
    }
}