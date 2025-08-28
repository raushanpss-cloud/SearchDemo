using System.Text.Json;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Searchify.Domain.Interfaces;
using Searchify.Domain.Model;

namespace Searchify.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly string _filePath = "Data/Products.json";

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
                if (products != null)
                { 
                    foreach (var item in products)
                    {
                        SaveSearch(item);
                    }
               
                }
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
                if (product != null)
                {
                    SaveSearch(product);
                }
                //await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                return product;
            }
            catch (Exception)
            {
                throw;
            }

        }

       


        public string SaveSearch(Product product)
        {
            

            try
            {
                // Read existing data
                var data = System.IO.File.Exists(_filePath)
                ? JsonSerializer.Deserialize<List<Product>>(System.IO.File.ReadAllText(_filePath)) ?? new List<Product>()
                    : new List<Product>();

                // Add new product
                data.Add(product);

                // Save updated data to file
                System.IO.File.WriteAllText(_filePath, JsonSerializer.Serialize(data));

                return "Data saved successfully.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
