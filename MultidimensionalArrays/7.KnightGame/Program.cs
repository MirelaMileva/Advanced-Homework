using System;

namespace _7.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chestBoard = new char[n, n];

            int counter = 0;

            for (int row = 0; row < chestBoard.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                char[] charArray = input.ToCharArray();

                for (int col = 0; col < chestBoard.GetLength(1); col++)
                {
                    chestBoard[row, col] = charArray[col];
                }
            }

            int knightCount = 0;
            int attackerRow = 0;
            int attackerCol = 0;

            while (true)
            {
                int maxAttacker = 0;
                for (int row = 0; row < chestBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chestBoard.GetLength(1); col++)
                    {
                        int currentKnigth = 0;

                        if (chestBoard[row, col] == 'K')
                        {
                            if (IsInside(chestBoard, row - 2, col + 1) && chestBoard[row - 2, col + 1] == 'K')
                            {
                                currentKnigth++;
                            }

                            if (IsInside(chestBoard, row - 2, col - 1) && chestBoard[row - 2, col - 1] == 'K')
                            {
                                currentKnigth++;
                            }

                            if (IsInside(chestBoard, row - 1, col + 2) && chestBoard[row - 1, col + 2] == 'K')
                            {
                                currentKnigth++;
                            }

                            if (IsInside(chestBoard, row - 1, col - 2) && chestBoard[row - 1, col - 2] == 'K')
                            {
                                currentKnigth++;
                            }

                            if (IsInside(chestBoard, row + 1, col + 2) && chestBoard[row + 1, col + 2] == 'K')
                            {
                                currentKnigth++;
                            }

                            if (IsInside(chestBoard, row + 1, col - 2) && chestBoard[row + 1, col - 2] == 'K')
                            {
                                currentKnigth++;
                            }

                            if (IsInside(chestBoard, row + 2, col + 1) && chestBoard[row + 2, col + 1] == 'K')
                            {
                                currentKnigth++;
                            }

                            if (IsInside(chestBoard, row + 2, col - 1) && chestBoard[row + 2, col - 1] == 'K')
                            {
                                currentKnigth++;
                            }
                        }

                        if (currentKnigth > maxAttacker)
                        {
                            maxAttacker = currentKnigth;
                            attackerRow = row;
                            attackerCol = col;
                        }
                    }

                }

                if (maxAttacker > 0)
                {
                    chestBoard[attackerRow, attackerCol] = '0';
                    knightCount++;
                }
                else
                {
                    Console.WriteLine(knightCount);
                    break;
                }
            }

        }
        private static bool IsInside(char[,] chestBoard, int row, int col)
        {
            return row >= 0 && row < chestBoard.GetLength(0) &&
                col >= 0 && col < chestBoard.GetLength(1);
        }
    }
}
