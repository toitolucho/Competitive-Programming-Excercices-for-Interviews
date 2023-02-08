using System;
using System.Collections.Generic;

public class PermuteUtils
{
    // Returns an enumeration of enumerators, one for each permutation
    // of the input.
    public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> list, int count)
    {
        if (count == 0)
        {
            yield return new T[0];
        }
        else
        {
            int startingElementIndex = 0;
            foreach (T startingElement in list)
            {
                IEnumerable<T> remainingItems = AllExcept(list, startingElementIndex);

                foreach (IEnumerable<T> permutationOfRemainder in Permute(remainingItems, count - 1))
                {
                    yield return Concat<T>(
                        new T[] { startingElement },
                        permutationOfRemainder);
                }
                startingElementIndex += 1;
            }
        }
    }

    // Enumerates over contents of both lists.
    public static IEnumerable<T> Concat<T>(IEnumerable<T> a, IEnumerable<T> b)
    {
        foreach (T item in a) { yield return item; }
        foreach (T item in b) { yield return item; }
    }

    // Enumerates over all items in the input, skipping over the item
    // with the specified offset.
    public static IEnumerable<T> AllExcept<T>(IEnumerable<T> input, int indexToSkip)
    {
        int index = 0;
        foreach (T item in input)
        {
            if (index != indexToSkip) yield return item;
            index += 1;
        }
    }

    private static List<string> CreateCombinations(int startIndex, string pair, string[] initialArray)
    {
        var combinations = new List<string>();
        for (int i = startIndex; i < initialArray.Length; i++)
        {
            var value = $"{pair}{initialArray[i]}";
            combinations.Add(value);
            combinations.AddRange(CreateCombinations(i + 1, value, initialArray));
        }

        return combinations;
    }

    

    static void Main21346(string[] args)
    {
        // int[] intInput = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // ShowPermutations<int>(intInput, 5);

        // string[] stringInput = { "Hello", "World", "Foo", "Ace" };
        // ShowPermutations<string>(stringInput, 3);

        // var strs = new[] {"A", "B", "C", "D", "E", "F"};
        // var combinations = CreateCombinations(0, "", strs);
        // var text = string.Join(", ", combinations);
        // Console.WriteLine(text);

        // var arr = new[] { "A", "B", "C" };

        // var arr2 = arr.SelectMany(
        //     x => arr.Select(
        //         y => x + y));

        var results = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,10 }.DifferentCombinations(5);

        foreach(var values in results)
        {
            foreach(var value in values)
            {
                Console.Write(value + " ") ;
            }
            Console.WriteLine();
        }

    }

    // Print out the permutations of the input 
    static void ShowPermutations<T>(IEnumerable<T> input, int count)
    {
        foreach (IEnumerable<T> permutation in PermuteUtils.Permute<T>(input, count))
        {
            foreach (T i in permutation)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();
        }
    }
}

public static class Ex
{
    public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
    {
        return k == 0 ? new[] { new T[0] } :
          elements.SelectMany((e, i) =>
            elements.Skip(i + 1).DifferentCombinations(k - 1).Select(c => (new[] {e}).Concat(c)));
    }
}