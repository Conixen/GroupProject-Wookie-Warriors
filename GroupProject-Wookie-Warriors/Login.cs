using System.Security.Cryptography.X509Certificates;

namespace GroupProject_Wookie_Warriors
{
    public class Login : User
    {
        public void Menu()
        {
            Console.WriteLine("Welcome login");
            int user;
            int adminuser;
            user = int.Parse(Console.ReadLine());
            adminuser = int.Parse(Console.ReadLine());

            if(user == 1)
            {
                LoginUser();
            }

            if (adminuser == 2 )
            {
                LoginAdmin();
            }

        }

        public void LoginUser()
        {

        }

        public void LoginAdmin()
        {

        }

       
    }
}
