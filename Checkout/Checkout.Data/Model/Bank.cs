using System.ComponentModel.DataAnnotations;

namespace Checkout.Data.Model
{
    public class Bank
    {
        [Key]
        public int BankID { get; set; }
        public string BankName { get; set; }
        public string BankURL { get; set; }
    }
}