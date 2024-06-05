using Microsoft.AspNetCore.Mvc;
using ProductService.DataStore;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {        
        private readonly ProductDataService _productService;

        public ProductsController()
        {
            _productService = new ProductDataService();
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }
    }
}
