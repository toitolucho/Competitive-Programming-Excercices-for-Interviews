using System;  
using System.IO;  
using System.Net; 
using System.Text.Json;


public class MyData
{
  public int val {get;set;}
}


class MainClass 
{
public static int N = 3;


  
  static List<int> AllIndexesOf(string str, string value) 
  {
    if (String.IsNullOrEmpty(value))
        throw new ArgumentException("the string to find may not be empty", "value");
    List<int> indexes = new List<int>();
    for (int index = 0;; index += value.Length) 
    {
        index = str.IndexOf(value, index);
        if (index == -1)
            return indexes;
        indexes.Add(index);
    }
  }
  
  static void Main25()
  {
    string[] data = new string[] {"2","4","8","<>","6","12","14"};
    //string[] data = new string[] {"2","2","4","<>","1","1","8","<>","7","6","5"};
    string separator = "<>";
    int rows=0;
    int columns =0;
    for(int index =0; ; index += separator.Length )
    {
      int pos = Array.IndexOf(data, separator,index);
      if(index == 0)
        columns =pos;         
      if(pos == -1)
        break;
      index = pos;
      rows++;
    }
    Console.WriteLine(columns);
    Console.WriteLine(rows);
    double[,] matrix;
    //fill wiith zero the vector solution
    if(columns-rows == 1)
    {
      matrix = new double[rows+1, columns+1];
      Console.WriteLine(matrix.Length);
      
      int fila=0, columna=0;
      foreach(string value in data)
      {
        if(value != "<>")
        {
          Console.WriteLine("[{0} , {1}] = {2}", fila, columna, value);
          matrix[fila,columna] = float.Parse(value);
          columna++;
          if((columna)%columns == 0)
          {
            matrix[fila,columna] = 0;
            fila++;
            columna = 0;

          }
            
        }        
      }
      //for(int i =0; i)
    }      
    else
    {
      matrix = new double[rows+1, columns];
      int fila=0, columna=0;
      foreach(string value in data)
      {
        if(value != "<>")
        {
          Console.WriteLine("[{0} , {1}] = {2}", fila, columna, value);
          matrix[fila,columna] = float.Parse(value);
          columna++;
          if((columna)%columns == 0)
          {            
            fila++;
            columna = 0;
          }
            
        }        
      }

    }

    for(int i=0; i< matrix.GetLength(0); i++)
    {
      for(int j=0; j< matrix.GetLength(1);j++)
      {
        Console.Write("{0} ", matrix[i,j]);
      }
      Console.WriteLine();
    }

   

    int rowCount = matrix.GetUpperBound(0) + 1;
    if (matrix == null || matrix.Length != rowCount * (rowCount + 1))
      throw new ArgumentException("The algorithm must be provided with a (n x n+1) matrix.");
    if (rowCount < 1)
      throw new ArgumentException("The matrix must at least have one row.");

    // pivoting
    for (int col = 0; col + 1 < rowCount; col++) if (matrix[col, col] == 0)
    // check for zero coefficients
    {
        // find non-zero coefficient
        int swapRow = col + 1;
        for (;swapRow < rowCount; swapRow++) if (matrix[swapRow, col] != 0) break;

        if (matrix[swapRow, col] != 0) // found a non-zero coefficient?
        {
            // yes, then swap it with the above
            double[] tmp = new double[rowCount + 1];
            for (int i = 0; i < rowCount + 1; i++)
            { tmp[i] = matrix[swapRow, i]; matrix[swapRow, i] = matrix[col, i]; matrix[col, i] = tmp[i]; }
        }
        else 
        {
          Console.WriteLine("he matrix has no unique solution");
          break;
        }
        //else return false; // no, then the matrix has no unique solution
    }

    // elimination
    for (int sourceRow = 0; sourceRow + 1 < rowCount; sourceRow++)
    {
        for (int destRow = sourceRow + 1; destRow < rowCount; destRow++)
        {
            double df = matrix[sourceRow, sourceRow];
            double sf = matrix[destRow, sourceRow];
            for (int i = 0; i < rowCount + 1; i++)
              matrix[destRow, i] = matrix[destRow, i] * df - matrix[sourceRow, i] * sf;
        }
    }

    // back-insertion
    for (int row = rowCount - 1; row >= 0; row--)
    {
        double f = matrix[row,row];
        if (f == 0) break; //return false;

        for (int i = 0; i < rowCount + 1; i++) matrix[row, i] /= f;
        for (int destRow = 0; destRow < row; destRow++)
        { 
          matrix[destRow, rowCount] -= matrix[destRow, row] * matrix[row, rowCount]; 
          matrix[destRow, row] = 0; 
        }
    }
    for(int i=0; i< rows+1; i++ )
    {
      for(int j =0; j< columns; j++)
      {
        Console.Write(matrix[i,j]);
      }
      Console.WriteLine();
    }

  }


 
   
}