namespace Behavioural_Chain_Of_Responsibility_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SupportHandler level1 = new Level1Support();
            SupportHandler level2 = new Level2Support();
            SupportHandler manager=new ManagerSupport();

            level1.SetNext(level2);
            level2.SetNext(manager);

            level1.HandleRequest("password reset");
            level1.HandleRequest("software issue");
            level1.HandleRequest("Admin Request");

            Console.ReadLine();
        }
    }
}
