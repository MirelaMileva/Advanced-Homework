using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPrepAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliesInput = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[] rosesInput = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int wreath = 0;
            int storedLiliesAndRoses = 0;

            Stack<int> lilies = new Stack<int>(liliesInput);
            Queue<int> roses = new Queue<int>(rosesInput);

            while (lilies.Count > 0 && roses.Count > 0)
            {
                var currentLilie = lilies.Peek();
                var currentRose = roses.Peek();

                if (roses.Count == 0)
                {
                    break;
                }

                if (currentLilie + currentRose == 15)
                {
                    wreath++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (currentLilie + currentRose > 15)
                {
                    lilies.Pop();
                    lilies.Push(currentLilie - 2);
                }
                else if (currentLilie + currentRose < 15)
                {
                    storedLiliesAndRoses += currentLilie + currentRose;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            if (storedLiliesAndRoses > 15)
            {
                while (storedLiliesAndRoses > 15)
                {
                    storedLiliesAndRoses -= 15;
                    wreath++;
                }
            }

            if (wreath >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreath} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreath} wreaths more!");
            }
        }
    }
}
