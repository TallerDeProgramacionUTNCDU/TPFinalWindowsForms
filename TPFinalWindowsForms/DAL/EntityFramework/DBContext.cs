using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TPFinalWindowsForms.Domain;
namespace TPFinalWindowsForms.DAL.EntityFramework;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alerta> Alerta { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=kesavan.db.elephantsql.com;Port=5432;Database=mnseyzle;Username=mnseyzle;Password=EkX5Pe9VK0I8PH7PidcPaprUxT4Dii6x");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<Alerta>(entity =>
        {
            entity.HasKey(e => e.Fecha).HasName("alerta_pkey");

            entity.ToTable("alerta");

            entity.Property(e => e.Fecha)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.Idcripto)
                .HasMaxLength(255)
                .HasColumnName("idcripto");
            entity.Property(e => e.Idusuario)
                .HasMaxLength(255)
                .HasColumnName("idusuario");
            entity.Property(e => e.Umbralalerta).HasColumnName("umbralalerta");
        });

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
