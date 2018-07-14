using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ws_appMayoristas
{
    public class CPagoMayorista : ClienteMayorista
    {
        private string _plaza;

        public string plaza
        {
            get { return _plaza; }
            set { _plaza = value; }
        }
        private string _cliente;

        public string cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public List<CPagoMayoristaresponse> getPagoMayorista(string plaza, string ccliente)
        {
            List<CPagoMayoristaresponse> pagoResponse = new List<CPagoMayoristaresponse>();
            

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {
                    SqlCommand query = new SqlCommand("exec [sAppMayoristas].[procMisPagos] @PLAZA, @CCLIENTE", conn);
                    query.Parameters.Add(new SqlParameter("PLAZA", plaza));
                    query.Parameters.Add(new SqlParameter("CCLIENTE", ccliente));
                    query.CommandTimeout = 0;

                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CPagoMayoristaresponse objResponse = new CPagoMayoristaresponse();
                            objResponse.FechaCorte = reader["FechaCorte"] == System.DBNull.Value ? "1900-01-01" : Convert.ToDateTime(reader["FEchaCorte"].ToString()).ToShortDateString();
                            objResponse.cCliente = reader["cCliente"] == System.DBNull.Value ? " " : reader["cCliente"].ToString();
                            objResponse.idCliente = reader["idCliente"] == System.DBNull.Value ? " " : reader["idCliente"].ToString();
                            objResponse.FechaPago = reader["FechaPago"] == System.DBNull.Value ? " " : Convert.ToDateTime(reader["FechaPago"].ToString()).ToShortDateString();
                            objResponse.ImportePagado = reader["ImportePagado"] == System.DBNull.Value ? (double)0.0 : Convert.ToDouble(reader["ImportePagado"].ToString());
                            objResponse.AplicacionAnticipo = reader["AplicacionAnticipo"] == System.DBNull.Value ? (double)0.0 : Convert.ToDouble(reader["AplicacionAnticipo"].ToString());
                            objResponse.Descuento = reader["Descuento"] == System.DBNull.Value ? (double)0.0 : Convert.ToDouble(reader["Descuento"].ToString());
                            objResponse.Anticipo = reader["Anticipo"] == System.DBNull.Value ? (double)0.0 : Convert.ToDouble(reader["Anticipo"].ToString());
                            objResponse.TotalAbono = reader["TotalAbono"] == System.DBNull.Value ? (double)0.0 : Convert.ToDouble(reader["TotalAbono"].ToString());
                            objResponse.Lugar = reader["Lugar"] == System.DBNull.Value ? " " : reader["Lugar"].ToString();
                            objResponse.mensaje = "200 OK";
                            pagoResponse.Add(objResponse);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                CPagoMayoristaresponse objResponse = new CPagoMayoristaresponse();
                objResponse.mensaje = "500 Error: " + ex.Message;
                pagoResponse.Add(objResponse);
                return pagoResponse;
            }
            
            return pagoResponse;
        }

    }

    public class CPagoMayoristaresponse
    {
        private string _FechaCorte;

        public string FechaCorte
        {
            get { return _FechaCorte; }
            set { _FechaCorte = value; }
        }
        private string _cCliente;

        public string cCliente
        {
            get { return _cCliente; }
            set { _cCliente = value; }
        }
        private string _idCliente;

        public string idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
        private string _FechaPago;

        public string FechaPago
        {
            get { return _FechaPago; }
            set { _FechaPago = value; }
        }
        private double _ImportePagado;

        public double ImportePagado
        {
            get { return _ImportePagado; }
            set { _ImportePagado = value; }
        }
        private double _AplicacionAnticipo;

        public double AplicacionAnticipo
        {
            get { return _AplicacionAnticipo; }
            set { _AplicacionAnticipo = value; }
        }
        private double _Descuento;

        public double Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }
        private double _Anticipo;

        public double Anticipo
        {
            get { return _Anticipo; }
            set { _Anticipo = value; }
        }
        private double _TotalAbono;

        public double TotalAbono
        {
            get { return _TotalAbono; }
            set { _TotalAbono = value; }
        }
        private string _Lugar;

        public string Lugar
        {
            get { return _Lugar; }
            set { _Lugar = value; }
        }

        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public CPagoMayoristaresponse()
        {
            this.FechaCorte = " ";
            this.cCliente = "0";
            this.idCliente = "1";
            this.FechaPago = " ";
            this.ImportePagado = 0.0;
            this.AplicacionAnticipo = 0.0;
            this.Descuento = 0.0;
            this.Anticipo = 0.0;
            this.TotalAbono = 0.0;
            this.Lugar =  " ";
            this.mensaje = " ";
        }

    }

}