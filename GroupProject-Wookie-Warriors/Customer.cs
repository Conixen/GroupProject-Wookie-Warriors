namespace GroupProject_Wookie_Warriors
{
    public class Customer : Login
    {
        

       public void CustomerAccounts(User user)
       {
            Console.WriteLine(user.Accounts);
            
       }

       static void TransferToAccount()
       {
         // överföring mellan två konton   
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

            if(user.UserLoans.Count > 0)
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


            if (double.TryParse(number,out double loan) && double.TryParse(time, out double year))
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
        

    }
}
