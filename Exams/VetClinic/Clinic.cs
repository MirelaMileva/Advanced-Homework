using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic()
        {
            data = new List<Pet>();
        }
        public Clinic(int capacity)
            : this()
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Count
            => this.data.Count;

        public void Add(Pet pet)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.data.FirstOrDefault(p => p.Name == name);

            if (pet != null)
            {
                this.data.Remove(pet);

                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.data.FirstOrDefault(p => p.Name == name && p.Owner == owner);

            if (pet != null)
            {
                return pet;
            }
            else
            {
                return null;
            }

        }

        public Pet GetOldestPet()
        {
            int oldestPet = int.MinValue;
            Pet pet = null;

            foreach (var currPet in this.data)
            {
                if (currPet.Age > oldestPet)
                {
                    oldestPet = currPet.Age;
                    pet = currPet;
                }
            }

            return pet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The clinic has the following patients:");

            foreach (var pet in this.data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

                                                                                                                        