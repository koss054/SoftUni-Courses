namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override bool EatFood(string foodType, int foodQty)
        {
            if (foodType == "Meat")
            {
                this.Weight += (foodQty * 1.0);
                this.FoodEaten += foodQty;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
