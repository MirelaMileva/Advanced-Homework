using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            double[][] jaggedMatrix = new double[dimentions][];

            FillMatrix(jaggedMatrix);

            CheckRowsForEqualLength(jaggedMatrix);

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitted = command.
                    Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                int value = int.Parse(splitted[3]);

                if (!IsValid(jaggedMatrix, row, col))
                {
                    continue;
                }

                if (splitted.Contains("Add"))
                {
                    jaggedMatrix[row][col] += value;
                }
                else if (splitted.Contains("Subtract"))
                {
                    jaggedMatrix[row][col] -= value;
                }
            }

            foreach (var row in jaggedMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }

        private static bool IsValid(double[][] jaggedMatrix, int row, int col)
        {
            return row >= 0 && row < jaggedMatrix.Length &&
                col >= 0 && col < jaggedMatrix[row].Length;
        }

        private static void CheckRowsForEqualLength(double[][] jaggedMatrix)
        {
            for (int row = 0; row < jaggedMatrix.Length - 1; row++)
            {
                if (jaggedMatrix[row].Length == jaggedMatrix[row + 1].Length)
                {
                    for (int col = 0; col < jaggedMatrix[row].Length; col++)
                    {
                        jaggedMatrix[row][col] *= 2;
                        jaggedMatrix[row + 1][col] *= 2;
                    }

                }
                else
                {
                    for (int col = 0; col < jaggedMatrix[row].Length; col++)
                    {
                        jaggedMatrix[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedMatrix[row + 1].Length; col++)
                    {
                        jaggedMatrix[row + 1][col] /= 2;
                    }
                }
            }
        }

        private static void FillMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                int[] rowData = Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();

                matrix[row] = new double[rowData.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = rowData[col];
                }

            }
        }
    }
}
