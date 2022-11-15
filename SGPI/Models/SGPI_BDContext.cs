using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SGPI.Models
{
    public partial class SGPI_BDContext : DbContext
    {
        public SGPI_BDContext()
        {
        }

        public SGPI_BDContext(DbContextOptions<SGPI_BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documento> Documentos { get; set; } = null!;
        public virtual DbSet<Entrevistum> Entrevista { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<Homologacion> Homologacions { get; set; } = null!;
        public virtual DbSet<Modulo> Modulos { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Programa> Programas { get; set; } = null!;
        public virtual DbSet<Programacion> Programacions { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<TipoHomologacion> TipoHomologacions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0R9U54R\\SQLEXPRESS;Initial Catalog=SGPI_BD;Initial Catalog=SGPI_BD;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDoc)
                    .HasName("PK__Document__0E65F8DB1F95AA8A");

                entity.ToTable("Documento");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrevistum>(entity =>
            {
                entity.HasKey(e => e.IdEntrevista)
                    .HasName("PK__Entrevis__EE6CE9C71C401AD7");

                entity.HasIndex(e => e.IdEstudiante, "IX_Entrevista")
                    .IsUnique();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Entrevista)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrevista_Usuario");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.ToTable("Estudiante");

                entity.HasIndex(e => e.IdUsuario, "IX_Estudiante")
                    .IsUnique();

                entity.HasIndex(e => e.IdPago, "IX_Estudiante_1")
                    .IsUnique();

                entity.Property(e => e.IdEstudiante).ValueGeneratedNever();

                entity.Property(e => e.Archivo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithOne(p => p.Estudiante)
                    .HasPrincipalKey<Entrevistum>(p => p.IdEstudiante)
                    .HasForeignKey<Estudiante>(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiante_Entrevista");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__0F834988F7D7E896");

                entity.ToTable("Genero");

                entity.Property(e => e.Genero1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Genero");
            });

            modelBuilder.Entity<Homologacion>(entity =>
            {
                entity.HasKey(e => e.IdHomologacion)
                    .HasName("PK__Homologa__C7746319DEF295A3");

                entity.ToTable("Homologacion");

                entity.HasIndex(e => e.IdPrograma, "IX_Homologacion")
                    .IsUnique();

                entity.Property(e => e.IdHomologacion).ValueGeneratedOnAdd();

                entity.Property(e => e.CodigoHomologacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomAsigHomologacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodoAcademico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdHomologacionNavigation)
                    .WithOne(p => p.Homologacion)
                    .HasForeignKey<Homologacion>(d => d.IdHomologacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Homologacion_Estudiante");

                entity.HasOne(d => d.IdHomologacion1)
                    .WithOne(p => p.Homologacion)
                    .HasForeignKey<Homologacion>(d => d.IdHomologacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Homologacion_TipoHomologacion");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Homologacion_Modulo");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("PK__Modulo__D9F1531536A68B46");

                entity.ToTable("Modulo");

                entity.Property(e => e.IdModulo).ValueGeneratedOnAdd();

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithOne(p => p.Modulo)
                    .HasPrincipalKey<Programacion>(p => p.IdModulo)
                    .HasForeignKey<Modulo>(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modulo_Programacion");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Modulos)
                    .HasForeignKey(d => d.IdPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modulo_Programa");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pago__FC851A3A08146745");

                entity.ToTable("Pago");

                entity.Property(e => e.IdPago).ValueGeneratedOnAdd();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdPagoNavigation)
                    .WithOne(p => p.Pago)
                    .HasPrincipalKey<Estudiante>(p => p.IdPago)
                    .HasForeignKey<Pago>(d => d.IdPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pago_Estudiante");
            });

            modelBuilder.Entity<Programa>(entity =>
            {
                entity.HasKey(e => e.IdPrograma)
                    .HasName("PK__Programa__AF94ECA5956089D2");

                entity.ToTable("Programa");

                entity.Property(e => e.Programa1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Programa");
            });

            modelBuilder.Entity<Programacion>(entity =>
            {
                entity.HasKey(e => e.IdProgramacion)
                    .HasName("PK__Programa__74E652C03E4509C2");

                entity.ToTable("Programacion");

                entity.HasIndex(e => e.IdPrograma, "IX_Programacion")
                    .IsUnique();

                entity.HasIndex(e => e.IdModulo, "IX_Programacion_1")
                    .IsUnique();

                entity.Property(e => e.FechaProgramacion).HasColumnType("datetime");

                entity.Property(e => e.PeriodoAcademico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salon)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__2A49584CBE7C627B");

                entity.ToTable("Rol");

                entity.Property(e => e.TipoRol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoHomologacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoHomologacion)
                    .HasName("PK__Programa__A45CB1084160E194");

                entity.ToTable("TipoHomologacion");

                entity.Property(e => e.TipoHomologacion1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TipoHomologacion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97DAB2CBB2");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).ValueGeneratedOnAdd();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDocNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdDoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Documento");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Genero");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPrograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Programa");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Usuario)
                    .HasPrincipalKey<Estudiante>(p => p.IdUsuario)
                    .HasForeignKey<Usuario>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Estudiante");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
