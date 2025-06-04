using System.Collections;

namespace LinqDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = [2, 43, 657, 68, 345, 634];
            //Console.WriteLine("\nEven Numbers using Query syntax");
            ////Query syntax
            //var evenNumbers=from n in numbers
            //                where n%2==0
            //                select n;
            //foreach (var item in evenNumbers)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("\nEven Numbers using Method syntax");
            ////Method Syntax
            //var evenNumbers1=numbers.Where(n => n%2==0);
            //foreach (var item in evenNumbers1)
            //{ Console.WriteLine(item); }


            //IList mixedList = new ArrayList();

            //mixedList.Add(10);
            //mixedList.Add(20);
            //mixedList.Add("Fransy");
            //mixedList.Add("Test");
            //mixedList.Add(new Product()
            //{ ProductId = 1, Name = "Test Product", Description = "Test DEscription", Price = 234 });

            ////Example for OfType operator

            //var intList = from i in mixedList.OfType<int>()
            //              select i;
            ////method syntax
            //var intList1 = mixedList.OfType<int>();
            //var stringList = from s in mixedList.OfType<string>()
            //                 select s;
            ////method syntax
            //var stringList1 = mixedList.OfType<string>();
            //var productList = from p in mixedList.OfType<Product>()
            //                  select p;
            ////method syntax
            //var productList1 = mixedList.OfType<Product>();
            //Console.WriteLine("\nInteger List filtered from mixedList");
            //foreach (var i in intList1)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("\nString List filtered from mixedList");
            //foreach (var i in stringList1)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("\nProduct List filtered from mixedList");
            //foreach (var i in productList1)
            //{
            //    Console.WriteLine($"{i.ProductId}\t{i.Name}\t {i.Description}\t {i.Price}");
            //}


            //Product product = new Product();
            //product.Demo();

            ////Supplier supplier = new Supplier();
            ////supplier.Demo();
            ///

          //  //Element operators
          //  IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
          //  IList<string> stringList = new List<string>() { null, "One", "Three", "Two", "Five", "Four" };
          //  IList<string> emptyList = new List<string>();


          //  //Example for First()
          //  Console.WriteLine($"First Element in the List {intList.First()}");
          //  Console.WriteLine($"1st Even Element in the List{intList.First(i =>i%2==0)}");

            
          //  Console.WriteLine($"First Element in the string List {stringList.First()}");

          ////  Console.WriteLine($"1st  Element in the emptyList{emptyList.First()}");

          //  //Example for FirstOrDefault
          //  Console.WriteLine($"First Element in the List {intList.FirstOrDefault()}");
          //  Console.WriteLine($"1st Even Element in the List{intList.FirstOrDefault(i => i % 2 == 0)}");


          //  Console.WriteLine($"First Element in the string List {stringList.FirstOrDefault()}");

          //  Console.WriteLine($"1st  Element in the emptyList{emptyList.FirstOrDefault()}");


          //  //Example for Last()
          //  Console.WriteLine($"Last Element in the List {intList.Last()}");
          //  Console.WriteLine($"last Even Element in the List{intList.Last(i => i % 2 == 0)}");


          //  Console.WriteLine($"Last Element in the string List {stringList.Last()}");

            Supplier supplier = new Supplier();
            supplier.Demo();
            Console.ReadLine();
        }
    }
}
