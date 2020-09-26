﻿using System;
using System.Collections.Generic;

namespace SetsAndDictionariesExerciseAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (!names.Contains(input))
                {
                    names.Add(input);
                }
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
