using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 0; i < num; i++)
            {
                int[] input = Console.ReadLine().
                    Split().
                    Select(int.Parse).
                    ToArray();

                if (input[0] == 1)
                {
                    int numberToPush = input[1];
                    stack.Push(numberToPush);
                }
                else if (input[0] == 2)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                    
                }
                else if (input[0] == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (input[0] == 4)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }

            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
