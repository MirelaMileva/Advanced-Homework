using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine().Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                var person = new Person(name, age);

                if (person.Age > 30)
                {
                    people.Add(person);
                }
               
            }

            foreach (var currPeople in people.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{currPeople.Name} - {currPeople.Age}");
            }
        }
    }
}
