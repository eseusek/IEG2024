using MeiShop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductListController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var localProducts = await GetProductsFromService("https://localhost:7172/api/products");
            //var ftpProducts = await GetProductsFromService("https://localhost:7167/api/ftpProducts");

            var allProducts = new List<Product>();
            allProducts.AddRange(localProducts);
            //allProducts.AddRange(ftpProducts);

            return allProducts;
        }

        private async Task<IEnumerable<Product>> GetProductsFromService(string url)
        {
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Product>>(response);
        }
    }
}
