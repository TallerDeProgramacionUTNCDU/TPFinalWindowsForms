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

    
    }
}
