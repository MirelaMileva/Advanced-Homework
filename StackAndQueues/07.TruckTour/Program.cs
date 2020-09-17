using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            FillQueue(n, pumps);

            int count = 0;

            while (true)
            {
                int fuel = 0;
                bool isFound = true;

                for (int i = 0; i < n; i++)
                {
                    int[] currentPump = pumps.Dequeue();

                    fuel += currentPump[0];

                    if (fuel < currentPump[1])
                    {
                        isFound = false;
                    }

                    fuel -= currentPump[1];

                    pumps.Enqueue(currentPump);
                }

                if (isFound)
                {
                    break;
                }

                count++;

                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(count);
        }

        private static void FillQueue(int n, Queue<int[]> pumps)
        {
            for (int i = 0; i < n; i++)
            {
                int[] currPump = Console.ReadLine().
                    Split().
                    Select(int.Parse).
                    ToArray();

                pumps.Enqueue(currPump);
            }
        }
    }
}
