using System.Security.Principal;

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
            foreach (var account in user.Accounts) 
            { 
                Console.WriteLine(account);
            }
        }
       
       static void TransferToAccount(User user) // Method to transfer between your accounts
       {
            Console.WriteLine("Your accounts:");    // Show thier accounts
            for (int i = 0; i < user.Accounts.Count; i++) 
            {
                Console.WriteLine($"{user.Accounts[i] }");
            }

            int fromAccountIndex;
            int toAccountIndex;
            double transferAmount;

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

        public void TransferToOtherCustomer1(User user, Customer targetAccount, double amount)
        {
            Console.WriteLine("Your accounts: ");
            for (int i = 0; i > user.Accounts.Count; i++)
            {
                Console.WriteLine($"{user.Accounts[i]}");
            }

            int fromAccountIndex;

            Console.WriteLine("Choose wich account you whant to transfer from:");
            if (!int.TryParse(Console.ReadLine(), out fromAccountIndex) || fromAccountIndex < 1 || fromAccountIndex > user.Accounts.Count)
            {
                Console.WriteLine("Wrong Answear");
                return;
            }

            if (account.Withdraw(amount))
            {
                targetAccount.account.Deposit(amount);
                Console.WriteLine($"{Name} transferred {amount} {account.Currency} to {targetAccount.Name}.");
            }
            else
            {
                Console.WriteLine("Transfer failed.");
            }

        }

        public void TransferLog1(double amount, string fromAccount, string toAccount)
        {
            string log = $"{DateTime.Now}: {amount} {account.Currency} transferred from {fromAccount}";
            transferLogs.Add(log);
        }

        public void PrintTransferLogs()
        {
            Console.WriteLine($"Transfer history for {Name}");
            foreach (var log in transferLogs)
            {
                Console.WriteLine(log);
            }
        }

        public void LoanAndInterest(User user)
        {

            //Rent and Interest.           
            double userloan;
            double rate = 0.05;
            string time;
            double interest;

            foreach (var acc in user.Accounts)
            {
                user.TotalBalance += acc.Balance;
            }

            if (user.UserLoans.Count > 0)
            {
                Console.WriteLine("You already have an active loan");
                user.TotalBalance = 0;
                return;
            }

            Console.WriteLine($"You have a total of: {user.TotalBalance} Sek\n" +
                "Interest rate: 5%\n" +
                "How much do you want to loan?");



            string number = Console.ReadLine();
            Console.WriteLine("How many years?");
            time = Console.ReadLine();


            if (double.TryParse(number, out double loan) && double.TryParse(time, out double year))
            {
                Console.Clear();

                if (loan > user.TotalBalance * 5)
                {
                    Console.WriteLine("Cant take such high loan");
                }
                else
                {
                    Console.WriteLine("Loan info:");
                    interest = (loan * rate * year);
                    userloan = loan + interest;
                    Console.WriteLine($"Loan: {loan}\n" +
                        $"Interest: {interest}\n" +
                        $"Total: {userloan}");

                    Console.WriteLine("\nDo you want to take this loan?\n" +
                        "1. Type yes\n" +
                        "2. Press Enter");
                    string takeLoan = Console.ReadLine();

                    if (takeLoan == "yes")
                    {
                        user.Accounts[0].Balance += loan;
                        Console.WriteLine($"This will be your total loan {userloan} Sek");
                        user.UserLoans.Add(userloan);
                        DataManage.SaveData(users);
                    }

                }
            }
            user.TotalBalance = 0;
        }


        public void AddNewAccount(User user)
        {
           
            Console.WriteLine("type account in your choice? (Savings/Salary)");
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
        }


    }
}
