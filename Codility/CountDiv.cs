using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codility
{
    public class CountDiv
    {
        public int solution(int A, int B, int K)
        {
            if(A%K != 0)
                A = A/K*K+K;
            if(B%K !=0)
                B = B/K*K;


            return B/K - A/K +1;
        }
    }
}