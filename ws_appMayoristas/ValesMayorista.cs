using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ws_appMayoristas
{
    [Serializable]
    [XmlType(TypeName = "ValesMayorista")]
    public class ValesMayorista
    {
        
        public uint idValera { get; set; }
        public string Fecha { get; set; }
        public string cCliente { get; set; }
        public Int16 idTipoCrediVale { get; set; }
        public string FolioCrediVale { get; set; }
        public string cFolioCredivaleVista { get; set; }
        public string PersonaAutorizada { get; set; }
        public string ReferenciaDestino { get; set; }
        public double Importe { get; set; }
        public string Vigencia { get; set; }
        public string Status { get; set; }
        public string cIndFactura { get; set; }
        public string FechaCancela { get; set; }
        public string MotivoCancela { get; set; }
        public string mensaje { get; set; }

        public ValesMayorista()
        {

            this.idValera = 0;
            this.Fecha = "1900-01-01";
            this.cCliente = "0";
            this.idTipoCrediVale = (Int16)0;
            this.FolioCrediVale = " ";
            this.cFolioCredivaleVista = " ";
            this.PersonaAutorizada = " ";
            this.ReferenciaDestino = " ";
            this.Importe = 0.0;
            this.Vigencia = "01-01-1900";
            this.Status = " ";
            this.cIndFactura = "0";
            this.FechaCancela = "01-01-1900";
            this.MotivoCancela = " ";
            this.mensaje = " ";
           
        }
    }
}