using System.Security.Principal;

namespace GroupProject_Wookie_Warriors
{
    public class Customer : Login
    {
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
        }   // Shows your accounts
       
        public void TransferToAccount(User user, Dictionary<string, User> users) // Method to transfer between your accounts
        {
            Console.Clear();
            Console.WriteLine("Your accounts:");    // Show thier accounts
            for (int i = 0; i < user.Accounts.Count; i++) 
            {
                Console.WriteLine($"{user.Accounts[i] }");
            }

            int fromAccountIndex;
            int toAccountIndex;
            decimal transferAmount;

            Console.WriteLine("Choose which account you wanna transfer from:"); // Asks which account to take money from
            if (!int.TryParse(Console.ReadLine(), out fromAccountIndex) || fromAccountIndex < 1 || fromAccountIndex > user.Accounts.Count)
            {
                Console.WriteLine("Wrong Answear"); // If user is a silly goose (out of range index)
                return;
            }
            var fromAccount = user.Accounts[fromAccountIndex - 1];

            Console.Write("Choose which account you wanna transfer to: ");  // asks which account they wanna send it to
            if (!int.TryParse(Console.ReadLine(), out toAccountIndex) || toAccountIndex < 1 || toAccountIndex > user.Accounts.Count)
            {
                Console.WriteLine("Wrong Answear"); // If user is a silly goose (out of range index)
                return;
            }
            var toAccount = user.Accounts[toAccountIndex - 1];

            if (fromAccount == toAccount)   // if they pick the same account
            {
                Console.WriteLine("Wrong Answear"); // if user trying to scam bank
                return;
            }
            Console.WriteLine("How much do you wanna transfer over:");

            if (!decimal.TryParse(Console.ReadLine(), out transferAmount) || transferAmount <= 0)
            {
                Console.WriteLine("Wrong Answear"); // if amount is negativ
                return;
            }
            if (fromAccount.Balance < transferAmount || fromAccount.Currency != toAccount.Currency)
            {
                Console.WriteLine("Wrong Answear or Invalid currency"); // if amount is more than what they have
                return;
            }
            // succesful transfer very nice
            fromAccount.Balance -= transferAmount;
            toAccount.Balance += transferAmount;

            Console.WriteLine($"Transfer complete :) \n{transferAmount} {fromAccount.Currency} has transfered from {fromAccount.AccountType} to {toAccount.AccountType}.");

            //Logs
            string fromAcc = user.Accounts[fromAccountIndex - 1].AccountType;
            string currency = user.Accounts[fromAccountIndex - 1].Currency;
            string toAcc = user.Accounts[toAccountIndex - 1].AccountType;

            transferAmount =- transferAmount;
            user.Logs.Add(new Logs(fromAcc, transferAmount, currency));

            transferAmount =- transferAmount;
            user.Logs.Add(new Logs(toAcc, transferAmount, currency));
            DataManage.SaveData(users);

        }

        public void TransferToOtherCustomer1(User user, Dictionary<string, User> users)
        {
            Console.Clear();
            Console.WriteLine("Your accounts: ");
            for (int i = 0; i < user.Accounts.Count; i++)
            {
                Console.WriteLine($"{user.Accounts[i]}");
            }

            int fromAccountIndex;
            decimal amount; /*= decimal.Parse(Console.ReadLine());*/

            Console.WriteLine("Choose wich account you want to transfer from:");
            if (!int.TryParse(Console.ReadLine(), out fromAccountIndex) || fromAccountIndex < 1 || fromAccountIndex > user.Accounts.Count)
            {
                Console.WriteLine("Invalid choice, try again.");
                return;
            }
            var fromAccount = user.Accounts[fromAccountIndex -1];
            Console.WriteLine("How much do you want to transfer?\n" +
                "Transactions only in same currency!!");

            if(!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid choice, try again.");
            }

            if(user.Accounts[fromAccountIndex -1].Balance < amount)
            {
                Console.WriteLine("Invalid amount, try again.");
                return;
            }

            Console.Clear();
            Console.WriteLine($"Wich customer do you whant to send money to? \nWrite down the name of the customer:\n");

            foreach(var users1 in users.Values)
            {
                Console.WriteLine($"{users1.UserName}'s First account is in {users1.Accounts[0].Currency}");
            }
            string chooseCustomer = Console.ReadLine(); 

            if (users.ContainsKey(chooseCustomer) && users[chooseCustomer].Accounts[0].Currency == user.Accounts[fromAccountIndex -1].Currency)
            {
                Console.WriteLine();
                user.Accounts[fromAccountIndex - 1].Balance -= amount;
                users[chooseCustomer].Accounts[0].Balance += amount;
            }
            else
            {
                Console.WriteLine("Invalid choice");
                return;
            }
            Console.Clear();
            Console.WriteLine($"You have sent {amount} {user.Accounts[fromAccountIndex - 1].Currency} to {users[chooseCustomer].UserName}");

            // Add transaction to logs
            string whichAccount = user.Accounts[fromAccountIndex - 1].AccountType;
            string currency = user.Accounts[fromAccountIndex - 1].Currency;

            amount =- amount;
            user.Logs.Add(new Logs(whichAccount, amount, currency));

            amount =- amount;
            user.Logs.Add(new Logs(chooseCustomer, amount, currency));

            DataManage.SaveData(users);                 

        }   // Transfer to other customer

        public bool Withdraw(User user,Dictionary<string, User> users)
        {
            Console.Clear();
            Console.WriteLine("Which account you wanna withdraw from:");

            Console.WriteLine("\nYour accounts:");    // Show thier accounts
            for (int i = 0; i < user.Accounts.Count; i++)
            {
                Console.WriteLine($"{user.Accounts[i]}");
            }

            int fromAccount;
            if(!int.TryParse(Console.ReadLine(), out fromAccount) || fromAccount > user.Accounts.Count || fromAccount < 1)
            {
                Console.WriteLine("Account doesnt exist");
                return false;
            }
           
            Console.WriteLine("How much you wanna withdraw?");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount > user.Accounts[fromAccount - 1].Balance || amount <= 0)
            {
                Console.WriteLine("The amount is to high or low or check your account money");
                return false;
            }

            if (amount > user.Accounts[fromAccount - 1].Balance)
            {
                Console.WriteLine("You cant take out more money than the max amount in your account");
                return false;
            }
            if(amount < 0)
            {
                Console.WriteLine("Invalid choice.");
                return false;
            }
            else
            {
                user.Accounts[fromAccount - 1].Balance -= amount;
                Console.WriteLine("Succecful Withdraw");
                DataManage.SaveData(users);
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
        }
        
        public void LoanAndInterest(User user,Dictionary<string,User> users)
        {

            //Rent and Interest.           
            decimal payBack;
            decimal rate = 0.05m;
            string time;
            decimal interest;
            decimal totalBalance = 0;            
            Console.Clear();

            //Checks if user have active loan and if user wants to payback
            if (user.UserLoans.Count > 0)
            {
                Console.WriteLine("You already have an active loan\n" +
                    "1. Payback loan\n" +
                    "2. Exit");

                string choose = Console.ReadLine();
                if(choose == "1")
                {
                    Console.Clear();
                    PayBackLoan(user, users);
                }                
                return;
            }
                                                                 
            foreach (var acc in user.Accounts)
            {           
               //Only display accounts in SEK
                if(acc.Currency == "SEK")
                {
                    totalBalance += acc.Balance;
                }                                     
            }

            Console.WriteLine($"You have a total of: {totalBalance} Sek\n" +
                "Interest rate: 5%\n" +
                "How much do you want to loan?");


            string number = Console.ReadLine();
            Console.WriteLine("How many years?");
            time = Console.ReadLine();

            //Checks if loan is valid
            if (decimal.TryParse(number, out decimal loan) && decimal.TryParse(time, out decimal year))
            {                
                Console.Clear();

                if (loan <= 0 || year <= 0 || year > 30)
                {
                    Console.WriteLine("Invalid");
                    return;
                }

                if (loan > totalBalance * 5)
                {
                    Console.WriteLine("Cant take such high loan");
                    return;
                }
                else
                {   //If valid loan will be proccessed. 
                    Console.WriteLine("Loan info:");
                    interest = (loan * rate * year);
                    payBack = loan + interest;
                    Console.WriteLine($"Loan: {loan} Sek\n" +
                        $"Payback interest: {interest} Sek in {year} years");

                    Console.WriteLine("\nDo you want to take this loan?\n" +
                        "1. Type yes\n" +
                        "2. Press enter");
                    string takeLoan = Console.ReadLine();
                    Console.Clear();

                    if (takeLoan == "yes") //User gets loan 
                    {
                        Console.WriteLine("YOUR ACCOUNTS:");
                        foreach(var accounts in user.Accounts)
                        {
                            Console.WriteLine(accounts);
                        }
                        int chooseAccount;
                        Console.WriteLine("\nChoose account to transfer to");
                        if(!int.TryParse(Console.ReadLine(), out chooseAccount) || chooseAccount >= user.Accounts.Count || chooseAccount < 1 || user.Accounts[chooseAccount - 1].Currency != "SEK")
                        {
                            Console.WriteLine("Account needs to be in SEK or Account doesnt exist");
                            return;
                        }
                       
                        user.Accounts[chooseAccount - 1].Balance += loan;
                        user.UserLoans.Add(payBack);
                        Console.WriteLine($"Loan successful");
                                              
                        DataManage.SaveData(users);
                    }                    
                }
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
            DataManage.SaveData(users);
            totalBalance = 0;
        }

        public void PayBackLoan(User user,Dictionary<string,User> users)
        {
            Console.WriteLine("You can payback your loan here\n" +
                    "Choose an account to payback with must be in Sek!");
                      
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
            Console.WriteLine("Type of account in your choice? (Savings/Salary)");

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

            Account newAccount = new Account(accountType, Balance, Currency);
            user.Accounts.Add(newAccount);
            Console.WriteLine($"New {accountType} account with {Balance} {Currency} have been added");
           
            DataManage.SaveData(users);
        }


        public void AccountInOtherCurrency(User user, Dictionary<string, User> users)
        {
            var exchange = new ExchangeRates();
            Console.Clear();
            if (user.Accounts.Count == 0)

            {
                Console.WriteLine("You have no accounts! ");
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
                }
                    Console.WriteLine("wrong currency,Choose between (EUR, USD, SEK)");
            }
            if (currencyChoice == accountChoice.Currency)
            {
                Console.WriteLine("You cant convert to same currency that you have.");
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
                            break;
                        case "USD":
                            exchangeRate = exchange.ExchangeRateToUsd["SEK"]; // SEK to USD
                            break;
                        default:
                            Console.WriteLine($"You cant convert to {currencyChoice}");
                            return;
                    }
                    break;

                case "EUR":
                    switch (currencyChoice)
                    {
                        case "SEK":
                            exchangeRate = exchange.ExchangeRateToSek["EUR"]; // EUR to SEK
                            break;
                        case "USD":
                            exchangeRate = exchange.ExchangeRateToUsd["EUR"]; // EUR to USD
                            break;
                        default:
                            Console.WriteLine($"You cant convert to {currencyChoice}");
                            return;
                    }
                    break;

                case "USD":
                    switch (currencyChoice)
                    {
                        case "SEK":
                            exchangeRate = exchange.ExchangeRateToSek["USD"];  // USD to SEK
                            break;
                        case "EUR":
                            exchangeRate = exchange.ExchangeRateToEuro["USD"]; // ÚSD to EUR
                            break;
                        default:
                            Console.WriteLine($"You cant convert to {currencyChoice}");
                            return;
                    }
                    break;

            default:
                 Console.WriteLine("Cant Convert!");
                 return;

            }
            accountChoice.Balance *= exchangeRate;
            accountChoice.Currency = currencyChoice;


            Console.WriteLine($"Successfully converted, Your new balance: {accountChoice.Balance} {accountChoice.Currency}");
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
                return;
            }
                      
            if (user.Accounts[chooseAccount - 1].Currency != "SEK")
            {
                Console.WriteLine("Choose an account in SEK");
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
                }
                else
                {
                    Console.WriteLine("Wrong amount, enter right amount.");
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
            }
            else
            {
                Console.WriteLine("No new saving account was created.");
            }
            DataManage.SaveData(users);
        }   // Open a savings account with intrest

        public void Deposit(User user, Dictionary<string, User> users)
        {
            Console.Clear();
            Console.WriteLine("Choose which account you wanna deposit to");// Asks which account to deposit to

            Console.WriteLine("\nYour accounts:");    // Show thier accounts
            for (int i = 0; i < user.Accounts.Count; i++)
            {
                Console.WriteLine($"{user.Accounts[i]}");
            }
            int indexDeposit;

            if (!int.TryParse(Console.ReadLine(), out indexDeposit) || indexDeposit < 1 || indexDeposit > user.Accounts.Count)
            {
                Console.WriteLine("Wrong Answear"); // If user is a silly goose (out of range index)
                return;
            }

            Account account = user.Accounts[indexDeposit - 1];   

            Console.WriteLine("How much do you wanna deposit?");
            decimal amount;

            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount, try again.");
                return;
            }
            account.Balance += amount; 
            Console.WriteLine($"Deposited {amount} {account.Currency}. New balance: {account.Balance}");
            DataManage.SaveData(users);
        }   // Put in money in your account

    }
}
