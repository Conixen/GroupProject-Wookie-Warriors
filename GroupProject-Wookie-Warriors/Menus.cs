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
                "\n-------------------------");

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
                    Console.Clear();
                    Console.WriteLine("Thank you for using Wookie Warriors program" +
                        "\n\n\n\nAnd not using the ShitLords program");
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        
        // User menu
        public void UserMenu(User user, Dictionary<string, User> users, Account account)
        {
            var a = new Customer();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Main Menu - Customer ====");
                Console.WriteLine("1. Show Your Balance");
                Console.WriteLine("2. Add New Account"); // AddNewAccount, OpenSavingAccounts
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Transfer"); // TransferToAccount, TransferToOtherCustomer1
                Console.WriteLine("5. Loan & intrest");
                Console.WriteLine("6. Account in other Currency");
                Console.WriteLine("8. TransferLog ");

                Console.WriteLine("0. Log out");
                Console.WriteLine("\nChoose one of the following options...");

                string choice = Console.ReadLine();

                switch (choice)
                {
                                    

                    case "1":                                             
                        a.CustomerAccounts(user); 
                        break;
                    case "2":
                        Console.WriteLine("Wanna open a new account or a savingsaccount" +
                            "\nType: 1 for New Account\nType 2 for Savingsaccount");
                        string accountChoice = Console.ReadLine();
                        if (accountChoice == "1") 
                        {
                            a.AddNewAccount();
                        }
                        if (accountChoice == "2") 
                        { 
                            a.OpenSavingAccounts(user);
                        }
                        break;
                    case "3":

                        a.TransferToOtherCustomer1(user);
               
                        break;
                    case "4":
                        Console.WriteLine("Wanna transfer to your accounts - Type: 0");
                        Console.WriteLine("Wanna transfer to other customer - Type: 1");
                        string transferChoice = Console.ReadLine();
                        if (transferChoice == "0")
                        {
                            a.TransferToAccount(user);
                        }
                        if (transferChoice == "1") 
                        {
                            a.TransferToOtherCustomer1(user, targetAccount, amount);
                        }
                        else
                            Console.WriteLine("Stop being a silly goose");
                        
                        break;
                    case "5":
                        a.LoanAndInterest(user);
                        break;
                    case "6":
                        a.AccountInOtherCurrency();
                        break;
                    case "7":
                        a.PrintTransferLogs();
                        break;
                    case "0":
                        Console.WriteLine($"You are now logging out {a}.");
                        Console.Clear();
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
