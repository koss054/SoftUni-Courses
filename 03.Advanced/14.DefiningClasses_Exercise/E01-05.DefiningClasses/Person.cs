using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Person
    {
        List<Person> people;
        string name;
        int age;

        public Person()
        {
            name = "No name";
            age = 1;
        }

        public Person(int age)
            : this()
        {
            this.age = age;
        }

        public Person(string name, int age)
            : this (age)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}
