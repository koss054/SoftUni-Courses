namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override bool EatFood(string foodType, int foodQty)
        {
            if (foodType == "Meat")
            {
                this.Weight += (foodQty * 0.25);
                this.FoodEaten += foodQty;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
