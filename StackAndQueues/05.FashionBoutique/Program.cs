using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothesValue = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            int capacity = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(clothesValue);

            int rack = 1;
            int valueSum = 0;

            while (stack.Any())
            {
                if (valueSum >= capacity)
                {
                    rack++;

                    if (valueSum == capacity)
                    {
                        valueSum = 0;
                        continue;
                    }

                }
                else
                {     
                    if (valueSum + stack.Peek() > capacity)
                    {
                        rack++;
                        valueSum = 0;
                        continue;
                    }
                    else
                    {
                        valueSum += stack.Pop();
                    }
                }
            }

            Console.WriteLine(rack);
        }
    }
}
