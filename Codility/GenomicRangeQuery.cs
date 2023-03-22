using System;
class GenomicRangeQuery { 
    public int[] solution(String S, int[] P, int[] Q)
    {
        //turnn on cells for each category accordin to S
        int[] answer = new int [P.Length];
        int[,] ocurrences  = new int[S.Length+1,4];
        for(int i=0; i<S.Length; i++)
        {
            if(S[i] == 'A') ocurrences[i+1,0] = 1;
            if(S[i] == 'C') ocurrences[i+1,1] = 1;
            if(S[i] == 'G') ocurrences[i+1,2] = 1;
            if(S[i] == 'T') ocurrences[i+1,3] = 1;
        }
        for(int i = 1; i< S.Length+1; i++)
        {
            for(int j = 0; j<4; j++)
                ocurrences[i,j] += ocurrences[i-1,j];
        }

        for(int i = 0; i< ocurrences.GetLength(0); i++)
        {
            for(int j = 0; j<4; j++)
                Console.Write(ocurrences[i,j]+", ");
            Console.WriteLine();
        }
        //acumulating history sum valu for each position
        int lowBound,highBound;
        for(int i = 0; i< P.Length; i++ )
        {
             Console.Write("From {0} to {1} ", P[i],  Q[i]);
            if(P[i]==0)
                lowBound = P[i];
            else
                lowBound = P[i]-1;
            highBound = Q[i];
            for(int j=0; j<4; j++)
            {
                if(ocurrences[highBound,j] != ocurrences[lowBound,j])
                {
                    Console.WriteLine(j+1);
                    answer[i] = j+1;
                    break;
                }
                    
            }

        }


        return answer;
    }

 }