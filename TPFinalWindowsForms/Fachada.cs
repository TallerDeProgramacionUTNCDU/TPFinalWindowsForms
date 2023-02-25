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
using Quartz.Impl.AdoJobStore.Common;
using TPFinalWindowsForms.ServicioMail;
using TPFinalWindowsForms.Api.Exceptions;
namespace TPFinalWindowsForms
{
    public class Fachada
    {

        DataCriptoAPI interaccionCrypto = new DataCriptoAPI();

        public List<CryptoDTO> ObtenerListaFavoritas()
        {
            try
            {
                DBContext context = new DBContext();
                RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
                var objetoUsuario = repoUsuario.GetUsuarioActual();
                string[] resultado = objetoUsuario.Favcriptos.Split(' ');
                List<string> listaFavoritas = resultado.ToList();
                List<CryptoDTO> listaCryptosDTO = interaccionCrypto.GetFavCryptosDTO(listaFavoritas);
                return listaCryptosDTO;
            }
            catch (WebException ex)
            {
                if (ex.Response is null)
                {
                    Login.log.Error("Error: no hubo respuesta del servicio");
                    throw new ExcepcionesApi("Se ha producido un error con el servicio de datos de Criptomonedas, intente mas tarde");
                }
                WebResponse mErrorResponse = ex.Response;
                using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                {
                    StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                    String mErrorText = mReader.ReadToEnd();
                    Login.log.Error("Error: {0} " + mErrorResponse);
                    throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
                }
            }
            catch (Exception ex)
            {
                Login.log.Error("Errpr: {0} " + ex.Message);
                throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
            }
        }

        public List<CryptoDTO> GetAllCryptoDTO()
        {
            try
            {
                DataCriptoAPI interaccionApi = new DataCriptoAPI();
                return interaccionApi.GetAllCrytosDTO();
            }
            catch (WebException ex)
            {
                if (ex.Response is null)
                {
                    Login.log.Error("Error: no hubo respuesta del servicio");
                    throw new ExcepcionesApi("Se ha producido un error con el servicio de datos de Criptomonedas, intente mas tarde");
                }
                WebResponse mErrorResponse = ex.Response;
                using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                {
                    StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                    String mErrorText = mReader.ReadToEnd();
                    Login.log.Error("Errpr: {0} " + mErrorText);
                    throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
                }
            }
            catch (Exception ex)
            {
                Login.log.Error("Error: {0} " + ex.Message);
                throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
            }

        }
        public IEnumerable<Alerta> GetAllAlerts()
        {
            DBContext contexto = new DBContext();
            RepositorioAlertas repositorioAlertas = new RepositorioAlertas(contexto);
            return repositorioAlertas.GetAll();
        }
        public List<HistoryItem> GetHystoryFrom(string cripto)
        {
            try
            {
                DataCriptoAPI interaccionApi = new DataCriptoAPI();
                var historial= interaccionApi.Get6MonthHistoryFrom(cripto);
                return historial;
            }
            catch (WebException ex)
            {
                if (ex.Response is null)
                {
                    Login.log.Error("Error: no hubo respuesta del servicio");
                    throw new ExcepcionesApi("Se ha producido un error con el servicio de datos de Criptomonedas, intente mas tarde");
                }
                else
                {
                    WebResponse mErrorResponse = ex.Response;
                    using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                    {
                        StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                        String mErrorText = mReader.ReadToEnd();
                        Login.log.Error("Error: {0} " + mErrorText);
                        Login.log.Debug("Respuesta del servicio vacía, no se encontró la crypto o la API no respondió");
                        List<HistoryItem> empty = new List<HistoryItem>();
                        return empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Login.log.Error("Error: {0} " + ex.Message);
                throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
            }
        }

        public void AddFavCrypto(string cripto)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            using (IUnitOfWork bUoW = new UnitOfWork(new DBContext()))
            {
                var usuario = repoUsuario.GetUsuarioActual();
                usuario.Favcriptos = usuario.Favcriptos + " " + cripto;
                context.SaveChanges();
            }
        }

        public Usuario GetUsuarioActual()
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            return repoUsuario.GetUsuarioActual();
        }

        public bool ExisteUsuario(string nick)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var buscado=repoUsuario.Get(nick);
            if (buscado is null) { return false; }
            else return true;
        }
        public void AgregarNuevoUsuario(string nickname, string nombre, string apellido, string contraseña, string email)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new DBContext()))
            {
                Usuario usuario = new Usuario(nickname, nombre, apellido, contraseña, email, "", 0, false);
                bUoW.RepositorioUsuario.Add(usuario);
                bUoW.Complete();
                Login.log.Info("Registro Exitoso");
            }
        }
        public Usuario GetUser(string nick)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            return repoUsuario.Get(nick);
        }

        public void DelFavCrypto(string cripto)
        {
            Utilidades utilidad = new Utilidades();
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            string cryptosFavoritas = "";
            var objetoUsuario = repoUsuario.GetUsuarioActual();
            string[] arrayCryptos = objetoUsuario.Favcriptos.Split(' ');           
            arrayCryptos[utilidad.PosCriptoABorrar(cripto)] = null;
            foreach (var nombreCrypto in arrayCryptos)
            {
                if (nombreCrypto != "")
                {
                    cryptosFavoritas = cryptosFavoritas + " " + nombreCrypto;
                }
            }
            using (IUnitOfWork bUoW = new UnitOfWork(new DBContext()))
            {
                objetoUsuario.Favcriptos = cryptosFavoritas;
                context.SaveChanges();
            }
        }
        public void ChangeUmbral(string umbral, NumberFormatInfo provider)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.GetUsuarioActual();
            objetoUsuario.Umbral = double.Parse(umbral, provider);
            context.SaveChanges();

        }

        public void RemoveAlertByIndex(int pos)
        {
            DBContext context = new DBContext();
            RepositorioAlertas repositorioAlertas = new RepositorioAlertas(context);
            var listaAlertas = this.GetAllAlerts();
            var i = -1;
            if (listaAlertas.Count() > 0)
            {
                foreach (var alerta in listaAlertas)
                {
                    i++;
                    if (pos == i)
                    {
                        repositorioAlertas.Remove(alerta);
                    }
                }
                context.SaveChanges();
            }

        }

        public void RemoveAllAlerts()
        {
            DBContext context = new DBContext();
            RepositorioAlertas repositorioAlertas = new RepositorioAlertas(context);
            var listaAlertas = this.GetAllAlerts();
            if (listaAlertas.Count() > 0)
            {
                foreach (var alerta in listaAlertas)
                {
                    repositorioAlertas.Remove(alerta);
                }
                context.SaveChanges();
            }

        }

        

        public static void ActivarSesion(string nickname)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.Get(nickname);
            objetoUsuario.SesionActiva = true;
            context.SaveChanges();
        }

        public static void DesactivarSesion()
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var arrayUsuarios = repoUsuario.GetAll();
            foreach (var usuario in arrayUsuarios)
            {
                if (usuario.SesionActiva)
                {
                    usuario.SesionActiva = false;
                }
            }
            context.SaveChanges();
        }

        public void ChangeNombre(string nombre)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.GetUsuarioActual();
            objetoUsuario.Nombre = nombre;
            context.SaveChanges();
        }

        public void ChangeApellido(string apellido)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.GetUsuarioActual();
            objetoUsuario.Apellido = apellido;
            context.SaveChanges();
        }

        public void ChangePassword(string pass)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.GetUsuarioActual();
            objetoUsuario.Contraseña = pass;
            context.SaveChanges();
        }

        public void ChangeEmail(string email)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.GetUsuarioActual();
            objetoUsuario.Email = email;
            context.SaveChanges();
        }

        public void ChangeUmbral(double umbral)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.GetUsuarioActual();
            objetoUsuario.Umbral = umbral;
            context.SaveChanges();
        }

        public void QuartzJob()
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            MailService mail = new MailService();
            Fachada fachada = new Fachada();
            DBContext contexto = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(contexto);
            RepositorioAlertas repoAlertas = new RepositorioAlertas(contexto);
            provider.NumberGroupSeparator = ",";
            provider.NumberDecimalSeparator = ".";
            var listaUsuarios = repoUsuario.GetAll();
            var usuario = repoUsuario.GetUsuarioActual();
            var listaFavoritas = fachada.ObtenerListaFavoritas();

            var j = 0;
            foreach (var crypto in listaFavoritas)
            {
                if (usuario.Umbral < Math.Abs(double.Parse(crypto.ChangePercent24hs, provider)))
                {
                    Alerta alerta = new Alerta
                    {
                        Idcripto = crypto.Name,
                        Idusuario = usuario.Nickname,
                        Fecha = DateTime.Now,
                        Umbralalerta = double.Parse(crypto.ChangePercent24hs, provider)
                    };
                    repoAlertas.Add(alerta);
                    contexto.SaveChanges();
                }
            }

            //mail.CrearMensajeMail();
            foreach (var user in listaUsuarios)
            {
                Login.log.Info("Mail enviado a " + user.Email);
            }
        }
    }
}
