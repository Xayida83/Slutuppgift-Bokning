using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElephantBooking
{
    public class User : IComparable<User>
    {
        public string FullName { get; set; }

        public int Phonenumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLoggedIn { get; set; }

        public User(string fullName, int phonenumber, string userName, string password, bool isAdmin = false, bool isLoggedIn = false)
        {
            FullName = fullName;
            UserName = userName;
            Phonenumber = phonenumber;
            Password = password;
            IsAdmin = isAdmin;
            IsLoggedIn = isLoggedIn;
        }

        public int CompareTo(User next)
        {
            return next.FullName.CompareTo(this.FullName);
        }
    }
}