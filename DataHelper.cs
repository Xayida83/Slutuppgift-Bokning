using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    public static class DataHelper
    {
        public static List<Booking> Bookings = BookingSeed();
        public static List<Elephant> Elephants = ElephantSeed();

        private static List<Booking> BookingSeed()
        {
            return new List<Booking>
            {
            new Booking{BookedElephant = new Elephant("Pelle",1,false), IsActive=false},
            new Booking{BookedElephant = new Elephant("Lisa",2,true), IsActive=true}
            };
        }

        private static List<Elephant> ElephantSeed()
        {
            var list = new List<Elephant>
            {
            new Elephant(name: "Sandra", id: 31, vacant: true),
            new Elephant(name: "Anders", id: 32, vacant: false),
            new Elephant(name: "Sören", id: 33, vacant: false),
            new Elephant(name: "Ida", id: 34, vacant: true),
            new Elephant(name: "Krokus", id: 35, vacant: false),
            new Elephant(name: "Snoken", id: 36, vacant: true),
            new Elephant(name: "Sofia", id: 37, vacant: false),
            new Elephant(name: "Erik", id: 38, vacant: true)
            };
            list.Sort();
            return list;
        }

        public static void AddItem()
        {
            throw new NotImplementedException();
        }

        public static void GetItem()
        {
            throw new NotImplementedException();
        }

        public static void GetItems()
        {
            throw new NotImplementedException();
        }

        public static void UpdateElephant(Elephant model)
        {
            var current = Elephants.SingleOrDefault(x => x.ID == model.ID);
            Elephants.Remove(current);
            Elephants.Add(model);
            Elephants.Sort();
        }

        public static void DeleteItem()
        {
            throw new NotImplementedException();
        }
    }
}