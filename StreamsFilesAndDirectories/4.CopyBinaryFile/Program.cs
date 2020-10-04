﻿using System;
using System.IO;

namespace _4.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
           using FileStream reader = new FileStream("../../../copyMe.png", FileMode.OpenOrCreate);

            using FileStream writer = new FileStream("../../../copied.png", FileMode.OpenOrCreate);

            byte[] buffer = new byte[4096];

            while (reader.CanRead)
            {
                var bytesRead = reader.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                {
                    break;
                }

                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
