using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class User
    {
        public string UserName { get; set; } //= ("Simon");
        public string Password { get; set; }
        // public bool isAdmin { get; set; }
        public int attempts {  get; set; }
        public bool logInSecurity { get; set; }

        List<(string UserName, string Password)> users = new List<(string, string)> { 
            ("Simon", "Wakanda"), 
            ("Tim", "Ironman"), 
            ("Filip", "Superman"), 
            ("Shokran", "Batman"), 
            ("Leon", "Joker") 
        };
        List<Account> accounts = new List<Account>(){new Account("Savings", 10000, "Sek")};
       

        public User(string userName, string password) 
        { 
            UserName = userName;
            Password = password;
        }
   
        /*
         * public void LogInUser(string userName, string password, int attempts)
        {
            UserName = userName;
            Password = password;
            logInSecurity = true;
            attempts = 0;
            while (logInSecurity)
            {
                if (attempts == 3)
                {
                    Console.WriteLine("To many failed log in attempts");
                    Console.ReadLine();
                    logInSecurity = false;
                }
                else if (userName != UserName)
                {
                    Console.WriteLine("Wrong Username");
                    attempts++;
                }
                else if (password != Password)
                {
                    Console.WriteLine("Wrong password");
                    attempts++;
                }
            
            }
        }*/
        //public void LogInAdmin(string userName, string password, int attempts, bool isAdmin)
        //{
          //  UserName = userName;
            //Password = password;
            //logInSecurity = true;
            //attempts = 0;

        //}
    }
}
