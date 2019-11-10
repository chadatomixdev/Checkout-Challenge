using System.ComponentModel.DataAnnotations;

namespace Checkout.Data.Model
{
    public class CardDetails
    {
        [Key]
        public int CardDetailsID { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string HolderName { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
    }
}