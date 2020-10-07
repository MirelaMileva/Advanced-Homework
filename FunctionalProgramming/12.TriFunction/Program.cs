using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isEqualOrLargerFunc =
                (word, criteria) => word.Sum(x => x) >= criteria;

            int target = int.Parse(Console.ReadLine());


            string[] names = Console.ReadLine().Split().ToArray();

            Func<string[], Func<string, int, bool>, string> myFunc = (names, isLargerFunc) => names.FirstOrDefault(x => isLargerFunc(x, target));

            string targetName = myFunc(names, isEqualOrLargerFunc);

            Console.WriteLine(targetName);
        }
    }
}
