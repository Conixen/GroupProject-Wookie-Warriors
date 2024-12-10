using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class Admin : User
    {
        private List<string> Permissions {  get; set; }

        public Admin(string username, string password, int id) :base(username, password, id)
        {
            UserName = username;
            Password = password;
            Id = id;
            
        }

        //public void ChnageCurrecy(Dictionary<string, decimal> newRates, string currencyType) 
        //{
        //    if (currencyType == "SEK")
        //    {
        //        exchangeRates.ExchangeRateToSek = newRates;
        //    }
        //    else if (currencyType == "EUR") 
        //    {
        //        exchangeRates.ExchangeRateToEuro = newRates;
        //    }
        //    else if (currencyType == "USD")
        //    { 
        //        exchangeRates.ExchangeRateToUsd = newRates;
        //    }
        //}

        //public decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        //{
        //    decimal rate = 0m;

        //    if (fromCurrency == "SEK")
        //    {
        //        if (toCurrency == "EUR")
        //            rate = exchangeRates.ExchangeRateToEuro["SEK"];
        //        else if (toCurrency == "USD")
        //            rate = exchangeRates.ExchangeRateToUsd["SEK"];
        //        else
        //            rate = 1m; // SEK to SEK

        //    }
        //    else if (fromCurrency == "EUR")
        //    {
        //        if (toCurrency == "SEK")
        //            rate = 1 / exchangeRates.ExchangeRateToEuro["SEK"];
        //        else if (toCurrency == "USD")
        //            rate = exchangeRates.ExchangeRateToUsd["EUR"];
        //        else
        //            rate = 1m; // EUR to EUR
        //    }
        //    // Om från valutan är USD
        //    else if (fromCurrency == "USD")
        //    {
        //        if (toCurrency == "SEK")
        //            rate = 1 / exchangeRates.ExchangeRateToUsd["SEK"];
        //        else if (toCurrency == "EUR")
        //            rate = 1 / exchangeRates.ExchangeRateToUsd["EUR"];
        //        else
        //            rate = 1m; // USD to USD
        //    }
        //    return amount * rate;

        //}
        //public User CreateUser(string username, string password, int id)
        //{
        //    if (!HasPermission("Create User"))
        //    {
        //        Console.WriteLine($"{UserName} does not have persmission to create users.");
        //        return null;
        //    }

        //    User newUser = new User(username, password, id);
        //    Console.WriteLine($"User {username} created successfully by {UserName}");
        //    return newUser;
        //}

        //public bool HasPermission(string permission)
        //{
        //    return Permissions.Contains(permission);
        //}
    }
}
