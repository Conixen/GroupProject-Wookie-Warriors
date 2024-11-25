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
       

        public User(string userName, string password) 
        { 
            UserName = userName;
            Password = password;
        }
   
        
    }
}
