using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class Ciudades
    {
        private Int16 _id;

        public Int16 id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _Ciudad;

        public string Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
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
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }


    }
}