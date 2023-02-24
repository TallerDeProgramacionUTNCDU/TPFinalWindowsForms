using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPFinalWindowsForms.Domain;

namespace TPFinalWindowsForms.DAL.EntityFramework.Mapping
{
    class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(pUsuario => pUsuario.Nickname);

            builder.Property(pUsuario => pUsuario.Nickname).ValueGeneratedOnAdd();

            builder.Property(pUsuario => pUsuario.Contraseña).IsRequired();

            builder.Property(pUsuario => pUsuario.Nombre).IsRequired();

            builder.Property(pUsuario => pUsuario.Apellido).IsRequired();

            builder.Property(pUsuario => pUsuario.Email).IsRequired();

            builder.Property(pUsuario => pUsuario.Favcriptos);

            builder.Property(pUsuario => pUsuario.Umbral);

            builder.Property(pUsuario => pUsuario.SesionActiva);

        }
    }
}
