using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class PcStoreContext : DbContext
{
    public PcStoreContext()
    {
    }

    public PcStoreContext(DbContextOptions<PcStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoría> Categorías { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=OC-PE05; Database=PcStore; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoría>(entity =>
        {
            entity.HasKey(e => e.IdCategoría).HasName("PK__Categorí__A3CC1B37563E1D35");

            entity.ToTable("Categoría");

            entity.Property(e => e.NombreCategoría)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210344C2BB0");

            entity.ToTable("Producto");

            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("money");

            entity.HasOne(d => d.IdCategoríaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoría)
                .HasConstraintName("FK__Producto__IdCate__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
