using System;
using System.Linq;

namespace _2.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            char[,] matrix = new char[dimentions[0], dimentions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries).
                    Select(char.Parse).
                    ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    bool isEqual = matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row + 1, col] == matrix[row + 1, col + 1] &&
                        matrix[row + 1, col] == matrix[row, col];

                    if (isEqual)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
