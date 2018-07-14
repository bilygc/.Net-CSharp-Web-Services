using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class CancelarVale
    {
        private string _idCancelacion;

        public string idCancelacion
        {
            get { return _idCancelacion; }
            set { _idCancelacion = value; }
        }


        private string _cResultado;

        public string cResultado
        {
            get { return _cResultado; }
            set { _cResultado = value; }
        }


        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        

    }
}