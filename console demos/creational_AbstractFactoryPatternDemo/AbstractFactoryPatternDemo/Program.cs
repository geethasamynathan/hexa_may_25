namespace AbstractFactoryPatternDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicleFactory regularVehicle = new RegularVehicleFactory();
            IBike regularBike = regularVehicle.CreateBike();
            regularBike.GetDetails();
            Console.ReadLine();
        }
    }
}
