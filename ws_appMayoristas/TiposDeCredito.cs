using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class TiposDeCredito
    {
        private string _idTipoDeCredito;

        public string idTipoDeCredito
        {
            get { return _idTipoDeCredito; }
            set { _idTipoDeCredito = value; }
        }
        private string _TipoDeCredito;

        public string TipoDeCredito
        {
            get { return _TipoDeCredito; }
            set { _TipoDeCredito = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

    }
}