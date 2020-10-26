using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedExamOctober2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksInput = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int[] threadsInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int valueToKill = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(tasksInput);
            Queue<int> threads = new Queue<int>(threadsInput);

            while (true)
            {
                var currTask = tasks.Peek();
                var currThread = threads.Peek();

                if (currTask == valueToKill)
                {
                    Console.WriteLine($"Thread with value {currThread} killed task {currTask}");
                    break;
                }

                if (currThread >= currTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }

                if (currThread < currTask)
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
