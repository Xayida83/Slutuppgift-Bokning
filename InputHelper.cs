using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElephantBooking
{
    public class InputHelper
    {
        public Meny CheckEnum(string question)
        {
            (int left, int top) = Console.GetCursorPosition();

            Meny selection;
            bool validInput;
            Meny result;
            while (true)
            {
                do
                {
                    Console.Write(question);
                    validInput = Enum.TryParse(Console.ReadLine(), out selection);

                    if (!validInput)
                    {
                        ClearCurrentLine(left, top);
                        Console.WriteLine("Something went wrong, try again");
                    }
                } while (!validInput);
                try
                {
                    var enumName = Enum.GetName(typeof(Meny), selection);
                    return result = (Meny)Enum.Parse(typeof(Meny), enumName);
                }
                catch (Exception)
                {
                    ClearCurrentLine(left, top);
                    Console.WriteLine("Something went wrong, try again");
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
                    Console.WriteLine("Something went wrong, pleas try again.");
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