using E03.Raiding.Contracts;

namespace E03.Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; private set; }

        public int Power { get; private set; }

        public virtual string CastAbility()
        {
            return null;
        }
    }
}
