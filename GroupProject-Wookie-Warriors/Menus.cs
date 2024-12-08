﻿using System;
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
                "2. Login as admin\n" + "\n0. Exit Program" +
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
                case "0":
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
        public void UserMenu(User user, Dictionary<string, User> users)
        {
            var customer = new Customer();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Main Menu - Customer ====");
                Console.WriteLine("1. Show Your Balance");
                Console.WriteLine("2. Add New Account"); // AddNewAccount, OpenSavingAccounts
                Console.WriteLine("3. Deposit/Witdraw"); // Deposit, Withdraw
                Console.WriteLine("4. Transfer"); // TransferToAccount, TransferToOtherCustomer1
                Console.WriteLine("5. Loan & intrest");
                Console.WriteLine("6. Account in other Currency");
                Console.WriteLine("7. TransferLog ");

                Console.WriteLine("0. Log out");
                Console.WriteLine("\nChoose one of the following options...");

                string choice = Console.ReadLine();
                

                switch (choice)
                {             
                    case "1":                                             
                        customer.CustomerAccounts(user); 
                        break;
                    case "2":
                        Console.WriteLine("Wanna open a new account or a savingsaccount" +
                            "\nType: 1 for New Account\nType 2 for Savingsaccount");
                        string accountChoice = Console.ReadLine();

                        if (accountChoice == "1") 
                        {
                            customer.AddNewAccount(user,users);
                        }
                        if (accountChoice == "2") 
                        {
                            customer.OpenSavingAccounts(user,users);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Wanna Deposit type: 1" +
                            "\nWanna Withdraw type: 2 ");
                        string withdrawDeposit = Console.ReadLine();
                        if (withdrawDeposit == "1") 
                        {
                            customer.Deposit(user,users);
                        }
                        if (withdrawDeposit == "2") 
                        {
                            customer.Withdraw(user,users);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Wanna transfer to your accounts - Type: 1");
                        Console.WriteLine("Wanna transfer to other customer - Type: 2");
                        string transferChoice = Console.ReadLine();
                        if (transferChoice == "1")
                        {
                            customer.TransferToAccount(user,users);
                        }
                        if (transferChoice == "2") 
                        {
                            customer.TransferToOtherCustomer1(user, users);
                        }
                        else
                            Console.WriteLine("Stop being a silly goose");
                        break;
                    case "5":
                        customer.LoanAndInterest(user,users);
                        break;
                    case "6":
                        customer.AccountInOtherCurrency(user,users);
                        break;
                    case "7":
                        customer.TransferLog(user, users);                        
                        break;
                    case "0":
                        Console.WriteLine($"You are now logging out {customer}.");
                        Console.Clear();
                        DataManage.SaveData(users);
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
                Console.WriteLine("\nPress any key to countine...");
                Console.ReadKey();
            }
        }
        // Admin menu 
        public void AdminMenu(User user, Dictionary<string, Admin> admins)
        {
            var accountManager = new CreateAccount();
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("==== Main Menu - Admin ====");
                Console.WriteLine("1. Create new account");
                Console.WriteLine("2. Currency");
                Console.WriteLine("0. Log out");
                Console.WriteLine("\nChoose one of the following options...");

                string adminChoice = Console.ReadLine();

                switch (adminChoice) 
                {
                    case "1":
                        Console.Write("Enter your username: ");
                        string username = Console.ReadLine();

                        accountManager.DisplayCreateAccountMenu(username); // Now it has access to the method
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "2":
                        // admin.ChnageCurrecy();
                        break;
                    case "0":
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
