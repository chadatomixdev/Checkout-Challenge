using Checkout.Data.Model;

namespace Checkout.Shared.Interfaces
{
    public interface ICardDetailsService
    {
        CardDetails GetCardDetailsByNumber(string cardNumber);
        CardDetails GetCardDetailsByID(int cardID);
        void AddCard(CardDetails card);
    }
}