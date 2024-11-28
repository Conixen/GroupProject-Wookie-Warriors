using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class Account
    {
        public string AccountType { get; set; } // Savings, Salary, Intrest accounts
        public double Balance { get; set; }     // Money in account

        // Take on later
        public string Currency { get; set; }    // ex. Sek, pund

       
        public Account(string accountType, double balance, string currency) 
        { 
            AccountType = accountType;
            Balance = balance;
            Currency = currency;
        
        }
        public override string ToString()
        {
            return $"{AccountType} {Balance} {Currency}";
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited {amount} {Currency} New balance: {Balance}");
            }
        }
    }
}
