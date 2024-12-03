using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class Menus
    {
        public static void Menu()
        {
            //Startmenu when program starts.
            var login = new Login();           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the login menu!\n" +
                "\n1. Login as customer\n" +
                "2. Login as admin\n" + "\n3. Exit Program" +
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
                case "3":
                    Console.WriteLine("Thank you for using Wookie Warriors program" +
                        "\n\n\nAnd not using the ShitLords program");
                    break;

                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        
        // User menu
        public void UserMenu(User user, Dictionary<string, User> users)
        {
            var a = new Customer();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Main Menu - Customer ====");
                Console.WriteLine("1. Show Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Log out");
                Console.WriteLine("\nChoose one of the following options...");

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
                        DataManage.SaveData(users);
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
                Console.WriteLine("Press any key to countine...");
                Console.ReadKey();
            }
        }
        // Admin menu 
        public void AdminMenu(User user, Dictionary<string, Admin> admins)
        {
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("==== Main Menu - Admin ====");
                Console.WriteLine("1. Create new account");
                Console.WriteLine("2. Currency");
                Console.WriteLine("3. Log out");
                Console.WriteLine("\nChoose one of the following options...");

                string adminChoice = Console.ReadLine();

                switch (adminChoice) 
                {
                    case "1":
                        // admin.CreateUser();
                        break;
                    case "2":
                        // admin.ChnageCurrecy();
                        break;
                    case "3":
                        Console.WriteLine("Logging out...");
                        DataManage.SaveAdminData(admins);
                        Console.Clear();
                        Menu();
                        return;
                    default:

                        Console.WriteLine("Wrong answear, try again");
                        break;         
                }
                Console.WriteLine("Press any key to countine...");
                Console.ReadKey();
            }
        }
    }
}
