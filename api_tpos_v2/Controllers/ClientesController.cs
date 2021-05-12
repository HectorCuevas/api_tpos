using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace api_tpos.Controllers
{
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController
    {


        [HttpGet]
        [Route("{imei}/{ruta}/{canal}")]
        public DataSet getussd(string imei, string ruta, string canal)
        {
            DataSet ds = new DataSet("Clientes");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_tpos_consulta_clientes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;

                    cmd.Parameters.Add("@RUTA", SqlDbType.VarChar).Value = ruta;
                    cmd.Parameters.Add("@CANAL", SqlDbType.VarChar).Value = canal;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Clientes");
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
