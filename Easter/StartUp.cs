namespace Easter
{
    using Core;
    using Core.Contracts;

    using Easter.Models.Bunnies;

    public class StartUp
    {
        public static void Main()
        {


            // Don't forget to uncomment Controller class in the Engine!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
