/*
Have the function MatrixChallenge(strArr) take strArr which will be an array of integers represented as strings. Within the array there will also be "<>" elements which represent break points. The array will make up a matrix where the (number of break points + 1) represents the number of rows. Here is an example of how strArr may look: ["5","7","8","<>","1","1","2"]. There is one "<>", so 1 + 1 = 2. Therefore there will be two rows in the array and the contents will be row1=[5 7 8] and row2=[1 1 2]. Your program should take the given array of elements, create the proper matrix, and then through the process of Gaussian elimination create a reduced row echelon form matrix (RREF matrix). For the array above, the resulting RREF matrix would be: row1=[1 0 3], row2=[0 1 -1]. Your program should return that resulting RREF matrix in string form combining all the integers, like so: "10301-1". The matrix can have any number of rows and columns (max=6x6 matrix and min=1x1 matrix). The matrix will not necessarily be a square matrix. If the matrix is an nx1 matrix it will not contain the "<>" element. The integers in the array will be such that the resulting RREF matrix will not contain any fractional numbers.
Once your function is working, take the final output string and replace all characters that appear in your ChallengeToken with --[CHAR]--.

Your ChallengeToken: daf9607
Examples
Input: ["2","4","8","<>","6","12","14"]
Output: 120001
Final Output: 12--0----0----0--1
Input: ["2","2","4","<>","1","1","8","<>","7","6","5"]
Output: 100010001
Final Output: 1--0----0----0--1--0----0----0--1
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByte
{
    public class RREF_Matrix
    {
        
    }
}