﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinalWindowsForms.Api.Exceptions
{
    internal class ExcepcionesApi : ApplicationException
    {
        public ExcepcionesApi(string mensaje) : base(mensaje)
        {

        }
    }

}
