using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class AssContext : DbContext
{
    public AssContext()
    {
    }

    public AssContext(DbContextOptions<AssContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source =DESKTOP-EGKD5AF; database=ass;integrated security=true; trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Bookid);

            entity.ToTable("bookings");

            entity.HasIndex(e => e.CategoryId, "IX_bookings_categoryId");

            entity.Property(e => e.Bookid).HasColumnName("bookid");
            entity.Property(e => e.Bookname).HasColumnName("bookname");
            entity.Property(e => e.Bookprice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("bookprice");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");

            entity.HasOne(d => d.Category).WithMany(p => p.Bookings).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CategoryName).HasColumnName("categoryName");
        });

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
