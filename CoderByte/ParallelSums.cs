/*
Have the function ArrayChallenge(arr) take the array of integers stored in arr which will always contain an even amount of integers, and determine how they can be split into two even sets of integers each so that both sets add up to the same number. If this is impossible return -1. If it's possible to split the array into two sets, then return a string representation of the first set followed by the second set with each integer separated by a comma and both sets sorted in ascending order. The set that goes first is the set with the smallest first integer.

For example: if arr is [16, 22, 35, 8, 20, 1, 21, 11], then your program should output 1,11,20,35,8,16,21,22
Once your function is working, take the final output string and replace all characters that appear in your ChallengeToken with --[CHAR]--.

Your ChallengeToken: daf9607
Examples
Input: [1,2,3,4]
Output: 1,4,2,3
Final Output: 1,4,2,3
Input: [1,2,1,5]
Output: -1
Final Output: -1
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByte
{
    public static class Ex
    {
        public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
            elements.SelectMany((e, i) =>
                elements.Skip(i + 1).DifferentCombinations(k - 1).Select(c => (new[] {e}).Concat(c)));
        }
    }
    public class ParallelSums
    {

        public static string ArrayChallenge(int[] arr) {

            // code goes here  
            int totalsum = arr.Sum();
            var results = arr.DifferentCombinations(arr.Length/2);
            foreach(var combination in results)
            {
            int partialSum = combination.Sum();
            int diference = totalsum - partialSum;
            if(partialSum == diference)
            {
                var subArray1 = arr.Except(combination).OrderBy(a=>a);
                var subArray2 = combination.OrderBy(a=>a);
                if(subArray1.First()< subArray2.First())
                {
                return String.Join(',', subArray1.OrderBy(a=>a).Concat(subArray2));         

                }
                else
                {
                return String.Join(',', subArray2.OrderBy(a=>a).Concat(subArray1));
                }
            }
            }
            return "-1";

        }
        static void Main_01() {  
            // keep this function call here
            //Console.WriteLine(ArrayChallenge());
            //string data = ArrayChallenge(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,10 });
            //string data = ArrayChallenge(new[] { 16, 22, 35, 8, 20, 1, 21, 11 });
            string data = ArrayChallenge(new[] { 1,2,3,4 });
            Console.WriteLine(data);
            //1,2,3,4
        }
    }
}