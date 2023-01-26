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
    public class DataCriptoAPI : IDataCriptoAPI
    {
        public List<CryptoDTO> GetFavCryptosDTO(List<String> pLista, dynamic responseFav)
        {
            var lista = new List<CryptoDTO>();
            foreach (var elemento in pLista)
            {
                    foreach (var bResponseItem in responseFav.data)
                    {
                        if (elemento == bResponseItem.id.ToString())
                        {
                            var objetoDTO = new CryptoDTO(bResponseItem.id.ToString(), bResponseItem.name.ToString(), bResponseItem.rank.ToString(), bResponseItem.priceUsd.ToString(), bResponseItem.symbol.ToString(), bResponseItem.changePercent24Hr.ToString());
                            lista.Add(objetoDTO);
                        }
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
        public List<CryptoDTO> GetAllCrytosDTO(dynamic responseAssets)
        {
            var lista = new List<CryptoDTO>();
                foreach (var bResponseItem in responseAssets.data)
                {
                    var objetoDTO = new CryptoDTO(bResponseItem.id.ToString(), bResponseItem.name.ToString(), bResponseItem.rank.ToString(), bResponseItem.priceUsd.ToString(), bResponseItem.symbol.ToString(), bResponseItem.changePercent24Hr.ToString());
                    lista.Add(objetoDTO);
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
        public List<HistoryItem> Get6MonthHistoryFrom(dynamic conexionHistory)
        {
            var historial = new List<HistoryItem>();
            var localnow = DateTime.Now;
            var sixMonthsBack = ((DateTimeOffset)(localnow.AddMonths(-6).ToUniversalTime())).ToUnixTimeMilliseconds();

                foreach (var bResponseItem in conexionHistory.data)
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
