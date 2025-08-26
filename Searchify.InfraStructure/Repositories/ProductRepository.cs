using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Searchify.Domain.Interfaces;
using Searchify.Domain.Model;

namespace Searchify.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        private List<Product> _products = new();
        public ProductRepository(AppDbContext context)
        {
            _context = context;

            _products.Add(new Product { ProductId = 1, Name = "Mobile", Price = 299 , Stock =10, Description = "Latest smartphone with high performance and camera quality.", Category ="Electronics"});
            _products.Add(new Product { ProductId = 2, Name = "Laptop", Price = 199, Stock = 15, Description = "Powerful laptop with 16GB RAM and 512GB SSD.", Category = "Electronics" });
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                var products =  _products;
                    //await _context.Products.ToListAsync();
                return products;
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
                var product = _products.FirstOrDefault(x => x.ProductId ==id);
                //await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                return product;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
