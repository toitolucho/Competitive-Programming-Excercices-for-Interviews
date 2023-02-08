/*
An array A consisting of N integers is given. Rotation of the array means that each element is shifted right by one index, and the last element of the array is moved to the first place. For example, the rotation of array A = [3, 8, 9, 7, 6] is [6, 3, 8, 9, 7] (elements are shifted right by one index and 6 is moved to the first place).

The goal is to rotate array A K times; that is, each element of A will be shifted to the right K times.

Write a function:

class Solution { public int[] solution(int[] A, int K); }

that, given an array A consisting of N integers and an integer K, returns the array A rotated K times.

For example, given

    A = [3, 8, 9, 7, 6]
    K = 3
the function should return [9, 7, 6, 3, 8]. Three rotations were made:

    [3, 8, 9, 7, 6] -> [6, 3, 8, 9, 7]
    [6, 3, 8, 9, 7] -> [7, 6, 3, 8, 9]
    [7, 6, 3, 8, 9] -> [9, 7, 6, 3, 8]
For another example, given

    A = [0, 0, 0]
    K = 1
the function should return [0, 0, 0]

Given

    A = [1, 2, 3, 4]
    K = 4
the function should return [1, 2, 3, 4]

Assume that:

N and K are integers within the range [0..100];
each element of array A is an integer within the range [−1,000..1,000].
In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codility
{
    public class CyclicRotation
    {
        public int[] solution(int[] A, int K) {
           int n = A.Length;  
            if(K==0)
                return A;      
            else if(n%K == 0 && K!=1)  
                return A;
            else if(n==0 || n==1)
                return A;
            else if(n==2)
            {
                if(K%2==2)
                    return A;
                else
                {
                    int aux = A[0];
                    A[0] = A[1];
                    A[1 ]=aux;    
                }
            }
            else
            {
                Console.WriteLine("rotacion generica");
                int aux =0;
                for(int i=0; i<K; i++)
                {
                    aux = A[n-1];
                    for(int j= n-1; j>=1; j--)
                    {
                        
                        A[j] = A[j-1];

                 
                    }
                    A[0] = aux;
                }             }

            return A;
        }
    }
}