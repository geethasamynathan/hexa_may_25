using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    internal class HashTableDemo
    {
        public void Demo()
        {
            Hashtable ht1=new Hashtable();
            ht1["id"] = 101;
            ht1["name"] = "Demo User";
            ht1["location"] = "Chennai";
            ht1[10] = "Ten";

            //Console.WriteLine("HashTable Keys are \n");
            //foreach(var ht in ht1.Keys)
            //{
            //    Console.WriteLine($"Key : {ht}");
            //}

            //Console.WriteLine("HashTable Values are \n");
            //foreach (var ht in ht1.Values)
            //{
            //    Console.WriteLine($"Values : {ht}");
            //}
            Console.WriteLine("HashTable Key and Values are \n");
            foreach (DictionaryEntry ht in ht1)
            {
                Console.WriteLine($"{ht.Key} : {ht.Value}");
            }

            ht1.Add("dept", "IT");
            Console.WriteLine("HashTable after \n");
            foreach (DictionaryEntry ht in ht1)
            {
                Console.WriteLine($"{ht.Key} : {ht.Value}");
            }

            Console.WriteLine(" Copying Keys from HashTable to an Array ");
            object[] h2 = new object[10];
            ht1.Keys.CopyTo(h2,0);
           
            Console.WriteLine(" Array Elements are");
            foreach (var item in h2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"h2[0] = {h2[0]}");
        }
    }
}
