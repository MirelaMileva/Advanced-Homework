using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag()
        {
            data = new List<Present>();
        }

        public Bag(string color, int capacity)
            : this()
        {
            this.Color = color;
            this.Capacity = capacity;
        }
        public string Color { get; set; }
        public int Capacity { get; set; }

        public int Count
            => this.data.Count;

        public void Add(Present present)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            Present present = this.data.FirstOrDefault(p => p.Name == name);

            if (present != null)
            {
                this.data.Remove(present);
                return true;
            }

            return false;
        }

        public Present GetHeaviestPresent()
        {
            double heaviestPresent = double.MinValue;
            Present present = null;

            foreach (var currPresent in this.data)
            {
                if (currPresent.Weight > heaviestPresent)
                {
                    heaviestPresent = currPresent.Weight;
                    present = currPresent;
                }
            }

            return present;
        }

        public Present GetPresent(string name)
        {
            Present present = this.data.FirstOrDefault(p => p.Name == name);

            if (present != null)
            {
                return present;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");

            foreach (var present in this.data)
            {
                sb.AppendLine($"{present}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
