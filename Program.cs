using System;
using System.Linq;

namespace ElephantBooking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "RIDE BIG!";

            DataHelper.LoadInDataOrSeed();

            //var intro = new Intro();
            //intro.Start();

            //var menues = new MenuHandler();
            //var user = DataHelper.Users.SingleOrDefault(x => x.IsLoggedIn);
            //if (user.IsAdmin)
            //{
            //    menues.PrintMenuAdmin();
            //}
            //else
            //{
            //    menues.PrintMenuCustumer();
            //}

            var menus = new MenuHandler();
            menus.Start();
            menus.LoginMenu();

            bool returnToMeny = true;
            while (returnToMeny)
            {
                var user = DataHelper.Users.SingleOrDefault(x => x.IsLoggedIn);
                if (user.IsAdmin)
                {
                    menus.PrintMenuAdmin();
                    menus.MainMenu();
                }
                else
                {
                    menus.PrintMenuCustumer();
                    menus.MainMenu();
                }

                if (menus.MainMenuOption == MainMenu.Exit || menus.StartMenuOption == StartMenu.Exit)
                {
                    returnToMeny = false;
                }
            }
            DataHelper.SaveCurrentFile();
        }
    }
}