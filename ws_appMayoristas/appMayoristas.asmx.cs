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
    [WebService(Namespace = "citrix6.calzzapato.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<saldoMayoristas> getSaldos(string aplicacion, string password, string cliente, string plaza, string tipoCredito)
        {
            var listOfSaldos = new List<saldoMayoristas>();
            if (Acceso.Verificar(aplicacion, password))
            {
                ClienteMayorista objCliente = new ClienteMayorista();
                listOfSaldos = objCliente.Saldo(cliente, plaza, tipoCredito);
            }
            else
            {
                var saldos = new saldoMayoristas();
                saldos.mensaje = "Acceso restringido";
                //Context.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                
                listOfSaldos.Add(saldos);
            }
            return listOfSaldos;
           
        }
        
        [WebMethod]
        public List<CorteActual> getCorteActual(string aplicacion, string password, string cliente)
        {
            var listOfCorteActual = new List<CorteActual>();
            
            if (Acceso.Verificar(aplicacion, password))
            {
                
                ClienteMayorista objCliente = new ClienteMayorista();
                listOfCorteActual = objCliente.CorteActualCompras(cliente);
            }
            else
            {
                CorteActual objCorteActual = new CorteActual();
                objCorteActual.mensaje = "Acceso restringido";
                listOfCorteActual.Add(objCorteActual);
                
            }
            return listOfCorteActual;

        }
        

        [WebMethod]
        public string getVales(string aplicacion, string password, string cliente, string plaza, string tipoCredito)
        {
            string valesMayoristas = string.Empty;
            //var lstValesMayorista = new List<ValesMayorista>();

            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                valesMayoristas = objCliente.ValesMayorista(cliente, plaza, tipoCredito); 
            }
            else
            {
                
                return "Acceso restringido";

            }
           
            return valesMayoristas;

        }

        [WebMethod]
        public List<BoletinadosMayorista> getBoletinados(string aplicacion, string password, string cliente)
        {
            var lstBoletinadosMayorista = new List<BoletinadosMayorista>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstBoletinadosMayorista = objCliente.Boletinados(cliente);
            }
            else
            {
                BoletinadosMayorista objBoletinados = new BoletinadosMayorista();

                objBoletinados.mensaje = "Acceso restringido";
                lstBoletinadosMayorista.Add(objBoletinados);

            }
            return lstBoletinadosMayorista;

        }

        [WebMethod]
        public List<SubclientesMayorista> getSubClientes(string aplicacion, string password)
        {
            var lstSubClientesMayorista = new List<SubclientesMayorista>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstSubClientesMayorista = objCliente.Subclientes();
            }
            else
            {
                SubclientesMayorista objSubclientes = new SubclientesMayorista();

                objSubclientes.mensaje = "Acceso restringido";
                lstSubClientesMayorista.Add(objSubclientes);

            }
            return lstSubClientesMayorista;

        }

        [WebMethod]
        public List<ClientesMedioContacto> getClienteMediosdeContacto(string aplicacion, string password)
        {
            var lstMediosContacto = new List<ClientesMedioContacto>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstMediosContacto = objCliente.MediosContacto();
            }
            else
            {
                ClientesMedioContacto objMediosContacto = new ClientesMedioContacto();

                objMediosContacto.mensaje = "Acceso restringido";
                lstMediosContacto.Add(objMediosContacto);

            }
            return lstMediosContacto; ;

        }

        [WebMethod]
        public List<DomicilioClientes> getDomicilioClientes(string aplicacion, string password)
        {
            var lstDomicilioClientes = new List<DomicilioClientes>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstDomicilioClientes = objCliente.Domiciliocliente();
            }
            else
            {
                DomicilioClientes objDomicilioClientes = new DomicilioClientes();

                objDomicilioClientes.mensaje = "Acceso restringido";
                lstDomicilioClientes.Add(objDomicilioClientes);

            }
            return lstDomicilioClientes; 

        }

        [WebMethod]
        public List<ClientesMayoristas> getClientesMayoristas(string aplicacion, string password)
        {
            var lstClientesMayoristas = new List<ClientesMayoristas>();
            if (Acceso.Verificar(aplicacion, password) )
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstClientesMayoristas = objCliente.ctsMayoristas();
            }
            else
            {
                ClientesMayoristas objClientesMayoristas = new ClientesMayoristas();

                objClientesMayoristas.mensaje = "Acceso restringido";
                lstClientesMayoristas.Add(objClientesMayoristas);

            }
            return lstClientesMayoristas;

        }

        [WebMethod]
        public List<TiposMediosDeContacto> getTiposMediosContacto(string aplicacion, string password)
        {
            var lstTiposMediosContacto = new List<TiposMediosDeContacto>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstTiposMediosContacto = objCliente.TiposContacto();
            }
            else
            {
                TiposMediosDeContacto objTiposMediosContacto = new TiposMediosDeContacto();

                objTiposMediosContacto.mensaje = "Acceso restringido";
                lstTiposMediosContacto.Add(objTiposMediosContacto);

            }
            return lstTiposMediosContacto;

        }

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
        public List<TiposDeCredito> getTiposDeCredito(string aplicacion, string password)
        {
            var lstTiposDeCredito = new List<TiposDeCredito>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstTiposDeCredito = objCliente.TiposDeCredito();
            }
            else
            {
                TiposDeCredito objTiposDeCredito = new TiposDeCredito();

                objTiposDeCredito.mensaje = "Acceso restringido";
                lstTiposDeCredito.Add(objTiposDeCredito);

            }
            return lstTiposDeCredito;

        }

        [WebMethod]
        public List<OficinasDeCredito> getOficinasDeCredito(string aplicacion, string password, string TipoSucursal)
        {
            var lstOficinasDeCredito = new List<OficinasDeCredito>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstOficinasDeCredito = objCliente.OficinasDeCredito(TipoSucursal);
            }
            else
            {
                OficinasDeCredito objOficinasDeCredito = new OficinasDeCredito();

                objOficinasDeCredito.mensaje = "Acceso restringido";
                lstOficinasDeCredito.Add(objOficinasDeCredito);

            }
            return lstOficinasDeCredito;

        }

        [WebMethod]
        public List<Plazas> getPlazas(string aplicacion, string password)
        {
            var lstPlazas = new List<Plazas>();
            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstPlazas = objCliente.Plazas();
            }
            else
            {
                Plazas objPlazas = new Plazas();

                objPlazas.mensaje = "Acceso restringido";
                lstPlazas.Add(objPlazas);

            }
            return lstPlazas;

        }

        [WebMethod]
        public List<CresponseReferenciasBanc> getReferenciasBancarias(string aplicacion, string password, string cliente = " " )

        {
            var lstReferenciasBancarias = new List<CresponseReferenciasBanc>();
            

                if (Acceso.Verificar(aplicacion, password))
                {

                    ClienteMayorista objCliente = new ClienteMayorista();
                    lstReferenciasBancarias = objCliente.refBancarias(cliente);
                }
                else
                {

                    CresponseReferenciasBanc objReferenciasBancarias = new CresponseReferenciasBanc();
                    objReferenciasBancarias.mensaje = "Acceso restringido";
                    lstReferenciasBancarias.Add(objReferenciasBancarias);

                }
    
            return lstReferenciasBancarias;

        }

        [WebMethod]
        public List<ReferenciasBancariasGenericas> getReferenciasBancariasGenericas(string aplicacion, string password, string cliente = " ")
        {
            var lstReferenciasBancariasGenericas = new List<ReferenciasBancariasGenericas>();


            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                lstReferenciasBancariasGenericas = objCliente.refBancariasGenericas(cliente);
            }
            else
            {

                ReferenciasBancariasGenericas objReferenciasBancariasGenericas = new ReferenciasBancariasGenericas();
                objReferenciasBancariasGenericas.mensaje = "Acceso restringido";
                lstReferenciasBancariasGenericas.Add(objReferenciasBancariasGenericas);

            }

            return lstReferenciasBancariasGenericas;

        }

        [WebMethod]
        public PostVale postVale(string aplicacion, string password, string cClienteEmisor, int idClienteEmisor, string movilEmisor, double importe, Int16 tipoMedio, string referenciaDestino, Int16 idOficialDestino, string nombreReceptor)
        {
            PostVale objVale = new PostVale();

            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                objVale = objCliente.asignarVale(cClienteEmisor, idClienteEmisor, movilEmisor, importe, tipoMedio, referenciaDestino, idOficialDestino, nombreReceptor);
            }
            else
            {


                objVale.mensaje = "Acceso restringido";


            }

            return objVale;
        }

        [WebMethod]
        public CancelarVale cancelarVale(string aplicacion, string password, Int16 tipoMedio, string referencia, string folioVale, int tipoCredivale)
        {
            CancelarVale objCancelarVale = new CancelarVale();

            if (Acceso.Verificar(aplicacion, password))
            {

                ClienteMayorista objCliente = new ClienteMayorista();
                objCancelarVale = objCliente.cancelarVale(tipoMedio, referencia, folioVale,tipoCredivale);
            }
            else
            {

                objCancelarVale.mensaje = "Acceso restringido";

            }

            return objCancelarVale;
        }

        [WebMethod]
        public List<CtipoCredivale> getTiposCredivale(string aplicacion, string password)
        {
            var lstTiposCredivale = new List<CtipoCredivale>();

            if (Acceso.Verificar(aplicacion, password))
            {
                CtipoCredivale objTiposCredivale = new CtipoCredivale();
                lstTiposCredivale = objTiposCredivale.tiposCredivale();
            }
            else
            {
                CtipoCredivale tiposCredivale = new CtipoCredivale();
                tiposCredivale.mensaje = "Acceso restringido";
                lstTiposCredivale.Add(tiposCredivale);
            }

            return lstTiposCredivale;
       }

        [WebMethod]
        public List<CclasificacionTickets> getClasificacionTickets(string aplicacion, string password)
        {
            var lstClasificacionTickets = new List<CclasificacionTickets>();

            if (Acceso.Verificar(aplicacion, password))
            {
                CclasificacionTickets objClasificacionTickets = new CclasificacionTickets();
                lstClasificacionTickets = objClasificacionTickets.getClasificacionTickets();
                
            }
            else
            {
                CclasificacionTickets objClasificacionTickets = new CclasificacionTickets();
                objClasificacionTickets.mensaje = "Acceso restringido";
                lstClasificacionTickets.Add(objClasificacionTickets);
            }

            return lstClasificacionTickets;
        }

        [WebMethod]
        public CMisValesComprasResponse getMisValesCompras(string aplicacion, string password, string prtcCliente, string prtcPlaza)
        {
            //string misValesCompras = string.Empty;
            CMisValesComprasResponse objResponse = new CMisValesComprasResponse();
            //var lstMisValesCompras = new List<CmisValesCompras>();

            if (Acceso.Verificar(aplicacion, password))
            {
                CmisValesCompras objMisValesCompras = new CmisValesCompras();
                objResponse = objMisValesCompras.getValesCompras(prtcCliente, prtcPlaza);

            }
            else
            {
                objResponse.cadenaRespuesta = "Acceso restringido";
            }

            //return misValesCompras;
            return objResponse;
        }

        [WebMethod]
        public CpostvaleFisico postValeFisico(string aplicacion, string password, string cCliente, string FolioVale, string PersonaAutorizada, double MontoMaximo)
        {
            CpostvaleFisico objValeFisico = new CpostvaleFisico();

            if (Acceso.Verificar(aplicacion, password))
            {
                return objValeFisico.AsignarVale(cCliente, FolioVale, PersonaAutorizada, MontoMaximo);
            }
            else
            {
                objValeFisico.mensaje = "Acceso restringido";
                return objValeFisico;
            }
        }

        [WebMethod]
        public CpostvaleFisico deleteValeFisico(string aplicacion, string password, Int64 idAsignacionValeFisico, string cCliente, string folioCredivale)
        {
            CpostvaleFisico objValeFisico = new CpostvaleFisico();

            if (Acceso.Verificar(aplicacion, password))
            {
                return objValeFisico.CancelarVale(idAsignacionValeFisico , cCliente, folioCredivale);
            }
            else
            {
                objValeFisico.mensaje = "Acceso restringido";
                return objValeFisico;
            }
        }

        [WebMethod]
        public List<CsituacionClientes> getCatalogoSituacionClientes(string aplicacion, string password)
        {
            var listOfSituacionClientes = new List<CsituacionClientes>();
            CsituacionClientes objSituacionClientes = new CsituacionClientes();

            if (Acceso.Verificar(aplicacion, password))
            {
                listOfSituacionClientes = objSituacionClientes.getCatalogo();
            }
            else
            {
                objSituacionClientes.mensaje = "Acceso restringido";
                listOfSituacionClientes.Add(objSituacionClientes);
            }
            
            return listOfSituacionClientes;
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

        [WebMethod]
        public List<CDetalleTicketResponse> getDetalleTicket(string aplicacion, string password, string folioFactura)
        {
            

            if (Acceso.Verificar(aplicacion, password))
            {
                CDetalleTicket objDetalleTicket = new CDetalleTicket();
                return objDetalleTicket.detalleTicket(folioFactura);
            }
            else
            {
                List<CDetalleTicketResponse> lstDetalleTicket = new List<CDetalleTicketResponse>();
                CDetalleTicketResponse objRespuesta = new CDetalleTicketResponse();
                objRespuesta.mensaje = "Acceso restringido";
                lstDetalleTicket.Add(objRespuesta);
                return lstDetalleTicket;
            }

            
        }

        [WebMethod]
        public List<CPagoMayoristaresponse> getPagoMayorista(string aplicacion, string password, string plaza, string ccliente)
        {
            

            if (Acceso.Verificar(aplicacion, password))
            {
                CPagoMayorista objPagoMayorista = new CPagoMayorista();
                return objPagoMayorista.getPagoMayorista(plaza,ccliente);
            }
            else
            {
                List<CPagoMayoristaresponse> lstResponse = new List<CPagoMayoristaresponse>();
                CPagoMayoristaresponse objResponse = new CPagoMayoristaresponse();
                objResponse.mensaje = "Acceso restringido";
                lstResponse.Add(objResponse);
                return lstResponse;
            }

        }

        [WebMethod]
        public CResponseEnviarCorreoSMS postPwdRecovery(string aplicacion, string password, string movilDest, string textoSMS)
        {
            CResponseEnviarCorreoSMS objResponse = new CResponseEnviarCorreoSMS();
            
            if (Acceso.Verificar(aplicacion, password))
            {
                CenviarCorreoSMS objEnviarCorreoSms = new CenviarCorreoSMS();
                objEnviarCorreoSms.recuperarPwd = true;
                objEnviarCorreoSms.tipoMedio = 1;
                objEnviarCorreoSms.movilDestinatario = movilDest;
                objEnviarCorreoSms.textoSMS = textoSMS;
                objResponse = objEnviarCorreoSms.enviarCorreoSMS();

                return objResponse;
            }
            else
            {
                objResponse.cadenaRespuesta = "Acceso restringido";
                objResponse.codigoRespuesta = 403;
                return objResponse;
            }
        }

        [WebMethod]
        public CpuntosCredigana getPuntosCredigana(string aplicacion, string password, string sCcliente, string sCsuccliente)
        {
            if (Acceso.Verificar(aplicacion, password))
            {
                CpuntosCredigana objResponse = new CpuntosCredigana();
                return objResponse.obtenerPuntos(sCcliente, sCsuccliente);
            }
            else
            {
                CpuntosCredigana objResponse = new CpuntosCredigana();
                objResponse.mensaje = "Acceso restringido";
                return objResponse;
            }
        }

        [WebMethod]
        public CValidaCredivaleResponse isValidCredivale(string aplicacion, string password, string sFolioVale, double iImporte)
        {
            if (Acceso.Verificar(aplicacion, password))
            {
                CcrediVale objCredivale = new CcrediVale(sFolioVale, iImporte);
                return objCredivale.isValid();
            }
            else
            {
                CcrediVale objCredivale = new CcrediVale();
                CValidaCredivaleResponse objResponse = new CValidaCredivaleResponse();
                objResponse.mensaje = "Acceso Restringido";
                return objResponse;
            }
        }


    }
}