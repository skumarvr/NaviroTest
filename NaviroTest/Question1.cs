using System;
using System.Collections.Generic;
using System.Text;

namespace NaviroTest
{
    public static class Question1
    {
        public static bool IsNullOrEmpty(string str)
        {
            // check if string is null
            // check for string length
            return !(str != null && str.Length > 0);
        }
    }
}
