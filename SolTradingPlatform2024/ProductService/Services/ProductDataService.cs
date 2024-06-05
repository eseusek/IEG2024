using ProductService.Models;

namespace ProductService.DataStore
{
    public class ProductDataService
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "BlackBerry", Price = 100.0m },
            new Product { Id = 2, Name = "Windows Phone", Price = 300.0m },
            new Product { Id = 3, Name = "iPhone", Price = 900.0m }
        };

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}
