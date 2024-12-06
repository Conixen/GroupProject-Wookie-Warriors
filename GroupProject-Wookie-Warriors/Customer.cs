﻿using System.Security.Principal;

namespace GroupProject_Wookie_Warriors
{
    public class Customer : Login
    {
        public string Name { get; set; }
        private Account account;
        private List<string> transferLogs = new List<string>(); //List for logs
        private List<Account> accounts = new List<Account>(); //List for accounts

        /* public Customer(string name, Account account, string accountType, double Balance, string Currency)
        {
            Name = name;
            this.account = account;
        }*/


        public void CustomerAccounts(User user)
        {
            Console.Clear();
            foreach (var account in user.Accounts) 
            { 
                Console.WriteLine(account);
            }
        }   // Shows your accounts
       
        public void TransferToAccount(User user) // Method to transfer between your accounts
       {
            Console.Clear();
            Console.WriteLine("Your accounts:");    // Show thier accounts
            for (int i = 0; i < user.Accounts.Count; i++) 
            {
                Console.WriteLine($"{user.Accounts[i] }");
            }

            int fromAccountIndex;
            int toAccountIndex;
            double transferAmount;

            Console.WriteLine("Choose which account you wanna transfer from:"); // Asks which account to take money from
            if (!int.TryParse(Console.ReadLine(), out fromAccountIndex) || fromAccountIndex < 0 || fromAccountIndex > user.Accounts.Count)
            {
                Console.WriteLine("Wrong Answear"); // If user is a silly goose (out of range index)
                return;
            }
            var fromAccount = user.Accounts[fromAccountIndex - 1];

            Console.Write("Choose which account you wanna transfer to: ");  // asks which account they wanna send it to
            if (!int.TryParse(Console.ReadLine(), out toAccountIndex) || toAccountIndex < 0 || toAccountIndex > user.Accounts.Count)
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

            if (!double.TryParse(Console.ReadLine(), out transferAmount) || transferAmount <= 0)
            {
                Console.WriteLine("Wrong Answear"); // if amount is negativ
                return;
            }
            if (fromAccount.Balance < transferAmount)
            {
                Console.WriteLine("Wrong Answear"); // if amount is more than what they have
                return;
            }
            // succesful transfer very nice
            fromAccount.Balance -= transferAmount;
            toAccount.Balance += transferAmount;

            Console.WriteLine($"Transfer complete :) \n{transferAmount} {fromAccount.Currency} has transfered from {fromAccount.AccountType} to {toAccount.AccountType}.");

       }

        public void TransferToOtherCustomer1(User user, Dictionary<string, User> users)
        {
            Console.Clear();
            Console.WriteLine("Your accounts: ");
            for (int i = 0; i < user.Accounts.Count; i++)
            {
                Console.WriteLine($"{user.Accounts[i]}");
            }

            int fromAccountIndex = user.Accounts.Count - 1;
            double amount; /*= double.Parse(Console.ReadLine());*/

            Console.WriteLine("Choose wich account you whant to transfer from:");
            if (!int.TryParse(Console.ReadLine(), out fromAccountIndex) || fromAccountIndex < 0 || fromAccountIndex > user.Accounts.Count)
            {
                Console.WriteLine("Invalid choice, try again.");
                return;
            }
            Console.WriteLine("How much do you want to transfer?");

            string wichAccount = user.Accounts[fromAccountIndex].AccountType;
            string currency = user.Accounts[fromAccountIndex].Currency;

            if(!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid choice, try again.");
            }

            if(user.Accounts[fromAccountIndex].Balance < amount)
            {
                Console.WriteLine("Invalid amount, try again.");
                return;
            }
            user.Accounts[fromAccountIndex].Balance -= amount;
            Console.WriteLine($"{amount} \nWich customer do you whant to send money to? \nWrite down the name of the customer:");

            foreach(var users1 in users.Keys)
            {
                Console.WriteLine(users1);
            }
            string chooseCustomer = Console.ReadLine();

            if (users.ContainsKey(chooseCustomer))
            {
                Console.WriteLine();
                users[chooseCustomer].Accounts[0].Balance += amount;
            }
            

            Console.WriteLine(amount);
            Console.WriteLine(users[chooseCustomer].Accounts[0].Balance);

            amount =- amount;
            user.Logss.Add(new Logs(wichAccount, amount, currency));

            amount =- amount;
            user.Logss.Add(new Logs(chooseCustomer, amount, currency));

            DataManage.SaveData(users);
            
            
            
            
            //if (account.Withdraw(amount))
            //{
            //    targetAccount.account.Deposit(amount);
            //    Console.WriteLine($"{Name} transferred {amount} {account.Currency} to {targetAccount.Name}.");
            //}
            //else
            //{
            //    Console.WriteLine("Transfer failed.");
            //}

        }   // Transfer to other customer

        public bool Withdraw(User user)
        {
            Console.Clear();
            Console.WriteLine("Which account you wanna withdraw from:");

            Console.WriteLine("\nYour accounts:");    // Show thier accounts
            for (int i = 0; i < user.Accounts.Count; i++)
            {
                Console.WriteLine($"{user.Accounts[i]}");
            }

            int fromAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("How much you wanna withdraw?");

            double amount = double.Parse(Console.ReadLine());

            if(amount > user.Accounts[fromAccount].Balance)
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
                user.Accounts[fromAccount].Balance -= amount;
                Console.WriteLine("Succecful Withdraw");
                return true;
            }
        }   // Method to take out money



        private Dictionary<int, List<string>> userTransferLogs = new Dictionary<int, List<string>>();
        public void TransferLog1(User user, double amount, string currency, string fromAccount, string toAccount, Dictionary<string, User> users)
        {
            foreach (var a in user.Logss)
            {
                Console.WriteLine(a);
            }

            if (!userTransferLogs.ContainsKey(user.Id))
            {
                userTransferLogs[user.Id] = new List<string>();
            }
                string log = $"{DateTime.Now}: {amount} {currency} transferred from {fromAccount} to {toAccount}.";
                userTransferLogs[user.Id].Add(log);
            
            DataManage.SaveData(users);
        }

        //public void PrintTransferLogs(User user, Dictionary<string, User> users)
        //{

           
        //    if (userTransferLogs.ContainsKey(user.Id))

        //    {
        //      Console.Clear();
        //      Console.WriteLine($"Transfer history for {user.UserName}");
        //        foreach (var log in transferLogs)
        //        {
                
        //            Console.WriteLine(log);

        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No transfer logs found.");
        //    }

        //}
            

        public void LoanAndInterest(User user,Dictionary<string,User> users)
        {

            //Rent and Interest.           
            double payBack;
            double rate = 0.05;
            string time;
            double interest;
            double totalBalance = 0;
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

            //Converts Euro currency to Sek within the user accounts     
            foreach (var acc in user.Accounts)
            {
                //Euro to Sek               
                if(acc.Currency != "Sek")
                {
                    acc.Balance *= 11.564;
                    acc.Currency = "Sek";                                  
                }       
                    totalBalance += acc.Balance;                              
            }           

            Console.WriteLine($"You have a total of: {totalBalance} Sek\n" +
                "Interest rate: 5%\n" +
                "How much do you want to loan?");


            string number = Console.ReadLine();
            Console.WriteLine("How many years?");
            time = Console.ReadLine();

            //Checks if loan is valid
            if (double.TryParse(number, out double loan) && double.TryParse(time, out double year))
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
                        user.Accounts[0].Balance += loan;                        
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
                      
            int userAccount = user.Accounts.Count - 1; //Checks if input is not valid 
            if(!int.TryParse(Console.ReadLine(), out userAccount) || userAccount > user.Accounts.Count || userAccount < 0 || user.Accounts[userAccount].Currency != "Sek")
            {
                Console.WriteLine("Account doesnt exist or invalid currency");
                return;
            }
            Console.Clear();

            Console.WriteLine("Enter the exact amount as your current loan");
            Console.WriteLine($"Current loan: {user.UserLoans[0]} Sek");           
            double amount;

            //If amount is not valid
            if (!double.TryParse(Console.ReadLine(), out amount) || amount > user.Accounts[userAccount].Balance || amount > user.UserLoans[0] || amount < user.UserLoans[0])
            {
                Console.WriteLine("The amount is to high or low");               
            }
           
            else if (amount == user.UserLoans[0])  //Payment goes through and loan is removed
            {
                user.Accounts[userAccount].Balance -= amount;
                amount = 0;               
                user.UserLoans.RemoveAt(0);
                Console.WriteLine("Payment successful");
            }
            DataManage.SaveData(users);
        }


        public void AddNewAccount(User user)
        {

            Console.Clear();
            Console.WriteLine("type of account in your choice? (Savings/Salary)");

            string AccountType = Console.ReadLine();

            Console.WriteLine("We have decided that your balance will be 0 and your currency SEK. ");
            double Balance = 0;
            string Currency = "Sek";

            Account newAccount = new Account(AccountType, Balance, Currency);
            user.Accounts.Add(newAccount);
            Console.WriteLine($"New {AccountType} account with {Balance} {Currency} have been added");

            
            DataManage.SaveData(users);
        }


        public void AccountInOtherCurrency(User user)
        {

            Console.Clear();
            if (accounts.Count == 0)

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

            double exchangeRate = 0;          
            switch (accountChoice.Currency.ToUpper())
            {
                case "SEK":
                    switch (currencyChoice)
                    {
                        case "EUR":
                            exchangeRate = 0.087; // SEK to EUR
                            break;
                        case "USD":
                            exchangeRate = 0.092; // SEK to USD
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
                            exchangeRate = 11.50; // EUR to SEK
                            break;
                        case "USD":
                            exchangeRate = 1.06; // EUR to USD
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
                            exchangeRate = 10.87;  // USD to SEK
                            break;
                        case "EUR":
                            exchangeRate = 0.95; // ÚSD to EUR
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
        }


        public void OpenSavingAccounts(User user)
        {
            Console.Clear();
            string currency = user.Accounts[0].Currency; // currency choice 
            double rate = 0.03; // 3% exchange rate


            double totalBalance = 0;
            foreach (var acc in user.Accounts)
            {
                Console.WriteLine($"- {acc.AccountType} {acc.Balance} {acc.Currency}");
                totalBalance += acc.Balance;      
            }
            Console.WriteLine($"You have a total balance of: {totalBalance} {currency}");
            Console.WriteLine("our Interest rate: 3%\n");

            double depositAmount = 0;
            bool validDepositAmount = false;
            while (!validDepositAmount)
            {
                Console.WriteLine($"Amount you want to deposit to your new saving account? (minimum 1 & Maximum {totalBalance})");
                if (double.TryParse(Console.ReadLine(), out depositAmount) && depositAmount >= 1 && depositAmount <= totalBalance)
                {
                    validDepositAmount = true;
                }
                else
                {
                    Console.WriteLine("wrong amount, enter right amount.");
                }
            }
            double interest = depositAmount * rate;
            double finalBalance = depositAmount - interest;
            //information about the new account
            Console.WriteLine("your new saving account:");
            Console.WriteLine($"Amount: {depositAmount} {currency} " +
                $"\nOur deducted interest Rate: {rate * 100}% and {interest:F2} {currency}" +
                $"\nFinal Balance after interest rate: {finalBalance:F2} {currency}");

            string customerChoice;
            do
            {
            Console.WriteLine("would you like to open your saving account? (yes/no)");
            customerChoice = Console.ReadLine().ToLower();

            } while (customerChoice != "yes" && customerChoice != "no");
           
            if(customerChoice == "yes")
            {
                Account newSavingAccount = new Account("SavingsAccount", finalBalance, currency);
                user.Accounts.Add(newSavingAccount);
                

                Console.WriteLine($"Your saving account has been created with the amount {finalBalance} {currency}.");
            }
            else
            {
                Console.WriteLine("No new saving account was created.");
            }
        }   // Open a savings account with intrest

        public void Deposit(User user)
        {
            Console.Clear();
            Console.WriteLine("Choose which account you wanna deposit to");// Asks which account to deposit to

            Console.WriteLine("\nYour accounts:");    // Show thier accounts
            for (int i = 0; i < user.Accounts.Count; i++)
            {
                Console.WriteLine($"{user.Accounts[i]}");
            }
            int indexDeposit;

            if (!int.TryParse(Console.ReadLine(), out indexDeposit) || indexDeposit < 0 || indexDeposit > user.Accounts.Count)
            {
                Console.WriteLine("Wrong Answear"); // If user is a silly goose (out of range index)
                return;
            }

            Account account = user.Accounts[indexDeposit];   

            Console.WriteLine("How much do you wanna deposit?");
            double amount;

            if (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount, try again.");
                return;
            }
            account.Balance += amount; 
            Console.WriteLine($"Deposited {amount} {account.Currency}. New balance: {account.Balance}");

        }   // Put in money in your account

    }
}
