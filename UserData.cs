using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    public class UserData : Intro
    {
        /// <summary>
        /// Hanterar olika skeden av Elephant klassen.
        /// </summary>
        public void LogIn()
        {
            while (true)
            {
                string name = CheckString("Your username: ");
                string password = CheckString("Your password: ");

                var result = DataHelper.Users.SingleOrDefault(x => x.UserName == name && x.Password == password);
                if (result is null || result.UserName != name || result.Password != password)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The password or username is wrong. Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;

                    continue;
                }

                result.IsLoggedIn = true;
                DataHelper.UpdateUser(result);
                break;
            }
        }

        public void CreateANewUser()
        {
            Console.WriteLine("Fill in the form, please.");
            string name = CheckString("Your full name: ");
            string phoneNumber = CheckPhoneNumber("Phonenumber: ");
            string userName = CheckString("User name: ");

            while (true)
            {
                var result = DataHelper.Users.SingleOrDefault(x => x.UserName == userName);
                if (result != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The username is wrong. Please try a difrent one.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }
            string password = CheckString("Password: ");
            Console.WriteLine();

            DataHelper.AddUser(new User(fullName: name, phonenumber: phoneNumber, userName: userName, password: password, isAdmin: false, isLoggedIn: true));
        }
    }
}