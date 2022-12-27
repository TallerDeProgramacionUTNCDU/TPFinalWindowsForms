using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinalWindowsForms.Domain;
using TPFinalWindowsForms.DAL.EntityFramework.Mapping;

namespace TPFinalWindowsForms.DAL.EntityFramework
{
    public partial class UsuarioManagerDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=kesavan.db.elephantsql.com;Port=5432;Database=mnseyzle;Username=mnseyzle;Password=EkX5Pe9VK0I8PH7PidcPaprUxT4Dii6x");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
            modelBuilder
                .HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2");

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Nickname).HasName("usuario_pk");

                entity.ToTable("usuarios");

                entity.Property(e => e.Nickname)
                    .HasComment("Nickname de usuario")
                    .HasColumnType("character varying")
                    .HasColumnName("nickname");
                entity.Property(e => e.Apellido)
                    .HasComment("Apellido del usuario")
                    .HasColumnType("character varying")
                    .HasColumnName("apellido");
                entity.Property(e => e.Contraseña)
                    .HasComment("Contraseña de usuario")
                    .HasColumnType("character varying")
                    .HasColumnName("contraseña");
                entity.Property(e => e.Email)
                    .HasComment("Correo del usuario")
                    .HasColumnType("character varying")
                    .HasColumnName("email");
                entity.Property(e => e.Favcriptos)
                    .HasComment("Criptomonedas favoritas del usuario")
                    .HasColumnType("character varying")
                    .HasColumnName("favcriptos");
                entity.Property(e => e.Nombre)
                    .HasComment("Nombre del usuario")
                    .HasColumnType("character varying")
                    .HasColumnName("nombre");
                entity.Property(e => e.Umbral).HasColumnName("umbral");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
