using System;
namespace Checkout.API.Models
{
    public enum TransactionStatus
    {
        Error,
        Pending,
        Cancelled,
        Completed,
        ValidationError
    }
}