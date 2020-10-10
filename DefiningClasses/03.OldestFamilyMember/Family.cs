using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People { get;set; }

        public void AddMembers(Person member)
        {
            People.Add(member);   
        }

        public Person GetOldestMember()
        {
            int maxAge = int.MinValue;
            Person person = null;

            foreach (var currPerson in People)
            {
                var currentAge = currPerson.Age;
                if (currentAge > maxAge)
                {
                    maxAge = currentAge;
                    person = currPerson;
                }
            }

            return person;
        }
    }
}
