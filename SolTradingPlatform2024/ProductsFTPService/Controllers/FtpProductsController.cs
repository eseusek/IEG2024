using ProductsFTPService.Models;
using ProductsFTPService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProductsFTPService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtpProductsController : ControllerBase
    {
        private readonly FtpProductService _productService;

        public FtpProductsController()
        {
            _productService = new FtpProductService();
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }
    }
}
