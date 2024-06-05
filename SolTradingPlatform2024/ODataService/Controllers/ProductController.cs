namespace ODataService.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using ODataService.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Query;
    using Microsoft.AspNetCore.OData.Routing.Controllers;

    public class ProductController : ODataController
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "BlackBerry", Price = 100.0m },
            new Product { Id = 2, Name = "Windows Phone", Price = 300.0m },
            new Product { Id = 3, Name = "iPhone", Price = 900.0m }
        };

        [EnableQuery]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(products);
        }

        [EnableQuery]
        public ActionResult<Product> Get([FromRoute] int key)
        {
            var item = products.SingleOrDefault(d => d.Id.Equals(key));

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}
