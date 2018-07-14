using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_appMayoristas
{
    public class PostVale
    {
        private int _nResultado;

        public int nResultado
        {
            get { return _nResultado; }
            set { _nResultado = value; }
        }
        private string _cResultado;

        public string cResultado
        {
            get { return _cResultado; }
            set { _cResultado = value; }
        }
        private string _eVale;

        public string eVale
        {
            get { return _eVale; }
            set { _eVale = value; }
        }
        private double _nImporteAutorizado;

        public double nImporteAutorizado
        {
            get { return _nImporteAutorizado; }
            set { _nImporteAutorizado = value; }
        }
        private string _cVigencia;

        public string cVigencia
        {
            get { return _cVigencia; }
            set { _cVigencia = value; }
        }
        private string _cNombreSubCliente;

        public string cNombreSubCliente
        {
            get { return _cNombreSubCliente; }
            set { _cNombreSubCliente = value; }
        }
        private int _idMedioDestino;

        public int idMedioDestino
        {
            get { return _idMedioDestino; }
            set { _idMedioDestino = value; }
        }
        private string _cReferenciaDestino;

        public string cReferenciaDestino
        {
            get { return _cReferenciaDestino; }
            set { _cReferenciaDestino = value; }
        }
        private int _idPeticion;

        public int idPeticion
        {
            get { return _idPeticion; }
            set { _idPeticion = value; }
        }

        private string _cFolioValeInterno;

        public string cFolioValeInterno
        {
            get { return _cFolioValeInterno; }
            set { _cFolioValeInterno = value; }
        }

        private string _Prefijo;

        public string Prefijo
        {
            get { return _Prefijo; }
            set { _Prefijo = value; }
        }

       
        
        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }
    }
}