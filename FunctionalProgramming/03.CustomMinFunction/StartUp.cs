using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Func<int[], int> minFunc = (nums) =>
            {
                int minValue = int.MaxValue;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] < minValue)
                    {
                        minValue = nums[i];
                    }
                }

                return minValue;

            };

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minFunc(numbers));
        }
    }
}
