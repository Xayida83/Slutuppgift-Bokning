using System;

namespace ElephantBooking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "RIDE BIG!";

            var booking = new Method();
            bool returnToMeny = true;
            while (returnToMeny)
            {
                booking.Options();
                if (booking.Option == Meny.EndThis)
                {
                    returnToMeny = false;
                }
            }
        }
    }
}