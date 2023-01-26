using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinalWindowsForms.Domain;
using TPFinalWindowsForms.IO;

namespace TPFinalWindowsForms.Api
{
    public interface IDataCriptoAPI
    {
        List<CryptoDTO> GetFavCryptosDTO(List<String> pLista,dynamic responseJson);

        List<CryptoDTO> GetAllCrytosDTO(dynamic responseJson);

        List<HistoryItem> Get6MonthHistoryFrom(dynamic responseJson);
       
    }
}
