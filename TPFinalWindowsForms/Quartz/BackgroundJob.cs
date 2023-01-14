using Quartz;
using Quartz.Impl.AdoJobStore.Common;
using ScottPlot.Renderable;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinalWindowsForms.DAL;
using TPFinalWindowsForms.DAL.EntityFramework;
using TPFinalWindowsForms.Domain;
using TPFinalWindowsForms.Visual;

namespace TPFinalWindowsForms.Quartz
{
    
    public class BackgroundJob : IJob
    {
        Mail mail = new Mail();
        Fachada fachada = new Fachada();
        static DBContext contexto = new DBContext();
        RepositorioUsuario repoUsuario = new RepositorioUsuario(contexto);
        NumberFormatInfo provider = new NumberFormatInfo();
        RepositorioAlertas repoAlertas = new RepositorioAlertas(contexto);

        public async Task Execute(IJobExecutionContext context)
        {
            provider.NumberGroupSeparator = ","; 
            provider.NumberDecimalSeparator = ".";
            var listaUsuarios = repoUsuario.GetAll();
            var usuario = repoUsuario.Get(Program.usuarioLogueado);
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
