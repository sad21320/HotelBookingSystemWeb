using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystemWeb.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AdditionalService> AdditionalServices { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceService> InvoiceServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка точности для всех денежных полей
            modelBuilder.Entity<RoomType>().Property(p => p.BasePrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Employee>().Property(p => p.Salary).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<AdditionalService>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Booking>().Property(p => p.TotalPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Invoice>().Property(p => p.TotalAmount).HasColumnType("decimal(18,2)");

            // Настройка связи для InvoiceService (чтобы EF понял внешний ключ ServiceID)
            modelBuilder.Entity<InvoiceService>()
                .HasOne(isv => isv.AdditionalService)
                .WithMany(s => s.InvoiceServices)
                .HasForeignKey(isv => isv.ServiceID);

            base.OnModelCreating(modelBuilder);
        }
    }
}