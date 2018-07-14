using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ws_appMayoristas
{
    public class CpostvaleFisico : ClienteMayorista
    {
        private Int64 _errNumber;
        private string _errDescrip;
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public string errDescrip
        {
            get { return _errDescrip; }
            set { _errDescrip = value; }
        }

        public Int64 errNumber
        {
            get { return _errNumber; }
            set { _errNumber = value; }
        }

        public CpostvaleFisico()
        {
            this.errDescrip = string.Empty;
            this.errNumber = 0;
        }

        public CpostvaleFisico AsignarVale(string cCliente, string FolioVale, string PersonaAutorizada, double MontoMaximo)
        {

            CpostvaleFisico objValeFisico = new CpostvaleFisico();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {
                    SqlCommand query = new SqlCommand("exec [sAppMayoristas].[procAsignarCredivale] @CCLIENTE, @FOLIOCREDIVALE, @PERSONAAUTORIZADA, @IMPORTEMAXIMO", conn);
                    query.Parameters.Add(new SqlParameter("CCLIENTE", cCliente));
                    query.Parameters.Add(new SqlParameter("FOLIOCREDIVALE", FolioVale));
                    query.Parameters.Add(new SqlParameter("PERSONAAUTORIZADA", PersonaAutorizada));
                    query.Parameters.Add(new SqlParameter("IMPORTEMAXIMO", MontoMaximo));

                    using (SqlDataReader reader = query.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            objValeFisico.errNumber = reader["errNumber"] == System.DBNull.Value ? (Int64)0 : Convert.ToInt64(reader["errNumber"].ToString());
                            objValeFisico.errDescrip = reader["errDescrip"] == System.DBNull.Value ? string.Empty : reader["errDescrip"].ToString();
                            objValeFisico.mensaje = "200 OK";

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objValeFisico.mensaje = "500 Error: " + ex.Message;
                return objValeFisico;
            }

            return objValeFisico;
        }

        public CpostvaleFisico CancelarVale(Int64 idAsignacionVale, string cCliente, string folioCredivale)
        {
            CpostvaleFisico objValeFisico = new CpostvaleFisico();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {
                    SqlCommand query = new SqlCommand("exec [sAppMayoristas].[procAsignarCredivale_Cancelar] @IDASIGNACIONVALE, @CCLIENTE, @FOLIOCREDIVALE", conn);
                    query.Parameters.Add(new SqlParameter("IDASIGNACIONVALE", idAsignacionVale));
                    query.Parameters.Add(new SqlParameter("CCLIENTE", cCliente));
                    query.Parameters.Add(new SqlParameter("FOLIOCREDIVALE", folioCredivale));


                    using (SqlDataReader reader = query.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            objValeFisico.errNumber = reader["errNumber"] == System.DBNull.Value ? (Int64)0 : Convert.ToInt64(reader["errNumber"].ToString());
                            objValeFisico.errDescrip = reader["errDescrip"] == System.DBNull.Value ? string.Empty : reader["errDescrip"].ToString();
                            objValeFisico.mensaje = "200 OK";

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objValeFisico.mensaje = "500 Error: " + ex.Message;
                return objValeFisico;
            }
            

            return objValeFisico;
        }
    }
}