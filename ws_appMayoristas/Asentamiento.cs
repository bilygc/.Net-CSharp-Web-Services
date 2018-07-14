using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class Asentamientos
    {
        private int _idCP;

        public int idCP
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
        private string _Asentamiento;

        public string Asentamiento
        {
            get { return _Asentamiento; }
            set { _Asentamiento = value; }
        }
        private string _idTipoAsenta;

        public string idTipoAsenta
        {
            get { return _idTipoAsenta; }
            set { _idTipoAsenta = value; }
        }
        private string _idEstado;

        public string idEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }
        private string _idMunicipio;

        public string idMunicipio
        {
            get { return _idMunicipio; }
            set { _idMunicipio = value; }
        }
        private string _idCiudad;

        public string idCiudad
        {
            get { return _idCiudad; }
            set { _idCiudad = value; }
        }
        private string _nLatitud;

        public string nLatitud
        {
            get { return _nLatitud; }
            set { _nLatitud = value; }
        }
        private string _nLongitud;

        public string nLongitud
        {
            get { return _nLongitud; }
            set { _nLongitud = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public Asentamientos()
        {
            this._idCP = 0;
            this._idAsentamiento = "";
            this._Asentamiento = "";
            this._idTipoAsenta = "";
            this._idEstado = "";
            this._idMunicipio = "";
            this._idCiudad = "";
            this._nLatitud = "";
            this._nLongitud = "";
            this._mensaje = "";
        }

    }
}