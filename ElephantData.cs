using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    /// <summary>
    /// Hanterar olika skeden av Elephant klassen.
    /// </summary>
    public class ElephantData : Intro
    {
        public void BookAnElephant()
        {
            PrintVacantList();

            while (true)
            {
                int idNumber = CheckInt("Choose elephant by writing it's id number: ");
                var elephant = DataHelper.Elephants.SingleOrDefault(x => x.ID == idNumber && x.Vacant == true);
                if (elephant is null || elephant.ID != idNumber)
                {
                    ConsoleTextColorRed("The ID number is wrong. Please try again.");
                    continue;
                }
                elephant.Vacant = false;
                DataHelper.UpdateElephant(elephant);
                var bookingData = new BookingData();
                bookingData.CreateBooking(elephant);

                Console.WriteLine();
                Console.WriteLine("You have rented the elephant.");
                Console.WriteLine();
                break;
            }
        }

        public void ReturnABooking()
        {
            while (true)
            {
                var currentBookings = DataHelper.Bookings.Where(x => x.UsernameForBooking == DataHelper.Users.SingleOrDefault(x => x.IsLoggedIn).UserName).ToList();
                if (currentBookings.Count == 0)
                {
                    Console.WriteLine("You have no current bookings");
                    break;
                }
                int idNumber = CheckInt("Write ID number of the Elepant that you are returning: ");
                var bookingToReturn = currentBookings.SingleOrDefault(x => x.BookedElephant.ID == idNumber);
                if (bookingToReturn is null)
                {
                    ConsoleTextColorRed("The ID number is wrong.Please try again.");
                    continue;
                }
                bookingToReturn.BookedElephant.Vacant = true;
                DataHelper.UpdateElephant(bookingToReturn.BookedElephant);

                DataHelper.DeleteBooking(bookingToReturn);

                Console.WriteLine();
                Console.WriteLine("You have returned the elephant.");
                Console.WriteLine();
                break;
            }
        }

        public void CreateANewElephant()
        {
            PrintOccupiedList();
            PrintVacantList();
            Console.WriteLine("Fill in this form please.");
            string name = CheckString("Name: ");
            int idNumber;
            while (true)
            {
                idNumber = CheckInt("ID: ");
                var elefant = DataHelper.Elephants.SingleOrDefault(x => x.ID == idNumber);
                if (!(elefant is null))
                {
                    ConsoleTextColorRed("This ID number is already in use. Please pick a new one.");
                    continue;
                }
                break;
            }

            string vacancy = CheckString("Vacant yes/no: ");
            vacancy.ToLower();
            bool free;
            if (vacancy == "yes")
            {
                free = true;
            }
            else
            {
                free = false;
            }

            DataHelper.AddElephant(new Elephant(name: name, id: idNumber, vacant: free));
            Console.WriteLine();
            Console.WriteLine("Your elephant have been saved.");
            Console.WriteLine();
        }

        public void DeleteAnElephant()
        {
            PrintVacantList();
            int idNumber;
            while (true)
            {
                idNumber = CheckInt("Write the Id number of the elephant you like to delete: ");
                var elephant = DataHelper.Elephants.SingleOrDefault(x => x.ID == idNumber);
                if (elephant is null || elephant.ID != idNumber)
                {
                    ConsoleTextColorRed("There is no elephant whit this ID number. Please try again.");
                    continue;
                }
                if (elephant.Vacant == false)
                {
                    ConsoleTextColorRed("The elephant is rented out.");
                    continue;
                }
                break;
            }

            DataHelper.DeleteElephant(idNumber);
            Console.WriteLine();
            Console.WriteLine("The elephant has been deleted.");
            Console.WriteLine();
        }

        public void PrintVacantList()
        {
            Console.WriteLine("These elephants are vacant.");
            Console.WriteLine();
            foreach (var animal in DataHelper.Elephants)
            {
                if (animal.Vacant == true)
                {
                    Console.WriteLine($"Name: {animal.Name} ID number: {animal.ID}");
                }
            }
            Console.WriteLine();
        }

        public void PrintOccupiedList()
        {
            Console.WriteLine("These elephants are occupied.");
            Console.WriteLine();
            foreach (var animal in DataHelper.Elephants)
            {
                if (animal.Vacant == false)
                {
                    Console.WriteLine($"Name: {animal.Name} ID number: {animal.ID}");
                }
            }
            Console.WriteLine();
        }
    }
}