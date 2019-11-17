using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using System.Linq;

namespace Checkout.UnitTests.Fakes
{
    public class CardDetailsServiceFake : BaseFake, ICardDetailsService
    {
        public void AddCard(CardDetails card)
        {
            var _cardDetails = new CardDetails { CardDetailsID = 4, CardNumber = "2223 0000 1047 9399", Cvv = "299", HolderName = "ADDTEST", ExpiryMonth = "11", ExpiryYear = "21" };
            CardDetails.Add(_cardDetails);
        }

        public CardDetails GetCardDetailsByID(int cardID)
        {
            return CardDetails.Where(cd => cd.CardDetailsID == cardID).FirstOrDefault();
        }

        public CardDetails GetCardDetailsByNumber(string cardNumber)
        {
            return CardDetails.Where(cd => cd.CardNumber == cardNumber).FirstOrDefault();
        }
    }
}