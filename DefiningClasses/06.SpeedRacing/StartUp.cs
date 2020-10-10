using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carsInfo = Console.ReadLine().Split();
                string model = carsInfo[0];
                double fuelAmount = double.Parse(carsInfo[1]);
                double fuelConsumptionForOneKm = double.Parse(carsInfo[2]); 

                Car car = new Car(model, fuelAmount, fuelConsumptionForOneKm, 0);
                cars.Add(car);

            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var cmdArgs = command.Split();
                string commandType = cmdArgs[0];
                string carModel = cmdArgs[1];
                int km = int.Parse(cmdArgs[2]);

                foreach (var car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.Drive(car.FuelAmount, car.FuelConsumptionPerKilometer, km);
                    }
                    
                }

            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
