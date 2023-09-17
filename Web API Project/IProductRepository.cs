using WebApiServiceRepositorySecurityDatabase.Models;

namespace WebApiServiceRepositorySecurityDatabase.Repositories
{
    public interface IProductRepository
    {
        public void Create(Product obj);
        public void Edit(int id);
        public List<Product> Details();
        public Product DetailsById(int id);
        public void Delete(int id);
    }
}
