using System;

namespace _06.GenericCountMethodDouble
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                box.Values.Add(number);
            }

            double targetItem = double.Parse(Console.ReadLine());

            double result = box.GreaterValueThan(targetItem);

            Console.WriteLine(result);
        }
    }
}
