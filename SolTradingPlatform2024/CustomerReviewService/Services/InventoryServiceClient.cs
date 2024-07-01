using System;
using System.Net.Http;
using System.Threading.Tasks;
using CustomerReviewService.Models; // Adjusted to use models within the Customer Review Service
using Microsoft.Extensions.Logging;
using System.Net.Http.Json; // Added for ReadAsAsync

namespace CustomerReviewService.Services
{
    public class InventoryServiceClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<InventoryServiceClient> _logger;

        public InventoryServiceClient(HttpClient client, ILogger<InventoryServiceClient> logger)
        {
            client.BaseAddress = new Uri("https://localhost:7262");
            _client = client;
            _logger = logger;
        }

        public async Task<InventoryItem> GetInventoryItem(int productId)
        {
            try
            {
                //var response = await _client.GetAsync($"api/inventory/{productId}");
                var response = await _client.GetAsync($"/Inventory/{productId}");
                response.EnsureSuccessStatusCode();
                var inventoryItem = await response.Content.ReadFromJsonAsync<InventoryItem>();

                if (inventoryItem == null)
                {
                    _logger.LogError("Received null inventory item for ProductId: {ProductId}", productId);
                    throw new InvalidOperationException($"Could not fetch inventory item for ProductId: {productId}");
                }

                return inventoryItem;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "Error fetching inventory item with ProductId: {ProductId}", productId);
                throw;
            }
        }
    }
}