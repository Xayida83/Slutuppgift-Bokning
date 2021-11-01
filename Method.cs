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
                int IdNumber = CheckInt("Choose elephant by writing it's id number: ");
                try
                {
                    var result = DataHelper.Elephants.SingleOrDefault(x => x.ID == IdNumber && x.Vacant == true);
                    result.Vacant = false;
                    DataHelper.UpdateElephant(result);
                    Console.WriteLine("You have rented the elephant.");
                    Console.WriteLine();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("The ID number is wrong. Pleas try again.");
                    throw;
                }

                //foreach (var animal in DataHelper.Elephants)
                //{
                //    if (IdNumber == animal.ID && animal.Vacant == true)
                //    {
                //        animal.Vacant = false;
                //        Console.WriteLine($"Elephant whit ID {IdNumber} is now occupied");
                //        Console.WriteLine();
                //        again = false;
                //        DataHelper.UpdateElephant(animal);
                //        break;
                //    }
                //    else if (IdNumber == animal.ID && animal.Vacant == false) //Skrivs inte ut alls
                //    {
                //        Console.WriteLine("This elephant is occupied.");
                //        Console.WriteLine();
                //        break;
                //    }
                //    else
                //    {
                //        Console.WriteLine("This elephant does not exixt."); //skrvier bara ut denna
                //        Console.WriteLine();
                //        break;
                //    }
                //}
            }
        }

        public void CancelABooking()
        {
            PrintOccupiedList();
            bool again = true;
            while (again)
            {
                int IdNumber = CheckInt("Write ID number of the Elepant that you are returning: ");

                try
                {
                    var result = DataHelper.Elephants.SingleOrDefault(x => x.ID == IdNumber && x.Vacant == false);
                    result.Vacant = true;
                    DataHelper.UpdateElephant(result);
                    Console.WriteLine("You have return the elephant.");
                    Console.WriteLine();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("The ID number is wrong. Pleas try again.");
                    throw;
                }
                //foreach (var animal in DataHelper.Elephants)
                //{
                //    if (IdNumber == animal.ID && animal.Vacant == false)
                //    {
                //        animal.Vacant = true;
                //        Console.WriteLine("You have returned the Elephant.");
                //        Console.WriteLine();
                //        again = false;
                //        break;
                //    }
                //    if (IdNumber == animal.ID && animal.Vacant == true)
                //    {
                //        Console.WriteLine("This elephant has not been rented out.");
                //        Console.WriteLine();
                //        break;
                //    }
                //    //Skriver man in rätt id nummer kommer det ändå upp att elefant inte finns.
                //    if (IdNumber != animal.ID)
                //    {
                //        Console.WriteLine("This elephant does not exixt.");
                //        Console.WriteLine();
                //        break;
                //    }
                //}
            }
        }

        public void CreateANewElephant()
        {
        }

        public void DeleteAnElephant()
        {
        }

        public void EndThis()
        {
            Console.WriteLine("Thank you for visiting Ride Big!\n" +
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
            Console.WriteLine("These elephants are Occupied.");
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