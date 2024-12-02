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

        public User CreateUser(string username, string password, int id)
        {
            if (!HasPermission("Create User"))
            {
                Console.WriteLine($"{UserName} does not have persmission to create users.");
                return null;
            }

            User newUser = new User(username, password, id);
            Console.WriteLine($"User {username} created successfully by {UserName}");
            return newUser;
        }
        public void ChnageCurrecy() 
        { 
            
        }

        public bool HasPermission(string permission)
        {
            return Permissions.Contains(permission);
        }
        
    }
}
