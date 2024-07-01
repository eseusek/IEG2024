using CustomerReviewService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerReviewService.Services
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsByProductId(int productId);
        Task AddReview(Review review);
        Task<IEnumerable<Review>> GetAllReviews(); // Ensure this method is declared
    }
}