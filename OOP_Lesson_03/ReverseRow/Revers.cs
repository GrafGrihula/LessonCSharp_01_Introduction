using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseRow
{
    public class Revers
    {
        public string StringRevers(string str)
        {
            var charArray = str.ToCharArray();
            Array.Reverse(charArray);
            var reversed = new string(charArray);

            return reversed;
        }
    }
}
