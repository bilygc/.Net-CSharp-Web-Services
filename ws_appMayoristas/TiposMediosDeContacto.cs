using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class TiposMediosDeContacto
    {
        private Int16 _idTipo;

        public Int16 idTipo
        {
            get { return _idTipo; }
            set { _idTipo = value; }
        }
        private string _Medio;

        public string Medio
        {
            get { return _Medio; }
            set { _Medio = value; }
        }
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public TiposMediosDeContacto()
        {
            this._idTipo = 0;
            this._Medio = "";
            this._mensaje = "";
        }
    }
}