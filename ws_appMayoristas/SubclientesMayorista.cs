using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class SubclientesMayorista
    {
        public uint idcliente { get; set; }
        public string ccliente { get; set; }
        public string CSUC_CLIENTE {get; set;}
        public string NombreSubCliente { get; set; }
        public string Movil { get; set; }
        public string Telefono { get; set; }
        public string eMail { get; set; }
        public string Domicilio { get; set; }
        public string CP { get; set; }
        public string Calle { get; set; }
        public string NumExt { get; set; }
        public string idCP { get; set; }
        public string idasentamiento { get; set; }
        public string mensaje { get; set; }

        public SubclientesMayorista()
        {
            this.idcliente = 0;
            this.ccliente = "";
            this.CSUC_CLIENTE = "";
            this.NombreSubCliente = "";
            this.Movil = "";
            this.Telefono = "";
            this.eMail = "";
            this.Domicilio = "";
            this.CP = "";
            this.Calle = "";
            this.NumExt = "";
            this.idCP = "";
            this.idasentamiento = "";
            this.mensaje = "";
        }
        
    }
}