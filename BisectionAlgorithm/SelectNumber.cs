using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisectionAlgorithm
{
    class SelectNumber
    {
        // User selects a number from a range. Range is defined by two parameters(declared in SelectNumber.Run()).
        public int Select(int lowB, int upB)
        {
            Console.WriteLine($"Select a number {lowB} - {upB - 1}");

            try
            {
                int num = Int32.Parse(Console.ReadLine());

                // Ensures that user selects a value within range. Notice the difference between the conditions on the inclusion of
                // '=' in the statement reflects the behavior the behavior of the parameters in Random.Next(int, int). 
                if (num >= lowB && num < upB)
                {
                    Console.WriteLine();
                    return num;
                }
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
            }
            Console.WriteLine();
            // This statement is reached only when the runtime does not enter the if block above.
            return Select(lowB, upB);
        }

        // Computer selects a random number within a range defined by the method's parameters.
        public int Guess(int lowerBound, int upperBound)
        {
            var rnd = new Random();
            return rnd.Next(lowerBound, upperBound);
        }

        // User tells computer whether its guess is over/under the users selected int value.
        // This method recurses until guess == selected value.
        public void Hint(int number, int guess, int iterations, int lowB, int upB)
        {
            Console.Clear();
            Console.WriteLine($"Number of guesses: {iterations}");
            Console.WriteLine();
            Console.WriteLine($"Is the number {guess}?");
            Console.WriteLine($"Your secret number: {number}");
            Console.WriteLine();
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
                        Console.Clear();
                        Console.WriteLine($"Computer guessed the number in ({iterations}) tries.");
                        Console.WriteLine();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Try again.");
                        Hint(number, guess, iterations, lowB, upB);
                        return;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine();
                Hint(number, guess, iterations, lowB, upB);
                return;
            }
            // Increments only when a new guess is called. Recursions above pass the same guess value
            // that entered the method when user's input is invalid.
            iterations++;
            Hint(number, Guess(lowB, upB), iterations, lowB, upB);
        }

        // Parameters must be ints greater than 0, where upB >= lowB.
        public void Run(int lowB, int upB)
        {
            Hint(Select(lowB, upB), Guess(lowB, upB), 1, lowB, upB);
        }
    }
}
