using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());

            var orders = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            for (int i = 0; i < orders.Length; i++)
            {
                if (food >= orders[i] && queue.Count > 0)
                {
                    if (queue.Any())
                    {
                        queue.Dequeue();
                        food -= orders[i];
                    }
                    
                }
                else
                {
                    break;
                }

            }

            if (queue.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
