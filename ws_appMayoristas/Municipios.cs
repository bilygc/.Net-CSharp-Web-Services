using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class Municipios
    {
        private string _IDEstado;

        public string IDEstado
        {
            get { return _IDEstado; }
            set { _IDEstado = value; }
        }
        private string _IDMunicipio;

        public string IDMunicipio
        {
            get { return _IDMunicipio; }
            set { _IDMunicipio = value; }
        }
        private string _Municipio;

        public string Municipio
        {
            get { return _Municipio; }
            set { _Municipio = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }



    }
}