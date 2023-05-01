using SimpleDapperExample.Entities;

namespace SimpleDapperExample.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Insert(Product product);
        void Delete(int id);
        void Update(Product product);

    }
}
