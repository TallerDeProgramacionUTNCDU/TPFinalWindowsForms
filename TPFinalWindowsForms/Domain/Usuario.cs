using System;
using System.Collections.Generic;
using TPFinalWindowsForms.DAL.EntityFramework;

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

    public bool SesionActiva { get; set; }

    public Usuario(string nickname, string nombre, string apellido, string contraseña, string email, string favcriptos, double umbral, bool sesionActiva)
    {
        Nickname=nickname;
        Nombre=nombre;
        Apellido=apellido;
        Contraseña=contraseña;
        Email=email;
        Favcriptos=favcriptos;
        Umbral=umbral;
        SesionActiva=sesionActiva;
    }

    public bool ExisteCripto(string cripto)
    {
        string[] arrayCryptos = Favcriptos.Split(' ');
        bool existe = false;
        int i = 0;
        foreach (var crypto in arrayCryptos)
        {
            if (crypto == cripto)
            {
                existe = true;
                break;
            }
            i++;
        }
        return existe;
    }

}
