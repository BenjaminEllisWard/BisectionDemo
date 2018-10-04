using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisectionAlgorithm
{
    public struct Bounds
    {
        public int UpperBound { get; set; }
        public int LowerBound { get; set; }

        public Bounds(int lowB, int upB)
        {
            this.UpperBound = upB;
            this.LowerBound = lowB;
        }
    }
}
