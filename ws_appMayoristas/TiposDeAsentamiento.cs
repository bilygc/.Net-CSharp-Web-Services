using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class TiposDeAsentamiento
    {
        private Int16 _idTipoAsenta;

        public Int16 idTipoAsenta
        {
            get { return _idTipoAsenta; }
            set { _idTipoAsenta = value; }
        }
        private string _TipoAsentamiento;

        public string TipoAsentamiento
        {
            get { return _TipoAsentamiento; }
            set { _TipoAsentamiento = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

    }
}