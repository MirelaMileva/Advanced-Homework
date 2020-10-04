using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");
            string[] textLines = File.ReadAllLines("../../../text.txt");

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordsCount.Add(word, 0);
            }

            char[] separator = { ' ', ',', '!', '?', '.', '-' };

            foreach (var line in textLines)
            {
                string[] currLine = line.ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in currLine)
                {
                    if (wordsCount.ContainsKey(word))
                    {
                        wordsCount[word]++;
                       
                    }
                }
            }

            using var actualResult = new StreamWriter("../../../actualResult.txt");

            foreach (var word in wordsCount)
            {
                actualResult.WriteLine($"{word.Key}-{word.Value}");
            }

            using var expectedResult = new StreamWriter("../../../expextedResult.txt");

            foreach (var item in wordsCount.OrderByDescending(i => i.Value))
            {
                expectedResult.WriteLine($"{item.Key}-{item.Value}");
            }

        }
    }
}
