using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] files = Directory.GetFiles(input);

            Dictionary<string, Dictionary<string, double>> fileInfo = new Dictionary<string, Dictionary<string, double>>();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";

            foreach (var filePath in files)
            {
                string fileName = filePath
                    .Split('\\').Last();
                string extension = fileName
                    .Split('.').Last();

                FileInfo fileInf = new FileInfo(fileName);
                double size = fileInf.Length / 1024d;

                if (!fileInfo.ContainsKey(extension))
                {
                    fileInfo.Add(extension, new Dictionary<string, double>());
                }

                fileInfo[extension].Add(fileName, size);

            }

            fileInfo = fileInfo.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key).ToDictionary(a => a.Key, b => b.Value);

            foreach (var file in fileInfo)
            {
                File.AppendAllText(path, $".{file.Key}" + Environment.NewLine);

                foreach (var item in file.Value.OrderBy(i => i.Value))
                {
                    File.AppendAllText(path, $"--{item.Key} - {item.Value:f3}kb" + Environment.NewLine);
                }
            }

        }

    }
}
