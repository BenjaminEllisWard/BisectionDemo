using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisectionAlgorithm
{
    class SelectNumber
    {
        public int Select()
        {
            Console.WriteLine("Select a number 1 - 100");

            try
            {
                int num = Int32.Parse(Console.ReadLine());

                if (num > 0 && num < 101)
                {
                    Console.WriteLine();
                    return num;
                }
                Console.Clear();
                Console.WriteLine("Invalid negative or zero input. Try again.");
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
            }
            Console.WriteLine();
            return Select();
        }

        public int Guess(int lowerBound, int upperBound)
        {
            var rnd = new Random();
            return rnd.Next(lowerBound, upperBound);
        }

        public void Hint(int number, int guess, int iterations, int lowB, int upB)
        {
            iterations++;

            Console.WriteLine($"Is the number {guess}?");
            Console.WriteLine();
            Console.WriteLine($"Your secret number: {number}");
            Console.WriteLine($"Select an option to tell the computer:");
            Console.WriteLine($"1: Guess is too high  2: Guess is too low  3: Guess is correct");

            try
            {
                int option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        upB = guess;
                        break;
                    case 2:
                        lowB = guess + 1;
                        break;
                    case 3:
                        Console.WriteLine($"Computer guessed the number in ({iterations}) tries.");
                        return;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine();
            }

            Hint(number, Guess(lowB, upB), iterations, lowB, upB);
        }

        public void Run()
        {
            Hint(Select(), Guess(1, 101), 0, 1, 101);
        }
    }
}
