using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    public class Method : Intro
    {
        public void Options()
        {
            Start();
            switch (FirstOption)
            {
                case StartMenu.Login:
                    LogIn();
                    break;

                case StartMenu.NewCustomer:
                    CreateANewUser();
                    break;

                case StartMenu.Exit:
                    Exit();
                    break;

                default:
                    break;
            }

            switch (Option)
            {
                case Menu.Booking:
                    BookAnElephant();
                    break;

                case Menu.Cancel:
                    CancelABooking();
                    break;

                case Menu.NewElephant:
                    CreateANewElephant();
                    break;

                case Menu.DeleteElephant:
                    DeleteAnElephant();
                    break;

                case Menu.Exit:
                    Exit();
                    break;

                default:
                    break;
            }
        }

        private void LogIn()
        {
            while (true)
            {
                string name = CheckString("Your username: ");
                string password = CheckString("Your password: ");
                try
                {
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

                    if (result.IsAdmin == true)
                    {
                        PrintMenuAdmin();
                        break;
                    }
                    if (result.IsAdmin == false)
                    {
                        PrintMenuCustumer();
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong. Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    throw;
                }
            }
        }

        private void CreateANewUser()
        {
            Console.WriteLine("Fill in the form, please.");
            string name = CheckString("Your full name: ");
            int number = CheckInt("Phonenumber: ");
            string userName = CheckString("User name: ");

            while (true)
            {
                //try
                // {
                var result = DataHelper.Users.SingleOrDefault(x => x.UserName == userName);
                if (result != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The username is wrong. Please try a difrent one.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
                //}
                //catch (Exception)
                //{
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    Console.WriteLine("Something went wrong. Please try again.");
                //    Console.ForegroundColor = ConsoleColor.White;
                //    continue;
                //}
            }
            string password = CheckString("Password: ");
            Console.WriteLine();

            DataHelper.AddUser(new User(fullName: name, phonenumber: number, userName: userName, password: password, isAdmin: false, isLoggedIn: true));
            Console.WriteLine("Welcome to RIDE BIG!");
            PrintMenuCustumer();
        }

        public void BookAnElephant()
        {
            PrintVacantList();

            while (true)
            {
                int idNumber = CheckInt("Choose elephant by writing it's id number: ");
                try
                {
                    var result = DataHelper.Elephants.SingleOrDefault(x => x.ID == idNumber && x.Vacant == true);
                    if (result is null || result.ID != idNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The ID number is wrong. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;

                        continue;
                    }
                    result.Vacant = false;
                    DataHelper.UpdateElephant(result);
                    Console.WriteLine();
                    Console.WriteLine("You have rented the elephant.");
                    Console.WriteLine();
                    break;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong. Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;

                    throw;
                }
            }
        }

        public void CancelABooking()
        {
            PrintOccupiedList();

            while (true)
            {
                int idNumber = CheckInt("Write ID number of the Elepant that you are returning: ");

                try
                {
                    var result = DataHelper.Elephants.SingleOrDefault(x => x.ID == idNumber && x.Vacant == false);
                    if (result is null || result.ID != idNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The ID number is wrong.Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;

                        continue;
                    }
                    result.Vacant = true;
                    DataHelper.UpdateElephant(result);
                    Console.WriteLine();
                    Console.WriteLine("You have return the elephant.");
                    Console.WriteLine();
                    break;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong.");
                    Console.ForegroundColor = ConsoleColor.White;

                    throw;
                }
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong, please try again.");
                    Console.ForegroundColor = ConsoleColor.White;

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
            PrintOccupiedList();
            PrintVacantList();
            int idNumber;
            while (true)
            {
                idNumber = CheckInt("Write the Id number of the elephant you like to delete: ");
                var elefant = DataHelper.Elephants.SingleOrDefault(x => x.ID == idNumber);
                if (elefant is null || elefant.ID != idNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong, please try again.");
                    Console.ForegroundColor = ConsoleColor.White;

                    continue;
                }
                break;
            }

            DataHelper.DeleteElephant(idNumber);
            Console.WriteLine();
            Console.WriteLine("The elephant has been deleted.");
            Console.WriteLine();
        }

        public void Exit()
        {
            Console.WriteLine("Thank you for visiting RIDE BIG!\n" +
                "Press enter to exit.");
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