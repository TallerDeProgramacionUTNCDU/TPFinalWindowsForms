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

namespace TPFinalWindowsForms
{
    public class InteraccionApi:IInteraccionApi
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
                    var responseFav = conexionFavCryptos.GetAPIResponseItem(assetsUrl);
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
                        //System.Console.WriteLine("Error: {0}", mErrorText);
                        Application.Exit();
                    }
                }
                catch (Exception ex)
                {
                    Login.log.Error("Errpr: {0} " + ex.Message);
                    //System.Console.WriteLine("Error: {0}", ex.Message);
                    Application.Exit();
                }
            }
            return lista;
        }
        public List<CryptoDTO> GetAllCrytosDTO()
        {
            var lista = new List<CryptoDTO>();
            var conexionAllCryptos = new JSONApiResponse();
            try
            {
                var responseAssets = conexionAllCryptos.GetAPIResponseItem(assetsUrl);
                foreach (var bResponseItem in responseAssets.data)
                {
                    var objetoDTO = new CryptoDTO(bResponseItem.id.ToString(), bResponseItem.name.ToString(), bResponseItem.rank.ToString(), bResponseItem.priceUsd.ToString(), bResponseItem.symbol.ToString(), bResponseItem.changePercent24Hr.ToString());
                    lista.Add(objetoDTO);
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
                    //System.Console.WriteLine("Error: {0}", mErrorText);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                Login.log.Error("Errpr: {0} " + ex.Message);
                //System.Console.WriteLine("Error: {0}", ex.Message);
                Application.Exit();
            }
            return lista;

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
                var responseJSON = conexionHistory.GetAPIResponseItem(historyUrl);
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
                    //System.Console.WriteLine("Error: {0}", mErrorText);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                Login.log.Error("Errpr: {0} " + ex.Message);
                //System.Console.WriteLine("Error: {0}", ex.Message);
                Application.Exit();
            }
            return historial;
        }

    }
}
