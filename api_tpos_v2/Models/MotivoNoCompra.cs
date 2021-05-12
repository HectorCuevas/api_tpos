using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_tpos_v2.Models
{
    public class MotivoNoCompra
    {
        public string Imei { get; set; }
        public string pRUTA { get; set; }
        public string pCO_CLI { get; set; }
        public string pCO_VEN { get; set; }
        public DateTime pFE_US_IN { get; set; }
        public int pCO_MOTIVO { get; set; }
        public string pCOMENTARIO { get; set; }
        public decimal pLATITUD { get; set; }
        public decimal pLONGITUD { get; set; }


    }
}