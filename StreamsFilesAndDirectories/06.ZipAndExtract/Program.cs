using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\Users\mirel\Desktop\ZipAndExtract", @"C:\Users\mirel\source\repos\StreamsFilesAndDirectoriesExercise\06.ZipAndExtract\archive.zip");
            ZipFile.ExtractToDirectory(@"C:\Users\mirel\source\repos\StreamsFilesAndDirectoriesExercise\06.ZipAndExtract\archive.zip",
                @"C:\Users\mirel\Desktop\SoftUni");
        }
    }
}
