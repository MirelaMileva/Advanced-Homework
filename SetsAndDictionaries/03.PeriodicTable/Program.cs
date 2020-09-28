using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalCompounds = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemicals = Console.ReadLine().Split();

                for (int k = 0; k < chemicals.Length; k++)
                {
                    if (!chemicalCompounds.Contains(chemicals[k]))
                    {
                        chemicalCompounds.Add(chemicals[k]);
                    }
                }
                
            }

            foreach (var chem in chemicalCompounds)
            {
                Console.Write(chem + " ");
            }
        }
    }
}
