using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class DataManage
    {
        //USER SECTION
        private const string DataFilePath = "userdata.json";

        // Load user data from the file
        public static Dictionary<string, User> LoadData()
        {
            if (File.Exists(DataFilePath))
            {
                string jsonData = File.ReadAllText(DataFilePath);
                return JsonSerializer.Deserialize<Dictionary<string, User>>(jsonData) ?? new Dictionary<string, User>();

            }
            return new Dictionary<string, User>();
        }

        // Save user data to the file
        public static void SaveData(Dictionary<string, User> users)
        {
            string jsonData = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });         
            File.WriteAllText(DataFilePath, jsonData);
        }

        // Add default users if the dictionary is empty
        public static void DefaultUsers(Dictionary<string, User> users)
        {
            if (users.Count == 0)
            {
                users["Filip"] = new User("Filip", "123", 1);
                users["Tim"] = new User("Tim", "124", 2);
                users["Simon"] = new User("Simon", "321", 3);
                users["Shokran"] = new User("Shokran", "432", 4);
                users["Leon"] = new User("Leon", "543", 5);
            
                // Adding default accounts
                users["Filip"].AddAccount(new Account("SavingsAccount", 100, "Sek"));
                users["Tim"].AddAccount(new Account("PensionAccount", 200, "Euro"));
                users["Simon"].AddAccount(new Account("SavingsAccount", 500, "Sek"));
                users["Shokran"].AddAccount(new Account("SavingsAccount", 200, "Sek"));
                users["Leon"].AddAccount(new Account("PensionAccount", 200, "Euro"));

                SaveData(users); // Save default users to file
            }
        }
        // ADMIN SECTION
        private const string DataFilePathAdmin = "admin.json";
        
        // Load admin data to file
        public static Dictionary<string, Admin> LoadAdminData()
        {
            if (File.Exists(DataFilePathAdmin))
            {
                string jsonData2 = File.ReadAllText(DataFilePathAdmin);
                return JsonSerializer.Deserialize<Dictionary<string, Admin>>(jsonData2) ?? new Dictionary<string, Admin>();
            }
            return new Dictionary<string, Admin>();
        }

        // Save admin data to file
        public static void SaveAdminData(Dictionary<string, Admin> admins)
        {
            string jsonData2 = JsonSerializer.Serialize(admins, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataFilePathAdmin, jsonData2);
        }

        //  Default admin users
        public static void AdminUsers(Dictionary<string, Admin> admins)
        {
            if(admins.Count == 0)
            {
                admins["Petter"] = new Admin("Petter", "Startrek4life", 6);
                admins["Johan"] = new Admin("Johan", "HejaAIK", 7);

                SaveAdminData(admins);
            }
        }
    }
}
