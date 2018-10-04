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
        public int Select(Bounds bounds)
        {
            Console.WriteLine($"Select your secret number {bounds.LowerBound} - {bounds.UpperBound - 1}");

            try
            {
                int num = Int32.Parse(Console.ReadLine());

                // Ensures that user selects a value within range. Notice the difference between the conditions on the inclusion of
                // '=' in the statement reflects the behavior the behavior of the parameters in Random.Next(int, int). 
                if (num >= bounds.LowerBound && num < bounds.UpperBound)
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
            return Select(bounds);
        }

        // Computer selects a random number within a range defined by the method's parameters.
        public int Guess(Bounds bounds)
        {
            var rnd = new Random();
            return rnd.Next(bounds.LowerBound, bounds.UpperBound);
        }

        // User tells computer whether its guess is over/under the users selected int value.
        // This method recurses until guess == selected value.
        public void Hint(int number, int guess, int iterations, Bounds bounds)
        {
            // Lie detection. Runtime enters this block if upper and lower bounds converge
            // without containing the computer's guess. Located at top of this block, since
            // bounds are set in switch statement later in the method before recursion.
            if (number < bounds.LowerBound || number >= bounds.UpperBound)
            {
                Console.WriteLine();
                Console.WriteLine("You are a liar. Never play this game again.");
                Console.WriteLine();
                return;
            }

            // main display
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
                        bounds.UpperBound = guess;
                        break;
                    case 2:
                        bounds.LowerBound = guess + 1;
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine($"Computer guessed the number in ({iterations}) tries.");
                        Console.WriteLine();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Try again.");
                        Hint(number, guess, iterations, bounds);
                        return;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine();
                Hint(number, guess, iterations, bounds);
                return;
            }
            // Increments only when a new guess is called. Recursions above pass the same guess value
            // that entered the method when user's input is invalid.
            iterations++;
            Hint(number, Guess(bounds), iterations, bounds);
        }

        // Parameters must be ints greater than 0, where bounds.UpperBound >= bounds.LowerBound.
        public void Run(Bounds bounds)
        {
            Hint(Select(bounds), Guess(bounds), 1, bounds);
        }
    }
}
