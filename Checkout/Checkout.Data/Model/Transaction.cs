using System;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Data.Model
{
    public class Transaction
    {
        [Key]
        public Guid TransactionID { get; set; }
        
        [DataType("decimal(18,5)")]
        public decimal Amount { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }
        [MaxLength(100)]
        public string SubStatus { get; set; }

        public int CurrencyID { get; set; }
        public int CardID { get; set; }
        public Guid MerchantID { get; set; }
        public CardDetails Card { get; set; }
        public Guid BankReferenceID { get; set; }
        public Currency Currency { get; set; }
        public Merchant Merchant { get; set; }
    }
}