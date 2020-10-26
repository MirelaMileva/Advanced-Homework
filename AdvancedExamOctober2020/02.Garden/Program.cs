using System;
using System.Collections.Generic;
using System.Linq;

namespace GardenSecondTry
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputRowAndCol = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int matrixRow = inputRowAndCol[0];
            int matrixCol = inputRowAndCol[1];
            int[,] matrix = new int[matrixRow, matrixCol];

            InitializeMatrix(matrix);

            string input;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                string[] inputInfo = input.Split();
                int currFlowerRow = int.Parse(inputInfo[0]);
                int currFlowerCol = int.Parse(inputInfo[1]);

                if (!IsInside(currFlowerRow, currFlowerCol, matrix))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                if (IsInside(currFlowerRow, currFlowerCol, matrix))
                {
                    matrix[currFlowerRow, currFlowerCol] = 1;
                }
            }

            List<int> indexes = new List<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        indexes.Add(row);
                        indexes.Add(col);
                    }
                }
            }

            BloomFlowers(matrix, indexes);

            PrintMatrix(matrix);
        }

        private static void BloomFlowers(int[,] matrix, List<int> indexes)
        {
            for (int i = 0; i < indexes.Count; i += 2)
            {
                int flowerRow = indexes[i];
                int flowerCol = indexes[i + 1];

                //right
                while (IsInside(flowerRow, flowerCol + 1, matrix))
                {
                    if (matrix[flowerRow, flowerCol + 1] == 1)
                    {
                        matrix[flowerRow, flowerCol + 1] += 1; 
                    }
                    else
                    {
                        matrix[flowerRow, flowerCol + 1] = 1;
                    }
   
                    flowerCol++;
                }

                //left
                flowerRow = indexes[i];
                flowerCol = indexes[i + 1];
                while (IsInside(flowerRow, flowerCol - 1, matrix))
                {
                    if (matrix[flowerRow, flowerCol - 1] == 1)
                    {
                        matrix[flowerRow, flowerCol - 1] += 1;
                    }
                    else
                    {
                        matrix[flowerRow, flowerCol - 1] = 1;
                    }
                    
                    flowerCol--;
                }


                //down
                flowerRow = indexes[i];
                flowerCol = indexes[i + 1];
                while (IsInside(flowerRow + 1, flowerCol, matrix))
                {
                    if (matrix[flowerRow + 1, flowerCol] == 1)
                    {
                        matrix[flowerRow + 1, flowerCol] +=1;
                    }
                    else
                    {
                        matrix[flowerRow + 1, flowerCol] = 1;
                    }
                   
                    flowerRow++;
                }

                // up
                flowerRow = indexes[i];
                flowerCol = indexes[i + 1];
                while (IsInside(flowerRow - 1, flowerCol, matrix))
                {
                    if (matrix[flowerRow - 1, flowerCol] == 1)
                    {
                        matrix[flowerRow - 1, flowerCol] +=1;
                    }
                    else
                    {
                        matrix[flowerRow - 1, flowerCol] = 1;
                    }
                    
                    flowerRow--;
                }
            }
        }

        private static void InitializeMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
