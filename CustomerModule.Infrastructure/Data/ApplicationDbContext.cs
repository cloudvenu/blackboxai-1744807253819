using Microsoft.EntityFrameworkCore;
using CustomerModule.Core.Entities;

namespace CustomerModule.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.CompanyName).HasMaxLength(100);
                entity.Property(e => e.CreditLimit).HasPrecision(18, 2);
                
                entity.OwnsOne(e => e.BillingAddress, address =>
                {
                    address.Property(a => a.Street).HasMaxLength(100);
                    address.Property(a => a.City).HasMaxLength(50);
                    address.Property(a => a.State).HasMaxLength(50);
                    address.Property(a => a.PostalCode).HasMaxLength(20);
                    address.Property(a => a.Country).HasMaxLength(50);
                });

                entity.OwnsOne(e => e.ShippingAddress, address =>
                {
                    address.Property(a => a.Street).HasMaxLength(100);
                    address.Property(a => a.City).HasMaxLength(50);
                    address.Property(a => a.State).HasMaxLength(50);
                    address.Property(a => a.PostalCode).HasMaxLength(20);
                    address.Property(a => a.Country).HasMaxLength(50);
                });
            });
        }
    }
}
