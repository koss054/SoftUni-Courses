namespace Gym
{
    using Gym.Core;
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Equipment;
    using Gym.Models.Gyms;

    public class StartUp
    {
        public static void Main()
        {
            //BoxingGym boxingGym = new BoxingGym("Borbata Batko Bro");

            //Boxer boxer1 = new Boxer("Ivan", "Mnogo ama Mnogo", 2);
            //Boxer boxer2 = new Boxer("Petro", "Ami ne mn brat", 0);

            //Kettlebell kettlebell = new Kettlebell();

            //boxingGym.AddAthlete(boxer1);
            //boxingGym.AddAthlete(boxer2);
            //boxingGym.AddEquipment(kettlebell);

            //System.Console.WriteLine(boxingGym.GymInfo());


            //return;
            // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
