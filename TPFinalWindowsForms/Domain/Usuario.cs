using System;
using System.Collections.Generic;

namespace TPFinalWindowsForms.Domain;

public partial class Usuario
{
    /// <summary>
    /// Nickname de usuario
    /// </summary>
    public string Nickname { get; set; } = null!;

    /// <summary>
    /// Nombre del usuario
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Apellido del usuario
    /// </summary>
    public string Apellido { get; set; } = null!;

    /// <summary>
    /// Contraseña de usuario
    /// </summary>
    public string Contraseña { get; set; } = null!;

    /// <summary>
    /// Correo del usuario
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Criptomonedas favoritas del usuario
    /// </summary>
    public string Favcriptos { get; set; }

    public double Umbral { get; set; }

}
