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
            var login = new Login();
            //Startmenu when program starts. 
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
                    LoginAdmin();
                    break;

                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        public void LoginAdmin()
        {

        }
        // Detta är menyn för när du har loggat in customer
        static void ShowMenu()
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
