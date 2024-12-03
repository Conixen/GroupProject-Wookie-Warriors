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


        public void AddNewAccount()
        {
           
            Console.WriteLine("type of account in your choice? (Savings/Salary)");
            string AccountType = Console.ReadLine();

            double Balance = 0;
            bool rightBalance = false;
            while (!rightBalance)
            {
                Console.WriteLine("How much money do you want to start with? (3000?) ");

                if (double.TryParse(Console.ReadLine(), out Balance) && Balance >= 0)
                {
                    rightBalance = true;
                }
                else
                {
                    Console.WriteLine("wrong sum, sorry could not make a new account");
                }
            }
            Console.WriteLine("Your currency will be in SEK ");
            string Currency = "SEK";

            Account newAccount = new Account(AccountType, Balance, Currency);
            accounts.Add(newAccount);
            Console.WriteLine($"New {AccountType} account with {Balance} {Currency} have been added");
        }


        public void AccountInOtherCurrency()
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("You have no accounts! ");
            }

            Console.WriteLine("Choose the account you want to convert: ");
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {accounts[i]}");
            }
            int Customerindex = -1;
            bool rightAccountChoice = false;
            while (!rightAccountChoice)
            {
                if (int.TryParse(Console.ReadLine(), out Customerindex) && Customerindex >= 1 && Customerindex <= accounts.Count)
                {
                    rightAccountChoice = true;
                }
                else
                {
                    Console.WriteLine("Choose an acccount that exists! ");
                }
            }
            Account customerAccountChoice = accounts[Customerindex - 1];


            string currencyChoice = "";
            while (currencyChoice.Length == 0)
            {
                Console.WriteLine("Convert to currency: ");
                currencyChoice = Console.ReadLine();

                if (currencyChoice.Length == 0)
                {
                    Console.WriteLine("Write a currency.");
                }
            }

            double exchangeRateChoice = 0;
            bool rightExchangeRate = false;
            while (!rightExchangeRate)
            {
                Console.WriteLine("Enter exchange rate in your choice: ex.(1 SEK= 0,10 USD)");
                if (double.TryParse(Console.ReadLine(), out exchangeRateChoice) && exchangeRateChoice > 0)
                {
                    rightExchangeRate = true;
                }
                else
                {
                    Console.WriteLine("Enter a valid exchange rate.");
                }
            }
            customerAccountChoice.Balance *= exchangeRateChoice;
            customerAccountChoice.Currency = currencyChoice;

            Console.WriteLine($"Successfully converted, Your new balance: {customerAccountChoice.Balance} {customerAccountChoice.Currency}");
        }


        static void OpenSavingAccounts(User user)
        {
            double rate = 0.05;

            double totalBalance = 0;
            foreach (var acc in user.Accounts)
            {
                totalBalance += acc.Balance;      
            }
            Console.WriteLine($"You have a total balance of: {totalBalance} SEK");
            Console.WriteLine("Interest rate: 5%\n");

            double depositAmount = 0;
            bool validDepositAmount = false;
            while (!validDepositAmount)
            {
                Console.WriteLine("Ammount you want to deposit? min 1 Sek");
                if (double.TryParse(Console.ReadLine(), out depositAmount) && depositAmount >= 1)
                {
                    validDepositAmount = true;
                }
                else
                {
                    Console.WriteLine("wrong amount, enter minimum 1 Sek.");
                }
            }
            double interest = depositAmount * rate;
            double cFinalBalance = depositAmount * interest;

            Console.WriteLine("your new saving account:");
            Console.WriteLine($" Deposit: {depositAmount} SEK" +
                $" Our interest Rate: {rate * 100}%" +
                $"earned with interest: {interest:F2} SEK" +
                $"Final Balance with interest rate: {cFinalBalance:F2}");

            Console.WriteLine("would you like to open your saving account? (yes/no)");
            string CustomerChoice = Console.ReadLine();
            if(CustomerChoice == "yes")
            {
                Account newSavingAccount = new Account("Savings", depositAmount, "SEK");
                user.Accounts.Add(newSavingAccount);
                newSavingAccount.Balance += interest;

                Console.WriteLine($"Your saving account has been created with deposit {depositAmount} SEK.");
            }
            else
            {
                Console.WriteLine("No new saving account was created.");
            }
        }


    }
}
