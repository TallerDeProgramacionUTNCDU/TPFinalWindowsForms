using Quartz;
using Quartz.Impl.AdoJobStore.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinalWindowsForms.DAL.EntityFramework;
using TPFinalWindowsForms.Domain;
using TPFinalWindowsForms.Visual;

namespace TPFinalWindowsForms.Quartz
{
    
    public class BackgroundJob : IJob
    {
        Fachada fachada = new Fachada();
        static UsuarioManagerDBContext context = new UsuarioManagerDBContext();
        RepositorioUsuario repoUsuario = new RepositorioUsuario(context);
        NumberFormatInfo provider = new NumberFormatInfo();
        ObjetoApiInteraccion interaccionCrypto = new ObjetoApiInteraccion();
        
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
                    j++;
                    var cryptoFechaNombre = interaccionCrypto.Get6MonthHistoryFrom(crypto.Id);
                    Program.listaAlertas.Add(cryptoFechaNombre[0].Time + " La crypto :" + crypto.Name + " cambio un: " + String.Format("{0:0.0000}", double.Parse(crypto.ChangePercent24hs, provider)) + "%");
                }

            }
            fachada.SendMail();
            foreach (var user in listaUsuarios)
            {
                Login.log.Info("Mail enviado a " + user.Email);
            }
        }
    }
}
