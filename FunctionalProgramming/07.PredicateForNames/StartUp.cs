using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int nameLenght = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split()
                .Where(n => n.Length <= nameLenght)
                .ToList();

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
