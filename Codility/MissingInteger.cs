using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codility
{
    public class MissingInteger
    {
        public int solution(int[] A) {
            if(A.Length == 1)
            {
                if(A[0]==1)
                    return 2;
                else
                    return 1;
                
            } 
           

            A = A.Order().ToArray();
            int negativeIndex = -1;
            for(int i =0; i<A.Length; i++)
            {
                if(A[i]<0)
                {
                    negativeIndex = i;
                    continue;
                }
                if(i>0&&A[i]>1 && A[i-1]<0)
                {
                    return 1;
                } 
                if( i>0 &&   A[i]>0 && A[i-1]> 0 && (A[i]-A[i-1])>1)
                {
                    
                     return A[i-1]+1;
                }
            }
            //  Console.WriteLine(negativeIndex);
        // Implement your solution here
            if(negativeIndex+1 == A.Length)
                return 1;
            else
                return A[A.Length-1]+1;
        }
    }
}