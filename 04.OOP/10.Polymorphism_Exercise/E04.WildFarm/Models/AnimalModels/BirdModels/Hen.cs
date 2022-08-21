namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override bool EatFood(string foodType, int foodQty)
        {
            this.Weight += (foodQty * 0.35);
            this.FoodEaten += foodQty;
            return true;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
