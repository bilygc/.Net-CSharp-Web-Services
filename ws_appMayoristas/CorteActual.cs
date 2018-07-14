using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class CorteActual
    {
        private string _ccliente;

        public string ccliente
        {
            get { return _ccliente; }
            set { _ccliente = value; }
        }
        private uint _idCliente;

        public uint idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
        private string _FechaDeCorte;

        public string FechaDeCorte
        {
            get { return _FechaDeCorte; }
            set { _FechaDeCorte = value; }
        }
        private string _FechaLimitePago;

        public string FechaLimitePago
        {
            get { return _FechaLimitePago; }
            set { _FechaLimitePago = value; }
        }
        private double _SaldoAlCorte;

        public double SaldoAlCorte
        {
            get { return _SaldoAlCorte; }
            set { _SaldoAlCorte = value; }
        }
        private double _PagoMinimo;

        public double PagoMinimo
        {
            get { return _PagoMinimo; }
            set { _PagoMinimo = value; }
        }
        private double _TotalPagado;

        public double TotalPagado
        {
            get { return _TotalPagado; }
            set { _TotalPagado = value; }
        }
        private double _DescuentoAplicado;

        public double DescuentoAplicado
        {
            get { return _DescuentoAplicado; }
            set { _DescuentoAplicado = value; }
        }
        private double _SaldoActual;

        public double SaldoActual
        {
            get { return _SaldoActual; }
            set { _SaldoActual = value; }
        }
        private double _AnticiposProximoCorte;

        public double AnticiposProximoCorte
        {
            get { return _AnticiposProximoCorte; }
            set { _AnticiposProximoCorte = value; }
        }
        private double _NuevasCompras;

        public double NuevasCompras
        {
            get { return _NuevasCompras; }
            set { _NuevasCompras = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public CorteActual()
        {
            _ccliente = string.Empty;
            _idCliente = 0;
            _FechaDeCorte = string.Empty;
            _FechaLimitePago = string.Empty;
            _SaldoAlCorte = 0.0;
            _PagoMinimo = 0.0;
            _TotalPagado = 0.0;
            _DescuentoAplicado = 0.0;
            _SaldoActual = 0.0;
            _AnticiposProximoCorte = 0.0;
            _NuevasCompras = 0.0;
            _mensaje = string.Empty;

        }
    }
}