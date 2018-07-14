using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace ws_appMayoristas
{
    [Serializable]
    [XmlType(TypeName = "CmisValesCompras")]
    public class CmisValesCompras : ClienteMayorista
    {
        private string _idFactura;

        public string idFactura
        {
            get { return _idFactura; }
            set { _idFactura = value; }
        }
        private string _FechaCompra;

        public string FechaCompra
        {
            get { return _FechaCompra; }
            set { _FechaCompra = value; }
        }
        private double _ImporteCompra;

        public double ImporteCompra
        {
            get { return _ImporteCompra; }
            set { _ImporteCompra = value; }
        }
        private string _idSucursalCompra;

        public string idSucursalCompra
        {
            get { return _idSucursalCompra; }
            set { _idSucursalCompra = value; }
        }
        private string _SucursalCompra;

        public string SucursalCompra
        {
            get { return _SucursalCompra; }
            set { _SucursalCompra = value; }
        }
        private uint _idCliente;

        public uint idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
        private string _cCliente;

        public string cCliente
        {
            get { return _cCliente; }
            set { _cCliente = value; }
        }
        private string _cSubCliente;

        public string cSubCliente
        {
            get { return _cSubCliente; }
            set { _cSubCliente = value; }
        }
        private string _idSubCliente;

        public string idSubCliente
        {
            get { return _idSubCliente; }
            set { _idSubCliente = value; }
        }

        private string _PersonaAutorizada;

        public string PersonaAutorizada
        {
            get { return _PersonaAutorizada; }
            set { _PersonaAutorizada = value; }
        }

        private double _PagoQuincenal;

        public double PagoQuincenal
        {
            get { return _PagoQuincenal; }
            set { _PagoQuincenal = value; }
        }
        private string _Segmentos;

        public string Segmentos
        {
            get { return _Segmentos; }
            set { _Segmentos = value; }
        }
        private string _Credivales;

        public string Credivales
        {
            get { return _Credivales; }
            set { _Credivales = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public CMisValesComprasResponse getValesCompras(string cCliente, string cPlaza)
        {
            
            string getValesCompras = string.Empty;
            
            var lstValesCompras = new List<CmisValesCompras>();
            CMisValesComprasResponse objMisValesComprasResponse = new CMisValesComprasResponse();

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {
                    SqlCommand query = new SqlCommand("[sAppMayoristas].[procMisVales_Compras] @PRTCCLIENTE, @PRTCPLAZA", conn);
                    query.Parameters.Add(new SqlParameter("PRTCCLIENTE", cCliente));
                    query.Parameters.Add(new SqlParameter("PRTCPLAZA", cPlaza));
                    query.CommandTimeout = 0;

                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CmisValesCompras objMisValesCompras = new CmisValesCompras();

                            objMisValesCompras.idFactura = reader["idFactura"] == System.DBNull.Value ? "" : reader["idFactura"].ToString();
                            objMisValesCompras.FechaCompra = reader["FechaCompra"] == System.DBNull.Value ? "1900-01-01" : Convert.ToDateTime(reader["FechaCompra"].ToString()).ToShortDateString();
                            objMisValesCompras.ImporteCompra = reader["ImporteCompra"] == System.DBNull.Value ? 0.0 : Convert.ToDouble(reader["ImporteCompra"].ToString());
                            objMisValesCompras.idSucursalCompra = reader["idSucursalCompra"] == System.DBNull.Value ? "" : reader["idSucursalCompra"].ToString();
                            objMisValesCompras.SucursalCompra = reader["SucursalCompra"] == System.DBNull.Value ? "" : reader["SucursalCompra"].ToString();
                            objMisValesCompras.idCliente = reader["idCliente"] == System.DBNull.Value ? 0 : Convert.ToUInt32(reader["idCliente"].ToString());
                            objMisValesCompras.cCliente = reader["cCliente"] == System.DBNull.Value ? " " : reader["cCliente"].ToString();
                            objMisValesCompras.cSubCliente = reader["cSubCliente"] == System.DBNull.Value ? " " : reader["cSubCliente"].ToString();
                            objMisValesCompras.idSubCliente = reader["idSubCliente"] == System.DBNull.Value ? " " : reader["idSubCliente"].ToString();
                            objMisValesCompras.PersonaAutorizada = reader["PersonaAutorizada"] == System.DBNull.Value ? " " : reader["PersonaAutorizada"].ToString();
                            objMisValesCompras.PagoQuincenal = reader["PagoQuincenal"] == System.DBNull.Value ? 0.0 : Convert.ToDouble(reader["PagoQuincenal"].ToString());
                            objMisValesCompras.Segmentos = reader["Segmentos"] == System.DBNull.Value ? " " : reader["Segmentos"].ToString();
                            objMisValesCompras.Credivales = reader["Credivales"] == System.DBNull.Value ? " " : reader["Credivales"].ToString();
                            objMisValesCompras.mensaje = "200 OK";

                            lstValesCompras.Add(objMisValesCompras);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objMisValesComprasResponse.cadenaRespuesta = "500 Internal Error: " + ex.Message;
                return objMisValesComprasResponse;
            }

            getValesCompras = CHerramientas.SerializarArrayList(lstValesCompras, typeof(CmisValesCompras));
            objMisValesComprasResponse.cadenaRespuesta = CHerramientas.CrearZipBase64(getValesCompras, "getMisValesCompras");
            return objMisValesComprasResponse;
            

        }

    }
}