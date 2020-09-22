using System;
using System.Linq;

namespace MultidimensionalArraysExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().
                    Split().
                    Select(int.Parse).
                    ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int diagonalSum = 0;
            int secondDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int number = matrix[row, col];
                    if (row == col)
                    {
                        diagonalSum += number;
                    }

                    if (col == n - 1 - row )
                    {
                        secondDiagonalSum += number;
                    }
                }
            }

            Console.WriteLine(Math.Abs(diagonalSum - secondDiagonalSum));
        }
    }
}
