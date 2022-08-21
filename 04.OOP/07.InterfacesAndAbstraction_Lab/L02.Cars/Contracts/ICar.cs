namespace Cars.Contracts
{
    public interface ICar
    {
        string Model { get; set; }

        string Color { get; set; }

        string Start()
        {
            return "Engine start";
        }

        string Stop();

    }
}
