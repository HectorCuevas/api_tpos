using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_tpos_v2.Models
{
    public class Token
    {
        public string token { get; set; }
        public string referencia { get; set; }
        public string telefono { get; set; }
        public decimal valor { get; set; }
        public string codigo { get; set; }
    }
}