using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();
            var locks = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Queue<int> locksNumbers = new Queue<int>(locks);
            Stack<int> bulletsNumber = new Stack<int>(bullets);
            int barrelSizeCount = 0;
            int moneyEarned = 0;
            int bulletUsed = 0;

            while (bulletsNumber.Count > 0)
            {

                if (barrelSizeCount == barrelSize)
                {
                    Console.WriteLine("Reloading!");
                    barrelSizeCount = 0;
                }
                else if (locksNumbers.Count == 0)
                {
                    break;
                }
                else if (bulletsNumber.Peek() <= locksNumbers.Peek())
                {
                    locksNumbers.Dequeue();
                    bulletsNumber.Pop();
                    barrelSizeCount++;
                    bulletUsed++;
                    Console.WriteLine("Bang!");
                }
                else if (bulletsNumber.Peek() > locksNumbers.Peek())
                {
                    bulletsNumber.Pop();
                    barrelSizeCount++;
                    bulletUsed++;
                    Console.WriteLine("Ping!");
                }
            }

            if (bulletsNumber.Count == 0)
            {
                if (locksNumbers.Count == 0)
                {
                    int bulletsSum = bulletUsed * bulletPrice;
                    moneyEarned = intelligence - bulletsSum;
                    Console.WriteLine($"{bulletsNumber.Count} bullets left. Earned ${moneyEarned}");
                }
                else
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksNumbers.Count}");
                }

            }
            else 
            {
                int bulletsSum = bulletUsed * bulletPrice;
                moneyEarned = intelligence - bulletsSum;
                Console.WriteLine($"{bulletsNumber.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
