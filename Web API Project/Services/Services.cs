using Microsoft.EntityFrameworkCore;
using WebApiServiceRepositorySecurityDatabase.Models;
using WebApiServiceRepositorySecurityDatabase.Repositories;

namespace WebApiServiceRepositorySecurityDatabase.Services
{
    public class Services : IServices
    {
        IProductRepository _rep;
        public Services(IProductRepository rep)
        {
            _rep = rep;
        }

        public List<string> CategoryNames()
        {
            return _rep.Details().Select(d => d.Category).Distinct().ToList();
        }

        public void Create(Product obj)
        {
            _rep.Create(obj);
        }

        public void Delete(int id)
        {
            _rep.Delete(id);

        }

        public List<Product> Details()
        {
            return _rep.Details();
        }

        public Product DetailsById(int id)
        {
            return _rep.DetailsById(id);
        }

        public List<Product> DetailsByCategory(string category)
        {
            return _rep.Details().Where(item => item.Category == category).ToList();
        }

        public void Edit(int id)
        {
            _rep.Edit(id);
        }

        public List<Product> OutOfStock()
        {
            return _rep.Details().Where(item => item.Quantity == 0).ToList();
        }

        public List<Product> RangeDetails(int l, int r)
        {
            return _rep.Details().Where(item => item.UnitPrice > l && item.UnitPrice < r).ToList();
        }
    }
}
