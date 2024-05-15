using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BibliotecaApi.Models
{
    public partial class bibliotecaContext : DbContext
    {
        public bibliotecaContext()
        {
        }

        public bibliotecaContext(DbContextOptions<bibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Carrera> Carreras { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-7IMQ128\\SQLEXPRESS;Database=biblioteca;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.AreId)
                    .HasName("PK__area__025514AD8CE3392F");

                entity.ToTable("area");

                entity.Property(e => e.AreId).HasColumnName("are_id");

                entity.Property(e => e.AreNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("are_nombre");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__carrera__4C9A0DB330999872");

                entity.ToTable("carrera");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CarNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("car_nombre");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.EstId)
                    .HasName("PK__estudian__40AA9098344B08BF");

                entity.ToTable("estudiante");

                entity.Property(e => e.EstId)
                    .ValueGeneratedNever()
                    .HasColumnName("est_id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.EstApellido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("est_apellido");

                entity.Property(e => e.EstFecha)
                    .HasColumnType("date")
                    .HasColumnName("est_fecha");

                entity.Property(e => e.EstNombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("est_nombre");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__estudiant__car_i__4D94879B");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.LibId)
                    .HasName("PK__libro__334638FE60F71133");

                entity.ToTable("libro");

                entity.Property(e => e.LibId)
                    .ValueGeneratedNever()
                    .HasColumnName("lib_id");

                entity.Property(e => e.AreId).HasColumnName("are_id");

                entity.Property(e => e.LibNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lib_nombre");

                entity.HasOne(d => d.Are)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.AreId)
                    .HasConstraintName("FK__libro__are_id__5629CD9C");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.PreId)
                    .HasName("PK__prestamo__E0CCC60D29709152");

                entity.ToTable("prestamo");

                entity.Property(e => e.PreId).HasColumnName("pre_id");

                entity.Property(e => e.EstId).HasColumnName("est_id");

                entity.Property(e => e.LibId).HasColumnName("lib_id");

                entity.Property(e => e.PreFecha)
                    .HasColumnType("date")
                    .HasColumnName("pre_fecha");

                entity.HasOne(d => d.Est)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.EstId)
                    .HasConstraintName("FK__prestamo__est_id__59063A47");

                entity.HasOne(d => d.Lib)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.LibId)
                    .HasConstraintName("FK__prestamo__lib_id__59FA5E80");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
