using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TPFinalWindowsForms.Domain;

public partial class Usuario
{
    public string Nickname { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Favcriptos { get; set; }
    public double Umbral { get; set; }

}
