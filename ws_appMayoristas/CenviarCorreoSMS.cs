using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ws_appMayoristas
{
    public class CenviarCorreoSMS : ClienteMayorista
    {

        private string _cCliente;
        private Int16 _tipoMedio;
        private string _movilOrigen;
        private string _movilDestinatario;
        private string _textoSMS;
        private string _remitenteCorreo;
        private string _correoDestinatario;
        private string _tituloCorreo;
        private string _cuerpoCorreo;
        private bool _recuperarPwd;

        public bool recuperarPwd
        {
            get { return _recuperarPwd; }
            set { _recuperarPwd = value; }
        }

        public string cCliente
        {
            get { return _cCliente; }
            set { _cCliente = value; }
        }

        public Int16 tipoMedio
        {
            get { return _tipoMedio; }
            set { _tipoMedio = value; }
        }

        public string movilOrigen
        {
            get { return _movilOrigen; }
            set { _movilOrigen = value; }
        }

        public string movilDestinatario
        {
            get { return _movilDestinatario; }
            set { _movilDestinatario = value; }
        }
        

        public string textoSMS
        {
            get { return _textoSMS; }
            set { _textoSMS = value; }
        }
        

        public string remitenteCorreo
        {
            get { return _remitenteCorreo; }
            set { _remitenteCorreo = value; }
        }
        

        public string correoDestinatario
        {
            get { return _correoDestinatario; }
            set { _correoDestinatario = value; }
        }
        

        public string tituloCorreo
        {
            get { return _tituloCorreo; }
            set { _tituloCorreo = value; }
        }
        

        public string cuerpoCorreo
        {
            get { return _cuerpoCorreo; }
            set { _cuerpoCorreo = value; }
        }

        public CenviarCorreoSMS()
        {
            this.cCliente = string.Empty;
            this.tipoMedio = 0;
            this.movilOrigen = string.Empty;
            this.movilDestinatario = string.Empty;
            this.textoSMS = string.Empty;
            this.remitenteCorreo = string.Empty;
            this.correoDestinatario = string.Empty;
            this.tituloCorreo = string.Empty;
            this.cuerpoCorreo = string.Empty;
            this.recuperarPwd = false;

        }

        public CResponseEnviarCorreoSMS enviarCorreoSMS()
        {
            //CHerramientas.Log("ws_appMayoristas.txt", "Probando funcionalidad de log");
            CResponseEnviarCorreoSMS objRespuesta = new CResponseEnviarCorreoSMS();
            
            //SMS
            if (this._tipoMedio == 1)
            {
                //validamos que la longitud del numero sea la correcta 521 + lada + numero o que no este vacio
                if (this._movilDestinatario.Length == 13)
                {
                    //Quitamos los acentos y caracteres especiales
                    this._textoSMS = CHerramientas.quitarAcentos(this._textoSMS);

                    //validamos que no exceda el limite de caracteres del sms y que no este vacio
                    if (this._textoSMS.Length <= 250)
                    {

                        //si el texto no es vacio o nulo
                        if (!string.IsNullOrEmpty(this._textoSMS.Trim()))
                        {
                            
                            //para finalizar verificamos que el numero de celular de donde se envia sea el que registro la persona o que sea un sms de recuperacion de pwd
                            if (this.verificarMovilMayorista(this.cCliente, this.movilOrigen) || this.recuperarPwd)
                            {

                                //Enviamos el sms al mayorista y al subcliente
                                string sMovilOrigenDestinatario = this._movilDestinatario;
                                objRespuesta.codigoRespuesta = CHerramientas.enviarSMS(sMovilOrigenDestinatario, this._textoSMS);
                                if (objRespuesta.codigoRespuesta == 0)
                                {
                                    objRespuesta.cadenaRespuesta = "Envio de SMS Exitoso!";
                                }
                                else
                                {
                                    objRespuesta.cadenaRespuesta = "Error:No se Pudo Enviar el SMS";
                                }
                            }
                            else
                            {
                                objRespuesta.cadenaRespuesta = "Numero de origen no registrado";
                                objRespuesta.codigoRespuesta = (-1);
                                return objRespuesta;
                            }
                        }
                        else
                        {
                            objRespuesta.cadenaRespuesta = "el texto del mensaje esta vacio";
                            objRespuesta.codigoRespuesta = (-1);
                            return objRespuesta;
                        }
                        
                    }
                    else
                    {
                        objRespuesta.cadenaRespuesta = "La longitud del mensaje excede los 250 caracteres";
                        objRespuesta.codigoRespuesta = (-1);
                        return objRespuesta;
                    }
                }
                else
                {
                    objRespuesta.cadenaRespuesta = "La longitud del numero celular es incorrecta, la longitud correcta es de 13 caracteres";
                    objRespuesta.codigoRespuesta = (-1);
                    return objRespuesta;
                }
                
            }//Correo E
            else if (this._tipoMedio == 2)
            {
                //VERIFICAMOS CORREO DEL REMITENTE SEA VALIDO
                if (CHerramientas.validarCorreoE(this._remitenteCorreo))
                {
                    //VERIFICAMOS CORREO DEL DESTINATARIO SEA VALIDO
                    if (CHerramientas.validarCorreoE(this._correoDestinatario))
                    {
                        // validamos que el titulo no este en blanco
                        if (!string.IsNullOrEmpty(this._tituloCorreo.Trim()))
                        {
                            //Verificamos que el cuerpo del correo no este en blanco
                            if (!string.IsNullOrEmpty(this._cuerpoCorreo.Trim()))
                            {
                                CHerramientas.enviarCorreo(this._remitenteCorreo, this._correoDestinatario, this._tituloCorreo, this._cuerpoCorreo);
                                objRespuesta.cadenaRespuesta = "Correo enviado!";
                                objRespuesta.codigoRespuesta = 0;
                                return objRespuesta;
                            }
                            else
                            {
                                objRespuesta.cadenaRespuesta = "El cuerpo del correo esta vacio";
                                objRespuesta.codigoRespuesta = (-1);
                                return objRespuesta;
                            }
                        }
                        else
                        {
                            objRespuesta.cadenaRespuesta = "El titulo del correo esta vacio";
                            objRespuesta.codigoRespuesta = (-1);
                            return objRespuesta;
                        }

                    }
                    else
                    {
                        objRespuesta.cadenaRespuesta = "El correo del destinatario no es valido";
                        objRespuesta.codigoRespuesta = (-1);
                        return objRespuesta;
                    }
                }
                else
                {
                    objRespuesta.cadenaRespuesta = "El correo del remitente no es valido";
                    objRespuesta.codigoRespuesta = (-1);
                    return objRespuesta;
                }
            }
            else
            {
                objRespuesta.cadenaRespuesta = "tipo de medio incorrecto! 1:SMS 2:Correo-E";
                objRespuesta.codigoRespuesta = (-1);
                return objRespuesta;
            }
            return objRespuesta;
        }

        public bool verificarMovilMayorista(string cCliente, string movil)
        {
            bool bMovil = false;
            

            try
            {
                using (SqlConnection conn = this.conexionBD())
                {
                    int nRegistros;

                    SqlCommand query = new SqlCommand("select cCliente from [YourEnterprise].[dbo].[eVale_MediosCliente] where cCliente = @CCLIENTE and cReferencia = @MOVIL ", conn);
                    query.Parameters.Add(new SqlParameter("CCLIENTE", cCliente));
                    query.Parameters.Add(new SqlParameter("MOVIL", movil));

                    nRegistros = Convert.ToInt32(query.ExecuteScalar());
                    if (nRegistros > 0)
                        bMovil = true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return bMovil;
        }
    }
}