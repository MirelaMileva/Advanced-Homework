using System;

namespace _02.TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());

            char[,] field = new char[sizeOfField, sizeOfField];
            int firstPlayerRow = -1;
            int firstPlayerCol = -1;
            int secondPlayerRow = -1;
            int secondPlayerCol = -1;
            bool isDeadFirstPlayer = false;
            bool isDeadSecondPlayer = false;

            InitializeField(field, ref firstPlayerRow, ref firstPlayerCol, ref secondPlayerRow, ref secondPlayerCol);
            PrintField(field);

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string firstPlayerCommand = commands[0];
                string secondPlayerCommand = commands[1];

                switch (firstPlayerCommand)
                {
                    case "up":
                        firstPlayerRow--;
                        if (firstPlayerRow < 0)
                        {
                            firstPlayerRow = field.GetLength(0) - 1;
                        }
                        break;
                    case "down":
                        firstPlayerRow++;
                        if (firstPlayerRow > field.GetLength(0) - 1)
                        {
                            firstPlayerRow = 0;
                        }
                        break;
                    case "left":
                        firstPlayerCol--;
                        if (firstPlayerCol < 0)
                        {
                            firstPlayerCol = field.GetLength(1) - 1;
                        }
                        break;
                    case "right":
                        firstPlayerCol++;
                        if (firstPlayerCol > field.GetLength(1) - 1)
                        {
                            firstPlayerCol = 0;
                        }
                        break;
                }

                switch (secondPlayerCommand)
                {
                    case "up":
                        secondPlayerRow--;
                        if (secondPlayerRow < 0)
                        {
                            secondPlayerRow = field.GetLength(0) - 1;
                        }
                        break;
                    case "down":
                        secondPlayerRow++;
                        if (secondPlayerRow > field.GetLength(0) - 1)
                        {
                            secondPlayerRow = 0;
                        }
                        break;
                    case "left":
                        secondPlayerCol--;
                        if (secondPlayerCol < 0)
                        {
                            secondPlayerCol = field.GetLength(1) - 1;
                        }
                        break;
                    case "right":
                        secondPlayerCol++;
                        if (secondPlayerCol > field.GetLength(1) - 1)
                        {
                            secondPlayerCol = 0;
                        }
                        break;
                }

                if (IsInside(firstPlayerRow, firstPlayerCol, field))
                {
                    if (field[firstPlayerRow, firstPlayerCol] == '*')
                    {
                        field[firstPlayerRow, firstPlayerCol] = 'f';
                    }

                    if (field[firstPlayerRow, firstPlayerCol] == 's')
                    {
                        field[firstPlayerRow, firstPlayerCol] = 'x';
                        isDeadFirstPlayer = true;
                        break;
                    }
                }

                if (IsInside(secondPlayerRow, secondPlayerCol, field))
                {
                    if (field[secondPlayerRow, secondPlayerCol] == '*')
                    {
                        field[secondPlayerRow, secondPlayerCol] = 's';
                    }

                    if (field[secondPlayerRow, secondPlayerCol] == 'f')
                    {
                        field[secondPlayerRow, secondPlayerCol] = 'x';
                        isDeadSecondPlayer = true;
                        break;
                    }
                }

            }

            PrintField(field);
        }
        private static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        public  static void InitializeField(char[,] field, ref int firstPlayerRow, ref int firstPlayerCol, ref int secondPlayerRow, ref int secondPlayerCol)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowData[col];

                    if (field[row, col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }

                    if (field[row, col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
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
