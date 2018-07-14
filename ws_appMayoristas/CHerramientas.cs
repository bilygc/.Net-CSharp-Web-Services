using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Web;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ws_appMayoristas
{
    public class CHerramientas
    {
        public static string SerializarArrayList(IList ArrlstObj, Type clase)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer Serializador = new XmlSerializer(typeof(IList), new Type[] { clase });

            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                try
                {
                    Serializador.Serialize(stream, ArrlstObj);
                    stream.Position = 0;
                    xmlDoc.Load(stream);
                    return xmlDoc.OuterXml;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

        }

        public static string CrearZipBase64(string xml, string Nombre)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(xml);
            writer.Flush();
            stream.Position = 0;


            MemoryStream outputMemStream = new MemoryStream();
            ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

            zipStream.SetLevel(3);
            //0-9, 9 being the highest level of compression
            ZipEntry newEntry = new ZipEntry(Nombre + ".xml");
            newEntry.DateTime = DateTime.Now;
            zipStream.PutNextEntry(newEntry);
            StreamUtils.Copy(stream, zipStream, new byte[4096]);
            zipStream.CloseEntry();
            zipStream.IsStreamOwner = false;
            zipStream.Close();
            outputMemStream.Position = 0;
            return Convert.ToBase64String(outputMemStream.ToArray()); ;
        }

        public static void enviarCorreo(string correoDesde, string correoPara, string Titulo, string Texto)
        {
            MailMessage mail = new MailMessage(correoDesde.Trim(), correoPara.Trim());
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Credentials = new System.Net.NetworkCredential("bilygc@calzzapato.com", "calzza013");
            client.EnableSsl = true;
            mail.Subject = Titulo;
            mail.Body = Texto;
            client.Send(mail);
        }

        public static string quitarAcentos(string textoConAcentos)
        {
            string textoNormalizado = textoConAcentos.Normalize(NormalizationForm.FormD);
            Regex reg = new Regex("[^a-zA-Z0-9 ]");
            string textoSinAcentos = reg.Replace(textoNormalizado, "");
            return textoSinAcentos;
        }

        public static Int32 enviarSMS(string numeroMovil, string texto)
        {
            Int32 codigoEjecucion = (-1);
            var proceso = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo iniciarInfo = new ProcessStartInfo();
            iniciarInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            iniciarInfo.FileName = "CMD.exe";
            iniciarInfo.Arguments = @"/C C:\supports\MensajesInfobip\ConsoleSMS_InfoBip.exe """ + numeroMovil + @"""  """ + texto + @"""  """ + @"""xml""";
            proceso.StartInfo = iniciarInfo;
            proceso.Start();


            proceso.WaitForExit(7000);
            if (proceso.HasExited)
            {
                codigoEjecucion = proceso.ExitCode;
            }



            return codigoEjecucion;
        }

        public static bool validarCorreoE(string correoE)
        {

            //generamos el patron de correo valido
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"
            );

            //hacemos el match entre el correo y el patron
            Match match = regex.Match(correoE);

            if (match.Success)
                return true;
            else
                return false;


        }

        public static void Log(string FileName, string Texto)
        {
            using (StreamWriter w = File.AppendText(@"c:\log\" + FileName))
            {
                w.WriteLine("\r\n-------------------------------------");
                w.WriteLine("{0} {1} -> {2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), Texto.Trim());
                w.WriteLine("-------------------------------------");
                w.Flush();

            }
        }

    }
}