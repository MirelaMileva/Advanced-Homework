using System;

namespace _02.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var result = FactorialSum(number);

            Console.WriteLine(result);
        }

        private static long FactorialSum(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * FactorialSum(number - 1);
        }
    }
}
