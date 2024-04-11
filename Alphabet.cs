using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Password_Ahalizator
{
    internal class Alphabet
    {

        public static int AlphabetLength(string password)
        {
            int alphabet_length = 0;

            bool check_higher = false;
            bool check_lower = false;
            bool check_digits = false;
            bool check_special = false;
            char symbol;

            for (int i = 0; i < password.Length; i++)
            {
                symbol = Convert.ToChar(password.Substring(i, 1));

                if (Char.IsDigit(symbol) == true && check_digits == false)
                {
                    check_digits = true;
                }
                if (Char.IsLower(symbol) == true && check_lower == false)
                {
                    check_lower = true;
                }
                if (Char.IsUpper(symbol) == true && check_higher == false)
                {
                    check_higher = true;
                }
                if (check_special == false && Char.IsUpper(symbol) == false && Char.IsLower(symbol) == false && Char.IsDigit(symbol) == false)
                {
                    check_special = true;
                }
            }
            if (check_digits == true) { alphabet_length += 10; }
            if (check_higher == true) { alphabet_length += 26; }
            if (check_lower == true) { alphabet_length += 26; }
            if (check_special == true) { alphabet_length += 33; }
           
            return alphabet_length;
        }
    }
}
