using Checkout.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Shared.Representers
{
    public class TransactionRepresenter
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public CardDetails Card { get; set; }
        public string MerchantID { get; set; }
        public string Bank { get; set; }
    }
}