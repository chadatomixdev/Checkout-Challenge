using System.ComponentModel.DataAnnotations;

namespace Checkout.Data.Model
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        public string Name { get; set; }
    }
}