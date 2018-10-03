using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisectionAlgorithm
{
    class Bisection
    {
        // Bisection method
        public void Guess(int guess, int[] list, int iterations)
        {
            // this if guess matches the member in middle of array
            if (guess == list[list.Length / 2])
            {
                Console.WriteLine($"Value({guess}) found at newArray[{Array.IndexOf(list, guess)}]");
                Console.WriteLine($"Value found after {iterations} bisections.");
                return;
            }

            // this if guess does not match member in middle of array
            else
            {
                Console.WriteLine($"{guess} is {(guess > list[list.Length / 2] ? "greater" : "less")}" +
                    $" than middle value: {list[list.Length / 2]}");

                // set list to half that contains guess
                list = guess > list[list.Length / 2] ? list.Skip(list.Length / 2).ToArray() :
                    list.Take(list.Length / 2).ToArray();

                // count iterations
                iterations++;

                // write new array with members separated by ', '
                Console.WriteLine($"newArray = {{{string.Join(", ", list)}}}");
            }

            Console.WriteLine();
            Guess(guess, list, iterations);
        }

        // Returns user input as an int to determine the number that will be searched for within an array.
        public int UserInputInt(int[] list)
        {
            try
            {
                Console.WriteLine($"Select a number 1 - {list[list.Length - 1]}");
                int guess = Int32.Parse(Console.ReadLine());
                Console.WriteLine();

                if (guess < list.Length && guess > 0)
                {
                    return guess;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Try again.");
                    Console.WriteLine();
                    guess = UserInputInt(list);
                    return guess;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine();
            }

            int otherGuess = UserInputInt(list);
            return otherGuess;
        }

        // User input returns an int that will determine size of array created in Run().
        public int UserInputArray()
        {
            try
            {
                Console.WriteLine("How big is your array?");
                int size = Int32.Parse(Console.ReadLine());
                Console.WriteLine();

                if (size <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid negative or zero input. Try again.");
                    Console.WriteLine();
                    size = UserInputArray();
                }
                return size;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine();
            }

                int otherSize = UserInputArray();
                return otherSize;
        }

        // Assigns an array's elements to incrementing int values starting at 1 and then returns that same array.
        public int[] AssignArray(int[] array)
        {
            int value = 1;
            foreach (int i in array)
            {
                array[Array.IndexOf(array, i)] = value++;
            }

            return array;
        }

        public void Run()
        {
            // Make an array
            int size = UserInputArray();
            int[] beginArray = new int[size];
            beginArray = AssignArray(beginArray);

            // Provide a value to search within array
            int guess = UserInputInt(beginArray);

            // Bisect array recursively until guess = middle value of array
            Guess(guess, beginArray, 0);
        }
    }
}
