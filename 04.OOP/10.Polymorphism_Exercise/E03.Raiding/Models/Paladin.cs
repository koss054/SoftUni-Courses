namespace E03.Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) 
            : base(name, 100)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
