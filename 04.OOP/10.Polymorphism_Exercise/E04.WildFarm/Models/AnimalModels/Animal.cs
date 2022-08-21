namespace WildFarm
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
           this.Name = name;
           this.Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public abstract string AskForFood();

        public abstract bool EatFood(string foodType, int foodQty);
    }
}
