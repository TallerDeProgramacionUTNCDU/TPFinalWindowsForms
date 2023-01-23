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
        List<CryptoDTO> GetFavCryptosDTO(List<String> pLista);

        List<CryptoDTO> GetAllCrytosDTO();

        List<HistoryItem> Get6MonthHistoryFrom(string cryptoID);
    }
}
