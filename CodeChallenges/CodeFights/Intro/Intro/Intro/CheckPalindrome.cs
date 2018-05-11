using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    class CheckPalindrome
    {
        public bool checkPalindrome(string inputString)
        {
            bool Palindrome = true;
            char[] chars = inputString.ToCharArray();
            for (int i = 0; i < chars.Length / 2; i++)
            {
                if (!(chars[i] == chars[chars.Length - 1 - i]))
                {
                    Palindrome = false;
                    break;
                }
            }
            return Palindrome;
        }
    }
}
