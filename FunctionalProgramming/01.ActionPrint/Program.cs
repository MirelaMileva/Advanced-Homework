using System;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");

            Action<string[]> printer = names => { Console.WriteLine(string.Join("\n", input)); };

            printer(input);
        }

    }
}
