using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class DomicilioClientes
    {
        private uint _idcliente;

        public uint idcliente
        {
            get { return _idcliente; }
            set { _idcliente = value; }
        }
        private string _cCliente;

        public string cCliente
        {
            get { return _cCliente; }
            set { _cCliente = value; }
        }
        private string _idCP;

        public string idCP
        {
            get { return _idCP; }
            set { _idCP = value; }
        }
        private string _idAsentamiento;

        public string idAsentamiento
        {
            get { return _idAsentamiento; }
            set { _idAsentamiento = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public DomicilioClientes()
        {
            this._idcliente = 0;
            this.cCliente = "";
            this._idCP = "";
            this._idAsentamiento = "";
        }

    }
}