using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TPFinalWindowsForms.Api;

namespace TPFinalWindowsForms
{
    public class JSONApiResponse:IJSONApiResponse
    {
        public dynamic data;
        public dynamic Data
        { get {return this.data;}
          set{ this.data = value;}
            }
         public JSONApiResponse()
         {

         }
        //Consulta sobre si en lugar de hacer que la clase JSONApiResponse sea la que ejecute un metodo para obtener el JSON de la API se podria hacer que la clase JSONApiResponse tenga un atributo "data" por ejemplo que sea de tipo dynamic y que en el constructor de la clase JSONApiResponse se ejecute el codigo del metodo GetAPIResponseItem, asi se podria crear la instancia fake de JSONApiResponse y no deberia crearse un JSONApiResponse que despues ejecuta otro metodo que es solo lo del metodo lo que nos interesa.  Ver como deberiamos cambiarlo en lo que ya teniamos
        public void GetAPIResponseItem(string mUrl)
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
            //return mResponseJSON;
            data=mResponseJSON;
        }
    }
}
