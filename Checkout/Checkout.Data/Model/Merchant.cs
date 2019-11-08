using System;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Data.Model
{
    public class Merchant
    {
        [Key]
        public Guid MerchantID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}