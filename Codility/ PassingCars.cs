using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codility
{
    public class  PassingCars
    {
         public int solution(int[] A)
         {
            int zeroCounter = 0;
            int passingCarsCounter = 0;
            for(int  i = 0; i<A.Length; i++)
            {
                if(A[i]==0)
                {
                    zeroCounter++;
                }
                else
                {
                    passingCarsCounter+=zeroCounter;
                    if(passingCarsCounter> 1000000000)
                        return -1;
                }
            }
            return passingCarsCounter;
         }
    }
}