using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Net.Mail;
using System.Globalization;
using System.Text;

namespace ws_appMayoristas
{
    public class ClienteMayorista
    {
        private Int16 tipoAmbiente = 1; //1 produccion, 2 pruebas
        

        public List<Asentamientos> Asentamientos()
        {
            
            var lstAsentamientos = new List<Asentamientos>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_Asentamientos_Get]", conn);
                    query.CommandTimeout = 0;


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            Asentamientos objAsentamientos = new ws_appMayoristas.Asentamientos();
                            objAsentamientos.idCP = reader["idCP"] == System.DBNull.Value ? 0 : Convert.ToInt32(reader["idCP"].ToString());
                            objAsentamientos.idAsentamiento = reader["idAsentamiento"] == System.DBNull.Value ? " " : reader["idAsentamiento"].ToString();
                            objAsentamientos.Asentamiento = reader["Asentamiento"] == System.DBNull.Value ? " " : reader["Asentamiento"].ToString();
                            objAsentamientos.idTipoAsenta = reader["idTipoAsenta"] == System.DBNull.Value ? " " : reader["idTipoAsenta"].ToString();
                            objAsentamientos.idEstado = reader["idEstado"] == System.DBNull.Value ? " " : reader["idEstado"].ToString();
                            objAsentamientos.idMunicipio = reader["idMunicipio"] == System.DBNull.Value ? " " : reader["idMunicipio"].ToString();
                            objAsentamientos.idCiudad = reader["idCiudad"] == System.DBNull.Value ? " " : reader["idCiudad"].ToString();
                            objAsentamientos.nLatitud = reader["nLatitud"] == System.DBNull.Value ? " " : reader["nLatitud"].ToString();
                            objAsentamientos.nLongitud = reader["nLongitud"] == System.DBNull.Value ? " " : reader["nLongitud"].ToString();



                            objAsentamientos.mensaje = "200 OK";
                            lstAsentamientos.Add(objAsentamientos);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Asentamientos objAsentamientos = new Asentamientos();
                objAsentamientos.mensaje = "500 Internal Error: " + ex.Message;
                lstAsentamientos.Add(objAsentamientos);
            }

            return lstAsentamientos;

        }

        public List<TiposDeAsentamiento> TiposAsentamientos()
        {
            
            var lstTiposAsentamientos = new List<TiposDeAsentamiento>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_TiposDeAsentamiento_Get]", conn);


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            TiposDeAsentamiento objTiposAsentamiento = new TiposDeAsentamiento();
                            objTiposAsentamiento.idTipoAsenta = Convert.ToInt16(reader["idTipoAsenta"].ToString());
                            objTiposAsentamiento.TipoAsentamiento = reader["TipoAsentamiento"] == System.DBNull.Value ? " " : reader["TipoAsentamiento"].ToString();
                            objTiposAsentamiento.mensaje = "200 OK";


                            lstTiposAsentamientos.Add(objTiposAsentamiento);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TiposDeAsentamiento objTiposAsentamiento = new TiposDeAsentamiento();
                objTiposAsentamiento.mensaje = "500 Internal Error: " + ex.Message;
                lstTiposAsentamientos.Add(objTiposAsentamiento);
            }

            return lstTiposAsentamientos;

        }

        public List<Ciudades> Ciudades()
        {
            
            var lstCiudades = new List<Ciudades>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_Ciudades_Get]", conn);


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            Ciudades objCiudades = new Ciudades();


                            objCiudades.id = Convert.ToInt16(reader["id"].ToString());
                            objCiudades.Ciudad = reader["Ciudad"] == System.DBNull.Value ? " " : reader["Ciudad"].ToString();
                            objCiudades.idEstado = reader["idEstado"] == System.DBNull.Value ? " " : reader["idEstado"].ToString();
                            objCiudades.idMunicipio = reader["idMunicipio"] == System.DBNull.Value ? " " : reader["idMunicipio"].ToString();
                            objCiudades.idCiudad = reader["idCiudad"] == System.DBNull.Value ? " " : reader["idCiudad"].ToString();
                            objCiudades.mensaje = "200 OK";


                            lstCiudades.Add(objCiudades);

                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Ciudades objCiudades = new Ciudades();
                objCiudades.mensaje = "500 Internal Error: " + ex.Message;
                lstCiudades.Add(objCiudades);
            }

            return lstCiudades;

        }

        public List<Municipios> Municipios()
        {
            
            var lstMunicipios = new List<Municipios>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_Municipios_Get]", conn);


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            Municipios objMunicipios = new Municipios();

                            objMunicipios.IDEstado = reader["IDEstado"] == System.DBNull.Value ? " " : reader["IDEstado"].ToString();
                            objMunicipios.IDMunicipio = reader["IDMunicipio"] == System.DBNull.Value ? " " : reader["IDMunicipio"].ToString();
                            objMunicipios.Municipio = reader["Municipio"] == System.DBNull.Value ? " " : reader["Municipio"].ToString();
                            objMunicipios.mensaje = "200 OK";


                            lstMunicipios.Add(objMunicipios);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Municipios objMunicipios = new Municipios();
                objMunicipios.mensaje = "500 Internal Error: " + ex.Message;
                lstMunicipios.Add(objMunicipios);
            }

            return lstMunicipios;

        }

        public List<Estados> Estados()
        {
            
            var lstEstados = new List<Estados>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {


                    SqlCommand query = new SqlCommand(".[sAppMayoristas].[procCtl_Estados_Get]", conn);


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            Estados objEstados = new Estados();

                            objEstados.IDEstado = reader["IDEstado"] == System.DBNull.Value ? " " : reader["IDEstado"].ToString();
                            objEstados.Estado = reader["Estado"] == System.DBNull.Value ? " " : reader["Estado"].ToString();
                            objEstados.mensaje = "200 OK";


                            lstEstados.Add(objEstados);

                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Estados objEstados = new Estados();
                objEstados.mensaje = "500 Internal Error: " + ex.Message;
                lstEstados.Add(objEstados);
            }

            return lstEstados;

        }


        protected SqlConnection conexionBD()
        {
            StackTrace stackFrame = new StackTrace();
            
            string metodoLlama = stackFrame.GetFrame(1).GetMethod().Name;//se verifica el metodo para dirigirlo a pruebas

            SqlConnection conn = new SqlConnection();

            if (metodoLlama != "cadena")//produccion
            {

                if (metodoLlama == "asignarVale")//para este metodo se abre conexion a bd buffer con usuario SA por tema re permisos de ejecucion de cmdshell
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringBufferSA"].ConnectionString;
                else
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringBuffer"].ConnectionString;
            }
            else//Pruebas
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringBufferPruebas"].ConnectionString;
            }
            conn.Open();

            return conn;


        }
    }
}