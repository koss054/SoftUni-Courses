namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override bool EatFood(string foodType, int foodQty)
        {
            if (foodType == "Vegetable" || foodType == "Meat")
            {
                this.Weight += (foodQty * 0.30);
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
