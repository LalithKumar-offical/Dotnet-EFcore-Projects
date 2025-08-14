using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Models;

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

   
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-EGKD5AF;database=ass;integrated security = true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__booking__5DE3A5B1768671E2");

            entity.ToTable("booking");

            entity.Property(e => e.BookingId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("booking_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BookingDate).HasColumnName("booking_date");
            entity.Property(e => e.FlightId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("flight_id");
        });
  OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
