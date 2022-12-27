using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinalWindowsForms.IO
{
    public class AlertaCryptoDTO
    {
        private string iName;
        private string iChangePercent24hs;
        public AlertaCryptoDTO(string pName, string pChangePercent)
        {
            iName = pName;
            iChangePercent24hs = pChangePercent;
        }
        public string Name
        {
            get { return iName; }
            set { iName = value; }
        }
        public string ChangePercent24hs
        {
            get { return iChangePercent24hs; }
            set { iChangePercent24hs = value; }
        }

    }
}
