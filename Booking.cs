using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    public class Booking : IComparable<Booking>
    {
        public Elephant BookedElephant { get; set; }
        public string UsernameForBooking { get; set; }

        public int CompareTo(Booking next)
        {
            return next.UsernameForBooking.CompareTo(this.UsernameForBooking);
        }
    }
}