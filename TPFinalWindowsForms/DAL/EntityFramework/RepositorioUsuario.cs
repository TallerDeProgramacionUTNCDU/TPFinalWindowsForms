using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinalWindowsForms.Domain;
using TPFinalWindowsForms.DAL;
using TPFinalWindowsForms.Api.Exceptions;
using TPFinalWindowsForms.Visual;

namespace TPFinalWindowsForms.DAL.EntityFramework
{
    public class RepositorioUsuario : Repositorio<DBContext, Usuario>, IRepositorioUsuario

    {
        public RepositorioUsuario(DBContext pDbContext) : base(pDbContext)
        {

        }
        public Usuario GetUsuarioActual()
        {

            var arrayUsuarios =  iDbContext.Set<Usuario>();
            Usuario usuarioActual = null;
            foreach (var usuario in arrayUsuarios)
            {
                if (usuario.SesionActiva)
                {
                    usuarioActual = usuario;
                }
            }
            if (usuarioActual == null)
            {
                MessageBox.Show("El usuario no está logueado");
                Login.log.Error("El usuario no se pudo encontrar porque no está logueado");
                throw new ExcepcionesApi("El usuario no se pudo encontrar porque no está logueado");
            }
            else
            {
                return usuarioActual;
            }

        }

    }
}
