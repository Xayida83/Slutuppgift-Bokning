using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    public class Intro : InputHelper
    {
        public Meny Option { get; set; }

        public void Start()
        {
            Console.WriteLine("WELCOME TO RENTALSERVICE RIDE BIG!".PadLeft(Console.WindowWidth / 2));

            Console.WriteLine();
            Console.WriteLine("Would you like to rent an elephant, press 1\n" +
                "Would you like to cancel a reservation, press 2\n" +
                "Would you like to register a new elephant, press 3\n" +
                "Would you like to delete an elephant, press 4 \n" +
                "When you are done, please press 5");
            Console.WriteLine();
            //Detta är en ändring
            Option = CheckEnum("Select from the menu by typing the correct number: "); //CheckEnum är en metod som kollar om val är möjligt
            Console.WriteLine();
        }
    }
}