using Checkout.Data.Model;
using System;
using System.Collections.Generic;

namespace Checkout.UnitTests.Fakes
{
    public class BaseFake
    {
        #region Properties 

        public List<Currency> Currencies = new List<Currency>();
        public List<Merchant> Merchants = new List<Merchant>();
        public List<Transaction> Transactions = new List<Transaction>();
        public List<CardDetails> CardDetails = new List<CardDetails>();

        #endregion

        public BaseFake()
        {
            GenerateFakeCurrencies();
            GenrateFakeMerchants();
            GenerateFakeCardDetails();
            GenerateFakeTransactions();
        }

        private void GenerateFakeCurrencies()
        {
            var _currency1 = new Currency { CurrencyId = 1, Name = "ZAR" };
            var _currency2 = new Currency { CurrencyId = 2,  Name = "USD" };
            var _currency3 = new Currency { CurrencyId = 3, Name = "GBP" };

            Currencies.Add(_currency1);
            Currencies.Add(_currency2);
            Currencies.Add(_currency3);
        }

        private void GenrateFakeMerchants()
        {
            var _merchant1 = new Merchant { MerchantID = Guid.Parse("1D620903-D485-4421-958F-8265C0B41844"), Name = "Test Merchant 1", Active = true, Description = "Testing Description 1" };
            var _merchant2 = new Merchant { MerchantID = Guid.Parse("311BFB23-11F9-44DA-B3F9-EF53DA3E6753"), Name = "Test Merchant 2", Active = true, Description = "Testing Description 2" };
            var _merchant3 = new Merchant { MerchantID = Guid.Parse("5D161A26-91A4-4784-8DEF-FAF0A3F9E8B7"), Name = "Test Merchant 3", Active = true, Description = "Testing Description 3" };

            Merchants.Add(_merchant1);
            Merchants.Add(_merchant2);
            Merchants.Add(_merchant3);
        }

        private void GenerateFakeCardDetails()
        {
            var _cardDetails1 = new CardDetails { CardDetailsID = 1, CardNumber = "4242 4242 4242 4242", Cvv = "100", HolderName = "CHADTBONTHUYS", ExpiryMonth = "11", ExpiryYear = "21" };
            var _cardDetails2 = new CardDetails { CardDetailsID = 2, CardNumber = "4543 4740 0224 9996", Cvv = "956", HolderName = "JOESOAP", ExpiryMonth = "05", ExpiryYear = "20" };
            var _cardDetails3 = new CardDetails { CardDetailsID = 3, CardNumber = "5436 0310 3060 6378", Cvv = "257", HolderName = "TESTCHECK", ExpiryMonth = "10", ExpiryYear = "19" };

            CardDetails.Add(_cardDetails1);
            CardDetails.Add(_cardDetails2);
            CardDetails.Add(_cardDetails3);
        }

        private void GenerateFakeTransactions()
        {
            var _transaction1 = new Transaction { TransactionID = Guid.Parse("CDE77BD3-8714-47AC-A3C3-212F10FFAEB6"), Amount = 200, Card = CardDetails[0], CardID = CardDetails[0].CardDetailsID, BankReferenceID = Guid.Parse("3EC61FC4-8801-4131-8C7E-1128A2D10273"), Currency = Currencies[2], CurrencyID = Currencies[2].CurrencyId, Merchant = Merchants[0], MerchantID = Merchants[0].MerchantID, Status = "Successful", SubStatus = "Successful" };
            var _transaction2 = new Transaction { TransactionID = Guid.Parse("9256282B-4948-4DA5-AD5E-37D4FD1107E3"), Amount = 200, Card = CardDetails[1], CardID = CardDetails[1].CardDetailsID, BankReferenceID = Guid.Parse("1EDA2E89-0DB5-48D9-B736-B3C6B153AB21"), Currency = Currencies[2], CurrencyID = Currencies[2].CurrencyId, Merchant = Merchants[1], MerchantID = Merchants[1].MerchantID, Status = "Successful", SubStatus = "Successful" };
            var _transaction3 = new Transaction { TransactionID = Guid.Parse("093923AD-8FD3-4D16-8FC9-44C8F5D00AEE"), Amount = 14, Card = CardDetails[2], CardID = CardDetails[2].CardDetailsID, BankReferenceID = Guid.Parse("C9A9E2A2-C567-4600-A922-51729AE4FBA9"), Currency = Currencies[0], CurrencyID = Currencies[0].CurrencyId, Merchant = Merchants[0], MerchantID = Merchants[0].MerchantID, Status = "Failed", SubStatus = "Invalid card number"};

            Transactions.Add(_transaction1);
            Transactions.Add(_transaction2);
            Transactions.Add(_transaction3);
        }
    }
}