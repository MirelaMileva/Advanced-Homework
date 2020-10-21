using System;
using System.Linq;

namespace _08.Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] inputPersonInfo = Console.ReadLine()
               .Split();

            string[] inputPersonBeer = Console.ReadLine()
                .Split();

            string[] inputBankAccount = Console.ReadLine()
               .Split();

            string fullName = inputPersonInfo[0] + " " + inputPersonInfo[1];
            string address = inputPersonInfo[2];
            string town = string.Join(" ", inputPersonInfo.Skip(3));

            string name = inputPersonBeer[0];
            int liters = int.Parse(inputPersonBeer[1]);
            bool isDrunk = inputPersonBeer[2] == "drunk" ? true : false;

            string nameOfAccount = inputBankAccount[0];
            double accountBalance = double.Parse(inputBankAccount[1]);
            string bankName = inputBankAccount[2];

            var personInfo = new Threeuple<string, string, string>(fullName, address, town);
            var personBeer = new Threeuple<string, int, bool>(name, liters, isDrunk);
            var accountDetails = new Threeuple<string, double, string>(nameOfAccount, accountBalance, bankName);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(accountDetails);
        }
    }
}
