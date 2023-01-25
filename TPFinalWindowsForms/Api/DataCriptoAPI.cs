using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using TPFinalWindowsForms.IO;
using TPFinalWindowsForms.Domain;
using TPFinalWindowsForms.DAL.EntityFramework;
using TPFinalWindowsForms.DAL;
using System.Globalization;
using TPFinalWindowsForms.Visual;
using Moq;
using TPFinalWindowsForms.Api;
using TPFinalWindowsForms.Api.Exceptions;

namespace TPFinalWindowsForms
{
    public class DataCriptoAPI:IDataCriptoAPI
    {
        public static string assetsUrl = "https://api.coincap.io/v2/assets";
        public static string history = "https://api.coincap.io/v2/assets/{0}/history?interval=d1";

        public List<CryptoDTO> GetFavCryptosDTO(List<String> pLista)
        {
            var lista = new List<CryptoDTO>();
            foreach (var elemento in pLista)
            {
                var conexionFavCryptos = new JSONApiResponse();
                try
                {
                    // var responseFav = conexionFavCryptos.GetAPIResponseItem(assetsUrl);
                    conexionFavCryptos.GetAPIResponseItem(assetsUrl);
                    var responseFav = conexionFavCryptos.data;
                    foreach (var bResponseItem in responseFav.data)
                    {
                        if (elemento == bResponseItem.id.ToString())
                        {
                            var objetoDTO = new CryptoDTO(bResponseItem.id.ToString(), bResponseItem.name.ToString(), bResponseItem.rank.ToString(), bResponseItem.priceUsd.ToString(), bResponseItem.symbol.ToString(), bResponseItem.changePercent24Hr.ToString());
                            lista.Add(objetoDTO);
                        }
                    }

                }
                catch (WebException ex)
                {
                    WebResponse mErrorResponse = ex.Response;
                    using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                    {
                        StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                        String mErrorText = mReader.ReadToEnd();
                        Login.log.Error("Errpr: {0} "+mErrorResponse);
                        throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
                    }
                }
                catch (Exception ex)
                {
                    Login.log.Error("Errpr: {0} " + ex.Message);
                    throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
                }
            }
            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                return null;
            }
        }
        /// --------//
        public List<CryptoDTO> GetAllCrytosDTO(dynamic responseAssets)
        {
            var lista = new List<CryptoDTO>();
            //var conexionAllCryptos = new JSONApiResponse();
            //try
            {
                //conexionAllCryptos.GetAPIResponseItem(assetsUrl);
                //var responseAssets = conexionAllCryptos.data;
                foreach (var bResponseItem in responseAssets)
                {
                    var objetoDTO = new CryptoDTO(bResponseItem.id.ToString(), bResponseItem.name.ToString(), bResponseItem.rank.ToString(), bResponseItem.priceUsd.ToString(), bResponseItem.symbol.ToString(), bResponseItem.changePercent24Hr.ToString());
                    lista.Add(objetoDTO);
                }

            }
            /*catch (WebException ex)
            {
                WebResponse mErrorResponse = ex.Response;
                using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                {
                    StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                    String mErrorText = mReader.ReadToEnd();
                    Login.log.Error("Errpr: {0} " + mErrorText);
                    throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
                }
            }
            catch (Exception ex)
            {
                Login.log.Error("Errpr: {0} " + ex.Message);
                throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
            }
            */
            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                return null;
            }

        }
        public List<HistoryItem> Get6MonthHistoryFrom(string cryptoID)
        {
            var historial = new List<HistoryItem>();
            var localnow = DateTime.Now;
            var sixMonthsBack = ((DateTimeOffset)(localnow.AddMonths(-6).ToUniversalTime())).ToUnixTimeMilliseconds();
            string historyUrl = String.Format(history, cryptoID);
            var conexionHistory = new JSONApiResponse();
            try
            {
                conexionHistory.GetAPIResponseItem(historyUrl);
                var responseJSON = conexionHistory.data;
                foreach (var bResponseItem in responseJSON.data)
                {
                    if ((bResponseItem.time) >= sixMonthsBack)
                    {
                        string precio = bResponseItem.priceUsd;

                        long tiempo = bResponseItem.time;
                        DateTimeOffset offset = DateTimeOffset.FromUnixTimeMilliseconds(tiempo);
                        DateTime convertido = offset.UtcDateTime.ToLocalTime();
                        var elementoHistorial = new HistoryItem(precio, convertido);
                        historial.Add(elementoHistorial);
                    }
                }
            }
            catch (WebException ex)
            {
                WebResponse mErrorResponse = ex.Response;
                using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                {
                    StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                    String mErrorText = mReader.ReadToEnd();
                    Login.log.Error("Errpr: {0} " + mErrorText);
                    throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
                }
            }
            catch (Exception ex)
            {
                Login.log.Error("Errpr: {0} " + ex.Message);
                throw new ExcepcionesApi("Error de conexión con el servicio, intente mas tarde");
            }
            if (historial.Count > 0)
            {
                return historial;
            }
            else
            {
                return null;
            }
        }

    }
}
