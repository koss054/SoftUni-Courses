namespace FoodShortage.Contracts
{
    public interface IBuyer
    {
        string Name { get; set; }

        int Food { get; set; }

        public int BuyFood(int totalFood);
    }
}
