using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class Startmenu
    {
        public void Menu()
        {
            //Startmenu when program starts.
            var login = new Login();           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the login menu!\n" +
                "\n1. Login as customer\n" +
                "2. Login as admin\n" +
                "-------------------------");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    login.LoginUser();
                    break;

                case "2":
                    Console.Clear();
                    login.LoginAdmin();
                    break;

                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        
        // User menu
        public void UserMenu(User user)
        {
            var a = new Customer();
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
                        a.CustomerAccounts(user); 
                        break;
                    case "2":
                        Console.WriteLine("Insättning gjord.");
                        a.LoanAndInterest(user);
                        break;
                    case "3":
                        Console.WriteLine("Uttag gjort.");
                        break;
                    case "4":
                        Console.WriteLine("Du har loggat ut.");
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }
        // Admin menu 
        public void AdminMenu()
        {

        }
    }
}
