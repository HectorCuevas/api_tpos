using promovil_rest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Http;
using System.Web.Http.Description;


namespace promovil_rest.Controllers
{
    public class PedidoController : ApiController
    {
        [Route("api/Pedido")]
        [ResponseType(typeof(Pedido))]
        public int PostEncabezado(Pedido pedido)
        {
            int retRecord = 0;

            if (pedido != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("[sp_TPOS_INSERTA ENCABEZADO]", con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        try
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@pTIPO_DOC", SqlDbType.VarChar).Value = pedido.tipo_doc;
                            cmd.Parameters.Add("@pImei", SqlDbType.VarChar).Value = pedido.imei;
                            cmd.Parameters.Add("@pRUTA", SqlDbType.VarChar).Value = pedido.ruta;
                            cmd.Parameters.Add("@pFACT_NUM", SqlDbType.Int).Value = pedido.fact_num;
                            cmd.Parameters.Add("@pCO_CLI", SqlDbType.VarChar).Value = pedido.co_cli;
                            cmd.Parameters.Add("@pCO_VEN", SqlDbType.VarChar).Value = pedido.co_ven;
                            cmd.Parameters.Add("@pNIT", SqlDbType.VarChar).Value = pedido.nit;
                            cmd.Parameters.Add("@pDPI", SqlDbType.VarChar).Value = pedido.dpi;
                            cmd.Parameters.Add("@pNOMBRE", SqlDbType.VarChar).Value = pedido.nombre;
                            cmd.Parameters.Add("@PDIRECCION", SqlDbType.VarChar).Value = pedido.direccion;
                            cmd.Parameters.Add("@pTELEFONO", SqlDbType.VarChar).Value = pedido.telefono;
                            cmd.Parameters.Add("@pFORMA_PAG", SqlDbType.VarChar).Value = pedido.forma_pag;
                            cmd.Parameters.Add("@pTIPO_VENTA ", SqlDbType.VarChar).Value = pedido.tipo_venta;
                            cmd.Parameters.Add("@pTOTAL", SqlDbType.Decimal).Value = pedido.total;
                            cmd.Parameters.Add("@pCOBRO", SqlDbType.Decimal).Value = pedido.cobro;
                            cmd.Parameters.Add("@pCOMENTARIO", SqlDbType.VarChar).Value = pedido.comentario;
                            cmd.Parameters.Add("@pFE_US_IN", SqlDbType.DateTime).Value = pedido.fe_us_in;
                            cmd.Parameters.Add("@pLATITUD", SqlDbType.Decimal).Value = pedido.latitud;
                            cmd.Parameters.Add("@pLONGITUD", SqlDbType.Decimal).Value = pedido.longitud;
                            cmd.Parameters.Add("@pDEPATAMENTO", SqlDbType.VarChar).Value = pedido.departamento;
                            cmd.Parameters.Add("@pMUNICIPIO", SqlDbType.VarChar).Value = pedido.municipio;
                            cmd.Parameters.Add("@pZONA", SqlDbType.TinyInt).Value = pedido.zona;
                            retRecord = cmd.ExecuteNonQuery();
                           // if (retRecord >= 0)
                         //   {
                                if (PostDetalles(pedido.detalles) >= 0)
                                {
                                    saveImage(pedido.imagen1, pedido.fact_num.ToString(), "1");
                                    saveImage(pedido.imagen2, pedido.fact_num.ToString(), "2");
                                    //  transaction.Commit();
                                }//
                                 //else transaction.Rollback();                                                        
                          //  }
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            ///  transaction.Rollback();
                            return 500;
                        }

                    }
                }
            }
            else
            {
                retRecord = 99;
            }
                return retRecord;
            
        }
        private int PostDetalles(List<DetallePedido> detalles)
        {
            int retRecord = 0, renglon = 1;
            SqlTransaction transaction;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion"].ConnectionString))
            {

                foreach (DetallePedido item in detalles)
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_TPOS_INSERTA DETALLE]", con))
                    {

                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }


                        /*   transaction = con.BeginTransaction("Transaction2");
                           cmd.Connection = con;
                           cmd.Transaction = transaction;*/
                        try
                        {


                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = item.imei;
                            cmd.Parameters.Add("@pTIPO_DOC", SqlDbType.VarChar).Value = item.tipo_doc;
                            cmd.Parameters.Add("@pFACT_NUM", SqlDbType.Int).Value = item.fact_num;
                            cmd.Parameters.Add("@pCOMENTARIO_RENGLON", SqlDbType.VarChar).Value = item.comentario_renglon;
                            cmd.Parameters.Add("@pCO_ART", SqlDbType.VarChar).Value = item.co_art;
                            cmd.Parameters.Add("@pRENG_NUM", SqlDbType.Int).Value = renglon;
                            cmd.Parameters.Add("@pRUTA", SqlDbType.VarChar).Value = item.ruta;
                            cmd.Parameters.Add("@pPREC_VTA", SqlDbType.Decimal).Value = item.prec_vta;
                            cmd.Parameters.Add("@pTOTAL_ART", SqlDbType.Decimal).Value = item.total_art;
                            cmd.Parameters.Add("@pDESCUENTO", SqlDbType.Decimal).Value = item.descuento;
                            cmd.Parameters.Add("@pRENG_NETO", SqlDbType.Decimal).Value = item.reng_neto;
                            cmd.Parameters.Add("@paux01", SqlDbType.Decimal).Value = item.aux1;
                            cmd.Parameters.Add("@pAUX02", SqlDbType.VarChar).Value = item.aux2;
                            retRecord = cmd.ExecuteNonQuery();
                            if (retRecord >= 0)
                            {
                                //   transaction.Commit();
                                renglon = renglon + 1;
                            }
                            else
                            {
                                //transaction.Rollback();                              
                                return -1;
                            }
                        }
                        catch (Exception ex)
                        {
                            // transaction.Rollback();
                            return -1;
                        }
                    }
                }
                con.Close();

            }
            return retRecord;
        }


        private string checkToken(string token)
        {
            string str = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["api_tpos.Properties.Settings.Conexion2"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_TPOS_INSERTA_RECARGA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = token;
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



        private void saveImage(string image, String id_mov, String type)
        {
            if (!String.IsNullOrEmpty(image) && !String.IsNullOrEmpty(id_mov))
            {
                String path;
                Bitmap bmp;
                using (var ms = new MemoryStream(Convert.FromBase64String(image)))
                {
                    bmp = new Bitmap(ms);
                    path = "C:\\DPI IMAGENES\\" + id_mov + "_" + type + ".jpeg";
                    bmp.Save(path, ImageFormat.Jpeg);
                }
            }
        }
    }

}