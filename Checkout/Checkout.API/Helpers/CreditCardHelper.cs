using Checkout.API.Models;
using Checkout.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.API.Helpers
{
    public class CreditCardHelper
    {

        //See https://en.wikipedia.org/wiki/Luhn_algorithm
        /// <summary>
        /// Verify if the card information is valid
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="expiryDate"></param>
        /// <param name="cvv"></param>
        /// <returns></returns>
        public static bool IsCreditCardInfoValid(string cardNumber, string expiryDate, string cvv)
        {
            var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
            var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
            var yearCheck = new Regex(@"^20[0-9]{2}$");
            var cvvCheck = new Regex(@"^\d{3}$");

            //Verify that the card number is valid
            if (!cardCheck.IsMatch(cardNumber))
                return false;

            //Verify that the cvv is valid as "999"
            if (!cvvCheck.IsMatch(cvv))
                return false;

            //Verify that the date format is valid as "MM/yyyy"
            var dateParts = expiryDate.Split('/');      
            if (!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1])) 
                return false;

            var year = int.Parse(dateParts[1]);
            var month = int.Parse(dateParts[0]);
            var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month);
            var cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

            //Verify that the expiry is greater than today & within next 6 years <7, 8>>
            return (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(6));
        }

        /// <summary>
        /// Mask the card number returned to the merchant
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public static string MaskCardNumber(string cardNumber)
        {
            var firstDigits = cardNumber.Substring(0, 6);
            var lastDigits = cardNumber.Substring(cardNumber.Length - 4, 4);

            var requiredMask = new String('X', cardNumber.Length - firstDigits.Length - lastDigits.Length);

            var maskedString = string.Concat(firstDigits, requiredMask, lastDigits);
            var maskedCardNumberWithSpaces = Regex.Replace(maskedString, ".{4}", "$0 ");

            return maskedString;
        }
    }
}