using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class CresponseReferenciasBanc
    {
        private string _cCliente;
        private string _FechaPago;
        private double _Descuento;
        private double _Importe;
        private string _Entidad;
        private string _Referencia;
        private string _Convenio;
        private string _mensaje;

        public string cCliente
        {
            get { return _cCliente; }
            set { _cCliente = value; }
        }
      

        public string FechaPago
        {
            get { return _FechaPago; }
            set { _FechaPago = value; }
        }
        

        public double Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }
        

        public double Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }
        

        public string Entidad
        {
            get { return _Entidad; }
            set { _Entidad = value; }
        }
        

        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }
        

        public string Convenio
        {
            get { return _Convenio; }
            set { _Convenio = value; }
        }

        

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public CresponseReferenciasBanc()
        {
            this._cCliente = string.Empty;
            this._FechaPago = string.Empty;
            this._Descuento = 0.0;
            this._Importe = 0.0;
            this._Entidad = string.Empty;
            this._Referencia = string.Empty;
            this._Convenio = string.Empty;
            this._mensaje = string.Empty;
        }

    }
}