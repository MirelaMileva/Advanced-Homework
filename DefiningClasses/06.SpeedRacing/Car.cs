using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuel, double fuelConsumption, double travelledDistance)
        {
            this.Model = model;
            this.FuelAmount = fuel;
            this.FuelConsumptionPerKilometer = fuelConsumption;
            this.TravelledDistance = travelledDistance;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double fuelAmount, double fuelConsumtion, double distanceToTravel)
        {
            double neededLitersToDrive = distanceToTravel * fuelConsumtion;

            if (neededLitersToDrive <= fuelAmount)
            {
                this.FuelAmount -= neededLitersToDrive;
                this.TravelledDistance += distanceToTravel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

        }
    }
}
