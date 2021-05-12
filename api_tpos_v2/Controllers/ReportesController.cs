using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_tpos.Controllers
{
    public class ReportesController : ApiController
    {
        [HttpGet]
        [Route("api/Reportes/Ventas/{imei}/{ruta}/{mes}")]
        public DataSet getReporte(string imei, string ruta, string mes)
        {
            DataSet ds = new DataSet("Ventas");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_consulta_ventas_por_producto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;

                    cmd.Parameters.Add("@pRuta", SqlDbType.VarChar).Value = ruta;
                    cmd.Parameters.Add("@pFecha", SqlDbType.VarChar).Value = mes;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Ventas");
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
        [Route("api/Reportes/Ventas/{imei}/{ruta}/{mes}")]
        public DataSet getInventario(string imei, string ruta)
        {
            DataSet ds = new DataSet("Ventas");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_tpos_consulta_resumen_inventario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;
                    cmd.Parameters.Add("@pRuta", SqlDbType.VarChar).Value = ruta;
                
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Ventas");
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
        [Route("api/Reportes/Categorias/{imei}/{ruta}/{mes}")]
        public DataSet getReporteCategorias(string imei,string ruta, string mes)
        {
            DataSet ds = new DataSet("Ventas");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sp_consulta_ventas_por_categoria]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;

                    cmd.Parameters.Add("@pRuta", SqlDbType.VarChar).Value = ruta;
                    cmd.Parameters.Add("@pFecha", SqlDbType.VarChar).Value = mes;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Ventas");
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
        [Route("api/Reportes/Facturas/{imei}/{ruta}/{mes}")]
        public DataSet getReporteFacturas(string imei,string ruta, string mes)
        {
            DataSet ds = new DataSet("Ventas");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sp_consulta_ventas_por_factura]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;

                    cmd.Parameters.Add("@pRuta", SqlDbType.VarChar).Value = ruta;
                    cmd.Parameters.Add("@pFecha", SqlDbType.VarChar).Value = mes;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Ventas");
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
        [Route("api/Reportes/Serial/{imei}/{serial}")]
        public DataSet getReporteSerial(string imei, string serial)
        {
            DataSet ds = new DataSet("Ventas");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sp_consulta_ventas_por_serial]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;

                    cmd.Parameters.Add("@pSerial", SqlDbType.VarChar).Value = serial;   
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Ventas");
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
        [Route("api/Reportes/Vendedor/{imei}/{ruta}/{mes}")]
        public DataSet getReporteVendedor(string imei, string ruta, string mes)
        {
            DataSet ds = new DataSet("Ventas");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sp_consulta_ventas_por_vendedor]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;

                    cmd.Parameters.Add("@pRuta", SqlDbType.VarChar).Value = ruta;
                    cmd.Parameters.Add("@pFecha", SqlDbType.VarChar).Value = mes;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Ventas");
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
        [Route("api/Reportes/ImeiSerial/{imei}/{serial}")]
        public DataSet getReporteImeiSerial(string imei, string serial)
        {
            DataSet ds = new DataSet("Ventas");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sp_consulta_busqueda_por_serial]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@imei", SqlDbType.VarChar).Value = imei;
                    cmd.Parameters.Add("@serial", SqlDbType.VarChar).Value = serial; 
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Ventas");
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
        [Route("api/Reportes/Anulacion/{imei}/{ruta}/{fact_num}")]
        public string setAnulacion(string imei, string ruta, int fact_num)
        {
            string str = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_tpos_anular_factura", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;
                    cmd.Parameters.Add("@RUTA", SqlDbType.VarChar).Value = ruta;
                    cmd.Parameters.Add("@fact_num", SqlDbType.Int).Value = fact_num;
                    {
                        con.Open();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        str = reader.GetString(2);

                    }
                }
            }
            return str;
        }


        [HttpGet]
        [Route("api/Reportes/Inventario/{imei}/{ruta}")]
        public DataSet getInventario2(string imei, string ruta)
        {
            DataSet ds = new DataSet("Ventas");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion2"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_tpos_consulta_resumen_inventario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;
                    cmd.Parameters.Add("@RUTA", SqlDbType.VarChar).Value = ruta;

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Ventas");
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
        [Route("api/Reportes/Imei/{imei}/{ruta}/{fecha}")]
        public DataSet getReporteImei(string imei, string ruta, string fecha)
        {
            DataSet ds = new DataSet("Ventas");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion2"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sp_tpos_consulta_ventas_por_imei]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;
                    cmd.Parameters.Add("@pRuta", SqlDbType.VarChar).Value = ruta;
                    cmd.Parameters.Add("@pFecha", SqlDbType.VarChar).Value = fecha;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Ventas");
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
        [Route("api/Reportes/VentaDiaria/{imei}/{ruta}/{fecha}")]
        public DataSet getReporteVentaDiaria(string imei, string ruta, string fecha)
        {
            DataSet ds = new DataSet("Ventas");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[sp_tpos_consulta_resumen_venta]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;
                    cmd.Parameters.Add("@pRuta", SqlDbType.VarChar).Value = ruta;
                    cmd.Parameters.Add("@pFecha", SqlDbType.VarChar).Value = fecha;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.TableMappings.Add("Table", "Ventas");
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
        [Route("api/Reportes/Traslado/{imei}/{vendedor}/{ruta}")]
        public string setTrasalado(string imei, string vendedor, string ruta)
        {
            string str = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_tpos_traslado_vendedor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = imei;
                    cmd.Parameters.Add("@CO_VEN", SqlDbType.VarChar).Value = vendedor;
                    cmd.Parameters.Add("@RUTA_NUEVA", SqlDbType.VarChar).Value = ruta;
                    {
                        con.Open();
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        str = reader.GetString(2);

                    }
                }
            }
            return str;
        }

    }
}
