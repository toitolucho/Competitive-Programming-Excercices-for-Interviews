using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderByte
{
    public class SimpleSymbols
    {
          public static string simpleSymbols(string str) {

            //code goes here
            StringBuilder strBuilder = new StringBuilder();
            //posChar>=97 && posChar<=122) || (posChar>=65 && posChar<=90) )
            int posChar = (int)str[0];
            if(((posChar>=97 && posChar<=122) || (posChar>=65 && posChar<=90)))
              return "false";
            else
            {
              for(int i = 1; i< str.Length-1; i++)
              {
                posChar = (int)str[i];
                if(  (posChar>=97 && posChar<=122) || (posChar>=65 && posChar<=90) )
                {
                    if(!(str[i-1] == '+' &&  str[i+1] == '+'))
                      return "false";
                    else
                      continue;
                }

              }
            }


            // char[] characters = str.ToArray();
            // Array.Sort(characters);
            // return new string(characters);
            return "true";

        }
    }
}