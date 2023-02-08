// See https://aka.ms/new-console-template for more information
using Codility;

Console.WriteLine("Hello, World!");

CyclicRotation cs = new CyclicRotation();
var dato = cs.solution(new int [] {0,1,2}, 22);
// var dato = cs.solution(new int [] {0,0,0}, 1);
//var dato = cs.solution(new int [] {}, 0);
printArray(dato);



 static void printArray(int[] dato)
{
    dato.ToList().ForEach(a =>
        Console.Write("{0}, ", a)
    );
    Console.WriteLine();
}
