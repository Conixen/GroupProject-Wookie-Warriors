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
        public static int NavigateMenu(string[] menuItems, string menuTitle)
        {
            int selectedIndex = 0; // The meny choice

            while (true)
            {
                Console.Clear();
                Console.WriteLine(menuTitle); 

                
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedIndex) 
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                       //Console.ForegroundColor = ConsoleColor.Yellow;                      
                    }

                    Console.WriteLine($"{i + 1}. {menuItems[i]}");
                    Console.ResetColor();
                }

                
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        if (selectedIndex < 0) selectedIndex = menuItems.Length - 1; 
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        if (selectedIndex >= menuItems.Length) selectedIndex = 0;
                        break;

                    case ConsoleKey.Enter:
                        return selectedIndex; 

                    case ConsoleKey.Escape:
                        return - 1;
                }
            }
        }
        public static void Menu()
        {            
            var login = new Login();
            string[] mainMenu = { "Login as customer", "Login as admin", "Exit Program" };

            while (true)
            {
                int selectedIndex = NavigateMenu(mainMenu, "Wookie Bank" +
                    "\nWelcome to the login menu!");

                Console.Clear();

                switch (selectedIndex)
                {
                    case 0: // Login as customer
                        login.LoginUser();
                        break;
                    case 1: // Login as admin
                        login.LoginAdmin();
                        break;
                    case 2: // Exit Program
                        Console.WriteLine("Thank you for using Wookie Warriors program!\n\n\nAnd not using the Shi... sith lords program.");
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void UserMenu(User user, Dictionary<string, User> users)
        {
            var customer = new Customer();
            string[] userMenuItems = {
            "Show Your Balance",
            "Add New Account",
            "Deposit/Withdraw",  // Deposit & withdraw
            "Transfer",      // Transfer to other customer
            "Loan & Intrest", // and see if u have a loan
            "Other",         // TransferLog, account in other currency, open savings account
            "Log Out",
            };

            while (true)
            {
                int selectedIndex = NavigateMenu(userMenuItems,"==== Main Menu - Customer ====\n");

                Console.Clear();
                
                switch (selectedIndex)
                {
                    case 0:
                        customer.CustomerAccounts(user);
                        break;
                    case 1:
                        customer.AddNewAccount(user, users);
                        break;
                    case 2:
                        Console.Clear();
                        string[] dWmenu = { "Deposit", "Withdraw", "Back" };
                        int dWChoice = NavigateMenu(dWmenu, "==== Deposit/Withdraw ====\n");
                        switch (dWChoice) 
                        {
                            case 0:
                                customer.Deposit(user, users);
                                break;
                            case 1:
                                customer.Withdraw(user, users);
                                break;
                            case 2:
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        string[] transferMenu = { "Transfer to your accounts", "Transfer to another customer", "Back" };
                        int transferChoice = NavigateMenu(transferMenu, "==== Deposit/Withdraw ====");
                        switch (transferChoice) 
                        {
                            case 0:
                                customer.TransferToAccount(user, users);
                                break;
                            case 1:
                                customer.TransferToOtherCustomer1(user, users);
                                break;
                            case 2:
                                break;     
                        }
                        break;
                    case 4:
                        customer.LoanAndInterest(user, users);
                        break;
                    case 5:
                        Console.Clear();
                        string[] otherMenu = { "Opening account with intrest", "Account in other Currency", "TransferLog", "Back" };
                        int otherChoice = NavigateMenu(otherMenu, "==== Other Options ====");
                        switch (otherChoice) 
                        {
                            case 0:
                                customer.OpenSavingAccounts(user, users);
                                break;
                            case 1:
                                customer.AccountInOtherCurrency(user, users);
                                break;
                            case 2:
                            customer.TransferLog(user, users);
                                break;
                            case 3:
                                break;
                        }
                        break;
                    case 6:
                        Console.WriteLine($"You are now logging out {user.UserName}.");
                        Console.ReadKey();
                        DataManage.SaveData(users);
                        Menu();
                        Console.Clear();
                        break;
                        
                }       

                Console.WriteLine("\nPress any key to continue...");
                
            }
        }

        public void AdminMenu(User user, Dictionary<string, Admin> admins, Login login)
        {
            var accountManager = new CreateAccount(login);
            var converter = new ConvertCurrency();

            string[] adminMenuItems = {
            "Create New Account",
            "Currency",
            "See exchange rates",
            "Log out"
            };

            while (true)
            {
                int selectedIndex = NavigateMenu(adminMenuItems, "==== Main Menu - Admin ====");

                Console.Clear();

                switch (selectedIndex)
                {
                    case 0:
                        Console.Write("Enter new username: ");
                        string username = Console.ReadLine();

                        Console.Write("Enter new user password: ");
                        string password = Console.ReadLine();

                        Console.Write("Enter user ID: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.Write("Enter initial balance for the user: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal initialBalance))
                            {
                                accountManager.CreateUserWithAccounts(username, password, id, initialBalance);
                            }
                            else
                            {
                                Console.WriteLine("Invalid balance. Returning to menu...");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Returning to menu...");
                        }
                        break;

                    case 1:
                        converter.ChangeCurrency();
                        
                        break;
                    case 2: 
                    {
                            converter.SeeRates();
                            break;    
                    }
                    case 3:
                        Console.WriteLine($"You are now logging out {user.UserName}.");
                        Console.ReadKey();
                        DataManage.SaveAdminData(admins);
                        Menu();
                        Console.Clear();
                        return;
                }
            }
        }
    }
}
