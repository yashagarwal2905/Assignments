using Microsoft.EntityFrameworkCore;

namespace WebApiServiceRepositorySecurityDatabase.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        
    }
    public class SDbContext : DbContext
    {
        public DbSet<Product> Products { get; set;}
        public SDbContext(DbContextOptions<SDbContext> options) : base(options) { }
    }

    public class CategoryViewModel
    {
        public List<string> UniqueCategoryNames { get; set; }
    }
}
