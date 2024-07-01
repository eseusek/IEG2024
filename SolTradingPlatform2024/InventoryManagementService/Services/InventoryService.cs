using InventoryManagementService.Models;

namespace InventoryManagementService.Services
{
    public class InventoryService
    {
        private readonly Dictionary<int, InventoryItem> _inventory = new();

        public void UpdateInventory(int productId, int quantity)
        {
            if (_inventory.ContainsKey(productId))
            {
                _inventory[productId].Quantity = quantity;
            }
            else
            {
                _inventory.Add(productId, new InventoryItem { ProductId = productId, Quantity = quantity });
            }
        }

        public InventoryItem GetInventoryByProduct(int productId)
        {
            if (_inventory.TryGetValue(productId, out var inventoryItem))
            {
                return inventoryItem;
            }

            return null;
        }
    }

}
