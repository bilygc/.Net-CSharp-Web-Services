using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ws_appMayoristas
{
    public class CsituacionClientes : ClienteMayorista
    {
        private Int16 _idStatus;
        private string _Status;
        private string _abrevStatus;
        private string _mensaje;

        public Int16 idStatus
        {
            get { return _idStatus; }
            set { _idStatus = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public string abrevStatus
        {
            get { return _abrevStatus; }
            set { _abrevStatus = value; }
        }

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public CsituacionClientes()
        {
            this.idStatus = (Int16) (-1);
            this.Status = string.Empty;
            this.abrevStatus = string.Empty;
            this.mensaje = string.Empty;
        }

        public List<CsituacionClientes> getCatalogo()
        {
            var listOfSituacionClientes = new List<CsituacionClientes>();
            

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {
                    SqlCommand query = new SqlCommand("exec [sAppMayoristas].[procCtl_ClientesSituacion_Get]", conn);
                    query.CommandTimeout = 0;

                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CsituacionClientes objSituacionClientes = new CsituacionClientes();
                            objSituacionClientes.idStatus = reader["idStatus"] == System.DBNull.Value ? (Int16)(-1) : Convert.ToInt16(reader["idStatus"].ToString());
                            objSituacionClientes.Status = reader["Status"] == System.DBNull.Value ? string.Empty : reader["Status"].ToString();
                            objSituacionClientes.abrevStatus = reader["abrevStatus"] == System.DBNull.Value ? string.Empty : reader["abrevStatus"].ToString();
                            objSituacionClientes.mensaje = "200 OK";
                            listOfSituacionClientes.Add(objSituacionClientes);
                        }
                    }
                }
            }
            catch(Exception ex){
                CsituacionClientes objSituacionClientes = new CsituacionClientes();
                objSituacionClientes.mensaje = "Erro: " + ex.Message;
                listOfSituacionClientes.Add(objSituacionClientes);
                return listOfSituacionClientes;
            }
            return listOfSituacionClientes;

        }
    }
}