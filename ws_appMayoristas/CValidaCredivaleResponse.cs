using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class CValidaCredivaleResponse
    {
        private bool _bValido;
        private string _sDescripcion;
        private string _mensaje;

        public bool bValido
        {
            get { return _bValido; }
            set { _bValido = value; }
        }

        public string sDescripcion
        {
            get { return _sDescripcion; }
            set { _sDescripcion = value; }
        }

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public CValidaCredivaleResponse()
        {
            this._bValido = false;
            this._mensaje = string.Empty;
            this._sDescripcion = string.Empty;
        }

    }
}