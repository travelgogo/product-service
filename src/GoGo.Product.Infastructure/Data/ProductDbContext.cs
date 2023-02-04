using Microsoft.EntityFrameworkCore;
using GoGo.Product.Domain.Entities;

namespace GoGo.Product.Infastructure.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tour>().Property(x => x.ChildrenFrom2To5Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Tour>().Property(x => x.ChildrenFrom5To11Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Tour>().Property(x => x.ChildrenUnder2Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Tour>().Property(x => x.AdultPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Tour>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Tour>().Property(x => x.PromotionPrice).HasColumnType("decimal(18,2)");


            modelBuilder.Entity<TourBooking>().Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<TourRequest>().Property(x => x.BudgetPerPerson).HasColumnType("decimal(18,2)");
        }

        public DbSet<Tour>? Tours { get; set; }

        public DbSet<TourBooking>? TourBookings { get; set; }

        public DbSet<TourStartDate>? TourStartDates { get; set; }

        public DbSet<TourRating>? TourRatings { get; set; }

        public DbSet<TourRequest>? TourRequests { get; set; }

    }
}