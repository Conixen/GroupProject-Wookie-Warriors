using GroupProject_Wookie_Warriors;
using System;
using System.Collections.Generic;

public class CreateAccount
{
    private readonly Login _login;

    public CreateAccount(Login login)
    {
        _login = login;
    }

    public void CreateUserWithAccounts(string username, string password, int id, decimal initialBalance)
    {
        if (_login.users.ContainsKey(username.ToLower())) // NEW CODE: Normalize username to lowercase
        {
            Console.WriteLine("Username already exists. Please choose another.");
            return;
        }

        // Create the user and add to dictionary
        var newUser = new User(username.ToLower(), password, id); // NEW CODE: Store username in lowercase
        _login.users[username.ToLower()] = newUser; // NEW CODE: Add user with normalized username

        // Add default account
        var defaultAccount = new Account("Default Account", initialBalance, "SEK");
        newUser.AddAccount(defaultAccount);

        Console.WriteLine($"User '{username}' created successfully!");

        // Save updated users dictionary
        DataManage.SaveData(_login.users); // NEW CODE: Save users immediately after creation
    

        foreach (var user in _login.users)
        {
            Console.WriteLine($"- {user.Key}");
        }
    }
}



