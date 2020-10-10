using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make 
        {
            get { return this.make; }
            set { this.make = value; }
        }
        public string Model 
        {
            get { return this.model; }
            set { this.model = value; } 
        }
        public int Year 
        { 
            get; 
            set;
        }
        public double FuelQuantity 
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double consumation = fuelQuantity - (distance * fuelConsumption);
            if (consumation > 0)
            {
                fuelQuantity -= (distance * fuelConsumption);
            }
            else
            {
                throw new InvalidOperationException("Not enough fuel to perform this trip!");
            }
        }

        public string Print()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L";
        }
    }
}
