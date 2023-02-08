using System.Collections;
using System.Text;

class LetterChanges {

  public static string FirstReverse(string str) {
    char[] charArray = str.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
  }


  public static string letterChanges(string str) {

    // code goes here  
    StringBuilder newStr = new StringBuilder();
    int posChar  = 0;
    for(int i =0; i< str.Length; i++)
    {
      if(str[i] == 'z')
      {
        //122 z 97 Z
        //90 a  65 A
        //str.Replace('z','a');
        newStr.Append('A');
      }
      else if(str[i] == 'Z')
      {
        //str.Replace('Z','A');    
        newStr.Append('A');    
      }
      else
      {
         //a e      i     o    u
         //97  101 , 105 , 111, 117

         posChar = (int) str[i];
        // Console.WriteLine(posChar);
         if((posChar>=97 && posChar<=122) || (posChar>=65 && posChar<=90) )
         {
          switch (str[i])
          {
              case 'd': newStr.Append('E'); break;
              case 'h': newStr.Append('I'); break;
              case 'n': newStr.Append('O'); break;
              case 't': newStr.Append('U'); break;
              default : posChar++; newStr.Append( ((char) posChar) );     break;    
          }
         }
         else
         {
          newStr.Append(str[i]);
         }
         /*AZaz
          Input: "hello*3"
          Output: Ifmmp*3
          cfbvUjgvm^Z[\]
         */
         
      }
      

    }
    return newStr.ToString();

  }



  

  public static string LetterCapitalize(string str) {

    // code goes here  
    StringBuilder strBuilder = new StringBuilder();
    //posChar>=97 && posChar<=122) || (posChar>=65 && posChar<=90) )
    int pos = (int)str[0];
    pos = pos - 32;
    strBuilder.Append((char) pos);  //aA 32   dD
    for(int i=1; i< str.Length; i++)
    {
        strBuilder.Append(str[i]);
        if(str[i] == ' ')
        {
          pos = (int)str[i+1];
          pos -=32;
          strBuilder.Append((char) pos);
          i++;
        }

    }
    return strBuilder.ToString();

  }


  public static string SimpleSymbols(string str) {

    // code goes here
    // StringBuilder strBuilder = new StringBuilder();
    // //posChar>=97 && posChar<=122) || (posChar>=65 && posChar<=90) )
    // int posChar = (int)str[0];
    // if(((posChar>=97 && posChar<=122) || (posChar>=65 && posChar<=90)))
    //   return "false";
    // else
    // {
    //   for(int i = 1; i< str.Length-1; i++)
    //   {
    //     posChar = (int)str[i];
    //     if(  (posChar>=97 && posChar<=122) || (posChar>=65 && posChar<=90) )
    //     {
    //         if(!(str[i-1] == '+' &&  str[i+1] == '+'))
    //           return "false";
    //         else
    //           continue;
    //     }

    //   }
    // }


    char[] characters = str.ToArray();
    Array.Sort(characters);
    return new string(characters);
   // return "true";

  }

  static void Main2() {  
    // keep this function call here
    //Console.WriteLine("Hola Mundo");
    //Console.WriteLine(FirstReverse(Console.ReadLine()));
    Console.WriteLine(SimpleSymbols("zrobocops")); 


    // string n = Console.ReadLine();
    // string k = Console.ReadLine();

    // Hashtable restrictionLetters = new Hashtable();
    // int quantity = 0;
    // foreach(var c in k)
    // {
    //   if(restrictionLetters.ContainsKey(c) )
    //   {
    //        quantity = int.Parse( restrictionLetters[c].ToString());                   
    //   }
    //   else
    //     quantity = 0;
    //   restrictionLetters[c] = ++quantity;
    // }


    // Console.WriteLine("HashTable values");
    // foreach(DictionaryEntry it in restrictionLetters)
    // {
    //   Console.WriteLine("Key {0} = {1}", it.Key, it.Value);
    // }


    // Hashtable query = new Hashtable();
    // int topRight = k.Length-1;
    // int minLeft = 0;
    // for(int right = k.Length-1; right<topRight; right++)
    // {
    //     for(int left = minLeft; left< n.Length- k.Length; left++)
    //     {
            
    //     }
    // }
    

  } 

}