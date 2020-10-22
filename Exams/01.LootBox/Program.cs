using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLootBoxInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var secondLootBoxInput = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            Queue<int> firstLootBox = new Queue<int>(firstLootBoxInput);
            Stack<int> secondLootBox = new Stack<int>(secondLootBoxInput);
            int collectionItems = 0;

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                var currFirstLootItem = firstLootBox.Peek();
                var currSecondLootItem = secondLootBox.Peek();
                int currValuesSum = currFirstLootItem + currSecondLootItem;

                if (currValuesSum % 2 == 0)
                {
                    collectionItems += currValuesSum;
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    firstLootBox.Enqueue(currSecondLootItem);
                    secondLootBox.Pop();
                }

            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (secondLootBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (collectionItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collectionItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collectionItems}");
            }
        }
    }
}
