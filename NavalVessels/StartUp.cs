namespace NavalVessels
{
    using Core;
    using Core.Contracts;

    using NavalVessels.Models;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}