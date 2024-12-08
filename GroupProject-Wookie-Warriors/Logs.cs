using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class Logs : Account
    {
        public DateTime Date { get; set; }
        public Logs(string accountType, decimal balance, string currency) : base(accountType, balance, currency)
        {
            AccountType = accountType;
            Balance = balance;
            Currency = currency;
            Date = DateTime.Now;

        }

        public override string ToString()
        {
            return $"{AccountType} {Balance} {Currency} Date: {Date}";
        }
    }
}
