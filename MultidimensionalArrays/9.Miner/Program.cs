using System;
using System.Linq;

namespace _9.Miner
{
    class Program
    {
        static char[,] matrix;
        static int minerRow;
        static int minerCol;
        static int coals;
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            matrix = new char[fieldSize, fieldSize];

            string[] commands = Console.ReadLine().Split();

            FillMatrix();

            foreach (var direction in commands)
            {
                if (direction == "left")
                {
                    Move(0, -1);
                }
                else if (direction == "right")
                {
                    Move(0, 1);
                }
                else if (direction == "up")
                {
                    Move(-1, 0);
                }
                else if (direction == "down")
                {
                    Move(1, 0);
                }
            }

            Console.WriteLine($"{coals} coals left. ({minerRow}, {minerCol})");
        }

        private static void Move(int row, int col)
        {
            if (IsInside(minerRow + row, minerCol + col))
            {
                minerRow += row;
                minerCol += col;

                if (matrix[minerRow, minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    Environment.Exit(0);
                }

                if (matrix[minerRow, minerCol] == 'c')
                {
                    coals--;
                    matrix[minerRow, minerCol] = '*';

                    if (coals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    if (matrix[row, col] == 'c')
                    {
                        coals++;
                    }
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
