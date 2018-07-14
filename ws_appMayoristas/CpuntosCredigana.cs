using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ws_appMayoristas
{
    public class CpuntosCredigana : ClienteMayorista
    {
        private double _puntos;

        public double puntos
        {
            get { return _puntos; }
            set { _puntos = value; }
        }

        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public CpuntosCredigana()
        {
            this._puntos = 0.0;
            this._mensaje = string.Empty;
        }

        public CpuntosCredigana obtenerPuntos(string sCcliente, string sCsuccliente)
        {
            CpuntosCredigana objResponse = new CpuntosCredigana();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {
                    SqlCommand query = new SqlCommand("select [sAppMayoristas].[fnPuntosSaldo_Get] (@CCLIENTE,@CSUCCLIENTE, 0) as puntos", conn);
                    query.Parameters.Add(new SqlParameter("CCLIENTE", sCcliente));
                    query.Parameters.Add(new SqlParameter("CSUCCLIENTE", sCsuccliente));
                    query.CommandTimeout = 0;

                    using (SqlDataReader reader = query.ExecuteReader())
                    {

                        reader.Read();
                        objResponse.puntos = reader["puntos"] == System.DBNull.Value ? (double)0.0 : Convert.ToDouble(reader["puntos"].ToString());
                        objResponse.mensaje = "200 OK";


                    }


                    SqlCommand queryBitacoraPts = new SqlCommand("exec [sAppMayoristas].[insBitacora_app_Puntos] @CCLIENTE ", conn);
                    queryBitacoraPts.Parameters.Add(new SqlParameter("CCLIENTE", sCcliente));

                    queryBitacoraPts.ExecuteNonQuery();
                }
               
            }
            catch (Exception ex)
            {
                objResponse.mensaje = "Error: " + ex.Message;
                return objResponse;
            }


            return objResponse;
        }
    }
}