using System.Security.Principal;

namespace GroupProject_Wookie_Warriors
{
    public class Customer : Login
    {
        

       public void CustomerAccounts(User user)
       {
            Console.WriteLine(user.Accounts);
            
       }
       // Method to transfer between your accounts
       static void TransferToAccount(User user) 
       {
            Console.WriteLine("Your accounts:");
            for (int i = 0; i < user.Accounts.Count; i++) 
            {
                Console.WriteLine($"{user.Accounts[i] }");
            }

            int fromAccountIndex;
            int toAccountIndex;
            double transferAmount;

            Console.WriteLine("Choose which account you wanna transfer from:");
            if (!int.TryParse(Console.ReadLine(), out fromAccountIndex) || fromAccountIndex < 1 || fromAccountIndex > user.Accounts.Count)
            {
                Console.WriteLine("Wrong Answear");
                return;
            }
            var fromAccount = user.Accounts[fromAccountIndex - 1];

            Console.Write("Choose which account you wanna transfer to: ");
            if (!int.TryParse(Console.ReadLine(), out toAccountIndex) || toAccountIndex < 1 || toAccountIndex > user.Accounts.Count)
            {
                Console.WriteLine("Wrong Answear");
                return;
            }
            var toAccount = user.Accounts[toAccountIndex - 1];

            if (fromAccount == toAccount)
            {
                Console.WriteLine("Wrong Answear");
                return;
            }
            Console.WriteLine("How much do you wanna transfer over:");

            if (!double.TryParse(Console.ReadLine(), out transferAmount) || transferAmount <= 0)
            {
                Console.WriteLine("Wrong Answear");
                return;
            }
            if (fromAccount.Balance < transferAmount)
            {
                Console.WriteLine("Wrong Answear");
                return;
            }

            fromAccount.Balance -= transferAmount;
            toAccount.Balance += transferAmount;

            Console.WriteLine($"Transfer complete :) \n{transferAmount} {fromAccount.Currency} has transfered from {fromAccount.AccountType} to {toAccount.AccountType}.");
            Console.WriteLine($"New balance: {fromAccount.AccountType}: {fromAccount.Balance} {fromAccount.Currency}");
            Console.WriteLine($"New balance: {toAccount.AccountType}: {toAccount.Balance} {toAccount.Currency}");

       }

        public bool Withdraw(User user,double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than 0.");
                return false;
            }
            
            if (amount > Balance)
            {
                Console.WriteLine("Not enough balance or invalid amount.");
                return false;
            }

            Balance -= amount;
            Console.WriteLine($"Withdrew {amount} {Currency} New balance: {Balance}");
            return true;
        }

        public bool TransferToOtherCustomer1(Account targetAccount, double amount)
        {
            if(amount <= 0)
            {  
                Console.WriteLine("The transfer amount must be greater than 0.");
                return false;
            }
            
            if (this.Withdraw(amount))
            {
                targetAccount.Deposit(amount);
                Console.WriteLine($"Transferred {amount} {Currency} from {AccountType} to {targetAccount.AccountType}.");
                return true;
            }
            return false;

        }
       static void TransferToOtherCustomer(decimal[][] accounts, int userIndex)
       {
            Console.WriteLine("Överföring mellan användare.");
            Console.WriteLine("Till vilken användare vill du föra över pengar till?");


           
       }

       static void TransferLog()
       {
         // logg på alla överföringar mm.... 
       }

       static void AddNewAccount()
       {
         // öppna nya konton   
       }

       static void AccountInOtherCurrency()
       {
          // konto i annan valuta  
       }
        
       static void OpenSavingAccounts()
       {
          //  öppna sparkonto och se ränta på insättning
       }

       static void LoanAndInterest()
       {
         //lån + ränta   
       } 
        

    }
}
