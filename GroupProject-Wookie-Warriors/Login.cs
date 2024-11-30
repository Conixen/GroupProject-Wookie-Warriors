using System;
using System.Collections.Generic;

namespace GroupProject_Wookie_Warriors
{
    public class Login 
    {
        // User login 
        public Dictionary<string, User> users = new Dictionary<string, User>
        {
                {"Filip", new User ("Filip","123",1) },
                {"Sim", new User ("Sim","124",2) }
        };

        public bool LoginUser() 
        {
            users["Filip"].AddAccount(new Account("SavingsAccount", 100, "Sek"));
            users["Filip"].AddAccount(new Account("Hej", 100, "Sek"));
            users["Filip"].AddAccount(new Account("La", 453, "Sek"));
            users["Sim"].AddAccount(new Account("PensionAccount", 100, "Euro"));

            int failedAttempts = 0;
            const int maxAttempts = 3;

            while (failedAttempts < maxAttempts)
            {
                Console.Clear();  
                Console.WriteLine("==== Inloggningsmeny ====");
                Console.Write("Användarnamn: ");
                string username = Console.ReadLine();

                Console.Write("Lösenord: ");
                string password = Console.ReadLine();


                if (users.TryGetValue(username, out User user) && user.Password == password)
                {
                    Console.Clear();
                    Console.WriteLine($"Välkommen, {username}!");
                    var usermenu = new Startmenu();
                    usermenu.UserMenu(user); 
                    return true;  
                }
                else
                {
                    failedAttempts++;
                    Console.WriteLine($"Fel användarnamn eller lösenord. Försök kvar: {maxAttempts - failedAttempts}");
                    Console.WriteLine("Tryck på valfri tangent för att försöka igen...");
                    Console.ReadKey();
                }
            }

            return false;  
        }

        // Admin login
       
        public bool LoginAdmin()
        {
            return false; 
        }
    }
}
