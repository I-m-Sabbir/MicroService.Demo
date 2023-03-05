using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Storage.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Product One", Description = "Description of product one", Price = 1200.20m },
            new Product { Id = 2, Name = "Product Two", Description = "Description of product Two", Price = 200.00m },
            new Product { Id = 3, Name = "Product Three", Description = "Description of product Three", Price = 2000.00m },
            new Product { Id = 4, Name = "Product Four", Description = "Description of product Four", Price = 1000.50m },
        };

        public ProductController()
        {

        }

        [HttpGet]
        public async Task<List<Product>?> Get() => await Task.Run(() => products.Any() ? products : null);

        [HttpGet("{id}")]
        public async Task<List<Product>?> Get(int id)
            => await Task.Run(()
                => products.Where(x => x.Id == id).Any() ? products.Where(x => x.Id == id).ToList() : null
            );

    }
}
