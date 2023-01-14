using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TPFinalWindowsForms.DAL.EntityFramework;
using TPFinalWindowsForms.Domain;

namespace TPFinalWindowsForms
{
    public class Mail
    {
        public void SendMail(string mensaje, string email)
        {           
            string fromMail = "tpfinaltallergrupo4v2@gmail.com";
            string fromPassword = "nqeuqapfkueewwpr";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Alerta Tendencias";
            message.To.Add(new MailAddress(email));
            message.Body = mensaje;
            //message.IsBodyHtml = false;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };            
            smtpClient.Send(message);
            
        }

        public void CrearMensajeMail()
        {
            DBContext context = new DBContext();
            RepositorioAlertas repoAlertas = new RepositorioAlertas(context);
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var listaUsuarios = repoUsuario.GetAll();
            var listaAlertas = repoAlertas.GetAll();
            string stringAlertasFromDB = "";
            
            //Creamos listas propias del objeto ya que no funcionaban los foreach anidados con las listas resultantes del getall();

            List<Alerta> listaAlertasObjeto = new List<Alerta>();
            List<Usuario> listaUsuarioObjeto = new List<Usuario>();
            foreach (var alerta in listaAlertas)
            {
                listaAlertasObjeto.Add(alerta);
            }
            foreach (var usuario in listaUsuarios)
            {
                listaUsuarioObjeto.Add(usuario);
            }


            foreach (var user in listaUsuarioObjeto)
            {
                stringAlertasFromDB = "";
                if (user.Favcriptos.Length > 0)
                {
                    foreach (var alerta in listaAlertasObjeto)
                    {
                        if (alerta.Idusuario == user.Nickname)
                        {
                            stringAlertasFromDB += "La cripto " + alerta.Umbralalerta + "cambio un " + String.Format("{0:0.0000}", alerta.Umbralalerta) + "%\n";                            
                        }
                    }
                }
                if (stringAlertasFromDB.Length > 0)
                {
                    stringAlertasFromDB += "\n Su umbral es del: " + user.Umbral + "%";
                    SendMail(stringAlertasFromDB, user.Email);
                }
            }
        }
    }
}
