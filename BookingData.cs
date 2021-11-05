using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    /// <summary>
    /// Hanterar olika skeden av Booking klassen.
    /// </summary>
    public class BookingData
    {
        public void CreateBooking(Elephant elephant)
        {
            var user = DataHelper.Users.SingleOrDefault(x => x.IsLoggedIn == true);

            var booking = new Booking { BookedElephant = elephant, UsernameForBooking = user.UserName };

            DataHelper.AddBooking(booking);
        }

        public void PrintBooking()
        {
            var user = DataHelper.Users.SingleOrDefault(x => x.IsLoggedIn == true);
            var bookings = DataHelper.Bookings.Where(x => x.UsernameForBooking == user.UserName);
            if (bookings != null)
            {
                foreach (var booking in bookings)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You have a booking on this elephant: {booking.BookedElephant.Name} Whit ID: {booking.BookedElephant.ID}");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You have no bookings.");
            }
        }
    }
}