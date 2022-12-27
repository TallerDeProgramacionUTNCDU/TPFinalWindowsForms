using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinalWindowsForms.DAL.EntityFramework
{
    public abstract class Repositorio<TDbContext, TEntity> : IRepositorio<TEntity> where TEntity : class where TDbContext : DbContext
    {
        protected readonly TDbContext iDbContext;
        public Repositorio(TDbContext pDbContext)
        {
            if (pDbContext == null)
            {
                throw new ArgumentNullException(nameof(pDbContext));
            }

            iDbContext = pDbContext;
        }

        public void Add(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            iDbContext.Set<TEntity>().Add(pEntity);
        }

        public TEntity Get(string pNick)
        {
            return iDbContext.Set<TEntity>().Find(pNick);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return iDbContext.Set<TEntity>();
        }
        public void Remove(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            iDbContext.Set<TEntity>().Remove(pEntity);
        }



    }


}
