using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codility
{


/*
This is a demo task.
Write a function:
class Solution { public int solution(int[] A); }
that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.
For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.
Given A = [1, 2, 3], the function should return 4.
Given A = [−1, −3], the function should return 1.
Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..100,000];
each element of array A is an integer within the range [−1,000,000..1,000,000].
*/


/*
A binary gap within a positive integer N is any maximal sequence of consecutive zeros that is surrounded by ones at both ends in the binary representation of N.

For example, number 9 has binary representation 1001 and contains a binary gap of length 2. The number 529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3. The number 20 has binary representation 10100 and contains one binary gap of length 1. The number 15 has binary representation 1111 and has no binary gaps. The number 32 has binary representation 100000 and has no binary gaps.

Write a function:

class Solution { public int solution(int N); }

that, given a positive integer N, returns the length of its longest binary gap. The function should return 0 if N doesn't contain a binary gap.

For example, given N = 1041 the function should return 5, because N has binary representation 10000010001 and so its longest binary gap is of length 5. Given N = 32 the function should return 0, because N has binary representation '100000' and thus no binary gaps.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..2,147,483,647].
*/
    public class BinaryGap
    {
        public int solution(int[] A) {
        // Implement your solution here
            return 0;
         }

         public static int solution2(int N) {
        // Implement your solution here
            int d, max = 0,  cont0 = 0, cont1=0;
            while(N!=0)
            {
                d = N%2;
                
                if(d==1)
                {
                    cont1++;
                    if(cont1==2)
                    {
                        if(cont0>max)
                            max = cont0;
                        cont1 = 1;
                        cont0 = 0;

                    }
                }
                else
                {
                   
                    if(cont1==1) 
                        cont0++;
                    
                }
                N/=2;
                //Console.WriteLine("{0}  =  {1} | {2}",d,cont1,cont0);
            }
                
            //Console.WriteLine("Max =" + max);
            return max;
        }

        static void Main() {  
            // keep this function call here
            Console.WriteLine("\n"+solution2(561892));
        } 
    }
}