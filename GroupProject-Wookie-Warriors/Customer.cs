using System.Net;
using System.Security.Principal;

namespace GroupProject_Wookie_Warriors
{
    public class Customer : Login
    {
        private int ScrollMenu(List<Account> accounts, string cHeader)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine(cHeader);
                for (int i = 0; i < accounts.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"-> {i + 1}. {accounts[i].AccountType} - Balance: {accounts[i].Balance} {accounts[i].Currency}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {i + 1}. {accounts[i].AccountType} - Balance: {accounts[i].Balance} {accounts[i].Currency}");
                    }
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex == 0) ? accounts.Count - 1 : selectedIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex == accounts.Count - 1) ? 0 : selectedIndex + 1;
                        break;
                    case ConsoleKey.Escape:
                        return -1; // Escape cancels the operation
                }

            } while (key != ConsoleKey.Enter);

            return selectedIndex;
        }
        public void CustomerAccounts(User user)
        {
            Console.Clear();
            Console.WriteLine("Your accounts:");
            Console.WriteLine("\n-----------------------------------");
            foreach (var account in user.Accounts) 
            { 
                Console.WriteLine(account);
                Console.WriteLine("-----------------------------------");

            }
            Console.ReadKey();
        }   // Shows your accounts
       
        public void TransferToAccount(User user, Dictionary<string, User> users) // Method to transfer between your accounts
        {
            Console.Clear();
            Console.WriteLine("Your accounts:");    // Show thier accounts
            for (int i = 0; i < user.Accounts.Count; i++) 
            {
                Console.WriteLine($"{user.Accounts[i] }");
            }

            // int fromAccountIndex;
            // int toAccountIndex;
            decimal transferAmount;

            Console.WriteLine("Choose which account you wanna transfer from:"); // Asks which account to take money from
            //if (!int.TryParse(Console.ReadLine(), out fromAccountIndex) || fromAccountIndex < 1 || fromAccountIndex > user.Accounts.Count)
            //{
            //    Console.WriteLine("Wrong Answear"); // If user is a silly goose (out of range index)
            //    return;
            //}
            int fromAccountIndex = ScrollMenu(user.Accounts, "Your Accounts:");
            var fromAccount = user.Accounts[fromAccountIndex];

            //Console.Write("Choose which account you wanna transfer to: ");  // asks which account they wanna send it to
            //if (!int.TryParse(Console.ReadLine(), out toAccountIndex) || toAccountIndex < 1 || toAccountIndex > user.Accounts.Count)
            //{
            //    Console.WriteLine("Wrong Answear"); // If user is a silly goose (out of range index)
            //    return;
            //}
            int toAccountIndex = ScrollMenu(user.Accounts, "Your Accounts:");
            var toAccount = user.Accounts[toAccountIndex];

            if (fromAccount == toAccount)   // if they pick the same account
            {
                Console.WriteLine("Wrong Answear"); // if user trying to scam bank
                Console.ReadKey();
                return;
            }
            Console.WriteLine("How much do you wanna transfer over:");

            if (!decimal.TryParse(Console.ReadLine(), out transferAmount) || transferAmount <= 0)
            {
                Console.WriteLine("Wrong Answear1"); // if amount is negativ
                Console.ReadKey();
                return;
            }
            if (fromAccount.Balance < transferAmount || fromAccount.Currency != toAccount.Currency)
            {
                Console.WriteLine("Wrong Answear or Invalid currency3"); // if amount is more than what they have
                Console.ReadKey();
                return;
            }
            // succesful transfer very nice
            fromAccount.Balance -= transferAmount;
            toAccount.Balance += transferAmount;

            Console.WriteLine($"Transfer complete :) \n{transferAmount} {fromAccount.Currency} has transfered from {fromAccount.AccountType} to {toAccount.AccountType}.");
            
            //Logs
            string fromAcc = user.Accounts[fromAccountIndex].AccountType;
            string currency = user.Accounts[fromAccountIndex].Currency;
            string toAcc = user.Accounts[toAccountIndex].AccountType;

            transferAmount =- transferAmount;
            user.Logs.Add(new Logs(fromAcc, transferAmount, currency));
            transferAmount =- transferAmount;
            user.Logs.Add(new Logs(toAcc, transferAmount, currency));
            DataManage.SaveData(users);
            Console.ReadKey();

        }

        public void TransferToOtherCustomer1(User user, Dictionary<string, User> users)
        {
            Console.Clear();

            Console.WriteLine("Choose which account you want to transfer from:");
            int fromAccountIndex = ScrollMenu(user.Accounts, "Your Accounts:");
            var fromAccount = user.Accounts[fromAccountIndex];

            Console.WriteLine("How much do you want to transfer?\nTransactions are only allowed in the same currency.");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount, try again.");
                return;
            }

            if (fromAccount.Balance < amount)
            {
                Console.WriteLine("You don't have enough funds, try again.");
                return;
            }

            Console.Clear();
            Console.WriteLine("Which customer do you want to send money to?\nNavigate with the arrow keys and press Enter to select.");

            List<User> customerList = new List<User>(users.Values);

            int customerIndex = ScrollUserMenu(customerList, "Available Customers:");
            User targetUser = customerList[customerIndex];

            if (targetUser.Accounts[0].Currency != fromAccount.Currency)
            {
                Console.WriteLine("Currencies do not match. Transaction cancelled.");
                return;
            }

            fromAccount.Balance -= amount;
            targetUser.Accounts[0].Balance += amount;

            Console.Clear();
            Console.WriteLine($"You have successfully sent {amount} {fromAccount.Currency} to {targetUser.UserName}.");

            user.Logs.Add(new Logs(fromAccount.AccountType, -amount, fromAccount.Currency));
            targetUser.Logs.Add(new Logs(targetUser.Accounts[0].AccountType, amount, fromAccount.Currency));

            DataManage.SaveData(users);
            Console.ReadKey();
        } // Transfer to other customer

        public bool Withdraw(User user,Dictionary<string, User> users)
        {
            Console.Clear();
            Console.WriteLine("Which account you wanna withdraw from:");

            //Console.WriteLine("\nYour accounts:");    // Show thier accounts
            //for (int i = 0; i < user.Accounts.Count; i++)
            //{
            //    Console.WriteLine($"{user.Accounts[i]}");
            //}
            int fromAccountIndex = ScrollMenu(user.Accounts, "Your Accounts:");
            var fromAccount = user.Accounts[fromAccountIndex];

            //if (!int.TryParse(Console.ReadLine(), out fromAccount) || fromAccount > user.Accounts.Count || fromAccount < 1)
            //{
            //    Console.WriteLine("Account doesnt exist");
            //    return false;
            //}

            Console.WriteLine("How much you wanna withdraw?");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount > fromAccount.Balance || amount <= 0)
            {
                Console.WriteLine("The amount is to high or low or check your account money");
                return false;
            }

            if (amount > fromAccount.Balance)
            {
                Console.WriteLine("You cant take out more money than the max amount in your account");
                Console.ReadKey();
                return false;
            }
            if(amount < 0)
            {
                Console.WriteLine("Invalid choice.");
                Console.ReadKey();
                return false;
            }
            else
            {
                fromAccount.Balance -= amount;
                Console.WriteLine("Succecful Withdraw");
                DataManage.SaveData(users);
                Console.ReadKey();
                return true;
            }           
        }   // Method to take out money

        public void TransferLog(User user, Dictionary<string, User> users)
        {
            foreach(var logs in user.Logs)
            {
                Console.WriteLine(logs);
            }    
            DataManage.SaveData(users);
            Console.ReadKey();
        }

        public void LoanAndInterest(User user, Dictionary<string, User> users)
        {
            decimal payBack;
            decimal rate = 0.05m;
            decimal interest;
            decimal totalBalance = 0;
            Console.Clear();

            if (user.UserLoans.Count > 0)
            {
                Console.WriteLine("You already have an active loan\n");

                List<string> options = new List<string> { "Payback loan", "Exit" };
                int choice = ScrollOptionsMenu(options, "Select an option:");

                if (choice == 0) 
                {
                    Console.Clear();
                    PayBackLoan(user, users);
                    Console.Clear();
                }
                return;
            }

            foreach (var acc in user.Accounts)
            {
                if (acc.Currency == "SEK")
                {
                    totalBalance += acc.Balance;
                }
            }
            CustomerAccounts(user);

            Console.WriteLine($"You have a total of: {totalBalance} SEK\n" +
                              "Interest rate: 5%\n" +
                              "How much do you want to loan?");

            string number = Console.ReadLine();
            Console.WriteLine("How many years?");
            string time = Console.ReadLine();

            if (decimal.TryParse(number, out decimal loan) && decimal.TryParse(time, out decimal year))
            {
                Console.Clear();

                if (loan <= 0 || year <= 0 || year > 30)
                {
                    Console.WriteLine("Invalid input for loan or years.");
                    Console.ReadKey();
                    return;
                }

                if (loan > totalBalance * 5)
                {
                    Console.WriteLine("You can't take such a high loan.");
                    Console.ReadKey();
                    return;
                }

                interest = loan * rate * year;
                payBack = loan + interest;

                Console.WriteLine("Loan info:");
                Console.WriteLine($"Loan: {loan} SEK\n" +
                                  $"Payback interest: {interest} SEK in {year} years");

                Console.WriteLine("\nDo you want to take this loan?\n" +
                                  "1. Type 'yes'\n" +
                                  "2. Press enter to cancel");
                string takeLoan = Console.ReadLine();
                Console.Clear();

                if (takeLoan.ToLower() == "yes") 
                {
                    Console.WriteLine("Choose an account to transfer the loan to (only SEK accounts are valid):");

                    List<Account> sekAccounts = user.Accounts.Where(a => a.Currency == "SEK").ToList();

                    if (sekAccounts.Count == 0)
                    {
                        Console.WriteLine("You don't have any accounts in SEK.");
                        Console.ReadKey();
                        return;
                    }

                    int selectedAccountIndex = ScrollMenu(sekAccounts, "Your SEK Accounts:");
                    var chosenAccount = sekAccounts[selectedAccountIndex];

                    chosenAccount.Balance += loan;
                    user.UserLoans.Add(payBack);

                    Console.WriteLine($"Loan successful! {loan} SEK has been added to your account: {chosenAccount.AccountType}");

                    DataManage.SaveData(users);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Loan cancelled.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.ReadKey();
            }
        }

        public void PayBackLoan(User user,Dictionary<string,User> users)
        {
            Console.WriteLine("You can payback your loan here\n" +
                    "Choose an account to payback with must be in Sek!");
            Console.ReadKey();

            int userAccount; //Checks if input is not valid 
            if(!int.TryParse(Console.ReadLine(), out userAccount) || userAccount >= user.Accounts.Count || userAccount < 1 || user.Accounts[userAccount - 1].Currency != "SEK")
            {
                Console.WriteLine("Account doesnt exist or invalid currency");
                return;
            }        
            Console.Clear();

            Console.WriteLine("Enter the exact amount as your current loan");
            Console.WriteLine($"Current loan: {user.UserLoans[0]} Sek");           
            decimal amount;

            //If amount is not valid
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount > user.Accounts[userAccount - 1].Balance || amount > user.UserLoans[0] || amount < user.UserLoans[0])
            {
                Console.WriteLine("The amount is to high or low");               
            }
           
            else if (amount == user.UserLoans[0])  //Payment goes through and loan is removed
            {
                user.Accounts[userAccount - 1].Balance -= amount;
                amount = 0;               
                user.UserLoans.RemoveAt(0);
                Console.WriteLine("Payment successful");
            }
            DataManage.SaveData(users);
        }


        public void AddNewAccount(User user, Dictionary<string, User> users)
        {
            Console.Clear();
            Console.WriteLine("Name of the account:)");

            string accountType = Console.ReadLine();

            foreach(var account in user.Accounts)
            {
                if(account.AccountType == accountType)
                {
                    Console.WriteLine("Account already exist!");
                    return;
                }
            }

            Console.WriteLine("We have decided that your balance will be 0 and your currency SEK. ");
            decimal Balance = 0;
            string Currency = "SEK";
            Console.ReadKey();
            Account newAccount = new Account(accountType, Balance, Currency);
            user.Accounts.Add(newAccount);
            Console.WriteLine($"New {accountType} account with {Balance} {Currency} have been added");

            DataManage.SaveData(users);
            Console.ReadKey();
        }


        public void AccountInOtherCurrency(User user, Dictionary<string, User> users)
        {
            var exchange = new ExchangeRates();
            Console.Clear();
            if (user.Accounts.Count == 0)

            {
                Console.WriteLine("You have no accounts! ");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Choose the account you want to convert: ");
            for (int i = 0; i < user.Accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {user.Accounts[i]}");
            }
            int Customerindex = -1;
            bool rightAccountChoice = false;
            while (!rightAccountChoice)
            {
                if (int.TryParse(Console.ReadLine(), out Customerindex) && Customerindex >= 1 && Customerindex <= user.Accounts.Count)
                {
                    rightAccountChoice = true;

                }
                else
                {
                    Console.WriteLine("Choose an acccount that exists! ");

                }
            }
            Account accountChoice = user.Accounts[Customerindex - 1];


            string currencyChoice = "";
            while (true) // make sure to get right currency
            {
                Console.WriteLine("Convert to currency: (EUR, USD, SEK)");
                currencyChoice = Console.ReadLine().ToUpper();


                if (currencyChoice == "EUR" || currencyChoice == "USD" || currencyChoice == "SEK")
                {
                    break;
                    Console.ReadKey();

                }

                Console.WriteLine("wrong currency,Choose between (EUR, USD, SEK)");
                Console.ReadKey();
            }
            if (currencyChoice == accountChoice.Currency)
            {
                Console.WriteLine("You cant convert to same currency that you have.");
                Console.ReadKey();

                return;
            }
            
            decimal exchangeRate = 0;          
            switch (accountChoice.Currency.ToUpper())
            {
                case "SEK":
                    switch (currencyChoice)
                    {
                        case "EUR":
                            exchangeRate = exchange.ExchangeRateToEuro["SEK"]; // SEK to EUR
                            Console.ReadKey();

                            break;
                        case "USD":
                            exchangeRate = exchange.ExchangeRateToUsd["SEK"]; // SEK to USD
                            Console.ReadKey();

                            break;
                        default:
                            Console.WriteLine($"You cant convert to {currencyChoice}");
                            Console.ReadKey();

                            return;
                    }
                    break;

                case "EUR":
                    switch (currencyChoice)
                    {
                        case "SEK":
                            exchangeRate = exchange.ExchangeRateToSek["EUR"]; // EUR to SEK
                            Console.ReadKey();

                            break;
                        case "USD":
                            exchangeRate = exchange.ExchangeRateToUsd["EUR"]; // EUR to USD
                            Console.ReadKey();

                            break;
                        default:
                            Console.WriteLine($"You cant convert to {currencyChoice}");
                            Console.ReadKey();

                            return;
                    }
                    break;

                case "USD":
                    switch (currencyChoice)
                    {
                        case "SEK":
                            exchangeRate = exchange.ExchangeRateToSek["USD"];  // USD to SEK
                            Console.ReadKey();

                            break;
                        case "EUR":
                            exchangeRate = exchange.ExchangeRateToEuro["USD"]; // ÚSD to EUR
                            Console.ReadKey();

                            break;
                        default:
                            Console.WriteLine($"You cant convert to {currencyChoice}");
                            Console.ReadKey();

                            return;
                    }
                    break;

            default:
                 Console.WriteLine("Cant Convert!");
                 Console.ReadKey();

                    return;

            }
            accountChoice.Balance *= exchangeRate;
            accountChoice.Currency = currencyChoice;


            Console.WriteLine($"Successfully converted, Your new balance: {accountChoice.Balance} {accountChoice.Currency}");
            Console.ReadKey();

            DataManage.SaveData(users);
        }


        public void OpenSavingAccounts(User user, Dictionary<string, User> users)
        {
            Console.Clear();
            string currency = "SEK"; // currency choice 
            decimal rate = 0.03m; // 3% exchange rate
            int savingAccount = user.Accounts.Count(account => account.AccountType== "SavingsAccount");
            //Checks if user have more than 2 or equal SavingsAccounts. 
            if(savingAccount >= 2)
            {
                Console.WriteLine("Max limit");
                Console.ReadKey();
                return;
            }

            decimal totalBalance = 0;
            foreach (var acc in user.Accounts)
            {
                Console.WriteLine($"- {acc.AccountType} {acc.Balance} {acc.Currency}");
                if(acc.Currency == "SEK")
                {
                    totalBalance += acc.Balance;                   
                }                        
            }
            Console.WriteLine($"You have a total balance of: {totalBalance} {currency}");
            Console.WriteLine("our Interest rate: 3%\n");

            int chooseAccount;
            Console.WriteLine("Choose an account to take money from");
            if (!int.TryParse(Console.ReadLine(), out chooseAccount) || chooseAccount < 1 || chooseAccount > user.Accounts.Count)
            {
                Console.WriteLine("Account doesnt exist!, Enter right account number");
                Console.ReadKey();
                return;
            }
                      
            if (user.Accounts[chooseAccount - 1].Currency != "SEK")
            {
                Console.WriteLine("Choose an account in SEK");
                Console.ReadKey();
                return;
            }
              
            decimal depositAmount = 0;
            bool validDepositAmount = false;
            while (!validDepositAmount)
            {
                Console.WriteLine($"Amount you want to deposit to your new saving account? (minimum 1 & Maximum {totalBalance})");
                if (decimal.TryParse(Console.ReadLine(), out depositAmount) && depositAmount >= 1 && depositAmount <= totalBalance)
                {
                    validDepositAmount = true;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Wrong amount, enter right amount.");
                    Console.ReadKey();
                }
            }
            decimal interest = depositAmount * rate;
            decimal finalBalance = depositAmount;
            //information about the new account
            Console.Clear();
            Console.WriteLine("Your new savings account:");
            Console.WriteLine($"Amount: {depositAmount} {currency} " +
                $"\nInterest Rate: {rate * 100}% and {interest:F2} {currency}" +
                $"\nFinal Balance: {finalBalance:F2} {currency}");

            string customerChoice;
            do
            {
            Console.WriteLine("Would you like to open your saving account? (yes/no)");
            customerChoice = Console.ReadLine().ToLower();

            } while (customerChoice != "yes" && customerChoice != "no");
           
            if(customerChoice == "yes")
            {
                Account newSavingAccount = new Account("SavingsAccount", finalBalance, currency);
                user.Accounts.Add(newSavingAccount);             
                Console.WriteLine($"Your saving account has been created with the amount {finalBalance} {currency}.");              
                user.Accounts[chooseAccount - 1].Balance -= depositAmount;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No new saving account was created.");
                Console.ReadKey();
            }
            DataManage.SaveData(users);
        }   // Open a savings account with intrest

        public void Deposit(User user, Dictionary<string, User> users)
        {
            Console.Clear();
            Console.WriteLine("Choose which account you want to deposit to:");

            // Scrollande meny för att välja konto
            int selectedAccountIndex = ScrollMenu(user.Accounts, "Your Accounts:");
            var selectedAccount = user.Accounts[selectedAccountIndex];

            // Ange belopp att sätta in
            Console.WriteLine($"How much do you want to deposit to {selectedAccount.AccountType}?");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
                Console.ReadKey();
                return;
            }

            // Utför insättningen
            selectedAccount.Balance += amount;
            Console.WriteLine($"Deposited {amount} {selectedAccount.Currency}. New balance: {selectedAccount.Balance}");
            Console.ReadKey();
            // Spara data
            DataManage.SaveData(users);
            
        }   // Put in money in your account

        private int ScrollUserMenu(List<User> users, string title)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine(title);
                for (int i = 0; i < users.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"-> {users[i].UserName} (First Account Currency: {users[i].Accounts[0].Currency})");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {users[i].UserName} (First Account Currency: {users[i].Accounts[0].Currency})");
                    }
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex == 0) ? users.Count - 1 : selectedIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex == users.Count - 1) ? 0 : selectedIndex + 1;
                        break;
                    case ConsoleKey.Escape:
                        return -1; 
                }

            } while (key != ConsoleKey.Enter);

            return selectedIndex;
        }

        private int ScrollOptionsMenu(List<string> options, string title)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine(title + "\n");

                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"-> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {options[i]}");
                    }
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex == 0) ? options.Count - 1 : selectedIndex - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex == options.Count - 1) ? 0 : selectedIndex + 1;
                        break;
                    case ConsoleKey.Escape:
                        return -1; // Escape för att avbryta
                }

            } while (key != ConsoleKey.Enter);

            return selectedIndex;
        }
    }
}
