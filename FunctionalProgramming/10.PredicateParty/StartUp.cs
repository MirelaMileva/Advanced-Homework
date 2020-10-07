using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                 .Split()
                 .ToList();

            Func<string, int, bool> lengthFunc = (name, length) => name.Length == length;
            Func<string, string, bool> startsWithFunc = (name, startsWithString) => name.StartsWith(startsWithString);
            Func<string, string, bool> endsWithFunc = (name, endsWithString) => name.EndsWith(endsWithString);

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                //Double Length 5
                string[] commandInfo = command.Split();
                string action = commandInfo[0];
                string condition = commandInfo[1];
                string param = commandInfo[2];

                if (action == "Double")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(param);
                        var temp = names.Where(x => lengthFunc(x, length)).ToList();
                        MyAddRange(names, temp);

                    }
                    else if (condition == "StartsWith")
                    {
                        var temp = names.Where(x => startsWithFunc(x, param)).ToList();
                        MyAddRange(names, temp);
                    }
                    else if (condition == "EndsWith")
                    {
                        var temp = names.Where(x => endsWithFunc(x, param)).ToList();
                        MyAddRange(names, temp);
                    }
                }
                else if (action == "Remove")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(param);
                        names = names.Where(x => !lengthFunc(x, length)).ToList();
                    }
                    else if (condition == "StartsWith")
                    {
                        names = names.Where(x => !startsWithFunc(x, param)).ToList();
                    }
                    else if (condition == "EndsWith")
                    {
                        names = names.Where(x => !endsWithFunc(x, param)).ToList();
                    }
                }

                command = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void MyAddRange(List<string> names, List<string> temp)
        {
            foreach (var currName in temp)
            {
                int index = names.IndexOf(currName);
                names.Insert(index, currName);
            }
        }
    }
}
