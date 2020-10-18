using System;
using System.Linq;
using System.Numerics;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int beeRow = 0; ;
            int beeCol = 0;
            FillMatrix(matrix, ref beeRow, ref beeCol);

            int polinationedFlowers = 0;
            string command = Console.ReadLine();

            while (command != "End")
            {
                switch (command)
                {
                    case "up":
                        Move(-1, 0, ref beeRow, ref beeCol, matrix,ref polinationedFlowers);
                        break;
                    case "down":
                        Move(1, 0, ref beeRow, ref beeCol, matrix,ref polinationedFlowers);
                        break;
                    case "left":
                        Move(0, -1, ref beeRow, ref beeCol, matrix,ref polinationedFlowers);
                        break;
                    case "right":
                        Move(0, 1, ref beeRow, ref beeCol, matrix,ref polinationedFlowers);
                        break;
                }

                command = Console.ReadLine();
            }

            CheckAndPrintPollinatedFlowers(polinationedFlowers);
            PrintMatrix(matrix);

        }

        private static void CheckAndPrintPollinatedFlowers(int polinationedFlowers)
        {
            if (polinationedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinationedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinationedFlowers} flowers more");
            }
        }

        private static void Move(int row, int col, ref int beeRow, ref int beeCol, char[,] matrix, ref int flowers)
        {
            if (!IsInside(beeRow + row, beeCol + col, matrix))
            {
                matrix[beeRow, beeCol] = '.';
                Console.WriteLine("The bee got lost!");
                CheckAndPrintPollinatedFlowers(flowers);
                PrintMatrix(matrix);
                Environment.Exit(0);
            }

            if (IsInside(beeRow + row, beeCol + col, matrix))
            {
                if (matrix[beeRow + row, beeCol + col] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';

                    beeRow += row;
                    beeCol += col;

                    matrix[beeRow, beeCol] = 'B';

                    if (IsInside(beeRow + row, beeCol + col, matrix))
                    {
                        if (matrix[beeRow + row, beeCol + col] == 'f')
                        {
                            flowers++;
                        }

                        matrix[beeRow, beeCol] = '.';
                        beeRow += row;
                        beeCol += col;
                        matrix[beeRow, beeCol] = 'B';
                        return;
                    }

                }
                if (matrix[beeRow + row, beeCol + col] == 'f')
                {
                    flowers++;
                    matrix[beeRow, beeCol] = '.';

                    beeRow += row;
                    beeCol += col;

                    matrix[beeRow, beeCol] = 'B';
                }
                else
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow += row;
                    beeCol += col;
                    matrix[beeRow, beeCol] = 'B';
                }
                
            }
        }

        private static void FillMatrix(char[,] matrix, ref int beeRow, ref int beeCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }

                }
            }

        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
