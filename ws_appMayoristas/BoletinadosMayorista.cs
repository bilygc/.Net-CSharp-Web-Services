using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class BoletinadosMayorista
    {
        public uint idcliente { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public string Desde { get; set; }
        public string Observaciones { get; set; }
        public string cClienteReporta { get; set; }
        public string mensaje { get; set; }

        public BoletinadosMayorista() {
            this.idcliente = 0;
            this.Paterno = "";
            this.Materno = "";
            this.Nombre = "";
            this.Desde = "";
            this.Observaciones = "";
            this.cClienteReporta = "";
            this.mensaje = "";
        }

    }
}