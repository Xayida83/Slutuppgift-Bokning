using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    public class Intro : InputHelper
    {
        public Menu Option { get; set; }
        public StartMenu FirstOption { get; set; }

        public void Start()
        {
            Console.WriteLine("WELCOME TO RENTALSERVICE RIDE BIG!".PadLeft(Console.WindowWidth / 2));
            Console.WriteLine("Login press 1");
            Console.WriteLine("New user press 2");
            Console.WriteLine("To exit press 3");

            FirstOption = CheckEnum("Select from the meny by typing the correct number: ");
            Console.WriteLine();
        }

        public void PrintMenuAdmin()
        {
            Console.WriteLine();
            Console.WriteLine("Rent an elephant, press 1\n" +
                "Cancel a reservation, press 2\n" +
                "Register a new elephant, press 3\n" +
                "Delete an elephant, press 4 \n" +
                "When you are done, please press 5");
            Console.WriteLine();

            Option = CheckEnumMenu("Select from the menu by typing the correct number: ");
            Console.WriteLine();
        }

        public void PrintMenuCustumer()
        {
            Console.WriteLine();
            Console.WriteLine("Rent an elephant, press 1\n" +
                "When you are done, please press 5");
            Console.WriteLine();
            while (true)
            {
                Option = CheckEnumMenu("Select from the menu by typing the correct number: ");
                if (Option == Menu.Cancel || Option == Menu.NewElephant || Option == Menu.DeleteElephant)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You can choose between number 1 and 5.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }
            Console.WriteLine();
        }
    }
}