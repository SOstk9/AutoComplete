using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AutoComplete.Models;

public partial class MoviesContext : DbContext
{
    public MoviesContext()
    {
    }

    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Besetzung> Besetzungs { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=.\\SQLEXPRESS;Database=Movies;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Besetzung>(entity =>
        {
            entity.HasKey(e => new { e.Filmid, e.Persid }).HasName("PK__Besetzun__245AF40E844B04AF");

            entity.ToTable("Besetzung");

            entity.HasIndex(e => e.Filmid, "Besetzung_bes");

            entity.HasIndex(e => e.Ord, "Besetzung_ord");

            entity.HasIndex(e => e.Persid, "Besetzung_pers");

            entity.Property(e => e.Filmid).HasColumnName("filmid");
            entity.Property(e => e.Persid).HasColumnName("persid");
            entity.Property(e => e.Ord).HasColumnName("ord");

            entity.HasOne(d => d.Film).WithMany(p => p.Besetzungs)
                .HasForeignKey(d => d.Filmid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Besetzung__filmi__3C69FB99");

            entity.HasOne(d => d.Pers).WithMany(p => p.Besetzungs)
                .HasForeignKey(d => d.Persid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Besetzung__persi__3D5E1FD2");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Film__3213E83F19B2DE35");

            entity.ToTable("Film");

            entity.HasIndex(e => e.Titel, "Film_titel");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Jahr)
                .HasColumnType("decimal(4, 0)")
                .HasColumnName("jahr");
            entity.Property(e => e.Punkte).HasColumnName("punkte");
            entity.Property(e => e.Regie).HasColumnName("regie");
            entity.Property(e => e.Stimmen).HasColumnName("stimmen");
            entity.Property(e => e.Titel)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("titel");

            entity.HasOne(d => d.RegieNavigation).WithMany(p => p.Films)
                .HasForeignKey(d => d.Regie)
                .HasConstraintName("FK__Film__regie__398D8EEE");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3213E83FF60B216E");

            entity.ToTable("Person");

            entity.HasIndex(e => e.Name, "pers_name");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
