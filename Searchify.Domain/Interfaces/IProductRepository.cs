using System.Collections.Generic;
using Searchify.Domain.Model;

namespace Searchify.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);

    }
}
