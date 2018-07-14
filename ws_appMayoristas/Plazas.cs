using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class Plazas
    {
        private string _idPlaza;

        public string idPlaza
        {
            get { return _idPlaza; }
            set { _idPlaza = value; }
        }
        private string _NombrePlaza;

        public string NombrePlaza
        {
            get { return _NombrePlaza; }
            set { _NombrePlaza = value; }
        }
        private string _idSerieVale;

        public string idSerieVale
        {
            get { return _idSerieVale; }
            set { _idSerieVale = value; }
        }
        private string _idestado;

        public string idestado
        {
            get { return _idestado; }
            set { _idestado = value; }
        }
        private string _IDMunicipio;

        public string IDMunicipio
        {
            get { return _IDMunicipio; }
            set { _IDMunicipio = value; }
        }
        private string _ClavePlaza;

        public string ClavePlaza
        {
            get { return _ClavePlaza; }
            set { _ClavePlaza = value; }
        }

        private string _eMail_Clientes;

        public string eMail_Clientes
        {
            get { return _eMail_Clientes; }
            set { _eMail_Clientes = value; }
        }

        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

    }
}