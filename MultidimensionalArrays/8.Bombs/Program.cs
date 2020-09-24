using System;
using System.Data;
using System.Linq;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            FillMatrix(matrix);
            string[] bombCoordinates = Console.ReadLine().
                Split(' ');

            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                int[] bombInfo = bombCoordinates[i].
                    Split(',', StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();

                int currRow = bombInfo[0];
                int currCol = bombInfo[1];
                int currBomb = matrix[currRow, currCol];

                if (currBomb > 0)
                {
                    matrix = BombExpode(matrix, currRow, currCol, currBomb);
                    matrix[currRow, currCol] = 0;
                }

            }

            int activeCells = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        activeCells++;
                    }
                }
            }
            PrintMatrix(matrix, activeCells, sum);

        }

        private static void PrintMatrix(int[,] matrix, int activeCells, int sum)
        {
            Console.WriteLine($"Alive cells: {activeCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] BombExpode(int[,] matrix, int row, int col, int bomb)
        {
            if (IsInside(matrix, row - 1, col - 1) && matrix[row -1, col -1] > 0)
            {
                matrix[row - 1, col - 1] -= bomb;
            }
            if (IsInside(matrix, row - 1, col) && matrix[row - 1, col] > 0)
            {
                matrix[row - 1, col] -= bomb;
            }
            if (IsInside(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
            {
                matrix[row - 1, col + 1] -= bomb;
            }
            if (IsInside(matrix, row, col - 1) && matrix[row, col - 1] > 0)
            {
                matrix[row, col - 1] -= bomb;
            }
            if (IsInside(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
            {
                matrix[row + 1, col - 1] -= bomb;
            }
            if (IsInside(matrix, row, col + 1) && matrix[row , col + 1] > 0)
            {
                matrix[row, col + 1] -= bomb;
            }
            if (IsInside(matrix, row + 1, col) && matrix[row + 1, col] > 0)
            {
                matrix[row + 1, col] -= bomb;
            }
            if (IsInside(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
            {
                matrix[row + 1, col + 1] -= bomb;
            }

            return matrix;
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }

        private static bool IsInside(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}

