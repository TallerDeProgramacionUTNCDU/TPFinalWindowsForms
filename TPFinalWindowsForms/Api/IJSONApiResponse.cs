using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinalWindowsForms.Api
{
    public interface IJSONApiResponse
    {
        dynamic Data { get; set; }
        dynamic GetAPIResponseItem(string mUrl);

        dynamic Data{ get; set;}
        void GetAPIResponseItem(string mUrl);
    }
}
