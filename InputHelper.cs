using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    /// <summary>
    /// Här validerars olika värden när användare väljer i menyerna.
    /// </summary>
    public class InputHelper
    {
        public StartMenuOption CheckEnum(string question)
        {
            (int left, int top) = Console.GetCursorPosition();

            StartMenuOption selection;
            bool validInput;
            StartMenuOption result;
            while (true)
            {
                do
                {
                    Console.Write(question);
                    validInput = Enum.TryParse(Console.ReadLine(), out selection);

                    if (!validInput)
                    {
                        ClearCurrentLine(left, top);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not a number, please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!validInput);
                try
                {
                    var enumName = Enum.GetName(typeof(StartMenuOption), selection);
                    return result = (StartMenuOption)Enum.Parse(typeof(StartMenuOption), enumName);
                }
                catch (Exception)
                {
                    ClearCurrentLine(left, top);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose a number 1-3, please try again");
                    Console.ForegroundColor = ConsoleColor.White;

                    continue;
                }
            }
        }

        public MainMenuOption CheckEnumMenu(string question)
        {
            (int left, int top) = Console.GetCursorPosition();

            MainMenuOption selection;
            bool validInput;
            MainMenuOption result;
            while (true)
            {
                do
                {
                    Console.Write(question);
                    validInput = Enum.TryParse(Console.ReadLine(), out selection);

                    if (!validInput)
                    {
                        ClearCurrentLine(left, top);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not a number, please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!validInput);
                try
                {
                    var enumName = Enum.GetName(typeof(MainMenuOption), selection);
                    return result = (MainMenuOption)Enum.Parse(typeof(MainMenuOption), enumName);
                }
                catch (Exception)
                {
                    ClearCurrentLine(left, top);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose a number from menu please and try again");
                    Console.ForegroundColor = ConsoleColor.White;

                    continue;
                }
            }
        }

        public int CheckInt(string questionForInt)
        {
            (int left, int top) = Console.GetCursorPosition();
            bool validInput;
            int result;
            do
            {
                Console.Write(questionForInt);
                validInput = int.TryParse(Console.ReadLine(), out result);
                if (!validInput)
                {
                    ClearCurrentLine(left, top);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to write a number, please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!validInput);
            return result;
        }

        public string CheckString(string questionForString)
        {
            (int left, int top) = Console.GetCursorPosition();
            bool notValidInput;
            string result;
            do
            {
                Console.Write(questionForString);
                result = Console.ReadLine();
                notValidInput = String.IsNullOrEmpty(result);
                if (notValidInput)
                {
                    ClearCurrentLine(left, top);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong, please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (notValidInput);
            return result;
        }

        public string CheckPhoneNumber(string questionForPhoneNumber)
        {
            (int left, int top) = Console.GetCursorPosition();
            bool validInput = true;
            string result;
            do
            {
                Console.Write(questionForPhoneNumber);
                result = Console.ReadLine();
                var resultCharArray = result.ToCharArray();

                for (int i = 0; i < resultCharArray.Length; i++)
                {
                    if (!char.IsDigit(resultCharArray[i]))
                    {
                        validInput = false;
                        break;
                    }
                }
                validInput = result.Length == 10 && validInput;
                if (!validInput)
                {
                    ClearCurrentLine(left, top);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to write a 10 didget phonenumber, please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!validInput);
            return result;
        }

        private static void ClearCurrentLine(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(left, top);
        }
    }
}