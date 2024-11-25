using System;
using System.Collections.Generic;

namespace GroupProject_Wookie_Warriors
{
    public class Login 
    {
        // För huvudmenyn
        public void Main1()
        {
            if (LoginUser())
            {
                // Hit kommer du när du har loggat in korrekt
                ShowMenu();
            }
            else
            {
                Console.WriteLine("För många misslyckade försök. Programmet avslutas.");
                Console.ReadKey();
            }
        }

        public bool LoginUser() 
        {
            var users = new Dictionary<string, string>
        {
            { "Filip", "123" },
            { "Leon", "1234" },
            { "Simon", "12345" },
            { "Tim", "123456" },
            { "Shokran", "1234567" }
        };

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


                if (users.TryGetValue(username, out string correctPassword) && correctPassword == password)
                {
                    Console.Clear();
                    Console.WriteLine($"Välkommen, {username}!");
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

        // Detta är menyn för när du har loggat in
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Huvudmeny ====");
                Console.WriteLine("1. Visa saldo");
                Console.WriteLine("2. Gör en insättning");
                Console.WriteLine("3. Gör ett uttag");
                Console.WriteLine("4. Logga ut");
                Console.Write("Välj ett alternativ: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Ditt saldo är: 10,000 SEK");
                        break;
                    case "2":
                        Console.WriteLine("Insättning gjord.");
                        break;
                    case "3":
                        Console.WriteLine("Uttag gjort.");
                        break;
                    case "4":
                        Console.WriteLine("Du har loggat ut.");
                        return;  
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }
    }
}
