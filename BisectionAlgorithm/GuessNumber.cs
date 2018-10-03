using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisectionAlgorithm
{
    class GuessNumber
    {
        private int LBound = 1;
        private int UBound = 1000;

        public int SelectRndNum()
        {
            var rnd = new Random();
            return rnd.Next(1, 1001);
        }

        // returns an int guessed by user
        public int Guess(int lBound, int uBound)
        {
            try
            {
                Console.WriteLine($"Guess a number between {lBound} and {uBound}");
                // user inputs guess
                int guess = Int32.Parse(Console.ReadLine());

                // return value and exit the method if guess is a valid input between 1 and 1000
                if (guess > 0 && guess < 1001)
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
            return Guess(lBound, uBound);
        }

        // checks if guess == number, tells user if guess is over/under, then recurses
        public void HighOrLow(int number, int guess, int iterations)
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
                this.UBound = guess > number ? guess - 1 : this.UBound;
                this.LBound = guess < number ? guess + 1 : this.LBound;

                Console.Clear();
                Console.WriteLine($"Number of guesses {iterations}");
                Console.WriteLine();
                Console.WriteLine($"The secret number is {(guess < number ? "greater" : "less")} than {guess}.");
            }

            Console.WriteLine();
            // Guess() is called from parameter list before recursion.
            HighOrLow(number, Guess(this.LBound, this.UBound), iterations);
        }

        public void Run()
        {
            HighOrLow(SelectRndNum(), Guess(this.LBound, this.UBound), 0);
        }
    }
}