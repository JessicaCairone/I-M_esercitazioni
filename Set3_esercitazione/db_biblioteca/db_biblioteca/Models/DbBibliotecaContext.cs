using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace db_biblioteca.Models;

public partial class DbBibliotecaContext : DbContext
{
    public DbBibliotecaContext()
    {
    }

    public DbBibliotecaContext(DbContextOptions<DbBibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libri> Libris { get; set; }

    public virtual DbSet<Prestiti> Prestitis { get; set; }

    public virtual DbSet<Utenti> Utentis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-12\\SQLEXPRESS;Database=db_biblioteca;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libri>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libri__18C65F4B5ED41BA3");

            entity.ToTable("Libri");

            entity.Property(e => e.LibroId).HasColumnName("libroID");
            entity.Property(e => e.AnnoPubblicazione).HasColumnName("anno_pubblicazione");
            entity.Property(e => e.Disponibilita).HasColumnName("disponibilità");
            entity.Property(e => e.Titolo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("titolo");
        });

        modelBuilder.Entity<Prestiti>(entity =>
        {
            entity.HasKey(e => e.PrestitoId).HasName("PK__Prestiti__7E579A75E8DE2CD5");

            entity.ToTable("Prestiti");

            entity.Property(e => e.PrestitoId).HasColumnName("prestitoID");
            entity.Property(e => e.DataPrestito).HasColumnName("data_prestito");
            entity.Property(e => e.DataRitorno).HasColumnName("data_ritorno");
            entity.Property(e => e.LibroRif).HasColumnName("libroRIF");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.LibroRifNavigation).WithMany(p => p.Prestitis)
                .HasForeignKey(d => d.LibroRif)
                .HasConstraintName("FK__Prestiti__libroR__3E52440B");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Prestitis)
                .HasForeignKey(d => d.UtenteRif)
                .HasConstraintName("FK__Prestiti__utente__3D5E1FD2");
        });

        modelBuilder.Entity<Utenti>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utenti__CA5C2253FFD2C473");

            entity.ToTable("Utenti");

            entity.HasIndex(e => e.Email, "UQ__Utenti__AB6E6164C8406A2F").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
