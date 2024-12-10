using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace GroupProject_Wookie_Warriors
{
    public class Login
    {
        public Dictionary<string, User> users;
        public Dictionary<string, Admin> admins;

        // Load data and default users/admins. 
        public Login()
        {           
            users = DataManage.LoadData();
            DataManage.DefaultUsers(users);

            admins = DataManage.LoadAdminData();
            DataManage.AdminUsers(admins);
        }
       
        public bool LoginUser() 
        {   
            // login attempts variables 
            int failedAttempts = 0;
            const int maxAttempts = 3;

            while (failedAttempts < maxAttempts)    // Loop whit 3 attempts
            {
                Console.Clear();
                Console.WriteLine("==== Login menu - Customer ====");
                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (users.TryGetValue(username, out User user) && user.Password == password)
                {   // sucecfull log in
                    Console.Clear();
                    Console.WriteLine($"Welcome, {username}!");
                    var usermenu = new Menus(); // creates a customer log in menu
                    usermenu.UserMenu(user,users);
                    return true;
                }
                else // Wrong username or password and increse number of attempts
                {
                    failedAttempts++;
                    Console.WriteLine($"Wrong username or password! \nTries left: {maxAttempts - failedAttempts}");                  
                    Console.WriteLine("Press any key to countinue...");
                    Console.ReadKey();
                }
            }
            return false;
        }
        public bool LoginAdmin()    // admin login
        {
            // login attempts variables 
            int failedAttempts = 0;
            const int maxAttempts = 3;

            while (failedAttempts < maxAttempts) // Loop whit 3 attempts
            {
                Console.Clear();
                Console.WriteLine("==== Login Menu - Admin ====");
                Console.Write("Username: ");
                string adminUser = Console.ReadLine();

                Console.WriteLine("Password:");
                string adminPassword = Console.ReadLine();

                if (admins.TryGetValue(adminUser, out Admin admin) && admin.Password == adminPassword)
                {   // succecful login 
                    Console.Clear();
                    Console.WriteLine($"Welcome {adminUser}");
                    var adminmenu = new Menus();    // create the admin menu
                    adminmenu.AdminMenu(admin,admins);
                    return true;
                }
                else // Wrong username or password and increse number of attempts
                {
                    failedAttempts++;
                    Console.WriteLine($"Wrong username or password! \nTries left: {maxAttempts - failedAttempts}");
                    Console.WriteLine("Press any key to countinue...");
                    Console.ReadKey();
                }
            }
            return false; 
        }
    }
}
