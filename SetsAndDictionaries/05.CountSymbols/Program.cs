using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];

                if (!symbols.ContainsKey(current))
                {
                    symbols.Add(current, 0);
                }

                symbols[current]++;
            }

            foreach (var sym in symbols)
            {
                Console.WriteLine($"{sym.Key}: {sym.Value} time/s");
            }
        }
    }
}
