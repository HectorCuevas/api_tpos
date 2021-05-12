using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_tpos_v2.Models
{
    public class Cobro
    {
        public string pImei { get; set; }
        public int pFACT_NUM { get; set; }
        public string pFORMA_PAG { get; set; }
        public decimal pCOBRO { get; set; }
        public DateTime pFE_US_IN { get; set; }
        public decimal pLATITUD { get; set; }
        public decimal pLONGITUD { get; set; }
    }
}