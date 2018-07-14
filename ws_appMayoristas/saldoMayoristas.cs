using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class saldoMayoristas
    {
        public string idcliente {get; set; }
        public string clavecliente { get; set; }
        public double saldo { get; set; }
        public double pagoMinimo { get; set; }
        public double limite { get; set; }
        public double disponible { get; set; }
        public string fecha { get; set; }
        public string mensaje { get; set; }
        public double Descuento { get; set; }
        public double LiquidaCon { get; set; }
        public string FechaProximoCorte { get; set; }

        public saldoMayoristas() {
            this.idcliente = "";
            this.clavecliente = "";
            this.saldo = 0.0;
            this.pagoMinimo = 0.0;
            this.limite = 0.0;
            this.disponible = 0.0;
            this.fecha = "1900-01-01";
            this.mensaje = "";
            this.Descuento = 0.0;
            this.LiquidaCon = 0.0;
            this.FechaProximoCorte = string.Empty;
        }
    }
}