using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class ExchangeRates
    {
        public Dictionary<string, decimal> ExchangeRateToSek { get; set; } = new Dictionary<string, decimal>()
        {
             { "SEK", 1.0m },
             { "EUR", 11.564m },
             { "USD", 10.789m }
        };

        public Dictionary<string, decimal> ExchangeRateToEuro { get; set; } = new Dictionary<string, decimal>()
        {
             { "SEK", 0.0866m },
             { "EUR", 1.0m },
             { "USD", 0.9460m }
        };

        public Dictionary<string, decimal> ExchangeRateToUsd { get; set; } = new Dictionary<string, decimal>()
        {
             { "SEK", 0.0914m },
             { "EUR", 1.0570m },
             { "USD", 1.0m }
        };
    }
}
