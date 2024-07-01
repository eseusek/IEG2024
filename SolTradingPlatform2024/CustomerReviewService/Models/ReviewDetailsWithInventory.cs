namespace CustomerReviewService.Models
{
    public class ReviewDetailsWithInventory
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }

}
