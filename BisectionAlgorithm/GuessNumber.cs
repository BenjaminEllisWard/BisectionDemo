using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisectionAlgorithm
{
    class GuessNumber
    {
        public int SelectRndNum(Bounds bounds)
        {
            var rnd = new Random();
            return rnd.Next(bounds.LowerBound, bounds.UpperBound);
        }

        // returns an int guessed by user
        public int Guess(Bounds bounds)
        {
            try
            {
                Console.WriteLine($"Guess a number between {bounds.LowerBound} and {bounds.UpperBound - 1}");
                // user inputs guess
                int guess = Int32.Parse(Console.ReadLine());

                // return value and exit the method if guess is a valid input between 1 and 1000
                if (guess >= bounds.LowerBound && guess < bounds.UpperBound)
                {
                    return guess;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine();
            }

            // Recursion executes only if method cannot return a value from try block above
            return Guess(bounds);
        }

        // checks if guess == number, tells user if guess is over/under, then recurses
        public void HighOrLow(int number, int guess, int iterations, Bounds bounds)
        {
            iterations++;
            
            if (guess == number)
            {
                Console.WriteLine();
                Console.WriteLine($"You guessed the secret number ({number}) correctly.");
                Console.WriteLine($"Number of guesses: {iterations}");
                Console.WriteLine();
                return;
            }
            else
            {
                bounds.UpperBound = guess > number ? guess : bounds.UpperBound;
                bounds.LowerBound = guess < number ? guess + 1 : bounds.LowerBound;

                Console.Clear();
                Console.WriteLine($"Number of guesses {iterations}");
                Console.WriteLine();
                Console.WriteLine($"The secret number is {(guess < number ? "greater" : "less")} than {guess}.");
            }

            Console.WriteLine();
            // Guess() is called from parameter list before recursion.
            HighOrLow(number, Guess(bounds), iterations, bounds);
        }

        public void Run(Bounds bounds)
        {
            HighOrLow(SelectRndNum(bounds), Guess(bounds), 0, bounds);
        }
    }
}