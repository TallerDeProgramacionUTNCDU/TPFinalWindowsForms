using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinalWindowsForms.Domain;
using TPFinalWindowsForms.DAL;

namespace TPFinalWindowsForms.DAL.EntityFramework
{
    public class RepositorioUsuario : Repositorio<UsuarioManagerDBContext, Usuario>, IRepositorioUsuario

    {
        public RepositorioUsuario(UsuarioManagerDBContext pDbContext) : base(pDbContext)
        {

        }

    }
}
