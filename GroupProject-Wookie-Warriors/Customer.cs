namespace GroupProject_Wookie_Warriors
{
    internal class Customer : Account
    {
        public string Name { get; set; }
        private List<string> transferLogs = new List<string>(); //List for logs

        public Customer(string name, string accountType, double Balance, string Currency) : base(accountType, Balance, Currency)
        {
            Name = name; 
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
            if(amount <= 0 || amount > Balance)
            {  
                Console.WriteLine("Transfer failed. Invalid amount or insufficient balance.");
                return false;
            }

            this.Withdraw(amount);
            targetAccount.Deposit(amount);


            this.TransferLog1(amount, this.AccountType, targetAccount.AccountType);
            targetAccount.TransferLog1(amount, this.AccountType, targetAccount.AccountType);

                Console.WriteLine($"Transferred {amount} {Currency} from {AccountType} to {targetAccount.AccountType}.");
                return true;
        }

       public void TransferLog1(double amount, string fromAccount, string toAccount)
       {
            string log = $"{DateTime.Now}: {amount} {Currency} transferred from {fromAccount}";
            transferLogs.Add(log);
       }

       public void PrintTransferLogs()
        {
            Console.WriteLine($"Transfer history for {Name}");
            foreach(var log in transferLogs)
            {
                Console.WriteLine(log);
            }
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
