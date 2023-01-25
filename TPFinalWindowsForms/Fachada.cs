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
using Npgsql.Internal.TypeHandlers;

namespace TPFinalWindowsForms
{
    public class Fachada
    {
        public static string assetsUrl = "https://api.coincap.io/v2/assets";
        public static string history = "https://api.coincap.io/v2/assets/{0}/history?interval=d1";

        private static string logued = "";
        public static string usuarioLogueado
        {
            get { return logued; }
            set { logued = value; }
        }
        DataCriptoAPI interaccionCrypto = new DataCriptoAPI();

        public List<CryptoDTO> ObtenerListaFavoritas()
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.Get(usuarioLogueado);
            string[] resultado = objetoUsuario.Favcriptos.Split(' ');
            List<string> listaFavoritas = resultado.ToList();
            List<CryptoDTO> listaCryptosDTO = interaccionCrypto.GetFavCryptosDTO(listaFavoritas);
            return listaCryptosDTO;
        }

        public List<CryptoDTO> GetAllCryptoDTO()
        {
            DataCriptoAPI interaccionApi = new DataCriptoAPI();
            var respuestaAPI=new JSONApiResponse();
            respuestaAPI.GetAPIResponseItem(assetsUrl);
            return interaccionApi.GetAllCrytosDTO(respuestaAPI.data);
        }
        public IEnumerable<Alerta> GetAllAlerts()
        {
            DBContext contexto = new DBContext();
            RepositorioAlertas repositorioAlertas = new RepositorioAlertas(contexto);
            return repositorioAlertas.GetAll();
        }
        public List<HistoryItem> GetHystoryFrom(string cripto)
        {
            DataCriptoAPI interaccionApi = new DataCriptoAPI();
            return interaccionApi.Get6MonthHistoryFrom(cripto);
        }

        public Usuario GetUsuarioActual()
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            return repoUsuario.Get(usuarioLogueado);
        }

        public void AddFavCrypto(string cripto)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            using (IUnitOfWork bUoW = new UnitOfWork(new DBContext()))
            {
                var usuario = repoUsuario.Get(usuarioLogueado);
                usuario.Favcriptos = usuario.Favcriptos + " " + cripto;
                context.SaveChanges();
            }
        }
        public bool ExisteCripto(string cripto)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.Get(usuarioLogueado);
            string[] arrayCryptos = objetoUsuario.Favcriptos.Split(' ');
            bool existe = false;
            int i = 0;
            foreach (var crypto in arrayCryptos)
            {
                if (crypto == cripto)
                {
                    existe = true;
                    break;
                }
                i++;
            }
            return existe;
        }
        public int PosCriptoABorrar(string cripto)
        {
            var objetoUsuario = GetUsuarioActual();
            string[] arrayCryptos = objetoUsuario.Favcriptos.Split(' ');
            int i = 0;
            foreach (var crypto in arrayCryptos)
            {
                if (crypto == cripto)
                {
                    break;
                }
                i++;
            }
            return i;
        }

        public void DelFavCrypto(string cripto)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            string cryptosFavoritas = "";
            var objetoUsuario = repoUsuario.Get(usuarioLogueado);
            string[] arrayCryptos = objetoUsuario.Favcriptos.Split(' ');           
            arrayCryptos[PosCriptoABorrar(cripto)] = null;
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
            var objetoUsuario = repoUsuario.Get(usuarioLogueado);
            objetoUsuario.Umbral = double.Parse(umbral, provider);
            context.SaveChanges();

        }

        public void RemoveAlert(Alerta alert)
        {
            DBContext context = new DBContext();
            RepositorioAlertas repositorioAlertas = new RepositorioAlertas(context);
            repositorioAlertas.Remove(alert);
            context.SaveChanges();
        }

        public void ChangeNombre(string nombre)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.Get(usuarioLogueado);
            objetoUsuario.Nombre = nombre;
            context.SaveChanges();
        }

        public void ChangeApellido(string apellido)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.Get(usuarioLogueado);
            objetoUsuario.Apellido = apellido;
            context.SaveChanges();
        }

        public void ChangePassword(string pass)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.Get(usuarioLogueado);
            objetoUsuario.Contraseña = pass;
            context.SaveChanges();
        }

        public void ChangeEmail(string email)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.Get(usuarioLogueado);
            objetoUsuario.Email = email;
            context.SaveChanges();
        }

        public void ChangeUmbral(double umbral)
        {
            DBContext context = new DBContext();
            RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
            var objetoUsuario = repoUsuario.Get(usuarioLogueado);
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
            var usuario = fachada.GetUsuarioActual();
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

            mail.CrearMensajeMail();
            foreach (var user in listaUsuarios)
            {
                Login.log.Info("Mail enviado a " + user.Email);
            }
        }




    }
}
