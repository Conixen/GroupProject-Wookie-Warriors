using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class Logs : Account
    {
        public Logs(string accountType, double balance, string currency) : base(accountType, balance, currency)
        {
            AccountType = accountType;
            Balance = balance;
            Currency = currency;
        }
    }
}
