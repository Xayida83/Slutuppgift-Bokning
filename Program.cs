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

            var menues = new MenuHandler();
            menues.Start();
            menues.LoginMenu();

            bool returnToMeny = true;
            while (returnToMeny)
            {
                if (menues.MainMenuOption == MainMenu.Exit || menues.StartMenuOption == StartMenu.Exit)
                {
                    returnToMeny = false;
                }
                else
                {
                    var user = DataHelper.Users.SingleOrDefault(x => x.IsLoggedIn);//exit fungerar inte. Hamnar här

                    if (user.IsAdmin)
                    {
                        menues.PrintMenuAdmin();
                        menues.MainMenu();
                    }
                    else
                    {
                        menues.PrintMenuCustumer();
                        menues.MainMenu();
                    }
                };
            }
            DataHelper.SaveCurrentFile();
        }
    }
}