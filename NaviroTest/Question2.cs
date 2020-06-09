using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace NaviroTest
{
    public class Question2
    {
        private List<uint> _postiveDivisors = new List<uint>();

        public Question2()
        {
            _postiveDivisors.Add(1);
        }

        public uint[] GetPostiveDivisors(uint num)
        {
            if(num == 0)
            {
                throw new ArgumentException("value of num must be greater than 0");
            }

            if (num == 1) return _postiveDivisors.ToArray();

            uint maxDivisor = (uint)Math.Ceiling(num/2.0);

            // loop run for maxDivisor/2 times
            for (uint i = 2, j = maxDivisor; i <= j; i+=1, j-=1)
            {
                // Add forward loop number
                if ( num%i == 0 ) _postiveDivisors.Add(i);
                // Add reverse loop number
                if ( i != j && num%j == 0 ) _postiveDivisors.Add(j);
            }

            _postiveDivisors.Add(num);
            return _postiveDivisors.ToArray();
        }
    }
}