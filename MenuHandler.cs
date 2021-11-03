using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    public class MenuHandler : Intro
    {
        public void LoginMenu()
        {
            var userData = new UserData();
            switch (StartMenuOption)
            {
                case StartMenu.Login:
                    userData.LogIn();
                    break;

                case StartMenu.NewCustomer:
                    userData.CreateANewUser();
                    break;

                case StartMenu.Exit:
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
                case ElephantBooking.MainMenu.Booking:
                    elephantData.BookAnElephant();
                    break;

                case ElephantBooking.MainMenu.Cancel:
                    elephantData.CancelABooking();
                    break;

                case ElephantBooking.MainMenu.NewElephant:
                    elephantData.CreateANewElephant();
                    break;

                case ElephantBooking.MainMenu.DeleteElephant:
                    elephantData.DeleteAnElephant();
                    break;

                case ElephantBooking.MainMenu.Exit:
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