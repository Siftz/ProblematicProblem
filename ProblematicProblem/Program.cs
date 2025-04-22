using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public static class Program
    {
        static Random  _rng = new Random();
        static bool _cont = true;

        static List<string> _activities = new List<string>()
            { "Movies", "Paintball", "Bowling", "Laser Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string userInput = Console.ReadLine()?.ToLower(); // null check
            _cont = userInput == "yes";
            Console.WriteLine();
            
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Name cannot be empty. Please try again.");
                return;
            }
            Console.WriteLine();
            
            Console.Write("What is your age? ");
            string ageInput = Console.ReadLine();
            if (int.TryParse(ageInput, out int userAge)) // null check again
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid age input. PLease try again.");
                return;
            }
            
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string listInput = Console.ReadLine()?.ToLower(); // null check
            bool seeList = listInput == "sure";
            if (seeList) 
            {
                foreach (string activity in _activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                string addInput = Console.ReadLine()?.ToLower();
                bool addToList = addInput == "yes";
                Console.WriteLine();
                
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    if (!string.IsNullOrEmpty(userAddition))
                    {
                        _activities.Add(userAddition);
                    }

                    foreach (string activity in _activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addInput = Console.ReadLine()?.ToLower(); // null check
                    addToList = addInput == "yes";
                }
            }

            while (_cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                int randomNumber = _rng.Next(_activities.Count);
                string randomActivity = _activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    _activities.Remove(randomActivity);
                    
                    randomNumber = _rng.Next(_activities.Count);
                    randomActivity = _activities[randomNumber];
                }

                Console.Write(
                    $"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                string contInput = Console.ReadLine()?.ToLower(); // null check
                _cont = contInput == "redo";
            }
        }
    }
}