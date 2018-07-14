using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class CorteAnterior
    {
        private string _cCliente;

        public string cCliente
        {
            get { return _cCliente; }
            set { _cCliente = value; }
        }
        private uint _idCliente;

        public uint idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
        private string _FechaCorte;

        public string FechaCorte
        {
            get { return _FechaCorte; }
            set { _FechaCorte = value; }
        }
        private double _TotalCorte;

        public double TotalCorte
        {
            get { return _TotalCorte; }
            set { _TotalCorte = value; }
        }
        private double _Pagos;

        public double Pagos
        {
            get { return _Pagos; }
            set { _Pagos = value; }
        }
        private double _Descuentos;

        public double Descuentos
        {
            get { return _Descuentos; }
            set { _Descuentos = value; }
        }
        private double _AnticiposAplicados;

        public double AnticiposAplicados
        {
            get { return _AnticiposAplicados; }
            set { _AnticiposAplicados = value; }
        }
        private double _Saldo;

        public double Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }
    }
}