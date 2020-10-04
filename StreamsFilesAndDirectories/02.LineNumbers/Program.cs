using System;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string currLine = lines[i];

                int lettersCount = CountOfLetters(currLine);
                int symbolsCount = CountOfPunctuationSymbols(currLine);

                lines[i] = $"Line {i + 1}: {currLine} ({lettersCount})({symbolsCount})";
            }

            File.WriteAllLines("../../../output.txt", lines);

        }

        static int CountOfLetters(string line)
        {
            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];

                if (Char.IsLetter(current))
                {
                    counter++;
                }
            }

            return counter;
        }

        static int CountOfPunctuationSymbols(string line)
        {
            char[] symbols = { '-', ',', '.', '!', '?', '\'' };
            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];

                if (symbols.Contains(current))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
