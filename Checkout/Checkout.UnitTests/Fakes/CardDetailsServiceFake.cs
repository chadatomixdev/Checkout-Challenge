using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Checkout.UnitTests.Fakes;
using System;
using System.Linq;

namespace Checkout.UnitTests
{
    public class CardDetailsServiceFake : BaseFact, ICardDetailsService
    {
        public void AddCard(CardDetails card)
        {
            throw new NotImplementedException();
        }

        public CardDetails GetCardDetailsByID(int cardID)
        {
            throw new NotImplementedException();
        }

        public CardDetails GetCardDetailsByNumber(string cardNumber)
        {
            throw new NotImplementedException();
        }
    }
}