namespace GroupProject_Wookie_Warriors
{
    internal class Customer : Account
    {
        public Customer(string accountType, double Balance, string Currency) : base(accountType, Balance, Currency)
        {

        }

       static void CustomerAccounts()
       {
          
       }

       static void TransferToAccount()
       {
         // överföring mellan två konton   
       }

        public bool Withdraw(double amount)
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
