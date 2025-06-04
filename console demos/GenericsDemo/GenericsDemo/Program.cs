namespace GenericsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool result = Calculator.AreEqual<int,float>(10, 100.345);
            bool result = Calculator.AreEqual<string,int>("10", 10);
            if(result)
            {
                Console.WriteLine("Both are Equal");
            }
            else
                Console.WriteLine("Not Equal");
            Console.ReadLine();
        }
    }
    class Calculator
    {
        public static bool AreEqual<T1,T2>(T1 value1, T2 value2)
        {
            return value1.Equals(value2);
        }
       
    }
}
