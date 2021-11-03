using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    public class InputHelper
    {
        public StartMenu CheckEnum(string question)
        {
            (int left, int top) = Console.GetCursorPosition();

            StartMenu selection;
            bool validInput;
            StartMenu result;
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
                        Console.WriteLine("Something went wrong, please try again");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!validInput);
                try
                {
                    var enumName = Enum.GetName(typeof(StartMenu), selection);
                    return result = (StartMenu)Enum.Parse(typeof(StartMenu), enumName);
                }
                catch (Exception)
                {
                    ClearCurrentLine(left, top);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong, please try again");
                    Console.ForegroundColor = ConsoleColor.White;

                    continue;
                }
            }
        }

        public Menu CheckEnumMenu(string question)
        {
            (int left, int top) = Console.GetCursorPosition();

            Menu selection;
            bool validInput;
            Menu result;
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
                        Console.WriteLine("Something went wrong, please try again");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!validInput);
                try
                {
                    var enumName = Enum.GetName(typeof(Menu), selection);
                    return result = (Menu)Enum.Parse(typeof(Menu), enumName);
                }
                catch (Exception)
                {
                    ClearCurrentLine(left, top);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong, please try again");
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
                    Console.WriteLine("Something went wrong, please try again.");
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
                    Console.WriteLine("Something went wrong, pleas try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (notValidInput);
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