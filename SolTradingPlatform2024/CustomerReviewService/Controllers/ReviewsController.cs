using System.Diagnostics;
using CustomerReviewService.Models;
using CustomerReviewService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerReviewService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewsController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult GetAllReviews()
        {
            var reviews = _reviewService.GetAllReviews();
            return Ok(reviews);
        }

        [HttpGet("{productId}")]
        public IActionResult GetReviewsByProduct(int productId)
        {
            var reviews = _reviewService.GetReviewsByProduct(productId);
            return Ok(reviews);
        }

        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            _reviewService.AddReview(review);
            return Ok();
        }

        // Endpoint for fetching review details with inventory
        [HttpGet("WithInventory/{productId}")]
        public async Task<IActionResult> GetReviewDetailsWithInventory(int productId)
        {
            var details = await _reviewService.GetReviewDetailsWithInventory(productId);
            return Ok(details);
        }
    }

}
