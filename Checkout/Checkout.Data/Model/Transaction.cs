using System;

namespace Checkout.Data.Model
{
    public class Transaction
    {
        public Guid TransactionID { get; set; }
        public int Amount { get; set; }
        public int CurrencyID { get; set; }
        public int CardID { get; set; }
        public Guid MerchantID { get; set; }
        public CardDetails Card { get; set; }
        public Guid BankReferenceID { get; set; }
        public Currency Currency { get; set; }
        public Merchant Merchant { get; set; }
    }
}