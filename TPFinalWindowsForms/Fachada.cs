using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TPFinalWindowsForms.DAL.EntityFramework;
using TPFinalWindowsForms.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using TPFinalWindowsForms.Domain;
using System.Windows.Forms;
using TPFinalWindowsForms.DAL;
using TPFinalWindowsForms.Visual;
using ScottPlot.Renderable;

namespace TPFinalWindowsForms
{
    public class Fachada
    {
        InteraccionApi interaccionCrypto = new InteraccionApi();

        public List<CryptoDTO> ObtenerListaFavoritas()
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.Get(Program.usuarioLogueado);
            string[] resultado = objetoUsuario.Favcriptos.Split(' ');
            List<string> listaFavoritas = resultado.ToList();
            List<CryptoDTO> listaCryptosDTO = interaccionCrypto.GetFavCryptosDTO(listaFavoritas);
            return listaCryptosDTO;
        }

        public void SendMail(string mensaje, string email)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            string fromMail = "TpFinalTallerGrupo4@gmail.com";
            string fromPassword = "dupgpbrtohmpklmo";
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
                stringAlertasFromDB += "\n Su umbral es del: " + user.Umbral + "%";
                SendMail(stringAlertasFromDB, user.Email);

            }

        }
    }
}
