using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class User
    {
        //Properties for user
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
       
        public List<double> UserLoans { get; set; }

        public List<Logs> Logss { get; set; }

        public List<Account> Accounts { get; set; }       
        public User(string userName, string password,int id) //Constructor so each user have their own accounts for example
        { 
            UserName = userName;
            Password = password;
            Id = id;
            Accounts = new List<Account>();
            UserLoans = new List<double>();
            Logss = new List<Logs>();
        }

        public void AddLogs(Logs log)
        {
            Logss.Add(log);
        }
   
        public void AddAccount(Account account) //Add new accounts for user example savingsAccount
        {
            Accounts.Add(account); 
        }  
    }
}
