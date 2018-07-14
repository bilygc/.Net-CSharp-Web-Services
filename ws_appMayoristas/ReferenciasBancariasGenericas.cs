using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class ReferenciasBancariasGenericas
    {
        private string _ccliente;        
        private uint _idCliente;        
        private string _Banco;        
        private string _Sucursal;        
        private string _Cuenta;        
        private string _Referencia;        
        private string _mensaje;        



        public string ccliente
        {
            get { return _ccliente; }
            set { _ccliente = value; }
        }

        public uint idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        public string Banco
        {
            get { return _Banco; }
            set { _Banco = value; }
        }

        public string Sucursal
        {
            get { return _Sucursal; }
            set { _Sucursal = value; }
        }

        public string Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }
    }
}