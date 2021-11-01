using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    public class Elephant : IComparable<Elephant>
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool Vacant { get; set; }

        public Elephant(string name, int id, bool vacant)
        {
            Name = name;
            ID = id;
            Vacant = vacant;
        }

        //https://stackoverflow.com/questions/26868600/how-to-sort-a-list-of-objects-with-icomparable-and-icomparer
        public int CompareTo(Elephant next)
        {
            //Snygg kod
            return next.ID.CompareTo(this.ID);
        }
    }
}