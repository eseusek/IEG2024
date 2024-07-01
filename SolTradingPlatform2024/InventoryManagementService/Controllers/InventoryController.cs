using InventoryManagementService.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateInventory(int productId, int quantity)
        {
            _inventoryService.UpdateInventory(productId, quantity);
            return Ok();
        }

        [HttpGet("{productId}")]
        public IActionResult GetInventoryByProduct(int productId)
        {
            var inventory = _inventoryService.GetInventoryByProduct(productId);
            return Ok(inventory);
        }
    }

}
