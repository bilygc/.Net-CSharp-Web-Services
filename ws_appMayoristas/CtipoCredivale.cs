using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ws_appMayoristas
{
    public class CtipoCredivale : ClienteMayorista
    {
        private Int16 _idTipo;
        private string _Descripcion;
        private string _Abreviacion;
        private string _mensaje;

        public Int16 idTipo
        {
            get { return _idTipo; }
            set { _idTipo = value; }
        }
        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
   

        public string Abreviacion
        {
            get { return _Abreviacion; }
            set { _Abreviacion = value; }
        }

        
        public List<CtipoCredivale> tiposCredivale()
        {
            
            var lstTiposCredivale = new List<CtipoCredivale>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_CredivalesTipo_Get] ", conn);


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            CtipoCredivale objTiposCredivale = new CtipoCredivale();
                            objTiposCredivale.idTipo = reader["idTipo"] == System.DBNull.Value ? (Int16)0 : Convert.ToInt16(reader["idTipo"].ToString());
                            objTiposCredivale.Descripcion = reader["Descripcion"] == System.DBNull.Value ? " " : reader["Descripcion"].ToString();
                            objTiposCredivale.Abreviacion = reader["Abreviacion"] == System.DBNull.Value ? " " : reader["Descripcion"].ToString();

                            objTiposCredivale.mensaje = "200 OK";
                            lstTiposCredivale.Add(objTiposCredivale);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CtipoCredivale objTiposCredito = new CtipoCredivale();
                objTiposCredito.mensaje = "500 Internal Error: " + ex.Message;
                lstTiposCredivale.Add(objTiposCredito);
            }

            return lstTiposCredivale;

        }
    }
}