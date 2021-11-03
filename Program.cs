using System;

namespace ElephantBooking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataHelper.LoadInDataOrSeed();
            Console.Title = "RIDE BIG!";

            var method = new Method();

            bool returnToMeny = true;
            while (returnToMeny)
            {
                method.Options();
                if (method.Option == Menu.Exit || method.FirstOption == StartMenu.Exit)
                {
                    returnToMeny = false;
                }
            }
            DataHelper.SaveCurrentFile();
        }
    }
}