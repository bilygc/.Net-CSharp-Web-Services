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
        public List<saldoMayoristas> Saldo(string idcliente, string plaza, string tipoCredito)
        {
            
            var listOfSaldos = new List<saldoMayoristas>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {


                    SqlCommand query = new SqlCommand("exec [sAppMayoristas].[procSaldosClientes_get] @CLIENTE, @PLAZA, @TIPOCREDITO", conn);
                    query.Parameters.Add(new SqlParameter("CLIENTE", idcliente));
                    query.Parameters.Add(new SqlParameter("PLAZA", plaza));
                    query.Parameters.Add(new SqlParameter("TIPOCREDITO", tipoCredito));
                    query.CommandTimeout = 0;

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            var saldos = new saldoMayoristas();
                            saldos.idcliente = reader["idcliente"] == System.DBNull.Value ? " " : reader["idcliente"].ToString();
                            saldos.clavecliente = reader["ccliente"] == System.DBNull.Value ? " " : reader["ccliente"].ToString();
                            saldos.saldo = reader["Saldo"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["Saldo"]);
                            saldos.pagoMinimo = reader["PagoMinimo"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["PagoMinimo"]);
                            saldos.limite = reader["nLimite"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["nLimite"]);
                            saldos.disponible = reader["Disponible"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["Disponible"]);
                            saldos.fecha = reader["Fecha"] == System.DBNull.Value ? " " : Convert.ToDateTime(reader["Fecha"]).ToShortDateString();
                            saldos.Descuento = reader["Descuento"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["Descuento"]);
                            saldos.LiquidaCon = reader["LiquidaCon"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["LiquidaCon"]);
                            saldos.FechaProximoCorte = reader["FechaProximoCorte"] == System.DBNull.Value ? " " : Convert.ToDateTime(reader["FechaProximoCorte"]).ToShortDateString();
                            listOfSaldos.Add(saldos);
                        }


                    }
                }
                
            }
            catch (Exception ex)
            {
                var saldos = new saldoMayoristas();
                saldos.mensaje = ex.Message;
                listOfSaldos.Add(saldos);
                Console.WriteLine("Se ha presentado un Error: " + ex.Message);
                
            }
         
            return listOfSaldos;
        }


        public PuntosMayorista puntos(string idcliente, string plaza)
        {
            SqlConnection conn;
            PuntosMayorista objPuntosMayorista = new PuntosMayorista();

            try
            {
                conn = this.conexionBD();

                SqlCommand query = new SqlCommand("exec [sAppMayoristas].[procSaldosClientes_get] @CLIENTE, @PLAZA", conn);
                query.Parameters.Add(new SqlParameter("CLIENTE", idcliente));
                query.Parameters.Add(new SqlParameter("PLAZA", plaza));


                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    // while there is another record present            
                    while (reader.Read())
                    {
                        objPuntosMayorista.puntos = Convert.ToInt32(reader["puntos"]);
                        objPuntosMayorista.strMensaje = "200 OK";

                    }
                }
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {

                objPuntosMayorista.strMensaje = ex.Message;
                Console.WriteLine("Se ha presentado un Error: " + ex.Message);
            }

            return objPuntosMayorista;
        }

        //public List<ValesMayorista> ValesMayorista(string strCliente, string strPlaza, string strTipoCredito )
        public string ValesMayorista(string strCliente, string strPlaza, string strTipoCredito)
        {
            string strValesMayoristas = string.Empty;
            
            var lstValesMayorista = new List<ValesMayorista>();

            try {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("exec [sAppMayoristas].[procMisVales_Folios] @CLIENTE, @PLAZA, @TIPOCREDITO", conn);
                    query.Parameters.Add(new SqlParameter("CLIENTE", strCliente));
                    query.Parameters.Add(new SqlParameter("PLAZA", strPlaza));
                    query.Parameters.Add(new SqlParameter("TIPOCREDITO", strTipoCredito));
                    query.CommandTimeout = 0;

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        
                        //mientras haya registros
                        while (reader.Read())
                        {
                            DateTime fechaAux;
                            //VARIABLES PARA CODIFICACION DE CARACTERES
                            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                            Encoding utf8 = Encoding.UTF8;
                            byte[] isoBytes;
                            byte[] utfBytes;
                            /////////////////////////////////////////
                            var objVales = new ValesMayorista();

                            objVales.idValera = reader["idValera"] == System.DBNull.Value ? (uint)0 : Convert.ToUInt32(reader["idValera"].ToString().Trim());
                            fechaAux = reader["Fecha"] == System.DBNull.Value ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(reader["Fecha"]);
                            objVales.Fecha = fechaAux.ToString("yyyy-MM-dd");
                            objVales.cCliente = reader["ccliente"] == System.DBNull.Value ? " " : reader["ccliente"].ToString().Trim();
                            objVales.idTipoCrediVale = reader["idTipoCredivale"] == System.DBNull.Value ? (Int16)0 : Convert.ToInt16(reader["idTipoCredivale"].ToString().Trim());
                            objVales.FolioCrediVale = reader["FolioCrediVale"] == System.DBNull.Value ? " " : reader["FolioCrediVale"].ToString().Trim();
                            objVales.cFolioCredivaleVista = reader["cFolioCredivaleVista"] == System.DBNull.Value ? " " : reader["cFolioCredivaleVista"].ToString().Trim();

                            //codificamos a utf8
                            objVales.PersonaAutorizada = reader["PersonaAutorizada"] == System.DBNull.Value ? " " : reader["PersonaAutorizada"].ToString().Trim();
                            isoBytes = iso.GetBytes(objVales.PersonaAutorizada);
                            utfBytes = Encoding.Convert(iso, utf8, isoBytes);
                            objVales.PersonaAutorizada = string.Empty;
                            objVales.PersonaAutorizada = utf8.GetString(utfBytes);
                            objVales.PersonaAutorizada = CHerramientas.quitarAcentos(objVales.PersonaAutorizada);
                            objVales.PersonaAutorizada = objVales.PersonaAutorizada.ToUpper();

                            objVales.ReferenciaDestino = reader["ReferenciaDestino"] == System.DBNull.Value ? " " : reader["ReferenciaDestino"].ToString().Trim();
                            objVales.Importe = reader["Importe"] == System.DBNull.Value ? (double)0.0 : Convert.ToDouble(reader["Importe"].ToString().Trim());
                            fechaAux = reader["Vigencia"] == System.DBNull.Value ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(reader["Vigencia"]);
                            objVales.Vigencia = fechaAux.ToString("yyyy-MM-dd");
                            objVales.Status = reader["Status"] == System.DBNull.Value ? " " : reader["Status"].ToString().Trim();
                            objVales.cIndFactura = reader["cIndFactura"] == System.DBNull.Value ? " " : reader["cIndFactura"].ToString().Trim();
                            fechaAux = reader["FechaCancela"] == System.DBNull.Value ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(reader["FechaCancela"]);
                            objVales.FechaCancela = fechaAux.ToString("yyyy-MM-dd");
                            objVales.MotivoCancela = reader["MotivoCancela"] == System.DBNull.Value ? " " : reader["MotivoCancela"].ToString().Trim();
                            objVales.mensaje = "200 OK";

                            lstValesMayorista.Add(objVales);

                        }
                    }
                }
            }catch(Exception ex){
                var objVales = new ValesMayorista();
                objVales.mensaje = "500 Internal Error: "+ex.Message;
                lstValesMayorista.Add(objVales);
            }

            //Serializamos la lista de objetos a una cadena xml
            strValesMayoristas = CHerramientas.SerializarArrayList(lstValesMayorista, typeof(ValesMayorista) );
            //convertimos la cadena a un archivo XML y lo comprimimos en un ZIP, lo convertimos a base64 y lo retornamos
            return CHerramientas.CrearZipBase64(strValesMayoristas, "getVales");

        }

        public List<BoletinadosMayorista> Boletinados(string strCliente )
        {
            
            var lstBoletinadosMayorista = new List<BoletinadosMayorista>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procClientesBoletinados_get] @CLIENTE", conn);
                    query.Parameters.Add(new SqlParameter("CLIENTE", strCliente));
                    query.CommandTimeout = 0;


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            var objBoletinados = new BoletinadosMayorista();
                            objBoletinados.idcliente = reader["idcliente"] == System.DBNull.Value ? 0 : Convert.ToUInt32(reader["idcliente"].ToString());
                            objBoletinados.Paterno = reader["Paterno"] == System.DBNull.Value ? " " : reader["Paterno"].ToString();
                            objBoletinados.Materno = reader["Materno"] == System.DBNull.Value ? " " : reader["Materno"].ToString();
                            objBoletinados.Nombre = reader["Nombre"] == System.DBNull.Value ? " " : reader["Nombre"].ToString();
                            objBoletinados.Desde = reader["Desde"] == System.DBNull.Value ? " " : Convert.ToDateTime(reader["Desde"]).ToShortDateString();
                            objBoletinados.Observaciones = reader["Observaciones"] == System.DBNull.Value ? " " : reader["Observaciones"].ToString();
                            objBoletinados.cClienteReporta = reader["cClienteReporta"] == System.DBNull.Value ? " " : reader["cClienteReporta"].ToString();
                            objBoletinados.mensaje = "200 OK";
                            lstBoletinadosMayorista.Add(objBoletinados);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                var objBoletinados = new BoletinadosMayorista();
                objBoletinados.mensaje = "500 Internal Error";
                lstBoletinadosMayorista.Add(objBoletinados);
            }

            return lstBoletinadosMayorista;

        }

        public List<SubclientesMayorista> Subclientes()
        {
            
            var lstSubclientes = new List<SubclientesMayorista>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_ClientesSubClientes_Get] ", conn);
                    query.CommandTimeout = 0;


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            var objSubclientes = new SubclientesMayorista();
                            objSubclientes.idcliente = reader["idcliente"] == System.DBNull.Value ? 0 : Convert.ToUInt32(reader["idcliente"].ToString());
                            objSubclientes.ccliente = reader["ccliente"] == System.DBNull.Value ? " " : reader["ccliente"].ToString();
                            objSubclientes.CSUC_CLIENTE = reader["CSUC_CLIENTE"] == System.DBNull.Value ? " " : reader["CSUC_CLIENTE"].ToString();
                            objSubclientes.NombreSubCliente = reader["NombreSubCliente"] == System.DBNull.Value ? " " : reader["NombreSubCliente"].ToString();
                            objSubclientes.Movil = reader["Movil"] == System.DBNull.Value ? " " : reader["Movil"].ToString();
                            objSubclientes.Telefono = reader["Telefono"] == System.DBNull.Value ? " " : reader["Telefono"].ToString();
                            objSubclientes.eMail = reader["eMail"] == System.DBNull.Value ? " " : reader["eMail"].ToString();
                            objSubclientes.Domicilio = reader["Domicilio"] == System.DBNull.Value ? " " : reader["Domicilio"].ToString();
                            objSubclientes.CP = reader["CP"] == System.DBNull.Value ? " " : reader["CP"].ToString();
                            objSubclientes.Calle = reader["Calle"] == System.DBNull.Value ? " " : reader["Calle"].ToString();
                            objSubclientes.NumExt = reader["NumExt"] == System.DBNull.Value ? " " : reader["NumExt"].ToString();
                            objSubclientes.idCP = reader["idCP"] == System.DBNull.Value ? " " : reader["idCP"].ToString();
                            objSubclientes.idasentamiento = reader["idasentamiento"] == System.DBNull.Value ? " " : reader["idasentamiento"].ToString();

                            objSubclientes.mensaje = "200 OK";
                            lstSubclientes.Add(objSubclientes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var objSubclientes = new SubclientesMayorista();
                objSubclientes.mensaje = "500 Internal Error: "+ex.Message;
                lstSubclientes.Add(objSubclientes);
            }

            return lstSubclientes;

        }


        public List<ClientesMedioContacto> MediosContacto()
        {
            
            var lstMediosContacto = new List<ClientesMedioContacto>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_ClientesMediosDeContacto_Get]", conn);
                    query.CommandTimeout = 0;


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            var objMedioContacto = new ClientesMedioContacto();

                            objMedioContacto.idcliente = reader["idcliente"] == System.DBNull.Value ? 0 : Convert.ToUInt32(reader["idcliente"].ToString());
                            objMedioContacto.cCliente = reader["cCliente"] == System.DBNull.Value ? " " : reader["cCliente"].ToString();
                            objMedioContacto.idTipoMedio = reader["idTipoMedio"] == System.DBNull.Value ? " " : reader["idTipoMedio"].ToString();
                            objMedioContacto.Referencia = reader["Referencia"] == System.DBNull.Value ? " " : reader["Referencia"].ToString();
                            objMedioContacto.Notas = reader["Notas"] == System.DBNull.Value ? " " : reader["Notas"].ToString();
                            objMedioContacto.Status = reader["Status"] == System.DBNull.Value ? " " : reader["Status"].ToString();

                            objMedioContacto.mensaje = "200 OK";
                            lstMediosContacto.Add(objMedioContacto);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                var objMedioContacto = new ClientesMedioContacto();
                objMedioContacto.mensaje = "500 Internal Error: " + ex.Message;
                lstMediosContacto.Add(objMedioContacto);
            }
            

            return lstMediosContacto;

        }

        public List<DomicilioClientes> Domiciliocliente()
        {
            
            var lstDomicilios = new List<DomicilioClientes>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_ClientesDomicilio_Get]", conn);
                    query.CommandTimeout = 0;


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            DomicilioClientes objDomicilios = new DomicilioClientes();

                            objDomicilios.idcliente = reader["idcliente"] == System.DBNull.Value ? 0 : Convert.ToUInt32(reader["idcliente"].ToString());
                            objDomicilios.cCliente = reader["cCliente"] == System.DBNull.Value ? " " : reader["cCliente"].ToString();
                            objDomicilios.idCP = reader["idCP"] == System.DBNull.Value ? " " : reader["idCP"].ToString();
                            objDomicilios.idAsentamiento = reader["idAsentamiento"] == System.DBNull.Value ? " " : reader["idAsentamiento"].ToString();

                            objDomicilios.mensaje = "200 OK";
                            lstDomicilios.Add(objDomicilios);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                DomicilioClientes objDomicilios = new DomicilioClientes();
                objDomicilios.mensaje = "500 Internal Error: " + ex.Message;
                lstDomicilios.Add(objDomicilios);
            }
           

            return lstDomicilios;

        }

        public List<ClientesMayoristas> ctsMayoristas()
        {
            
            var lstClientesMayoristas = new List <ClientesMayoristas>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_Clientes_Get]", conn);
                    query.CommandTimeout = 0;


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        Int64 i = 0;
                        while (reader.Read())
                        {
                            ClientesMayoristas objMayoristas = new ClientesMayoristas();

                            objMayoristas.idcliente = reader["idcliente"] == System.DBNull.Value ? 0 : Convert.ToUInt32(reader["idcliente"].ToString());
                            objMayoristas.cCliente = reader["cCliente"] == System.DBNull.Value ? " " : reader["cCliente"].ToString();
                            objMayoristas.Paterno = reader["Paterno"] == System.DBNull.Value ? " " : reader["Paterno"].ToString();
                            objMayoristas.Materno = reader["Materno"] == System.DBNull.Value ? " " : reader["Materno"].ToString();
                            objMayoristas.Nombre = reader["Nombre"] == System.DBNull.Value ? " " : reader["Nombre"].ToString();
                            objMayoristas.RFC = reader["RFC"] == System.DBNull.Value ? " " : reader["RFC"].ToString();
                            objMayoristas.idPlaza = reader["idPlaza"] == System.DBNull.Value ? " " : reader["idPlaza"].ToString();
                            objMayoristas.TipoDeCredito = reader["TipoDeCredito"] == System.DBNull.Value ? " " : reader["TipoDeCredito"].ToString();
                            objMayoristas.idCP = reader["idCP"] == System.DBNull.Value ? " " : reader["idCP"].ToString();
                            objMayoristas.idAsentamiento = reader["idAsentamiento"] == System.DBNull.Value ? " " : reader["idAsentamiento"].ToString();
                            objMayoristas.idStatus = reader["idStatus"] == System.DBNull.Value ? (Int16)(-1) : Convert.ToInt16(reader["idStatus"].ToString());
                            objMayoristas.puntosCredigana = i++;

                            objMayoristas.mensaje = "200 OK";
                            lstClientesMayoristas.Add(objMayoristas);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClientesMayoristas objMayoristas = new ClientesMayoristas();
                objMayoristas.mensaje = "500 Internal Error: " + ex.Message;
                lstClientesMayoristas.Add(objMayoristas);
            }

            return lstClientesMayoristas;

        }

        public List<TiposMediosDeContacto> TiposContacto()
        {
            
            var lstMediosContacto = new List<TiposMediosDeContacto>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_TiposMediosDeContacto_Get]", conn);


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            TiposMediosDeContacto objMediosContacto = new TiposMediosDeContacto();
                            objMediosContacto.idTipo = Convert.ToInt16(reader["idTipo"].ToString());
                            objMediosContacto.Medio = reader["Medio"] == System.DBNull.Value ? " " : reader["Medio"].ToString();


                            objMediosContacto.mensaje = "200 OK";
                            lstMediosContacto.Add(objMediosContacto);

                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                TiposMediosDeContacto objMediosContacto = new TiposMediosDeContacto();
                objMediosContacto.mensaje = "500 Internal Error: " + ex.Message;
                lstMediosContacto.Add(objMediosContacto);
            }

            return lstMediosContacto;

        }

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

        public List<TiposDeCredito> TiposDeCredito()
        {
            
            var lstTiposCredito = new List<TiposDeCredito>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_TiposDeCredito_Get]", conn);


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            TiposDeCredito objTiposDeCredito = new TiposDeCredito();
                            objTiposDeCredito.idTipoDeCredito = reader["idTipoDeCredito"] == System.DBNull.Value ? " " : reader["idTipoDeCredito"].ToString();
                            objTiposDeCredito.TipoDeCredito = reader["TipoDeCredito"] == System.DBNull.Value ? " " : reader["TipoDeCredito"].ToString();

                            objTiposDeCredito.mensaje = "200 OK";
                            lstTiposCredito.Add(objTiposDeCredito);

                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                TiposDeCredito objTiposDeCredito = new TiposDeCredito();
                objTiposDeCredito.mensaje = "500 Internal Error: " + ex.Message;
                lstTiposCredito.Add(objTiposDeCredito);
            }

            return lstTiposCredito;

        }

        public List<OficinasDeCredito> OficinasDeCredito(string sTipoSucursal)
        {
            
            var lstOficinas = new List<OficinasDeCredito>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_OficinasCredito_Get] @TIPOSUCURSAL", conn);
                    query.Parameters.Add(new SqlParameter("TIPOSUCURSAL", sTipoSucursal));


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            OficinasDeCredito objOficinas = new OficinasDeCredito();

                            objOficinas.idOficina = reader["idOficina"] == System.DBNull.Value ? " " : reader["idOficina"].ToString();
                            objOficinas.NombreOficina = reader["NombreOficina"] == System.DBNull.Value ? " " : reader["NombreOficina"].ToString();
                            objOficinas.Principal = reader["Principal"] == System.DBNull.Value ? " " : reader["Principal"].ToString();
                            objOficinas.idPlaza = reader["idPlaza"] == System.DBNull.Value ? " " : reader["idPlaza"].ToString();
                            objOficinas.TipoTienda = reader["TipoTienda"] == System.DBNull.Value ? " " : reader["TipoTienda"].ToString();
                            objOficinas.Calle = reader["Calle"] == System.DBNull.Value ? " " : reader["Calle"].ToString();
                            objOficinas.NumExt = reader["NumExt"] == System.DBNull.Value ? " " : reader["NumExt"].ToString();
                            objOficinas.NumInt = reader["NumInt"] == System.DBNull.Value ? " " : reader["NumInt"].ToString();
                            objOficinas.Colonia = reader["Colonia"] == System.DBNull.Value ? " " : reader["Colonia"].ToString();
                            objOficinas.idAsentamiento = reader["idAsentamiento"] == System.DBNull.Value ? " " : reader["idAsentamiento"].ToString();
                            objOficinas.CP = reader["CP"] == System.DBNull.Value ? " " : reader["CP"].ToString();
                            objOficinas.nLatitud = reader["nLatitud"] == System.DBNull.Value ? " " : reader["nLatitud"].ToString();
                            objOficinas.nLongitud = reader["nLongitud"] == System.DBNull.Value ? " " : reader["nLongitud"].ToString();
                            objOficinas.Referencia = reader["Referencia"] == System.DBNull.Value ? " " : reader["Referencia"].ToString();
                            objOficinas.Telefono = reader["Telefono"] == System.DBNull.Value ? " " : reader["Telefono"].ToString();
                            objOficinas.Localidad = reader["Localidad"] == System.DBNull.Value ? " " : reader["Localidad"].ToString();
                            objOficinas.Municipio = reader["Municipio"] == System.DBNull.Value ? " " : reader["Municipio"].ToString();
                            objOficinas.Estado = reader["Estado"] == System.DBNull.Value ? " " : reader["Estado"].ToString();
                            objOficinas.Pais = reader["Pais"] == System.DBNull.Value ? " " : reader["Pais"].ToString();


                            objOficinas.mensaje = "200 OK";
                            lstOficinas.Add(objOficinas);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OficinasDeCredito objOficinas = new OficinasDeCredito();
                objOficinas.mensaje = "500 Internal Error: " + ex.Message;
                lstOficinas.Add(objOficinas);
            }

            return lstOficinas;

        }

        public List<Plazas> Plazas()
        {
            
            var lstPlazas = new List<Plazas>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCtl_Plazas_Get]", conn);


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            Plazas objPlazas = new Plazas();
                            objPlazas.idPlaza = reader["idPlaza"] == System.DBNull.Value ? " " : reader["idPlaza"].ToString();
                            objPlazas.NombrePlaza = reader["NombrePlaza"] == System.DBNull.Value ? " " : reader["NombrePlaza"].ToString();
                            objPlazas.idSerieVale = reader["idSerieVale"] == System.DBNull.Value ? " " : reader["idSerieVale"].ToString();
                            objPlazas.idestado = reader["idestado"] == System.DBNull.Value ? " " : reader["idestado"].ToString();
                            objPlazas.IDMunicipio = reader["IDMunicipio"] == System.DBNull.Value ? " " : reader["IDMunicipio"].ToString();
                            objPlazas.ClavePlaza = reader["ClavePlaza"] == System.DBNull.Value ? " " : reader["ClavePlaza"].ToString();
                            objPlazas.eMail_Clientes = reader["eMail_Clientes"] == System.DBNull.Value ? " " : reader["eMail_Clientes"].ToString();

                            objPlazas.mensaje = "200 OK";
                            lstPlazas.Add(objPlazas);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Plazas objPlazas = new Plazas();
                objPlazas.mensaje = "500 Internal Error: " + ex.Message;
                lstPlazas.Add(objPlazas);
            }

            return lstPlazas;

        }

        public CorteAnterior CorteAnteriorCompras(string cliente)
        {
            SqlConnection conn;
            CorteAnterior objCorteAnterior = new CorteAnterior();

            try
            {
                conn = this.conexionBD();

                SqlCommand query = new SqlCommand("[sAppMayoristas].[procCorteAnteriorCompras] @CLIENTE", conn);
                query.Parameters.Add(new SqlParameter("CLIENTE", cliente));

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    // while there is another record present            
                    while (reader.Read())
                    {
                        objCorteAnterior.cCliente = reader["cCliente"] == System.DBNull.Value ? " " : reader["cCliente"].ToString();
                        objCorteAnterior.idCliente = reader["idCliente"] == System.DBNull.Value ? 0 : Convert.ToUInt32(reader["idCliente"].ToString());
                        objCorteAnterior.FechaCorte = reader["FechaCorte"] == System.DBNull.Value ? " " : Convert.ToDateTime(reader["FechaCorte"].ToString()).ToShortDateString();
                        objCorteAnterior.TotalCorte = reader["TotalCorte"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["TotalCorte"].ToString());
                        objCorteAnterior.Pagos = reader["Pagos"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["Pagos"].ToString());
                        objCorteAnterior.Descuentos = reader["Descuentos"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["Descuentos"].ToString());
                        objCorteAnterior.AnticiposAplicados = reader["AnticiposAplicados"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["AnticiposAplicados"].ToString());
                        objCorteAnterior.Saldo = reader["Saldo"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["Saldo"].ToString());
                        objCorteAnterior.mensaje = "200 OK";


                    }
                }
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                
                objCorteAnterior.mensaje = "500 Internal Error: " + ex.Message;
                
            }

            return objCorteAnterior;

        }

        public List<CorteActual> CorteActualCompras(string cliente)
        {
            
            //CorteActual objCorte = new CorteActual();
            var listOfCorteActual = new List<CorteActual>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procCorteActualCompras] @CLIENTE", conn);
                    query.Parameters.Add(new SqlParameter("CLIENTE", cliente));
                    query.CommandTimeout = 0;

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            CorteActual objCorte = new CorteActual();
                            objCorte.ccliente = reader["ccliente"] == System.DBNull.Value ? " " : reader["ccliente"].ToString();
                            objCorte.idCliente = reader["idCliente"] == System.DBNull.Value ? 0 : Convert.ToUInt32(reader["idCliente"].ToString());
                            objCorte.FechaDeCorte = reader["FechaDeCorte"] == System.DBNull.Value ? " " : Convert.ToDateTime(reader["FechaDeCorte"].ToString()).ToShortDateString();
                            objCorte.FechaLimitePago = reader["FechaLimitePago"] == System.DBNull.Value ? " " : Convert.ToDateTime(reader["FechaLimitePago"].ToString()).ToShortDateString();
                            objCorte.SaldoAlCorte = reader["SaldoAlCorte"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["SaldoAlCorte"].ToString());
                            objCorte.PagoMinimo = reader["PagoMinimo"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["PagoMinimo"].ToString());
                            objCorte.TotalPagado = reader["TotalPagado"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["TotalPagado"].ToString());
                            objCorte.DescuentoAplicado = reader["DescuentoAplicado"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["DescuentoAplicado"].ToString());
                            objCorte.SaldoActual = reader["SaldoActual"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["SaldoActual"].ToString());
                            objCorte.AnticiposProximoCorte = reader["AnticiposProximoCorte"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["AnticiposProximoCorte"].ToString());
                            objCorte.NuevasCompras = reader["NuevasCompras"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["NuevasCompras"].ToString());
                            objCorte.mensaje = "200 OK";
                            listOfCorteActual.Add(objCorte);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CorteActual objCorte = new CorteActual();
                objCorte.mensaje = "500 Internal Error: " + ex.Message;
                listOfCorteActual.Add(objCorte);
            }

            return listOfCorteActual;

        }

        public List<CorteDetalle> corteDetalle(Int16 tipo, string cliente)
        {
            SqlConnection conn;
            var lstCorteDetalle = new List<CorteDetalle>();

            try
            {
                conn = this.conexionBD();

                SqlCommand query = new SqlCommand("[sAppMayoristas].[procCorteCompras_Detalle] @TIPO, @CLIENTE", conn);
                query.Parameters.Add(new SqlParameter("TIPO", tipo));
                query.Parameters.Add(new SqlParameter("CLIENTE", cliente));

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    // while there is another record present            
                    while (reader.Read())
                    {
                        CorteDetalle objCorteDetalle = new CorteDetalle();
                        objCorteDetalle.FechaCorte = reader["FechaCorte"] == System.DBNull.Value ? " " : Convert.ToDateTime(reader["FechaCorte"].ToString()).ToShortDateString();
                        objCorteDetalle.idCredivale = reader["idCredivale"] == System.DBNull.Value ? " " : reader["idCredivale"].ToString();
                        objCorteDetalle.ImporteCompra = reader["ImporteCompra"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["ImporteCompra"].ToString());
                        objCorteDetalle.idCliente = reader["idCliente"] == System.DBNull.Value ? 0 : Convert.ToUInt32(reader["idCliente"].ToString());
                        objCorteDetalle.cCliente = reader["cCliente"] == System.DBNull.Value ? " " : reader["cCliente"].ToString();
                        objCorteDetalle.cSubCliente = reader["cSubCliente"] == System.DBNull.Value ? " " : reader["cSubCliente"].ToString();
                        objCorteDetalle.idSubCliente =  reader["idSubCliente"] == System.DBNull.Value ? 0 : Convert.ToUInt32(reader["idSubCliente"].ToString());
                        objCorteDetalle.FechaCompra = reader["FechaCompra"] == System.DBNull.Value ? " " : Convert.ToDateTime(reader["FechaCompra"].ToString()).ToShortDateString();
                        objCorteDetalle.idSucursalCompra = reader["idSucursalCompra"] == System.DBNull.Value ? " " : reader["idSucursalCompra"].ToString();
                        objCorteDetalle.SucursalCompra = reader["SucursalCompra"] == System.DBNull.Value ? " " : reader["SucursalCompra"].ToString();
                        objCorteDetalle.PagoQuincenal = reader["PagoQuincenal"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["PagoQuincenal"].ToString());
                        objCorteDetalle.Pago = reader["Pago"] == System.DBNull.Value ? Convert.ToInt16(0) : Convert.ToInt16(reader["Pago"].ToString());
                        objCorteDetalle.Pagos = reader["Pagos"] == System.DBNull.Value ? Convert.ToInt16(0) : Convert.ToInt16(reader["Pagos"].ToString());
                        objCorteDetalle.mensaje = "200 OK"; 
                        lstCorteDetalle.Add(objCorteDetalle);

                    }
                }
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                CorteDetalle objCorteDetalle = new CorteDetalle();
                objCorteDetalle.mensaje = "500 Internal Error: " + ex.Message;
                lstCorteDetalle.Add(objCorteDetalle);
            }

            return lstCorteDetalle;

        }

        public List<CresponseReferenciasBanc> refBancarias(string cliente)
        {            

            var listOfReferencias = new List<CresponseReferenciasBanc>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procSaldosClientes_get] @CLIENTE, '', '05', 1", conn);
                    query.Parameters.Add(new SqlParameter("CLIENTE ", cliente));
                    query.CommandTimeout = 0;

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var referenciaBancaria = new CresponseReferenciasBanc();
                            referenciaBancaria.cCliente = reader["cCliente"] == System.DBNull.Value ? string.Empty : reader["cCliente"].ToString();
                            referenciaBancaria.FechaPago = reader["FechaPago"] == System.DBNull.Value ? string.Empty : Convert.ToDateTime(reader["FechaPAgo"]).ToShortDateString();
                            referenciaBancaria.Descuento = reader["Descuento"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["Descuento"]);
                            referenciaBancaria.Importe = reader["Importe"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["Importe"]);
                            referenciaBancaria.Entidad = reader["Entidad"] == System.DBNull.Value ? string.Empty : reader["Entidad"].ToString();
                            referenciaBancaria.Referencia = reader["Referencia"] == System.DBNull.Value ? string.Empty : reader["Referencia"].ToString();
                            referenciaBancaria.Convenio = reader["Convenio"] == System.DBNull.Value ? string.Empty : reader["Convenio"].ToString();
                            listOfReferencias.Add(referenciaBancaria);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var referenciaBancaria = new CresponseReferenciasBanc();
                referenciaBancaria.mensaje = "500 Internal Error: " + ex.Message;
                listOfReferencias.Add(referenciaBancaria);
            }

            return listOfReferencias;
            

        }

        public List<ReferenciasBancariasGenericas> refBancariasGenericas(string cliente)
        {
            
            var lstrefBancariasGenericas = new List<ReferenciasBancariasGenericas>();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procReferenciasBancarias_Genericas] @CLIENTE ", conn);
                    query.Parameters.Add(new SqlParameter("CLIENTE ", cliente));
                    query.CommandTimeout = 0;

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            ReferenciasBancariasGenericas objRefBancariasGenericas = new ReferenciasBancariasGenericas();
                            objRefBancariasGenericas.ccliente = reader["ccliente"] == System.DBNull.Value ? " " : reader["ccliente"].ToString();
                            objRefBancariasGenericas.idCliente = reader["idCliente"] == System.DBNull.Value ? 0 : Convert.ToUInt32(reader["idCliente"].ToString());
                            objRefBancariasGenericas.Banco = reader["Banco"] == System.DBNull.Value ? " " : reader["Banco"].ToString();
                            objRefBancariasGenericas.Sucursal = reader["Sucursal"] == System.DBNull.Value ? " " : reader["Sucursal"].ToString();
                            objRefBancariasGenericas.Cuenta = reader["Cuenta"] == System.DBNull.Value ? " " : reader["Cuenta"].ToString();
                            objRefBancariasGenericas.Referencia = reader["Referencia"] == System.DBNull.Value ? " " : reader["Referencia"].ToString();

                            objRefBancariasGenericas.mensaje = "200 OK";
                            lstrefBancariasGenericas.Add(objRefBancariasGenericas);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ReferenciasBancariasGenericas objRefBancariasGenericas = new ReferenciasBancariasGenericas();
                objRefBancariasGenericas.mensaje = "500 Internal Error: " + ex.Message;
                lstrefBancariasGenericas.Add(objRefBancariasGenericas);
            }

            return lstrefBancariasGenericas;

        }

        public PostVale asignarVale(string cClienteEmisor, int idClienteEmisor, string movilEmisor, double importe, Int16 tipoMedio, string referenciaDestino, Int16 idOficialDestino, string nombreReceptor)
        {
            PostVale objVale = new PostVale();
            

            try
            {

                CenviarCorreoSMS objEnviarCorreoSms = new CenviarCorreoSMS();

                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[proceVale_Get] @CCLIENTEEMISOR, @IDCLIENTEEMISOR, @MOVILEMISOR, @IMPORTE, @TIPOMEDIO, @REFERENCIADESTINO, @IDOFICIALDESTINO, @NOMBRERECEPTOR", conn);
                    query.Parameters.Add(new SqlParameter("CCLIENTEEMISOR", cClienteEmisor));//clave del emisor
                    query.Parameters.Add(new SqlParameter("IDCLIENTEEMISOR", idClienteEmisor));//id del emisor
                    query.Parameters.Add(new SqlParameter("MOVILEMISOR", movilEmisor));//numero de celular del mayorista
                    query.Parameters.Add(new SqlParameter("IMPORTE", importe));//importe del vale
                    query.Parameters.Add(new SqlParameter("TIPOMEDIO", tipoMedio));//1 celular 2 correo-e
                    query.Parameters.Add(new SqlParameter("REFERENCIADESTINO", referenciaDestino));//numero de celular o correo-e
                    query.Parameters.Add(new SqlParameter("IDOFICIALDESTINO", idOficialDestino));//ultimos 3 digitos ife
                    query.Parameters.Add(new SqlParameter("NOMBRERECEPTOR", nombreReceptor));//nombreReceptor subcliente


                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // mientras haya registros            
                        while (reader.Read())
                        {

                            objVale.nResultado = reader["nResultado"] == System.DBNull.Value ? 0 : Convert.ToInt32(reader["nResultado"].ToString());
                            objVale.cResultado = reader["cResultado"] == System.DBNull.Value ? " " : reader["cResultado"].ToString();
                            objVale.eVale = reader["eVale"] == System.DBNull.Value ? " " : reader["eVale"].ToString();
                            objVale.nImporteAutorizado = reader["nImporteAutorizado"] == System.DBNull.Value ? 0 : Convert.ToDouble(reader["nImporteAutorizado"].ToString());
                            objVale.cVigencia = reader["cVigencia"] == System.DBNull.Value ? "1900-01-01" : reader["cVigencia"].ToString();
                            objVale.cVigencia = objVale.cVigencia.Trim() == "" ? "1900-01-01" : objVale.cVigencia;
                            objVale.cNombreSubCliente = reader["cNombreSubCliente"] == System.DBNull.Value ? " " : reader["cNombreSubCliente"].ToString();
                            objVale.idMedioDestino = reader["idMedioDestino"] == System.DBNull.Value ? 0 : Convert.ToInt32(reader["idMedioDestino"].ToString());
                            objVale.cReferenciaDestino = reader["cReferenciaDestino"] == System.DBNull.Value ? " " : reader["cReferenciaDestino"].ToString();
                            objVale.idPeticion = reader["idPeticion"] == System.DBNull.Value ? 0 : Convert.ToInt32(reader["idPeticion"].ToString());
                            objVale.cFolioValeInterno = reader["cFolioValeInterno"] == System.DBNull.Value ? " " : reader["cFolioValeInterno"].ToString();
                            objVale.Prefijo = reader["Prefijo"] == System.DBNull.Value ? " " : reader["Prefijo"].ToString();


                            objVale.mensaje = "200 OK";


                        }

                        //si el tipo de medio es correo electronico
                        if (tipoMedio == 2)
                        {
                            //enviamos correo electronico de autorizacion al subcliente
                            CHerramientas.enviarCorreo("bilygc@calzzapato.com", referenciaDestino.Trim(), "Credito Calzzapato", objVale.cResultado);
                        }

                        SqlCommand queryBitacora = new SqlCommand("exec [sAppMayoristas].[proceVale_DesdeApp_set] @FOLIOEVALE", conn);
                        queryBitacora.Parameters.Add(new SqlParameter("FOLIOEVALE", objVale.eVale));

                        queryBitacora.ExecuteNonQuery();


                    }
                }
                

            }
            catch (Exception ex)
            {

                objVale.mensaje = "500 Internal Error: " + ex.Message;

            }

            return objVale;
        }

        public CancelarVale cancelarVale(Int16 tipoMedio, string referencia, string folioVale, int tipoCredivale)
        {
            CancelarVale objCancelarvale = new CancelarVale();
            

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {

                    SqlCommand query = new SqlCommand("[sAppMayoristas].[proceVale_Cancelar] @TIPOMEDIO, @REFERENCIA, @FOLIOVALE, @TIPOCREDIVALE ", conn);
                    query.Parameters.Add(new SqlParameter("TIPOMEDIO", tipoMedio));//celular o correo-e
                    query.Parameters.Add(new SqlParameter("REFERENCIA", referencia));//numero de celular o correo-e
                    query.Parameters.Add(new SqlParameter("FOLIOVALE", folioVale));//folio a cancelar
                    query.Parameters.Add(new SqlParameter("@TIPOCREDIVALE", tipoCredivale));//tipo de credivale



                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        // while there is another record present            
                        while (reader.Read())
                        {
                            objCancelarvale.idCancelacion = reader["idCancelacion"] == System.DBNull.Value ? " " : reader["idCancelacion"].ToString();
                            objCancelarvale.cResultado = reader["cResultado"] == System.DBNull.Value ? " " : reader["cResultado"].ToString();

                            objCancelarvale.mensaje = "200 OK";


                        }
                    }
                }
            }
            catch (Exception ex)
            {

                objCancelarvale.mensaje = "500 Internal Error: " + ex.Message;

            }

            return objCancelarvale;
        }

        protected SqlConnection conexionBD()
        {
            StackTrace stackFrame = new StackTrace();
            
            string metodoLlama = stackFrame.GetFrame(1).GetMethod().Name;//se verifica si el metodo de asignacion de vale es el que abre conexion para dirigirlo a pruebas

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