using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinalWindowsForms.DAL
{
        public interface IRepositorio<TEntity> where TEntity : class
        {

            void Add(TEntity pEntity);

            void Remove(TEntity pEntity);

            TEntity Get(string pNick);

            IEnumerable<TEntity> GetAll();

    }
}
