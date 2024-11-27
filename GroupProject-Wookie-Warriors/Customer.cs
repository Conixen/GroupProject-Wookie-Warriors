namespace GroupProject_Wookie_Warriors
{
    class Customer //hej
    {

       static void CustomerAccounts()
       {
          
       }

       static void TransferToAccount()
       {
         // överföring mellan två konton   
       }

        public bool Withdraw(double amount)
        {
            if (amount >= Balance && amount < 0)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount}, new balance: {Balance}");
                return true;
            }
            else
            {
                Console.WriteLine("Not enough balance or invalid amount.");
                return false;
            }
        }

        public bool TransferToOtherCustomer1(BankAccount recipient, double amount)
        {
            if(Withdraw(amount))
            {
                recipient.Deposit(amount);
                Console.WriteLine($"The transfer of {amount} to {recipient.Accountholder} was successfull.");
                return true;
            }
            else
            {
                Console.WriteLine("The transfer failed.");
                return false;
            }
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
