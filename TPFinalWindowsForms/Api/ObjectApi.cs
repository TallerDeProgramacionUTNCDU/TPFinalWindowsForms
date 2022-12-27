using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TPFinalWindowsForms
{
    public class ObjectApi
    {
        public ObjectApi() { }
        public dynamic GetAPIResponseItem(string mUrl)
        {

            // Se crea el request http
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUrl);

            // Se ejecuta la consulta
            WebResponse mResponse = mRequest.GetResponse();

            // Se obtiene los datos de respuesta
            Stream responseStream = mResponse.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

            // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
            dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());
            return mResponseJSON;
        }
    }
}
