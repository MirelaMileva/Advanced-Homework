using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] currClothes = input[1].Split(",");

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());

                }

                foreach (var item in currClothes)
                {
                    if (!clothes[color].ContainsKey(item))
                    {
                        clothes[color].Add(item, 0);
                    }

                    clothes[color][item]++;
                }

            }

            string[] lookUpItem = Console.ReadLine().Split();
            string colorToLook = lookUpItem[0];
            string itemToLook = lookUpItem[1];

            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes: ");

                foreach (var clothe in color.Value)
                {
                    if (color.Key == colorToLook && clothe.Key == itemToLook)
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
                    }

                }
            }
        }
    }
}
