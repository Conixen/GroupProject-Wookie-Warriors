using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class ConvertCurrency : Login
    {
        
        private ExchangeRates exchangeRates;
        public ConvertCurrency() 
        { 
            exchangeRates = new ExchangeRates();
        }
        public void ChangeCurrency()
        {
            Console.WriteLine("Choose currency type to update (SEK, EUR, USD):");
            string currencyType = Console.ReadLine().ToUpper();

            if (currencyType != "SEK" && currencyType != "EUR" && currencyType != "USD")
            {
                Console.WriteLine("Invalid currency type. Returning to menu...");
                return;
            }

            var newRates = new Dictionary<string, decimal>();

            Console.WriteLine($"Enter exchange rate for {currencyType} to SEK:");
            newRates["SEK"] = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine($"Enter exchange rate for {currencyType} to EUR:");
            newRates["EUR"] = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine($"Enter exchange rate for {currencyType} to USD:");
            newRates["USD"] = Convert.ToDecimal(Console.ReadLine());

            if (currencyType == "SEK")
            {
                exchangeRates.ExchangeRateToSek = newRates;
            }
            else if (currencyType == "EUR")
            {
                exchangeRates.ExchangeRateToEuro = newRates;
            }
            else if (currencyType == "USD")
            {
                exchangeRates.ExchangeRateToUsd = newRates;
            }

            Console.WriteLine("Exchange rates updated successfully!");
 
        }

        public decimal ConvertToCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            decimal rate = 1m;

            if (fromCurrency == "SEK")
            {
                if (toCurrency == "EUR") rate = exchangeRates.ExchangeRateToEuro["SEK"];
                else if (toCurrency == "USD") rate = exchangeRates.ExchangeRateToUsd["SEK"];
            }
            else if (fromCurrency == "EUR")
            {
                if (toCurrency == "SEK") rate = 1 / exchangeRates.ExchangeRateToEuro["SEK"];
                else if (toCurrency == "USD") rate = exchangeRates.ExchangeRateToUsd["EUR"];
            }
            else if (fromCurrency == "USD")
            {
                if (toCurrency == "SEK") rate = 1 / exchangeRates.ExchangeRateToUsd["SEK"];
                else if (toCurrency == "EUR") rate = 1 / exchangeRates.ExchangeRateToUsd["EUR"];
            }

            return amount * rate;
        }
    }
}
