using System;

namespace LuckyTicket
{
    class Program
    {

        static bool Check(ref string input) //Checking correct input
        {
            if (!Int32.TryParse(input, out int trash)) return false; // Is it digit
            if (input.Length > 8 || input.Length < 4) return false; // Is it right length

            if (input.Length % 2 == 1) input = input.Insert(0, "0");
            return true;
        }

        static bool Parcing(string input) //Parce our string
        {
            int sumRight = 0, sumLeft = 0;
            for (int i = 0; i < input.Length / 2; i++)
            {
                sumLeft += Int32.Parse(input[i].ToString());
                sumRight += Int32.Parse(input[input.Length - i - 1].ToString());
            }
            return sumLeft == sumRight ? true : false;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                // Reading string
                string input;
                Console.WriteLine("Input ticket number:");
                input = Console.ReadLine();
                //

                if (input == "exit") break;

                // Check and Parse our string
                if (Check(ref input))
                {
                    bool isLucky = Parcing(input);
                    Console.WriteLine(isLucky ? "\nYou`ve got a lucky ticket!\n" : "\nYou'll got it next time\n",
                            isLucky ? Console.ForegroundColor = ConsoleColor.Green : Console.ForegroundColor = ConsoleColor.Red);
                }
                else Console.WriteLine("\nWrong input!\n", Console.ForegroundColor = ConsoleColor.Red);
                //

                Console.ResetColor();
            }
        }
    }
}
