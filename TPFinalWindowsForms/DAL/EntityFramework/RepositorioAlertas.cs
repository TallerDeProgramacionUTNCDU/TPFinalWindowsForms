using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinalWindowsForms.Domain;
using TPFinalWindowsForms.DAL;

namespace TPFinalWindowsForms.DAL.EntityFramework
{
    public class RepositorioAlertas : Repositorio<DBContext, Alerta>, IRepositorioAlertas

    {
        public RepositorioAlertas(DBContext pDbContext) : base(pDbContext)
        {

        }

    }
}
