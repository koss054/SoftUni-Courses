using E02.VehiclesExtension.Core;

namespace E02.VehiclesExtension
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
