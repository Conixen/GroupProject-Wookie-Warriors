using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
       
        public List<double> UserLoans { get; set; }

        public List<Account> Accounts { get; set; }       
        public User(string userName, string password,int id) 
        { 
            UserName = userName;
            Password = password;
            Id = id;
            Accounts = new List<Account>();
            UserLoans = new List<double>();
        }
   
        public void AddAccount(Account account)
        {
            Accounts.Add(account); 
        }  
    }
}
