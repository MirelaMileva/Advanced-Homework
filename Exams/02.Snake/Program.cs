using System;
using System.Collections.Generic;
using System.Xml;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] territory = new char[fieldSize, fieldSize];
            int snakeRow = 0;
            int snakeCol = 0;
            int foodCount = 0;
            List<int> firstBurrow = new List<int>();
            List<int> secondBurrow = new List<int>();

            InitializeField(territory, ref snakeRow, ref snakeCol, ref firstBurrow, ref secondBurrow);

            string command = Console.ReadLine();

            while (true)
            {
                switch (command)
                {
                    case "up":
                        Move(-1, 0, territory, ref snakeRow, ref snakeCol, ref foodCount, ref firstBurrow, ref secondBurrow);
                        break;
                    case "down":
                        Move(1, 0, territory, ref snakeRow, ref snakeCol, ref foodCount, ref firstBurrow, ref secondBurrow);
                        break;
                    case "left":
                        Move(0, -1, territory, ref snakeRow, ref snakeCol, ref foodCount, ref firstBurrow, ref secondBurrow);
                        break;
                    case "right":
                        Move(0, 1, territory, ref snakeRow, ref snakeCol, ref foodCount, ref firstBurrow, ref secondBurrow);
                        break;
                }

                if (foodCount >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    Console.WriteLine($"Food eaten: {foodCount}");
                    PrintTerritory(territory);
                    break;
                }

                command = Console.ReadLine();
            }
        }
        private static void PrintTerritory(char[,] territory)
        {
            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static void Move(int row, int col, 
            char[,] territory, ref int snakeRow, 
            ref int snakeCol, ref int food, 
            ref List<int> firstBurrow, ref List<int> secondBurrow)
        {
            if (!IsInside(snakeRow + row, snakeCol + col, territory))
            {
                territory[snakeRow, snakeCol] = '.';
                Console.WriteLine($"Game over!");
                Console.WriteLine($"Food eaten: {food}");
                PrintTerritory(territory);
                Environment.Exit(0);
            }

            if (IsInside(snakeRow + row, snakeCol + col, territory))
            {
                territory[snakeRow, snakeCol] = '.';
                snakeRow += row;
                snakeCol += col;

                if (territory[snakeRow, snakeCol] == '*')
                {
                    food++;
                    territory[snakeRow, snakeCol] = 'S';
                }

                if (territory[snakeRow, snakeCol] == 'B' && firstBurrow[0] == snakeRow && firstBurrow[1] == snakeCol)
                {
                    territory[snakeRow, snakeCol] = '.';
                    snakeRow = secondBurrow[0];
                    snakeCol = secondBurrow[1];
                    territory[snakeRow, snakeCol] = 'S';

                }

                if (territory[snakeRow, snakeCol] == 'B' && firstBurrow[0] == snakeRow && firstBurrow[1] == snakeCol)
                {
                    territory[snakeRow, snakeCol] = '.';
                    snakeRow = firstBurrow[0];
                    snakeCol = firstBurrow[1];
                    territory[snakeRow, snakeCol] = 'S';
                }
            }
        }
        private static void InitializeField(char[,] territory, ref int snakeRow, ref int snakeCol, ref List<int> firstBurrow, ref List<int> secondBurrow)
        {
            for (int row = 0; row < territory.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    territory[row, col] = rowData[col];

                    if (territory[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (territory[row, col] == 'B')
                    {
                        if (firstBurrow.Count == 2)
                        {
                            secondBurrow.Add(row);
                            secondBurrow.Add(col);
                        }
                        else
                        {
                            firstBurrow.Add(row);
                            firstBurrow.Add(col);
                        }
                    }

                }
            }
        }

        private static bool IsInside(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
