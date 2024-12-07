﻿using System;
using System.Collections.Generic;

namespace GroupProject_Wookie_Warriors
{
    public class CreateAccount : Login
    {

            // Method to create a new user and add them to the users dictionary
            public void CreateNewUser(string username, string password, int id)
        {
            if (users.ContainsKey(username))
            {
                Console.WriteLine("Username already exists. Please choose another.");
                return;
            }

            var newUser = new User(username, password, id); // Create a new User object
            users[username] = newUser; // Add the user to the dictionary

            Console.WriteLine($"User '{username}' created successfully!");
        }

        // Method to set up accounts for a user
        public void SetupDefaultAccounts(string username)
        {
            if (!admins.TryGetValue(username, out Admin admin))
            {
                Console.WriteLine($"User '{username}' does not exist.");
                return;
            }
            // Add default accounts for the user
            var savingsAccount = new Account("Savings Account", 1000.00m, "SEK");
            var salaryAccount = new Account("Salary Account", 5000.00m, "SEK");

            admin.AddAccount(savingsAccount);
            admin.AddAccount(salaryAccount);

            Console.WriteLine($"Default accounts created for user '{username}':");
            foreach (var account in admin.Accounts)
            {
                Console.WriteLine($"- {account}");
            }

        }

        public void DisplayCreateAccountMenu(string username)
        {
            if (!admins.TryGetValue(username, out Admin admin))
            {
                Console.WriteLine($"User '{username}' does not exist.");
                return;
            }

            Console.WriteLine($"Welcome, {username}! Let's create a new account.");
            Console.Write("Enter account type (e.g., Savings, Salary, Investment): ");
            string accountType = Console.ReadLine();

            Console.Write("Enter initial balance: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal initialBalance))
            {
                Console.WriteLine("Invalid balance. Please enter a numeric value.");
                return;
            }

            Console.Write("Enter currency (e.g., SEK, USD, EUR): ");
            string currency = Console.ReadLine();

            var customAccount = new Account(accountType, initialBalance, currency);
            admin.AddAccount(customAccount);

            Console.WriteLine($"Custom account '{accountType}' created successfully for user '{username}'!");
            Console.WriteLine($"Account Details: {customAccount}");
        }

 
    }
}



