using System.Collections;

namespace CollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList myarrayList = new ArrayList();
            // myarrayList.Add(100);
            // myarrayList.Add("Geetha");
            // myarrayList.Add('S');
            // myarrayList.Add(3.14);
            // Console.WriteLine("List of item in the myArrayList");
            // foreach (var item in myarrayList)
            // {
            //     Console.WriteLine(item);
            // }
            // ArrayList myarrayList2 = new ArrayList() { "Apple", "300", "Bread" };
            // myarrayList.AddRange(myarrayList2);


            // Console.WriteLine("After AddRange (2)");
            // foreach (var item in myarrayList)
            // {
            //     Console.WriteLine(item);
            // }

            // myarrayList.Insert(1, "New inserted Item");
            // Console.WriteLine("\n After Insert(1)");
            // foreach (var item in myarrayList)
            // {
            //     Console.WriteLine(item);
            // }

            // ArrayList veggies = new ArrayList() { "Carrot", "Beans", "Potato", "Peas" };
            // myarrayList.InsertRange(0,veggies);
            // Console.WriteLine("\n After InsertRange(0,veggies");
            // foreach (var item in myarrayList)
            // {
            //     Console.WriteLine(item);
            // }
            // //Console.WriteLine($"\n Count : {myarrayList.Count}");
            // //myarrayList.Remove("New inserted Item");
            // //Console.WriteLine("After Removed New inserted Item");
            // //Console.WriteLine($"\n Count : {myarrayList.Count}");
            // //myarrayList.RemoveAt(0);
            // //Console.WriteLine("After removed item in o index position");
            // //Console.WriteLine($" Count : {myarrayList.Count}");
            // myarrayList.RemoveRange(1, 3);
            // Console.WriteLine("\nAfter Removed RemoveRange(1, 3)");
            // foreach(var item in myarrayList)
            // { Console.WriteLine(item); }



            // ArrayList newarrayList = new ArrayList() { "Pomegrante", "Grape", "Litchi", "Green Apple", "Carrot" };
            // Console.WriteLine("After newarrayList.Sort();");
            // newarrayList.Sort();
            // foreach (var item in newarrayList)
            // {
            //     Console.WriteLine(item);
            // }


            // Console.WriteLine("\n After newarrayList.Reverse();");
            // newarrayList.Reverse();
            // foreach (var item in newarrayList)
            // {
            //     Console.WriteLine(item);
            // }

            // ArrayList clonedList =(ArrayList) newarrayList.Clone();
            // Console.WriteLine("\n Cloned List");
            // foreach (var item in clonedList)
            // {
            //     Console.WriteLine(item);
            // }

            // myarrayList.Clear();

            // if (newarrayList.Contains("Grape"))
            //     Console.WriteLine("Grape is Available");

            //Console.WriteLine($"Index of Grape  {newarrayList.IndexOf("Grape")}");

            // Console.WriteLine(" Count "+newarrayList.Count);
            // Console.WriteLine("Capacity : " + newarrayList.Capacity);

            //HashTableDemo hashTableDemo = new HashTableDemo();
            //hashTableDemo.Demo();


            //StackDemo stack = new StackDemo();
            //stack.Demo();

            //SortedListDemo sortedListDemo = new SortedListDemo();
            //sortedListDemo.Demo();

            ListDemonstration.GetAllEmployees();
            ListDemonstration.AddNewEMployee();
            ListDemonstration.GetAllEmployees();
            Console.ReadLine();
        }
    }
}
