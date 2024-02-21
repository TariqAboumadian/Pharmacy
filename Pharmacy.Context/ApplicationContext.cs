using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;

namespace Pharmacy.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItemMedicine>().HasKey(e =>
            
                new { e.MedicineId, e.CartItemId }
            );
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CarItems> CarItems { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItemMedicine> CartItemMedicines { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
    
}
