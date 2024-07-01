using CustomerReviewService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerReviewService.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly List<Review> _reviews = new List<Review>();

        public Task<IEnumerable<Review>> GetReviewsByProductId(int productId)
        {
            var reviews = _reviews.Where(r => r.ProductId == productId);
            return Task.FromResult(reviews.AsEnumerable());
        }

        public Task AddReview(Review review)
        {
            _reviews.Add(review);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Review>> GetAllReviews()
        {
            return Task.FromResult(_reviews.AsEnumerable());
        }
    }
}