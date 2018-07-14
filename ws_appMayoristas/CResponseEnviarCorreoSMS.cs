using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class CResponseEnviarCorreoSMS
    {
        private Int32 _codigoRespuesta;
        private string _cadenaRespuesta;

        public Int32 codigoRespuesta
        {
            get { return _codigoRespuesta; }
            set { _codigoRespuesta = value; }
        }
        

        public string cadenaRespuesta
        {
            get { return _cadenaRespuesta; }
            set { _cadenaRespuesta = value; }
        }

        public CResponseEnviarCorreoSMS()
        {
            this._cadenaRespuesta = string.Empty;
            this._codigoRespuesta = 0;
        }
    }
}