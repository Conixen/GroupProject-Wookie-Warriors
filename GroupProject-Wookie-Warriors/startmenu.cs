﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_Wookie_Warriors
{
    public class Startmenu
    {
        public void Menu()
        {
            var login = new Login();
            //Startmenu when program starts. 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the login menu!\n" +
                "\n1. Login as customer\n" +
                "2. Login as admin\n" +
                "-------------------------");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    login.LoginUser();
                    break;

                case "2":
                    Console.Clear();
                    LoginAdmin();
                    break;

                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        public void LoginAdmin()
        {

        }
    }
}
