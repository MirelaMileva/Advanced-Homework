using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            //HashSet<int> firstSet = new HashSet<int>();
            //HashSet<int> secondSet = new HashSet<int>();

            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = nums[0];
            int m = nums[1];

            List<int> firstRow = new List<int>();
            List<int> secondRow = new List<int>();
            HashSet<int> repeatedNumber = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstRow.Add(number);
            }

            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondRow.Add(number);
            }

            foreach (var num in firstRow)
            {
                if (firstRow.Contains(num) && secondRow.Contains(num))
                {
                    repeatedNumber.Add(num);
                }
 
            }

            foreach (var item in repeatedNumber)
            {
                Console.Write(item + " ");
            }
        }
    }
}
