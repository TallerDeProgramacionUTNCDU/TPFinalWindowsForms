﻿using Newtonsoft.Json;
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
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public JSONApiResponse() 
        { 

        }
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
            Data=mResponseJSON;
        }
    }
}
