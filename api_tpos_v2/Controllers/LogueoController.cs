using api_tpos.Models;
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

namespace api_tpos.Controllers
{
   // [RoutePrefix("api/Logueo")]
    public class LogueoController : ApiController
    {

        [HttpPost]
        [Route("api/Logueo/Sesion")]
        [ResponseType(typeof(Sesion))]
        public DataSet getUSer(Sesion sesion)
        {
            DataSet ds = new DataSet("Logueo");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion2"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_tpos_logueo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Tipo_Sesion", SqlDbType.VarChar).Value = sesion.tipo_sesion;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = sesion.imei;
                    cmd.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = sesion.latitud;
                    cmd.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = sesion.longitud;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Logueo");
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

        [Route("api/Logueo")]
        [ResponseType(typeof(User))]
        public int PostEncabezado(User user)
        {
            int retRecord = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion2"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_tpos_valida_imei", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = user.imei;
                      cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = user.clave;
                 //   cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = user;
                //    cmd.Parameters.Add(" @Clave", SqlDbType.VarChar).Value = clave;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        retRecord = reader.GetInt32(0);

                    }
                }
            }
            return retRecord;
        }

     
    }
}
