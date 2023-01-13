using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinalWindowsForms.DAL.EntityFramework;

namespace TPFinalWindowsForms.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositorioUsuario RepositorioUsuario { get; }
        IRepositorioAlertas RepositorioAlertas { get; }
        void Complete();
    }
}
