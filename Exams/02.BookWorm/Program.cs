using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] initialWord = Console.ReadLine().ToCharArray();
            Stack<char> word = new Stack<char>(initialWord);
            int sizeOfField = int.Parse(Console.ReadLine());

            char[,] field = new char[sizeOfField, sizeOfField];
            int playerRow = 0;
            int playerCol = 0;

            InitializeField(field, ref playerRow, ref playerCol);

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "up":
                        Move(-1, 0, field, ref playerRow, ref playerCol, word);
                        break;
                    case "down":
                        Move(1, 0, field, ref playerRow, ref playerCol, word);
                        break;
                    case "left":
                        Move(0, -1, field, ref playerRow, ref playerCol, word);
                        break;
                    case "right":
                        Move(0, 1, field, ref playerRow, ref playerCol, word);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join("", word.Reverse()));
            PrintMatrix(field);
        }
        private static void PrintMatrix(char[,] field)
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

        private static void InitializeField(char[,] field, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowData[col];
                    if (field[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }

        private static void Move(int row, int col, char[,] matrix,ref int playerRow,ref int playerCol, Stack<char> word)
        {
            if (!IsInside(playerRow + row, playerCol + col, matrix))
            {
                if (word.Count > 0)
                {
                    word.Pop();
                }
            }

            if (IsInside(playerRow + row, playerCol + col, matrix))
            {
                char symbol = matrix[playerRow + row, playerCol + col];
                if (Char.IsLetter(symbol))
                {
                    word.Push(symbol);
                }

                matrix[playerRow, playerCol] = '-';

                playerRow += row;
                playerCol += col;

                matrix[playerRow, playerCol] = 'P';
            }
        }


        private static bool IsInside(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
