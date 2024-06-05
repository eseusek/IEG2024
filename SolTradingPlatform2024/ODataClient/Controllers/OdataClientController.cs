using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ODataService.Models;
using System;

namespace ODataClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdataClientController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var serviceRoot = "http://localhost:5139/odata/";
            var context = new Default.Container(new Uri(serviceRoot));

            return await context.Product.ExecuteAsync();            
        }
    }
}
