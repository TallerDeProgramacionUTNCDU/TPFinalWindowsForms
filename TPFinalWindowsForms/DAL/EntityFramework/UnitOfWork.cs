using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinalWindowsForms.DAL;

namespace TPFinalWindowsForms.DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DBContext iDbContext;

        private bool iDisposedValue = false;

        public UnitOfWork(DBContext pDbContext)
        {
            if (pDbContext == null)
            {
                throw new NotImplementedException();
            }

            this.iDbContext = pDbContext;
            this.RepositorioUsuario = new RepositorioUsuario(pDbContext);
        }

        public IRepositorioUsuario RepositorioUsuario { get; private set; } 
        public IRepositorioAlertas RepositorioAlertas { get; private set; }
        public void Complete()
        {
            this.iDbContext.SaveChanges();
        }
        protected virtual void Dispose(bool pDisposing)
        {
            if (!this.iDisposedValue)
            {
                if (pDisposing)
                {
                    this.iDbContext.Dispose();
                }
                this.iDisposedValue = true;
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
