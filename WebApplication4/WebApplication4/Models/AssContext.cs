using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

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

    public virtual DbSet<FlightDetail> FlightDetails { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-EGKD5AF; database=ass; integrated security=true; trustservercertificate=true;");

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

            entity.HasOne(d => d.Flight).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("FK__booking__flight___3B75D760");

            entity.HasMany(d => d.Passes).WithMany(p => p.Bookings)
                .UsingEntity<Dictionary<string, object>>(
                    "BookingDetail",
                    r => r.HasOne<Passenger>().WithMany()
                        .HasForeignKey("PassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__booking_d__pass___3F466844"),
                    l => l.HasOne<Booking>().WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__booking_d__booki__3E52440B"),
                    j =>
                    {
                        j.HasKey("BookingId", "PassId").HasName("PK__booking___331996BF46B57115");
                        j.ToTable("booking_details");
                        j.IndexerProperty<string>("BookingId")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("booking_id");
                        j.IndexerProperty<string>("PassId")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("pass_id");
                    });
        });

        modelBuilder.Entity<FlightDetail>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__flight_d__E37057657CCEA56E");

            entity.ToTable("flight_details");

            entity.Property(e => e.FlightId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("flight_id");
            entity.Property(e => e.FlightDate).HasColumnName("flight_date");
            entity.Property(e => e.FlightDestination)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("flight_destination");
            entity.Property(e => e.FlightName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("flight_name");
            entity.Property(e => e.FlightSeat).HasColumnName("flight_seat");
            entity.Property(e => e.FlightSource)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("flight_source");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.PassId).HasName("PK__passenge__EFA330E7F312DCE2");

            entity.ToTable("passengers");

            entity.Property(e => e.PassId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pass_id");
            entity.Property(e => e.Address)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.PassName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pass_name");
            entity.Property(e => e.PhoneNo).HasColumnName("phone_no");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
