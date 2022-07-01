namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main()
        {
            var bike = new Motorcycle(80, 22.6);
            var racebke = new RaceMotorcycle(150, 35.6);
            var bikeconsumption = bike.FuelConsumption;
            var raceBikefuelconsumption = racebke.FuelConsumption;
            var stop = string.Empty;
        }
    }
}
