using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            string input = Console.ReadLine();
            Func<int, int> addFunc = num => num + 1;
            Func<int, int> multiplyFunc = num => num * 2;
            Func<int, int> subtractFunc = num => num - 1;
            Action<int[]> printNumbers = n => Console.WriteLine(string.Join(" ", n));

            while (input != "end")
            {
                if (input == "print")
                {
                    printNumbers(numbers);
                }
                else if (input == "add")
                {
                    numbers = numbers.Select(addFunc).ToArray();
                }
                else if (input == "multiply")
                {
                    numbers = numbers.Select(multiplyFunc).ToArray();
                }
                else if (input == "subtract")
                {
                   numbers = numbers.Select(subtractFunc).ToArray();
                }

                input = Console.ReadLine();
            }

        }

    }
}
