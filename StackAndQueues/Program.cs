using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueuesExerciseAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            int[] numbersToPush = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var stack = new Stack<int>();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            for (int i = 0; i < n; i++)
            {
                stack.Push(numbersToPush[i]);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else 
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }    
            }
            

        }
    }
}
