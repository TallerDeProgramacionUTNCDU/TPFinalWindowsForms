using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TPFinalWindowsForms.Domain
{
    public class HistoryItem
    {
        private string iPriceUSD;
        private DateTime iTime;

        public HistoryItem(string pPriceUSD, DateTime pTime)
        {
            iPriceUSD = pPriceUSD;
            iTime = pTime;
        }
        public string PriceUSD
        {
            get { return iPriceUSD; }
            set { iPriceUSD = value; }
        }
        public DateTime Time
        {
            get { return iTime; }
            set { iTime = value; }
        }


    }
}
