using Searchify.Domain.Interfaces;
using Searchify.Domain.Model;

namespace Searchify.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                return await _productRepository.GetAllProducts();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _productRepository.GetProductById(id);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
