using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Representers
{
    public class TransactionCreationRepresenter
    {
        public Guid BankResponseID { get; set; }
        public string Status { get; set; }
        public string SubStatus { get; set; }
    }
}