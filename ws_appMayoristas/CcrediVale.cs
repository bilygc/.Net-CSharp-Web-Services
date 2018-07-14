using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ws_appMayoristas
{
    public class CcrediVale : ClienteMayorista
    {
        private string _sFolio;

        private double _iImporte;

        public string sFolio
        {
            get { return _sFolio; }
            set { _sFolio = value; }
        }

        public double iImporte
        {
            get { return _iImporte; }
            set { _iImporte = value; }
        }

        public CcrediVale()
        {
            this._sFolio = string.Empty;
            this._iImporte = 0;
        }

        public CcrediVale(string sFolio, double iImporte)
        {
            this._sFolio = sFolio;
            this._iImporte = iImporte;
        }

        public CValidaCredivaleResponse isValid()
        {

            CValidaCredivaleResponse objResponse = new CValidaCredivaleResponse();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {
                    SqlCommand query = new SqlCommand("Exec [sAppMayoristas].[proc_Credivale_Validez] @FOLIO, @IMPORTE", conn);
                    query.Parameters.Add(new SqlParameter("FOLIO", this._sFolio));
                    query.Parameters.Add(new SqlParameter("IMPORTE", this._iImporte));

                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        reader.Read();
                        objResponse.bValido = Convert.ToInt16(reader["errNumber"]) >= 0 ? true : false;
                        objResponse.sDescripcion = reader["errDescrip"] == System.DBNull.Value ? " " : reader["errDescrip"].ToString();
                        objResponse.mensaje = "200 OK";

                    }

                }
            }
            catch (Exception ex)
            {
                objResponse.mensaje = "500 Internal Error: " + ex.Message;
                return objResponse;
            }

            return objResponse; 

        }

    }
}