using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class CorteDetalle
    {
        private string _FechaCorte;

        public string FechaCorte
        {
            get { return _FechaCorte; }
            set { _FechaCorte = value; }
        }
        private string _idCredivale;

        public string idCredivale
        {
            get { return _idCredivale; }
            set { _idCredivale = value; }
        }
        private double _ImporteCompra;

        public double ImporteCompra
        {
            get { return _ImporteCompra; }
            set { _ImporteCompra = value; }
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
        private uint _idSubCliente;

        public uint idSubCliente
        {
            get { return _idSubCliente; }
            set {
                _idSubCliente = value;
            }
        }
        private string _FechaCompra;

        public string FechaCompra
        {
            get { return _FechaCompra; }
            set { _FechaCompra = value; }
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
        private double _PagoQuincenal;

        public double PagoQuincenal
        {
            get { return _PagoQuincenal; }
            set { _PagoQuincenal = value; }
        }
        private Int16 _Pago;

        public Int16 Pago
        {
            get { return _Pago; }
            set { _Pago = value; }
        }
        private Int16 _Pagos;

        public Int16 Pagos
        {
            get { return _Pagos; }
            set { _Pagos = value; }
        }
        private string _FechaVence;

        public string FechaVence
        {
            get { return _FechaVence; }
            set { _FechaVence = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }
    }
}