using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");

            var songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                string commands = Console.ReadLine();

                if (commands.Contains("Play"))
                {
                    songs.Dequeue();
                }
                else if (commands.Contains("Add"))
                {
                    string songToAdd = commands.Substring(4, commands.Length - 4);

                    if (songs.Contains(songToAdd))
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(songToAdd);
                    }
                    
                }
                else if (commands.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
