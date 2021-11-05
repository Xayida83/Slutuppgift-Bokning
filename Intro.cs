using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    /// <summary>
    /// Skriver ut menyena och sparar valet man har gjort.
    /// </summary>
    public class Intro : InputHelper
    {
        public MainMenuOption MainMenuOption { get; set; }
        public StartMenuOption StartMenuOption { get; set; }

        public void Start()
        {
            Console.WriteLine("WELCOME TO RENTALSERVICE RIDE BIG!".PadLeft(Console.WindowWidth / 2));
            Console.WriteLine("Login press 1");
            Console.WriteLine("New user press 2");
            Console.WriteLine("To exit press 3");

            StartMenuOption = CheckEnum("Select from the menu by typing the correct number: ");
            Console.WriteLine();
        }

        public void PrintMenuAdmin()
        {
            var bookingData = new BookingData();
            bookingData.PrintBooking();

            Console.WriteLine();
            Console.WriteLine("Rent an elephant, press 1\n" +
                "Return elephant, press 2\n" +
                "Register a new elephant, press 3\n" +
                "Delete an elephant, press 4 \n" +
                "Log out, please press 5");
            Console.WriteLine();

            MainMenuOption = CheckEnumMenu("Select from the menu by typing the correct number: ");
            Console.WriteLine();
        }

        public void PrintMenuCustumer()
        {
            var bookingData = new BookingData();
            bookingData.PrintBooking();

            Console.WriteLine();
            Console.WriteLine("Rent an elephant, press 1\n" +
                "Return elephant, press 2\n" +
                "Log out, please press 5");
            Console.WriteLine();
            while (true)
            {
                MainMenuOption = CheckEnumMenu("Select from the menu by typing the correct number: ");
                if (MainMenuOption == MainMenuOption.NewElephant || MainMenuOption == MainMenuOption.DeleteElephant)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You can choose number 1 or 5.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }
            Console.WriteLine();
        }
    }
}