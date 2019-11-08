namespace Checkout.Data.Models
{
    public class CardDetails
    {
        public int CardId { get; set; }
        public string Number { get; set; }
        public string Cvv { get; set; }
        public string HolderName { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerDetails Customer { get; set; }
    }
}