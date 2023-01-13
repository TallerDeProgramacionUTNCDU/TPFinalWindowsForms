using System;
using System.Collections.Generic;

namespace TPFinalWindowsForms.Domain;

public partial class Alerta
{
    public string Idusuario { get; set; }

    public string Idcripto { get; set; }

    public double Umbralalerta { get; set; }

    public DateTime Fecha { get; set; }
}
