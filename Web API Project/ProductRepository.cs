using WebApiServiceRepositorySecurityDatabase.Models;

namespace WebApiServiceRepositorySecurityDatabase.Repositories
{
    public class ProductRepository : IProductRepository
    {
        SDbContext _context;
        public ProductRepository(SDbContext context)
        {
            _context = context;
        }
        public void Create(Product obj)
        {
            _context.Products.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product obj = _context.Products.Find(id);
            _context.Products.Remove(obj);
            _context.SaveChanges();
        }

        public List<Product> Details()
        {
            return _context.Products.ToList();
        }

        public Product DetailsById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Edit(int id)
        {
            Product obj = _context.Products.Find(id);
            _context.Products.Update(obj);
        }
    }
}
