/*
Have the function StringChallenge(str) read str which will be a string of roman numerals in decreasing order. The numerals being used are: I for 1, V for 5, X for 10, L for 50, C for 100, D for 500 and M for 1000. Your program should return the same number given by str using a smaller set of roman numerals. For example: if str is "LLLXXXVVVV" this is 200, so your program should return CC because this is the shortest way to write 200 using the roman numeral system given above. If a string is given in its shortest form, just return that same string.
Once your function is working, take the final output string and replace all characters that appear in your ChallengeToken with --[CHAR]--.

Your ChallengeToken: daf9607
Examples
Input: "XXXVVIIIIIIIIII"
Output: L
Final Output: L
Input: "DDLL"
Output: MC
Final Output: MC
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByte
{

    public class RomanNumeralReduction
    {
        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;            
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900); 
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);            
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            return "";
        }

        public static string StringChallenge(string str) 
        {
            int sum =0;
            foreach(char val in str)
            {                
                switch (val)
                {
                    case 'I' : sum+=1; break;
                    case 'V' : sum+=5; break;
                    case 'X' : sum+=10; break;
                    case 'L' : sum+=50; break;
                    case 'C' : sum+=100; break;
                    case 'D' : sum+=500; break;
                    case 'M' : sum+=1000; break;                   
                    
                }
            }
            return ToRoman(sum);

        }
        static void Main_03() {  
            // keep this function call here
            Console.WriteLine(StringChallenge(Console.ReadLine()));
        } 

    }
}