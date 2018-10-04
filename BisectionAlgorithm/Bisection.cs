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
        public void Bisect(int guess, int[] list, int iterations)
        {
            // this if guess matches the member in middle of array
            if (guess == list[list.Length / 2])
            {
                Console.WriteLine($"Value({guess}) found at newArray[{Array.IndexOf(list, guess)}]");
                Console.WriteLine($"Value found after {iterations} bisections.");
                Console.WriteLine();
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
                Console.WriteLine($"newArray[] = {{{string.Join(", ", list)}}}");
            }

            Console.WriteLine();

            // Calls this method recursively, passing the half of the original list that contains the number.
            Bisect(guess, list, iterations);
        }

        // Returns user input as an int to determine the number that will be searched for within an array.
        // Method recurses if user does not input an int within parameter array's length.
        public int UserInputInt(int[] list)
        {
            try
            {
                Console.WriteLine($"Select a number 1 - {list[list.Length - 1]}");
                int searchValue = Int32.Parse(Console.ReadLine());
                Console.WriteLine();

                if (searchValue < list.Length && searchValue > 0)
                {
                    return searchValue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Try again.");
                    Console.WriteLine();

                    searchValue = UserInputInt(list);
                    return searchValue;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine();

                int searchValue = UserInputInt(list);
                return searchValue;
            }
        }

        // User input returns an int that will determine length of array created in Run().
        public int UserInputArrayLength()
        {
            try
            {
                Console.WriteLine("How big is your array?");

                // user input
                int size = Int32.Parse(Console.ReadLine());
                Console.WriteLine();

                // If input is invalid, method is called recursively to assign size.
                if (size <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid negative or zero input. Try again.");
                    Console.WriteLine();
                    size = UserInputArrayLength();
                }
                return size;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine();
            }

                int otherSize = UserInputArrayLength();
                return otherSize;
        }

        // Assigns an array's elements to incrementing int values starting at 1 and then returns assigned array.
        public int[] AssignArrayElements(int[] array)
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
            int[] beginArray = new int[UserInputArrayLength()];
            beginArray = AssignArrayElements(beginArray);

            // Provide a value to search within array
            int searchValue = UserInputInt(beginArray);

            // Bisect array recursively until guess == middle value of array
            Bisect(searchValue, beginArray, 0);
        }
    }
}
