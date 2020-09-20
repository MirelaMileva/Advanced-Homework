using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> changes = new Stack<string>();

            changes.Push(text.ToString());

            for (int i = 0; i < commands; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens[0] == "1")
                {
                    string textToAdd = tokens[1];
                    text.Append(textToAdd);
                    changes.Push(text.ToString());
                }
                else if (tokens[0] == "2")
                {
                    int elementsToRemove = int.Parse(tokens[1]);
                    text.Remove(text.Length - elementsToRemove, elementsToRemove);
                    changes.Push(text.ToString());
                }
                else if (tokens[0] == "3")
                {
                    int index = int.Parse(tokens[1]);
                    Console.WriteLine(text[index -1]);
                }
                else if(tokens[0] == "4")
                {
                    changes.Pop();
                    text = new StringBuilder();
                    text.Append(changes.Peek());
                }
            }
        }
    }
}
