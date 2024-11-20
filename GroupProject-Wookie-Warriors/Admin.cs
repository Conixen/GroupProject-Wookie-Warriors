using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class Admin : User
    {
        List<string> Permissions {  get; set; }

        public Admin(string username, string password, List<string> permissions)
        {
            Permissions = permissions;
        }

        public override void CreateUser()
        {

        }

    }
}
