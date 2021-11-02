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

            switch (Option)
            {
                case Meny.Booking:
                    BookAnElephant();
                    break;

                case Meny.Cancel:
                    CancelABooking();
                    break;

                case Meny.NewElephant:
                    CreateANewElephant();
                    break;

                case Meny.DeleteElephant:
                    DeleteAnElephant();
                    break;

                case Meny.EndThis:
                    EndThis();
                    break;

                default:
                    break;
            }
        }

        public void BookAnElephant()
        {
            PrintVacantList();

            bool again = true;
            while (again)
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
                    Console.WriteLine("Something went wrong.");
                    Console.ForegroundColor = ConsoleColor.White;

                    throw;
                }
            }
        }

        public void CancelABooking()
        {
            PrintOccupiedList();
            bool again = true;
            while (again)
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

        public void EndThis()
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