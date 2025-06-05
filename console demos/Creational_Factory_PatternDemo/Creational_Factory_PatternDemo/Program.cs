namespace Creational_Factory_PatternDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the card Type \n MoneyBack \n Titanium");
            ICreditCard cardDetails = null;
            string CardType = Console.ReadLine();
            if(CardType=="MonyBack")
            {
                cardDetails = new MoneyBack();
            }
            else
            {
                cardDetails = new Titanium();
            }
            if (CardType != null)
            {
                Console.WriteLine($"Card Type: {cardDetails.GetCardType()}");
                Console.WriteLine($"credit Limit : {cardDetails.GetCreditLimit()}");
                Console.WriteLine($"Annual Charge : {cardDetails.GetAnnualCharge()}");
            }

            Console.ReadLine();
        }
    }
}
