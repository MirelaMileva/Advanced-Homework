using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupCapacity = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            int[] bottleWithWater = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            Stack<int> bottles = new Stack<int>(bottleWithWater);
            Queue<int> cupsFilling = new Queue<int>(cupCapacity);

            int wastedWater = 0;
            int currentCupValue = 0;

            while (cupsFilling.Count > 0)
            {
                currentCupValue += cupsFilling.Peek();

                if (bottles.Count == 0)
                {
                    break;
                }
                else if (bottles.Peek() >= currentCupValue)
                {
                    cupsFilling.Dequeue();
                    wastedWater += bottles.Pop() - currentCupValue;
                    currentCupValue = 0;
                }
                else if (currentCupValue > bottles.Peek())
                {
                    while (currentCupValue > 0)
                    {
                        currentCupValue -= bottles.Pop();

                        if (currentCupValue <= bottles.Peek())
                        {
                            wastedWater += bottles.Pop() - currentCupValue;
                            cupsFilling.Dequeue();
                            currentCupValue = 0;
                            break;
                        }

                    }

                }
            }

            if (cupsFilling.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsFilling)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
