using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Concert> Concerts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ConcertSpec> ConcertSpecs { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<HallBooking> HallBookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concert>()
                .HasOne(c => c.ConcertSpecs)
                .WithOne(cs => cs.Concert)
                .HasForeignKey<ConcertSpec>(cs => cs.ConcertId);
            modelBuilder.Entity<Concert>()
                .HasOne(c => c.Creator)
                .WithMany(u => u.Concerts)
                .HasForeignKey(c => c.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Concert>()
                .Property(c => c.ConcertId)
                .UseIdentityByDefaultColumn()
                .HasIdentityOptions(startValue: 100);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Concert)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.ConcertId);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Audience)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);
            modelBuilder.Entity<User>()
                .HasIndex(u=>u.Email)
                .IsUnique();
            modelBuilder.Entity<Hall>()
                .HasMany(h => h.Bookings)
                .WithOne(hb => hb.Hall)
                .HasForeignKey(h => h.HallId);
            modelBuilder.Entity<Concert>()
                .HasMany(c => c.HallBookings)
                .WithOne(hb=>hb.Concert)
                .HasForeignKey(hb=>hb.ConcertId);
            modelBuilder.Entity<Hall>()
                .HasOne(h => h.HallOwner)
                .WithMany(u => u.Halls)
                .HasForeignKey(h=> h.hallOwnerId);
            modelBuilder.Entity<HallBooking>()
                .HasOne(hb => hb.User)
                .WithMany(u => u.HallBookings)
                .HasForeignKey(hb => hb.UserId);
        }   
    }

}
