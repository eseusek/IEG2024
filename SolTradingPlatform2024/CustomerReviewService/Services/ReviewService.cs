using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerReviewService.Models;

namespace CustomerReviewService.Services
{
    public class ReviewService
    {
        private readonly InventoryServiceClient _inventoryServiceClient;
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(InventoryServiceClient inventoryServiceClient, IReviewRepository reviewRepository)
        {
            _inventoryServiceClient = inventoryServiceClient;
            _reviewRepository = reviewRepository;
        }

        public async Task<ReviewDetailsWithInventory> GetReviewDetailsWithInventory(int productId)
        {
            var inventoryItem = await _inventoryServiceClient.GetInventoryItem(productId);
            var reviews = await _reviewRepository.GetReviewsByProductId(productId);

            return new ReviewDetailsWithInventory
            {
                ProductId = productId,
                Quantity = inventoryItem.Quantity,
                Reviews = reviews
            };
        }

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return await _reviewRepository.GetAllReviews();
        }

        public async Task<IEnumerable<Review>> GetReviewsByProduct(int productId)
        {
            return await _reviewRepository.GetReviewsByProductId(productId);
        }

        public async Task AddReview(Review review)
        {
            await _reviewRepository.AddReview(review);
        }
    }
}