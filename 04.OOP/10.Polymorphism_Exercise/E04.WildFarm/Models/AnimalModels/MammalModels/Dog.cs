namespace WildFarm
{
    class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override bool EatFood(string foodType, int foodQty)
        {
            if (foodType == "Meat")
            {
                this.Weight += (foodQty * 0.40);
                this.FoodEaten += foodQty;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
