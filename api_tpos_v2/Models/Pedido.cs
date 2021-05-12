using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace promovil_rest.Models
{
    public class Pedido
    {
        public string token { get; set; }
        public string tipo_doc { get; set; }
        public string imei { get; set; }
        public string ruta { get; set; }
        public int fact_num { get; set; }
        public string co_cli { get; set; }
        public string co_ven { get; set; }
        public string nit { get; set; }
        public string dpi { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string forma_pag { get; set; }
        public string tipo_venta { get; set; }
        public double total { get; set; }
        public double cobro { get; set; }
        public string comentario { get; set; }
        public DateTime fe_us_in { get; set; }
        public decimal nro_doc { get; set; }
        public decimal latitud { get; set; }
        public decimal longitud { get; set; }
        public string departamento { get; set; }
        public string municipio { get; set; }
        public byte zona { get; set; }
        public String imagen1 { get; set; }
        public String imagen2 { get; set; }
        [JsonProperty(PropertyName = "pedidos")]
        public List<DetallePedido> detalles { get; set; }
    }
}