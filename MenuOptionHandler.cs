using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    public class MenuOptionHandler : Intro
    {
        public void LoginMenu()
        {
            var userData = new UserData();
            switch (StartMenuOption)
            {
                case StartMenuOption.Login:
                    userData.LogIn();
                    ClearConsole();
                    break;

                case StartMenuOption.NewCustomer:
                    userData.CreateANewUser();
                    break;

                case StartMenuOption.Exit:
                    Exit();
                    break;

                default:
                    break;
            }
        }

        public void MainMenu()
        {
            var elephantData = new ElephantData();
            switch (MainMenuOption)
            {
                case ElephantBooking.MainMenuOption.Booking:
                    elephantData.BookAnElephant();
                    ClearConsole();
                    break;

                case ElephantBooking.MainMenuOption.Return:
                    elephantData.ReturnABooking();
                    ClearConsole();
                    break;

                case ElephantBooking.MainMenuOption.NewElephant:
                    ClearConsole();
                    elephantData.CreateANewElephant();
                    ClearConsole();
                    break;

                case ElephantBooking.MainMenuOption.DeleteElephant:
                    elephantData.DeleteAnElephant();
                    ClearConsole();
                    break;

                case ElephantBooking.MainMenuOption.Exit:
                    Exit();
                    break;

                default:
                    break;
            }
        }

        public void Exit()
        {
            Console.WriteLine("Thank you for visiting RIDE BIG!\n" +
                "Press enter to exit.");
            Console.WriteLine();
        }
    }
}