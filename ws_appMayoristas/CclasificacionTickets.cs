using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ws_appMayoristas
{
    public class CclasificacionTickets : ClienteMayorista
    {
        private Int16 _idClasificacion;

        public Int16 idClasificacion
        {
            get { return _idClasificacion; }
            set { _idClasificacion = value; }
        }
        private string _Clasificacion;

        public string Clasificacion
        {
            get { return _Clasificacion; }
            set { _Clasificacion = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public List<CclasificacionTickets> getClasificacionTickets()
        {
            
            var lstClasificacionTickets = new List<CclasificacionTickets>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {
                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_SegmentosClasificacion_Get]", conn);

                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CclasificacionTickets objClasificacionTickets = new CclasificacionTickets();

                            objClasificacionTickets.idClasificacion = reader["idClasificacion"] == System.DBNull.Value ? (Int16)0 : Convert.ToInt16(reader["idClasificacion"].ToString());
                            objClasificacionTickets.Clasificacion = reader["Clasificacion"] == System.DBNull.Value ? " " : reader["Clasificacion"].ToString();
                            objClasificacionTickets.mensaje = "200 OK";
                            lstClasificacionTickets.Add(objClasificacionTickets);

                        }
                    }
                }
            }
            catch(Exception ex){
                CclasificacionTickets objClasificacionTickets = new CclasificacionTickets();
                objClasificacionTickets.mensaje = "500 Internal Error: " + ex.Message;
                lstClasificacionTickets.Add(objClasificacionTickets);
                return lstClasificacionTickets;
            }

            return lstClasificacionTickets;
        }

    }
}