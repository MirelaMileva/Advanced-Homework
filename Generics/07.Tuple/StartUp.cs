using System;
using System.Globalization;

namespace _07.Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] inputPersonInfo = Console.ReadLine()
                .Split();

            string[] inputPersonBeer = Console.ReadLine()
                .Split();

            string[] inputNumbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string fullName = inputPersonInfo[0] + " " + inputPersonInfo[1];
            string address = inputPersonInfo[2];

            string name = inputPersonBeer[0];
            int liters = int.Parse(inputPersonBeer[1]);

            int myInt = int.Parse(inputNumbers[0]);
            double myDouble = double.Parse(inputNumbers[1]);


            var personInfo = new Tuple<string, string>(fullName, address);
            var personBeer = new Tuple<string, int>(name, liters);
            var numbers = new Tuple<int, double>(myInt, myDouble);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(numbers);
        }
    }
}
