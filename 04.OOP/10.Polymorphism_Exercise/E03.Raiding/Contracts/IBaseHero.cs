namespace E03.Raiding.Contracts
{
    public interface IBaseHero
    {
        public string Name { get; }

        public int Power { get; }

        public string CastAbility();
    }
}
