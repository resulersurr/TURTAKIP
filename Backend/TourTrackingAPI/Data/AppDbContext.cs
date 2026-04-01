using Microsoft.EntityFrameworkCore;
using TourTrackingAPI.Models;

namespace TourTrackingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourDate> TourDates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tour>()
                .HasMany(t => t.Days)
                .WithOne()
                .HasForeignKey(d => d.TourId);
        }
    }
}
