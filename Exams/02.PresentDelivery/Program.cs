using System;
using System.Linq;
using System.Reflection.Metadata;

namespace _02.PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int sizeOfNeighborhood = int.Parse(Console.ReadLine());
            char[,] neighborhood = new char[sizeOfNeighborhood, sizeOfNeighborhood];
            int santaRow = -1;
            int santaCol = -1;
            int niceKidsPresents = 0;
            int niceKidsCount = 0;

            InitializeNeighborhood(neighborhood, ref santaRow, ref santaCol, ref niceKidsCount);

            while (true)
            {
                if (presentsCount == 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    break;
                }

                string command = Console.ReadLine();

                if (command == "Christmas morning")
                {
                    break;
                }

                neighborhood[santaRow, santaCol] = '-';

                switch (command)
                {
                    case "up":
                        santaRow--;
                        break;
                    case "down":
                        santaRow++;
                        break;
                    case "left":
                        santaCol--;
                        break;
                    case "right":
                        santaCol++;
                        break;
                }

                if (IsInside(santaRow, santaCol, neighborhood))
                {
                    if (neighborhood[santaRow, santaCol] == 'V')
                    {
                        presentsCount--;
                        niceKidsCount--;
                        niceKidsPresents++;
                        neighborhood[santaRow, santaCol] = 'S';
                    }
                    else if (neighborhood[santaRow, santaCol] == 'X')
                    {
                        neighborhood[santaRow, santaCol] = 'S';
                    }
                    else if (neighborhood[santaRow, santaCol] == 'C')
                    {
                        neighborhood[santaRow, santaCol] = 'S';

                        if (IsInside(santaRow - 1, santaCol, neighborhood) &&
                            neighborhood[santaRow - 1, santaCol] == 'V' ||
                            neighborhood[santaRow - 1, santaCol] == 'X')
                        {
                            presentsCount--;
                            if (neighborhood[santaRow - 1, santaCol] == 'V')
                            {
                                niceKidsCount--;
                            }
                            neighborhood[santaRow - 1, santaCol] = '-';
                        }

                        if (IsInside(santaRow + 1, santaCol, neighborhood) &&
                             neighborhood[santaRow + 1, santaCol] == 'V' ||
                            neighborhood[santaRow + 1, santaCol] == 'X')
                        {
                            presentsCount--;
                            if (neighborhood[santaRow + 1, santaCol] == 'V')
                            {
                                niceKidsCount--;
                            }
                            neighborhood[santaRow + 1, santaCol] = '-';
                        }

                        if (IsInside(santaRow, santaCol - 1, neighborhood) &&
                             (neighborhood[santaRow, santaCol - 1] == 'V' ||
                            neighborhood[santaRow, santaCol - 1] == 'X'))
                        {
                            presentsCount--;
                            if (neighborhood[santaRow, santaCol - 1] == 'V')
                            {
                                niceKidsCount--;
                            }
                            neighborhood[santaRow, santaCol - 1] = '-';
                        }

                        if (IsInside(santaRow, santaCol + 1, neighborhood) &&
                             (neighborhood[santaRow, santaCol + 1] == 'V' ||
                            neighborhood[santaRow, santaCol + 1] == 'X'))
                        {
                            presentsCount--;
                            if (neighborhood[santaRow, santaCol + 1] == 'V')
                            {
                                niceKidsCount--;
                            }
                            neighborhood[santaRow, santaCol + 1] = '-';
                        }
                    }

                    neighborhood[santaRow, santaCol] = 'S';
                }
            }

            PrintNeighborhood(neighborhood);

            if (niceKidsCount == 0)
            {
                Console.WriteLine($"Good job, Santa! {niceKidsPresents} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKidsCount} nice kid/s.");
            }
        }

        private static void InitializeNeighborhood(char[,] neighborhood, ref int santaRow, ref int santaCol, ref int niceKidsCount)
        {
            for (int row = 0; row < neighborhood.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < neighborhood.GetLength(1); col++)
                {
                    neighborhood[row, col] = rowData[col];

                    if (neighborhood[row, col] == 'S')
                    {
                        santaRow = row;
                        santaCol = col;
                    }
                    if (neighborhood[row, col] == 'V')
                    {
                        niceKidsCount++;
                    }
                }
            }

        }

        private static void PrintNeighborhood(char[,] neighborhood)
        {
            for (int row = 0; row < neighborhood.GetLength(0); row++)
            {
                for (int col = 0; col < neighborhood.GetLength(1); col++)
                {
                    Console.Write(neighborhood[row, col] + " ");
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
