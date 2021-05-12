
using api_tpos.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Http.Description;

namespace api_tpos.Controllers
{
    [RoutePrefix("api/Promociones")]
    public class PromocionesController : ApiController
    {
        [HttpGet]
        [Route("{imei}/{canal}")]
        public DataSet getPromos(string imei, string canal)
        {
            DataSet ds = new DataSet("Promociones");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_tpos_consulta_promociones", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;

                    cmd.Parameters.Add("@CANAL", SqlDbType.SmallInt).Value = canal;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Promociones");
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