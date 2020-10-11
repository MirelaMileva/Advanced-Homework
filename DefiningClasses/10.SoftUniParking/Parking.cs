﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }

        public int Count 
            => this.cars.Count;

        public string AddCar(Car car)
        {
            bool IsExisting = cars.Any(c => c.RegistrationNumber == car.RegistrationNumber);

            if (IsExisting)
            {
                return "Car with that registration number, already exists!";
            }

            if (capacity == cars.Count)
            {
                return "Parking is full!";
            }

            cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(car);
            return $"Successfully removed {car.RegistrationNumber}";
        }

        public Car GetCar(string registrationNumber)
          =>  cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                var car = cars.FirstOrDefault(c => c.RegistrationNumber == regNumber);
                cars.Remove(car);
            }
        }
    }
}
