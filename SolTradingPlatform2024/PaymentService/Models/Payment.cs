namespace PaymentService.Models
{
    public class Payment
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public decimal Amount { get; set; }
    }
}
