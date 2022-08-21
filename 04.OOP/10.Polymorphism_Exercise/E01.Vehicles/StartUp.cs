using E01.Vehicles.Core;

namespace E01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
