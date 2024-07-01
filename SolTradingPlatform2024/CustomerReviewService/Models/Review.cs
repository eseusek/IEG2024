namespace CustomerReviewService.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Content { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }


}
