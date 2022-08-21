using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            return people.OrderByDescending(a => a.Age).First();      
        }
    }
}
