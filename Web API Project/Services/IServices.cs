using WebApiServiceRepositorySecurityDatabase.Models;

namespace WebApiServiceRepositorySecurityDatabase.Services
{
    public interface IServices
    {
        public void Create(Product obj);
        public void Edit(int id);
        public List<Product> Details();
        public Product DetailsById(int id);
        public List<Product> OutOfStock();
        public List<Product> RangeDetails(int l, int r);
        public List<string> CategoryNames();
        public List<Product> DetailsByCategory(string category);
        public void Delete(int id);
    }
}
