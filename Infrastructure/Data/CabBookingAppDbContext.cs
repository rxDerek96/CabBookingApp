using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CabBookingAppDbContext : DbContext
    {
        public CabBookingAppDbContext(DbContextOptions<CabBookingAppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Place>(ConfigurePlace);
            modelBuilder.Entity<CabType>(ConfigureCabType);
            modelBuilder.Entity<History>(ConfigureHistory);
            modelBuilder.Entity<Booking>(ConfigureBooking);
        }
        public DbSet<Place> Places { get; set; }
        public DbSet<CabType> CabTypes { get; set; }
        public DbSet<History> Historys { get; set; }
        public DbSet<Booking> Bookings { get; set; }





        private void ConfigurePlace(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Places");
            builder.HasKey(p => p.PlaceId);
            builder.Property(p => p.PlaceName).HasMaxLength(30);
        }
        private void ConfigureCabType(EntityTypeBuilder<CabType> builder)
        {
            builder.ToTable("CabTypes");
            builder.HasKey(c => c.CabTypeId);
            builder.Property(c => c.CabTypeName).HasMaxLength(30);
        }
        private void ConfigureBooking(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Email).HasMaxLength(50);
            builder.Property(m => m.BookingDate).HasMaxLength(128);
            builder.Property(m => m.BookingTime).HasMaxLength(5);
            builder.Property(m => m.PickUpAddress).HasMaxLength(200);
            builder.Property(m => m.Landmark).HasMaxLength(30);
            builder.Property(m => m.PickupTime).HasMaxLength(5);
            builder.Property(m => m.ContactNo).HasMaxLength(25);
            builder.Property(m => m.Status).HasMaxLength(30);
            
        }
        private void ConfigureHistory(EntityTypeBuilder<History> builder)
        {
            builder.ToTable("Bookings history");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Email).HasMaxLength(50);
            builder.Property(m => m.BookingDate).HasMaxLength(128);
            builder.Property(m => m.BookingTime).HasMaxLength(5);
            builder.Property(m => m.PickUpAddress).HasMaxLength(200);
            builder.Property(m => m.Landmark).HasMaxLength(30);
            builder.Property(m => m.PickupTime).HasMaxLength(5);
            builder.Property(m => m.ContactNo).HasMaxLength(25);
            builder.Property(m => m.Status).HasMaxLength(30);
            builder.Property(m => m.comp_time).HasMaxLength(5);
            builder.Property(m => m.Feedback).HasMaxLength(1000);

        }
    }
}
