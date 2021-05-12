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

namespace api_tpos_v2.Controllers
{
    public class CobroController : ApiController
    {
        [HttpGet]
        [Route("api/Cobro/{imei}/{cod}")]
        public DataSet getPromos(String imei, String cod)
        {
            DataSet ds = new DataSet("Cobros");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("tpos_documentos_pendiente_cliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;
                    cmd.Parameters.Add("@pRuta", SqlDbType.VarChar).Value = cod;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Cobros");
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


        [HttpGet]
        [Route("api/Cobro/Movimientos/{imei}/{cod}")]
        public DataSet getMovimientos(String imei, String cod)
        {
            DataSet ds = new DataSet("Cobros");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[tpos_Consulta_movimientos_Cliente]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Imei", SqlDbType.VarChar).Value = imei;
                    cmd.Parameters.Add("@pCo_cli", SqlDbType.VarChar).Value = cod;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Cobros");
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

        [HttpPost]
        [Route("api/Cobro")]
        [ResponseType(typeof(Cobro))]
        public int setCobro(Cobro cobro)
        {
            int id = 0;
            DataSet ds = new DataSet("Cobro");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion2"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_TPOS_INSERTA_COBROS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pImei", SqlDbType.VarChar).Value =cobro.pImei;
                    cmd.Parameters.Add("@pFACT_NUM", SqlDbType.Int).Value = cobro.pFACT_NUM;
                    cmd.Parameters.Add("@pFORMA_PAG", SqlDbType.VarChar).Value = cobro.pFORMA_PAG;
                    cmd.Parameters.Add("@pCOBRO", SqlDbType.Decimal).Value = cobro.pCOBRO;
                    cmd.Parameters.Add("@pFE_US_IN", SqlDbType.DateTime).Value = cobro.pFE_US_IN;
                    cmd.Parameters.Add("@pLATITUD", SqlDbType.Decimal).Value = cobro.pLATITUD;
                    cmd.Parameters.Add("@pLONGITUD", SqlDbType.Decimal).Value = cobro.pLONGITUD;
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

    }
}
