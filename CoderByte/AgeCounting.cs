using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoderByte
{
    public class AgeCounting
    {
        static void Main3() 
        {  
    
          WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/age-counting");
          WebResponse response = request.GetResponse();
          StreamReader reader = new StreamReader(response .GetResponseStream());
          string json = reader.ReadToEnd();
          //string json = "{\"data\":\"key=IAfpK, age=58, key=WNVdi, age=64, key=jp9zt, age=47\"}";
          json = json.Remove(0,9);
          json = json.Remove(json.Length-2,2);
        // Console.WriteLine(json);
          int age = 0;
          int ageCounter = 0;
          int totalItems = 0;
          for(int i=0; i< json.Length-3; i++)
          {
            if(json[i]== 'a' && json[i+1]=='g' && json[i+2]=='e')
            {
              if(i+5<json.Length &&  json[i+5] ==',')
              {
                age = int.Parse(json.Substring(i+4, 1));
                i+=17;
              }
              else if(i+5 == json.Length)
              {
                  age = int.Parse(json.Substring(i+4, 1));
                  break;
              }
              else
              {
                age = int.Parse(json.Substring(i+4, 2));
                i+=18;
              }
                
            // Console.WriteLine(age);
            if(age>=50)
                ageCounter++;
            totalItems++;   
              
            }
          }

          
          Console.WriteLine(ageCounter);
          response.Close();
      }
    }
}