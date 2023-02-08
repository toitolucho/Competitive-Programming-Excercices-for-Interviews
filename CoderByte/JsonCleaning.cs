using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoderByte
{
    public class JsonCleaning
    {
        public static void Main()
        {
            WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/json-cleaning");    
            WebResponse response = request.GetResponse();
            //Console.WriteLine(response);
            StreamReader reader = new StreamReader(response .GetResponseStream());
            string json = reader.ReadToEnd();
        // Console.WriteLine(json);
            string[] values = {"\"-\"", "\"\"", "\"N\\/A\""}; 
            
            //string value = values[2];
            //Console.WriteLine(value);
            //string value = "-";
            foreach(string value in values)
            {
                for (int index = 0;  ; index += value.Length) 
                {
                    if(index > json.Length)
                        break; 
                    index = json.IndexOf(value, index);
                    // Console.WriteLine("index {0} of {1}", index, value);  
                    if (index == -1)
                        break;
                    //remove the element from the array  
                    //Console.WriteLine("founded {0} at position {1}, removed substring {2}" , value, index,  json.Substring(index, 10));  
                    //Console.WriteLine("character {0}", json[index-1]);
                    if(json[index-1]== ',' || json[index-1]== '[')
                    {
                        //Console.WriteLine("remove element from array");
                        
                        json = json.Remove(index-1, value.Length+1);
                        //json.Remove(index, value.Length);
                    }//remove the entire key value from json
                    else if(json[index-1]== ':')
                    {
                        //Console.WriteLine("remove element from json");
                        int auxIndex = index-3;
                        //while(auxIndex>=0 && ( json[auxIndex] != ',' || json[auxIndex] != '{'))
                        while(auxIndex>=0 && ( json[auxIndex] != '"'))
                        //while(( json[auxIndex] != '"'))
                        {
                        auxIndex--;
                        }
                    // Console.WriteLine("Founded {0}, at position {1} , removed {2}" , json[auxIndex], auxIndex, json.Substring(auxIndex, 10) );
                        json = json.Remove(auxIndex,index-auxIndex+value.Length+1);          
                    }

                    //Console.WriteLine("");

                }
            }



            


            Console.WriteLine(json);
            response.Close();
        }
    }
}