using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinalWindowsForms.ServicioMail
{
    public interface IMailService
    {
        void SendMail(string mensaje, string email);
    }

}
