namespace Behavioural_Observer_Pattern_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Stock oneplusStock=new Stock();
          MobileApp mobile = new MobileApp();
          WebApp webApp = new WebApp();
            oneplusStock.RegisterObserver(mobile);
            oneplusStock.RegisterObserver(webApp);

            oneplusStock.SetPrice(48000);
            oneplusStock.SetPrice(39000);

            oneplusStock.RemoveObserver(webApp);

            oneplusStock.SetPrice(34000);
            Console.ReadLine();
        }
    }
}
