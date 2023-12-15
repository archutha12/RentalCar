using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RentalCar.Models;

public partial class rentalcarsContext : DbContext
{
    public rentalcarsContext()
    {
    }

    public rentalcarsContext(DbContextOptions<rentalcarsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<car> cars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ICS-LT-JG476D3\\SQLEXPRESS;Initial Catalog=rentalcars;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Adminid).HasName("PK__Admin__719EE09037903A42");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Bookingid).HasName("PK__Booking__73961EC5DD3D4709");

            entity.HasOne(d => d.CarNoNavigation).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Booking__CarNo__4316F928");

            entity.HasOne(d => d.Cust).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Booking__Custid__412EB0B6");

            entity.HasOne(d => d.Driver).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Booking__Driveri__4222D4EF");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Custid).HasName("PK__Customer__049D3E817DD1E3BC");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Driverid).HasName("PK__Driver__F1B2D17CA4F28789");
        });

        modelBuilder.Entity<car>(entity =>
        {
            entity.HasKey(e => e.CarNo).HasName("PK__car__68A00DDDF1EC04AD");
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
