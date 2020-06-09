using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace NaviroTest
{
    public class InvalidTriangleException : Exception
    {
        public InvalidTriangleException()
        {
        }

        public InvalidTriangleException(string message)
            : base(message)
        {
        }
    }

    public class Question3
    {
        public Question3()
        {
        }

        private void CheckIsValidTriangle(int a, int b, int c)
        {
            // check condition - sum of two sides of a triangle must be greater than the third side 
            if (a + b <= c
                || a + c <= b
                || b + c <= a)
            {
                throw new InvalidTriangleException("Inputs cannot form a valid triangle");
            }   
        }

        public double CalculateArea(int a, int b, int c)
        {
            if(a<=0 || b<=0 || c<=0)
            {
                throw new InvalidTriangleException("Negative inputs");
            }

            CheckIsValidTriangle(a, b, c);

            float s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return Math.Round(area,2);
        }
    }
}