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

        public Admin(string username, string password, List<string> permissions)
            :base(username, password)
        {
            Permissions = permissions;
        }

        public User CreateUser(string username, string password)
        {
            if (!HasPermission("Create User"))
            {
                Console.WriteLine($"{UserName} does not have persmission to create users.");
                return null;
            }

            User newUser = new User(username, password);
            Console.WriteLine($"User {username} created successfully by {UserName}");
            return newUser;
        }

        public bool HasPermission(string permission)
        {
            return Permissions.Contains(permission);
        }
        
    }
}
