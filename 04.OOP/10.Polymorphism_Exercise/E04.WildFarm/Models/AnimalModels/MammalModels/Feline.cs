namespace WildFarm
{
    public abstract class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }
    }
}
