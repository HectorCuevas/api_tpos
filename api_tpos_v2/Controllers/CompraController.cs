using api_tpos_v2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace promovil_rest.Controllers
{
   // [RoutePrefix("api/Compra")]
    public class CompraController : ApiController
    {
        [Route("api/Compra")]
        [ResponseType(typeof(MotivoNoCompra))]
        public int setMotivo(MotivoNoCompra motivo)
        {
            int id = 0;
            DataSet ds = new DataSet("Motivo");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion2"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_TPOS_INSERTA_MOTIVO_NO_COMPRA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pImei", SqlDbType.VarChar).Value = motivo.Imei;
                    cmd.Parameters.Add("@pRUTA", SqlDbType.VarChar).Value = motivo.pRUTA;
                    cmd.Parameters.Add("@pCO_CLI", SqlDbType.VarChar).Value = motivo.pCO_CLI;
                    cmd.Parameters.Add("@pCO_VEN", SqlDbType.VarChar).Value = motivo.pCO_VEN;
                    cmd.Parameters.Add("@pFE_US_IN", SqlDbType.VarChar).Value = motivo.pFE_US_IN;
                    cmd.Parameters.Add("@pCO_MOTIVO", SqlDbType.VarChar).Value = motivo.pCO_MOTIVO;
                    cmd.Parameters.Add("@pCOMENTARIO", SqlDbType.VarChar).Value = motivo.pCOMENTARIO;
                    cmd.Parameters.Add("@pLATITUD", SqlDbType.VarChar).Value = motivo.pLATITUD;
                    cmd.Parameters.Add("@pLONGITUD", SqlDbType.VarChar).Value = motivo.pLONGITUD;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    id = cmd.ExecuteNonQuery();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return id;
        }


        [HttpGet]
        [Route("api/Compra/Motivo/{imei}")]
        public DataSet getPromos(String imei)
        {
            DataSet ds = new DataSet("Motivo");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sp_tpos_consulta_motivos_no_compra]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@imei", SqlDbType.VarChar).Value = imei;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Motivo");
                    adp.SelectCommand = cmd;
                    adp.Fill(ds);

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return ds;
        }

    }
}
