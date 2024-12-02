using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GroupProject_Wookie_Warriors
{
    public class Login
    {
        // User/customer login 
        public Dictionary<string, User> users = new Dictionary<string, User>
        {
                {"Filip", new User ("Filip","123",1) },
                {"Simon", new User ("Simon","124",2) },
                {"Shokran", new User("Shokran", "321", 3) },
                {"Tim", new User("Tim", "432", 4) },
                {"Leon", new User("Leon", "543", 5) }
        };
        // Our beloved Admins and thier log ins
        public Dictionary<string, Admin> admins = new Dictionary<string, Admin>
        {
            {"Johan", new Admin("Johan", "HejaAIK", 1, new List<string> { "Create User", "Change Currency" })},
            {"Petter", new Admin("Petter", "Startrek4life", 2, new List<string> { "Create User", "Change Currency" })}
        };

        public bool LoginUser() // user/customer log in
        {   // Acoounts for the user/customer
            users["Filip"].AddAccount(new Account("SavingsAccount", 100, "Sek"));
            users["Filip"].AddAccount(new Account("Hej", 100, "Sek"));
            users["Filip"].AddAccount(new Account("La", 453, "Sek"));
            users["Simon"].AddAccount(new Account("PensionAccount", 100, "Euro"));

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
                    var usermenu = new Startmenu(); // creates a customer log in menu
                    usermenu.UserMenu(user);
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
                    var adminmenu = new Startmenu();    // create the admin menu
                    adminmenu.UserMenu(admin);
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
