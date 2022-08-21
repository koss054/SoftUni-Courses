namespace WildFarm
{
    public interface IAnimal
    {
        public string Name { get; }

        public double Weight { get; }

        public int FoodEaten { get; }

        public string AskForFood();

        public bool EatFood(string foodType, int foodQty);
    }
}
