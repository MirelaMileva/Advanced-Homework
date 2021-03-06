﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking()
        {
            data = new List<Car>();
        }

        public Parking(string type, int capacity)
            :this()
        {
            this.Type = type;
            this.Capacity = capacity;
        }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count
            => this.data.Count;

        public void Add(Car car)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (car != null)
            {
                this.data.Remove(car);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            int latestYear = int.MinValue;
            Car car = null;

            foreach (var currCar in data)
            {
                if (currCar.Year > latestYear)
                {
                    latestYear = currCar.Year;
                    car = currCar;
                }
            }

            return car;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (car != null)
            {
                return car;
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in this.data)
            {
                sb.AppendLine($"{car}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
