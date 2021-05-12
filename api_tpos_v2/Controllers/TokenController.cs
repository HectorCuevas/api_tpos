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
    [Route("api/Recarga")]
    public class TokenController : ApiController
    {
        [Route("api/Recarga")]
        [ResponseType(typeof(Token))]
        public string checkToken(Token token)
        {
            string str = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion2"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_TPOS_INSERTA_RECARGA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pTOKEN", SqlDbType.VarChar).Value = token.token;
                    cmd.Parameters.Add("@pREFERENCIA", SqlDbType.VarChar).Value = token.referencia;
                    cmd.Parameters.Add("@pTELEFONO", SqlDbType.VarChar).Value = token.telefono;
                    cmd.Parameters.Add("@pValor", SqlDbType.Decimal).Value = token.valor;
                    cmd.Parameters.Add("@pCODIGO", SqlDbType.VarChar).Value = token.codigo;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        str = reader.GetString(1);

                    }
                }
            }
            return str;
        }
    }
}
