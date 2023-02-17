using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codility
{
    public class MissingInteger2
    {
        
         public int solution(int[] A) {
            SortedSet<int> sortedValues = new SortedSet<int>();
            List<int> expectedOrder = new List<int>();
            for(int i = 0; i< A.Length; i++)
            {
                sortedValues.Add(A[i]);
                expectedOrder.Add(i+1);
            }

            foreach(int value in expectedOrder)
            {
                if(!sortedValues.Contains(value))
                {
                    return value;
                }
            }

            if(sortedValues.Count()==expectedOrder.Count() )
            {
                return expectedOrder[expectedOrder.Count()-1]+1;
            }

            return 1;
         }

    }
}