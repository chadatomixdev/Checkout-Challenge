using Checkout.Data.Model;
using Checkout.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Services
{
    public class CardDetailsService
    {
        private readonly RepositoryService _contextService;

        public CardDetailsService(RepositoryService contextService)
        {
            _contextService = contextService;
        }

        /// <summary>
        /// Search for existing card by card number
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public CardDetails GetCardDetailsByNumber(string cardNumber)
        {
            return _contextService.Find<CardDetails>(cd => cd.CardNumber == cardNumber).FirstOrDefault();
        }

        /// <summary>
        /// Search for existing card by card ID
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public CardDetails GetCardDetailsByID(int cardID)
        {
            return _contextService.Find<CardDetails>(cd => cd.CardDetailsID == cardID).FirstOrDefault();
        }

        /// <summary>
        /// Add a new card to the database
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(CardDetails card)
        {
            _contextService.Add(card);
        }
    }
}