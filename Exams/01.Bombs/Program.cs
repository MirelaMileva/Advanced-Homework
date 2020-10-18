using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffectsInput = Console.ReadLine()
                .Split(",")
                .Select(int.Parse)
                .ToArray();

            int[] bombCasingInput = Console.ReadLine()
                .Split(",")
                .Select(int.Parse)
                .ToArray();

            Queue<int> bombEffects = new Queue<int>(bombEffectsInput);
            Stack<int> bombCasing = new Stack<int>(bombCasingInput);

            int daturaBombType = 40;
            int cherryBombType = 60;
            int smokeDecoyBombType = 120;

            Dictionary<string, int> bombTypes = new Dictionary<string, int>();
            bombTypes.Add("Datura Bombs", 0);
            bombTypes.Add("Cherry Bombs", 0);
            bombTypes.Add("Smoke Decoy Bombs", 0);

            while (bombEffects.Count > 0 && bombCasing.Count > 0)
            {
                int currBombSum = bombCasing.Peek() + bombEffects.Peek();

                if (currBombSum == daturaBombType)
                {
                    bombTypes["Datura Bombs"]++;
                    bombCasing.Pop();
                    bombEffects.Dequeue();
                }
                else if (currBombSum == cherryBombType)
                {
                    bombTypes["Cherry Bombs"]++;
                    bombCasing.Pop();
                    bombEffects.Dequeue();
                }
                else if (currBombSum == smokeDecoyBombType)
                {
                    bombTypes["Smoke Decoy Bombs"]++;
                    bombCasing.Pop();
                    bombEffects.Dequeue();
                }
                else
                {
                    int currBombCasing = bombCasing.Peek();
                    bombCasing.Pop();
                    bombCasing.Push(currBombCasing - 5);
                }

                if (bombTypes["Datura Bombs"] >= 3 && bombTypes["Cherry Bombs"] >= 3 && bombTypes["Smoke Decoy Bombs"] >= 3)
                {
                    break;
                }
            }

            bombTypes = bombTypes.OrderBy(b => b.Key).ToDictionary(a => a.Key, b => b.Value);

            if (bombTypes["Datura Bombs"] >= 3 && bombTypes["Cherry Bombs"] >= 3 && bombTypes["Smoke Decoy Bombs"] >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                PrintOutput(bombEffects, bombCasing, bombTypes);
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
                PrintOutput(bombEffects, bombCasing, bombTypes);
            }
        }

        private static void PrintOutput(Queue<int> bombEffects, Stack<int> bombCasing, Dictionary<string, int> bombTypes)
        {
            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombTypes)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}

