using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsumeTheDogAPI
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the dog consumer!");
            ShowList();
        }

        public static void ShowList()
        {
            Console.WriteLine("What would you like to do? (Please type a numeric number and hit enter)");
            Console.WriteLine("1) Print all dog breeds." +
                            "\n2) Download and save a random dog image." +
                            "\n3) Print all sub-breeds of a user specified breed." +
                            "\n4) Download and save an image of a user specified breed." +
                            "\n5) Exit program" +
                            "\n");
   
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                switch (userInput)
                {
                    case 1:
                        Case1.PrintAllBreeds();
                        break;
                    case 2:
                        Case2.SaveRandomDogImage();
                        break;
                    case 3:
                        Case3.PrintSpecifiedSubBreeds();
                        break;
                    case 4:
                        Case4.SaveSpecifiedBreedImage();
                        break;
                    case 5:
                        Console.WriteLine("Exiting program");
                        System.Threading.Thread.Sleep(400);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("{0} is not a valid option.",userInput);
                        ShowList();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number, for example '2'.");
                ShowList();
            }
        }
    }
}
