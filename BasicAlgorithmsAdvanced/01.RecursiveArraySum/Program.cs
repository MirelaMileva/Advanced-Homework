using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = Sum(numbers, 0) ;
            Console.WriteLine(result);
        }

        private static int Sum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }

            var resultSoFar = Sum(array, index + 1);

            return array[index] + resultSoFar;
        }
    }
}
