using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.NovoReshenie
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();
            List<string> filters = new List<string>();

            while (input != "Print")
            {
                string[] tokens = input.Split(";");
                string command = tokens[0];
                string filterType = tokens[1];
                string filterParam = tokens[2];
                if (command == "Add filter")
                {
                    filters.Add($"{filterType};{filterParam}");
                }
                else if (command == "Remove filter")
                {
                    filters.Remove($"{filterType};{filterParam}");
                }

                input = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                string[] tokens = filter.Split(";");
                string filterType = tokens[0];
                string filterParam = tokens[1];

                switch (filterType)
                {
                    case "Starts with":
                        names = names.Where(n => !n.StartsWith(filterParam)).ToList();
                        break;
                    case "Ends with":
                        names = names.Where(n => !n.EndsWith(filterParam)).ToList();
                        break;
                    case "Length":
                        names = names.Where(n => n.Length != int.Parse(filterParam)).ToList();
                        break;
                    case "Contains":
                        names = names.Where(n => !n.Contains(filterParam)).ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
