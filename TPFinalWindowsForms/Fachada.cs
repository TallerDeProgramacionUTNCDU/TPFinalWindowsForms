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

namespace TPFinalWindowsForms
{
    public class Fachada
    {
        ObjetoApiInteraccion interaccionCrypto = new ObjetoApiInteraccion();

        public List<CryptoDTO> ObtenerListaFavoritas()
        {
            UsuarioManagerDBContext context = new UsuarioManagerDBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.Get(Program.usuarioLogueado);
            string[] resultado = objetoUsuario.Favcriptos.Split(' ');
            List<string> listaFavoritas = resultado.ToList();
            List<CryptoDTO> listaCryptosDTO = interaccionCrypto.GetFavCryptosDTO(listaFavoritas);
            return listaCryptosDTO;
        }

        public void SendMail()
        {
            UsuarioManagerDBContext context = new UsuarioManagerDBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var listaUsuarios = repoUsuario.GetAll();
            foreach (var usuario in listaUsuarios)
            {
                if (usuario.Favcriptos.Length > 0)
                {
                    string fromMail = "TpFinalTallerGrupo4@gmail.com";
                    string fromPassword = "dupgpbrtohmpklmo";
                    List<AlertaCryptoDTO> listaCryptosAlerta = interaccionCrypto.GetAlertas(usuario.Nickname);
                    if (listaCryptosAlerta.Count >0)
                    {
                        string mensaje = "";
                        foreach (var crypto in listaCryptosAlerta)
                        {
                            mensaje = mensaje + "\n Crypto: " + crypto.Name + "   Cambio Porcentual 24h: " + crypto.ChangePercent24hs + "%";
                        }
                        mensaje = mensaje + "\n Su umbral es del: " + usuario.Umbral + "%"; 

                        MailMessage message = new MailMessage();
                        message.From = new MailAddress(fromMail);
                        message.Subject = "Alerta Tendencias";
                        message.To.Add(new MailAddress(usuario.Email));
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
                }
            }           
        }










        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();
                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


    }
}
