using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class ClientesMayoristas
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
        private string _Paterno;

        public string Paterno
        {
            get { return _Paterno; }
            set { _Paterno = value; }
        }
        private string _Materno;

        public string Materno
        {
            get { return _Materno; }
            set { _Materno = value; }
        }
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _RFC;

        public string RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }
        private string _idPlaza;

        public string idPlaza
        {
            get { return _idPlaza; }
            set { _idPlaza = value; }
        }
        private string _TipoDeCredito;

        public string TipoDeCredito
        {
            get { return _TipoDeCredito; }
            set { _TipoDeCredito = value; }
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

        private Int16 _idStatus;

        public Int16 idStatus
        {
            get { return _idStatus; }
            set { _idStatus = value; }
        }

        private Int64 _puntosCredigana;

        public Int64 puntosCredigana
        {
            get { return _puntosCredigana; }
            set { _puntosCredigana = value; }
        }
        
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public ClientesMayoristas()
        {
            this._idcliente = 0;
            this._cCliente = "";
            this._Paterno = "";
            this._Materno = "";
            this._Nombre = "";
            this._RFC = "";
            this._idPlaza = "";
            this._TipoDeCredito = "";
            this._idCP = "";
            this._idAsentamiento = "";
            this._puntosCredigana = 0;
            this._mensaje = "";
        }

        
    }
}