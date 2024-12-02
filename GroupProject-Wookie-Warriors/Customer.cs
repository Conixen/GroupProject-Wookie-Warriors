using System.Security.Principal;

namespace GroupProject_Wookie_Warriors
{
    public class Customer : Login
    {
        public string Name { get; set; }
        private Account account;
        private List<string> transferLogs = new List<string>(); //List for logs

        public Customer(string name, Account account, string accountType, double Balance, string Currency)
        {
            Name = name;
            this.account = account;
        }


        public void CustomerAccounts(User user)
       {
            Console.WriteLine(user.Accounts);
            
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

        public void TransferToOtherCustomer1(Customer targetAccount, double amount)
        {
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
                    }

                }
            }
            user.TotalBalance = 0;
        }


        static void AddNewAccount()
       {
         // öppna nya konton   
       }

       static void AccountInOtherCurrency()
       {
          // konto i annan valuta  
       }
        

       // static void OpenSavingAccounts()
       //{
          //  öppna sparkonto och se ränta på insättning
       //}


    }
}
