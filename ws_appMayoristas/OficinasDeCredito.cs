using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class OficinasDeCredito
    {
        private string _idOficina;

        public string idOficina
        {
            get { return _idOficina; }
            set { _idOficina = value; }
        }
        private string _NombreOficina;

        public string NombreOficina
        {
            get { return _NombreOficina; }
            set { _NombreOficina = value; }
        }
        private string _Principal;

        public string Principal
        {
            get { return _Principal; }
            set {
                    if (value == "True")
                    {
                        this._Principal = "1";
                    }
                    else if (value == "False")
                    {
                        this._Principal = "0";
                    }
            }
        }
        private string _idPlaza;

        public string idPlaza
        {
            get { return _idPlaza; }
            set { _idPlaza = value; }
        }
        
        private string _TipoTienda;

        public string TipoTienda
        {
            get { return _TipoTienda; }
            set { _TipoTienda = value; }
        }

        private string _Calle;

        public string Calle
        {
            get { return _Calle; }
            set { _Calle = value; }
        }
        private string _NumExt;

        public string NumExt
        {
            get { return _NumExt; }
            set { _NumExt = value; }
        }
        private string _NumInt;

        public string NumInt
        {
            get { return _NumInt; }
            set { _NumInt = value; }
        }
        private string _Colonia;

        public string Colonia
        {
            get { return _Colonia; }
            set { _Colonia = value; }
        }
        private string _CP;

        public string CP
        {
            get { return _CP; }
            set { _CP = value; }
        }

        private string _idAsentamiento;

        public string idAsentamiento
        {
            get { return _idAsentamiento; }
            set { _idAsentamiento = value; }
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

        private string _Referencia;

        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private string _Localidad;

        public string Localidad
        {
            get { return _Localidad; }
            set { _Localidad = value; }
        }
        private string _Municipio;

        public string Municipio
        {
            get { return _Municipio; }
            set { _Municipio = value; }
        }
        private string _Estado;

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        private string _Pais;

        public string Pais
        {
            get { return _Pais; }
            set { _Pais = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

    }
}