using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] malesInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] femaleInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> males = new Stack<int>(malesInput);
            Queue<int> females = new Queue<int>(femaleInput);
            int matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                var currentMale = males.Peek();
                var currentFemale = females.Peek();

                if (currentMale <= 0)
                {
                    males.Pop();
                    continue;
                }

                if (currentFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (currentMale % 25 == 0)
                {
                    males.Pop();

                    if (males.Count > 0)
                    {
                        males.Pop();
                    }

                    continue;
                }

                if (currentFemale % 25 == 0)
                {
                    females.Dequeue();

                    if (females.Count > 0)
                    {
                        females.Dequeue();
                    }

                    continue;
                }

                if (currentMale == currentFemale)
                {
                    males.Pop();
                    females.Dequeue();
                    matches++;
                }
                else
                {
                    females.Dequeue();
                    males.Pop();
                    males.Push(currentMale - 2);
                }
            }

            Console.WriteLine($"Matches: {matches}");
            if (males.Count > 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }

        }
    }
}
