using BirthdayCelebrations.Contracts;

namespace BirthdayCelebrations.Models
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }
    }
}
