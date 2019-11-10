using Checkout.API.Models;
using Checkout.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Helpers
{
    public class CreditCardHelper
    {
        //TODO Add Credit card validation 

        private static CardDetailsService _cardDetailsService;

        public CreditCardHelper(CardDetailsService cardDetailsService)
        {
            _cardDetailsService = cardDetailsService;
        }

        /// <summary>
        /// Verify if the card exists and if it doesnt insert the card into the db
        /// </summary>
        /// <param name="card"></param>
        public static void SaveCardDetails(CardDetails card)
        {
            if (_cardDetailsService.GetCardDetails(card.CardNumber) is null)
            {
                //TODO Add automapper to handle model mappings
                var entity = new Data.Model.CardDetails
                {
                    CardNumber = card.CardNumber,
                    Cvv = card.Cvv,
                    ExpiryMonth = card.ExpiryMonth,
                    ExpiryYear = card.ExpiryYear,
                    HolderName = card.HolderName
                };

                _cardDetailsService.AddCard(entity);
            }
        }
    }
}