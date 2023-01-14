using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinalWindowsForms.Api
{
    public interface IObjectApi<TEntity> where TEntity : class
    {
        dynamic GetAPIResponseItem(string mUrl);

    }
}
