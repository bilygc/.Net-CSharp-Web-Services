using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class ClientesMedioContacto
    {
        public uint idcliente { get; set; }
        public string cCliente { get; set; }
        public string idTipoMedio { get; set; }
        public string Referencia { get; set; }
        public string Notas { get; set; }
        private string _Status;

        public string Status
        {
            get { return this._Status; }
            set {
                if (value == "True")
                {
                    this._Status = "1";
                }
                else if(value == "False"){
                    this._Status = "0"; 
                }
                
            }
        }
        public string mensaje { get; set; }

        public ClientesMedioContacto()
        {
            this.idcliente = 0;
            this.cCliente = "";
            this.idTipoMedio = "";
            this.Referencia = "";
            this.Notas = "";
            this.Status = "";
            this.mensaje = "";
            
        }
    }
}