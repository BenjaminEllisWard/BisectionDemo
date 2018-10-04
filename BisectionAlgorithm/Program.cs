using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisectionAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var bisect = new Bisection();
            bisect.Run();

            var userGuess = new GuessNumber();
            userGuess.Run(new Bounds(1, 1001));

            var userSelect = new SelectNumber();
            userSelect.Run(new Bounds(1, 101));
        }
    }
}
