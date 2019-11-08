using Checkout.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Representers
{
    public class TransactionRepresenter
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }

        public CardDetails Card { get;set; }

    }
}