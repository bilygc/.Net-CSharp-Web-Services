using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ws_appMayoristas
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {        


        [WebMethod]
        public List<Asentamientos> getAsentamientos(string aplicacion, string password)
        {
            var lstAsentamientos = new List<Asentamientos>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstAsentamientos = objCliente.Asentamientos();
            }
            else
            {
                Asentamientos objAsentamientos = new Asentamientos();

                objAsentamientos.mensaje = "Acceso restringido";
                lstAsentamientos.Add(objAsentamientos);

            }
            return lstAsentamientos;

        }

        [WebMethod]
        public List<TiposDeAsentamiento> getTiposDeAsentamientos(string aplicacion, string password)
        {
            var lstTiposDeAsentamiento = new List<TiposDeAsentamiento>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstTiposDeAsentamiento = objCliente.TiposAsentamientos();
            }
            else
            {
                TiposDeAsentamiento objTiposDeasentamiento = new TiposDeAsentamiento();

                objTiposDeasentamiento.mensaje = "Acceso restringido";
                lstTiposDeAsentamiento.Add(objTiposDeasentamiento);

            }
            return lstTiposDeAsentamiento;

        }

        [WebMethod]
        public List<Ciudades> getCiudades(string aplicacion, string password)
        {
            var lstCiudades = new List<Ciudades>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstCiudades = objCliente.Ciudades();
            }
            else
            {
                Ciudades objCiudades = new Ciudades();

                objCiudades.mensaje = "Acceso restringido";
                lstCiudades.Add(objCiudades);

            }
            return lstCiudades;

        }

        [WebMethod]
        public List<Municipios> getMunicipios(string aplicacion, string password)
        {
            var lstMunicipios = new List<Municipios>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstMunicipios = objCliente.Municipios();
            }
            else
            {
                Municipios objMunicipios = new Municipios();

                objMunicipios.mensaje = "Acceso restringido";
                lstMunicipios.Add(objMunicipios);

            }
            return lstMunicipios;

        }

        [WebMethod]
        public List<Estados> getEstados(string aplicacion, string password)
        {
            var lstEstados = new List<Estados>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstEstados = objCliente.Estados();
            }
            else
            {
                Estados objEstados = new Estados();

                objEstados.mensaje = "Acceso restringido";
                lstEstados.Add(objEstados);

            }
            return lstEstados;

        }


        [WebMethod]
        public CResponseEnviarCorreoSMS postCorreoSMS(string aplicacion, string password, string cCliente, Int16 tipoMedio, string movilOrigen, string movilDestinatario, string textoSMS, string remitenteCorreo, string correoDestinatario, string tituloCorreo, string cuerpoCorreo)
        {
            CResponseEnviarCorreoSMS objRespuestaEnviarCorreoSMS = new CResponseEnviarCorreoSMS();

            if (Acceso.Verificar(aplicacion, password))
            {
                CenviarCorreoSMS objEnviarCorreoSMS = new CenviarCorreoSMS();

                objEnviarCorreoSMS.cCliente = cCliente;
                objEnviarCorreoSMS.tipoMedio = tipoMedio;
                objEnviarCorreoSMS.movilOrigen = movilOrigen;
                objEnviarCorreoSMS.movilDestinatario = movilDestinatario;
                objEnviarCorreoSMS.textoSMS = textoSMS;
                objEnviarCorreoSMS.remitenteCorreo = remitenteCorreo;
                objEnviarCorreoSMS.correoDestinatario = correoDestinatario;
                objEnviarCorreoSMS.tituloCorreo = tituloCorreo;
                objEnviarCorreoSMS.cuerpoCorreo = cuerpoCorreo;

                objRespuestaEnviarCorreoSMS = objEnviarCorreoSMS.enviarCorreoSMS();
            }
            else
            {
                
                objRespuestaEnviarCorreoSMS.cadenaRespuesta = "Acceso restringido";
                objRespuestaEnviarCorreoSMS.codigoRespuesta = (-1);
            }

            return objRespuestaEnviarCorreoSMS;
        }


    }
}