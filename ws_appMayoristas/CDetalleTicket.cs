using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ws_appMayoristas
{
    public class CDetalleTicketResponse
    {
        private string _ccliente;

        public string ccliente
        {
            get { return _ccliente; }
            set { _ccliente = value; }
        }
        private string _csuc_cliente;

        public string csuc_cliente
        {
            get { return _csuc_cliente; }
            set { _csuc_cliente = value; }
        }
        private string _PersonaAutorizada;

        public string PersonaAutorizada
        {
            get { return _PersonaAutorizada; }
            set { _PersonaAutorizada = value; }
        }
        private string _Domicilio;

        public string Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }
        }
        private string _RFC;

        public string RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }
        private int _idArticulo;

        public int idArticulo
        {
            get { return _idArticulo; }
            set { _idArticulo = value; }
        }
        private string _NombreArticulo;

        public string NombreArticulo
        {
            get { return _NombreArticulo; }
            set { _NombreArticulo = value; }
        }
        private string _cdescorta;

        public string cdescorta
        {
            get { return _cdescorta; }
            set { _cdescorta = value; }
        }
        private Int16 _Cantidad;

        public Int16 Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        private double _PrecioUnitario;

        public double PrecioUnitario
        {
            get { return _PrecioUnitario; }
            set { _PrecioUnitario = value; }
        }
        private double _SubTotalArticulo;

        public double SubTotalArticulo
        {
            get { return _SubTotalArticulo; }
            set { _SubTotalArticulo = value; }
        }
        private double _DescuentoArticulo;

        public double DescuentoArticulo
        {
            get { return _DescuentoArticulo; }
            set { _DescuentoArticulo = value; }
        }
        private double _SubTotal;

        public double SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }
        private double _DescuentoTotal;

        public double DescuentoTotal
        {
            get { return _DescuentoTotal; }
            set { _DescuentoTotal = value; }
        }
        private double _Impuesto;

        public double Impuesto
        {
            get { return _Impuesto; }
            set { _Impuesto = value; }
        }
        private double _Total;

        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private double _ImporteSS;

        public double ImporteSS
        {
            get { return _ImporteSS; }
            set { _ImporteSS = value; }
        }

        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }


    }
    public class CDetalleTicket : ClienteMayorista
    {
        private string _cIndFactura;

        public string cIndFactura
        {
            get { return _cIndFactura; }
            set { _cIndFactura = value; }
        }

        public List<CDetalleTicketResponse> detalleTicket(string folioFactura)
        {
            List<CDetalleTicketResponse> lstDetalle = new List<CDetalleTicketResponse>();
            

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {
                    SqlCommand query = new SqlCommand("exec [sAppMayoristas].[procMisVales_Ticket] @FOLIOFACTURA", conn);
                    query.Parameters.Add(new SqlParameter("FOLIOFACTURA", folioFactura));
                    query.CommandTimeout = 0;

                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CDetalleTicketResponse objRespuesta = new CDetalleTicketResponse();

                            objRespuesta.ccliente = reader["ccliente"] == System.DBNull.Value ? " " : reader["ccliente"].ToString();
                            objRespuesta.csuc_cliente = reader["csuc_cliente"] == System.DBNull.Value ? " " : reader["csuc_cliente"].ToString();
                            objRespuesta.PersonaAutorizada = reader["PersonaAutorizada"] == System.DBNull.Value ? " " : reader["PersonaAutorizada"].ToString();
                            objRespuesta.Domicilio = reader["Domicilio"] == System.DBNull.Value ? " " : reader["Domicilio"].ToString();
                            objRespuesta.RFC = reader["RFC"] == System.DBNull.Value ? " " : reader["RFC"].ToString();
                            objRespuesta.ImporteSS = reader["ImporteSS"] == System.DBNull.Value ? (double)0 : Convert.ToDouble(reader["ImporteSS"].ToString());
                            objRespuesta.idArticulo = reader["idArticulo"] == System.DBNull.Value ? 0 : Convert.ToInt32(reader["idArticulo"].ToString());
                            objRespuesta.NombreArticulo = reader["NombreArticulo"] == System.DBNull.Value ? " " : reader["NombreArticulo"].ToString();
                            objRespuesta.cdescorta = reader["cdescorta"] == System.DBNull.Value ? " " : reader["cdescorta"].ToString();
                            objRespuesta.Cantidad = reader["Cantidad"] == System.DBNull.Value ? (Int16)0 : Convert.ToInt16(reader["Cantidad"].ToString());
                            objRespuesta.PrecioUnitario = reader["PrecioUnitario"] == System.DBNull.Value ? (double)0 : Convert.ToDouble(reader["PrecioUnitario"].ToString());
                            objRespuesta.SubTotalArticulo = reader["SubTotalArticulo"] == System.DBNull.Value ? (double)0 : Convert.ToDouble(reader["SubTotalArticulo"].ToString());
                            objRespuesta.DescuentoArticulo = reader["DescuentoArticulo"] == System.DBNull.Value ? (double)0 : Convert.ToDouble(reader["DescuentoArticulo"].ToString());
                            objRespuesta.SubTotal = reader["SubTotal"] == System.DBNull.Value ? (double)0 : Convert.ToDouble(reader["SubTotal"].ToString());
                            objRespuesta.DescuentoTotal = reader["DescuentoTotal"] == System.DBNull.Value ? (double)0 : Convert.ToDouble(reader["DescuentoTotal"].ToString());
                            objRespuesta.Impuesto = reader["Impuesto"] == System.DBNull.Value ? (double)0 : Convert.ToDouble(reader["Impuesto"].ToString());
                            objRespuesta.Total = reader["Total"] == System.DBNull.Value ? (double)0 : Convert.ToDouble(reader["Total"].ToString());
                            objRespuesta.mensaje = "200 OK";

                            lstDetalle.Add(objRespuesta);

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                CDetalleTicketResponse objRespuesta = new CDetalleTicketResponse();
                objRespuesta.mensaje = "500 Internal Error: " + ex.Message;
                lstDetalle.Add(objRespuesta);
                return lstDetalle;
            }

            return lstDetalle;
        }

    }
}