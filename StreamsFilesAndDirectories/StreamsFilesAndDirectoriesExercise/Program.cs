using System;
using System.IO;
using System.Linq;

namespace StreamsFilesAndDirectoriesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            using var stream = new StreamReader("./text.txt");
            int counter = 0;

            while (!stream.EndOfStream)
            {
                var line = stream.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (counter % 2 == 0)
                {
                    line = line.Replace('-', '@');
                    line = line.Replace(',', '@');
                    line = line.Replace('.', '@');
                    line = line.Replace('!', '@');
                    line = line.Replace('?', '@');

                    line = String.Join(" ", line
                        .Split(' ')
                        .Reverse());

                    Console.WriteLine(line);
                    
                }

                counter++;

            }
        }
    }
}
