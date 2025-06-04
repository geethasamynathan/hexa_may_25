using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    internal class SortedListDemo
    {
        public void Demo()
        {
            SortedList sl = new SortedList();
           //sl.Add(001, "ziavudeen");
            sl.Add(002, "Abinaya");
            sl.Add(003, "John");
            sl.Add(004, "Arjun");
            sl.Add(007, "Nithin");
            sl.Add(006, "Fransy");
            sl.Add(005, "Ritesh");
            foreach (DictionaryEntry item in sl)
            {
                Console.WriteLine(item.Key + "\t\t" + item.Value);
            }
            Console.WriteLine(" Check whether ziavudeen  is in the List or not? \n\n");
            if (sl.ContainsValue("ziavudeen"))
            {
                Console.WriteLine("This student name is already in the list");
            }
            else
            {
                sl.Add(008, "ziavudeen");
                Console.WriteLine(" ziavudeen name Added in the List");
            }
            Console.WriteLine(sl.Count);

            if (sl.ContainsKey(008))
            {
                Console.WriteLine(" Yes. Key 008 is Available in the List");
            }
            else
            {
                Console.WriteLine(" Yes. Key 008 is  Not Available in the List");
            }

            object KeyAtIndex3 = sl.GetKey(3);
            Console.WriteLine(" Key at the Index(3) = " + KeyAtIndex3);

            int myindex = sl.IndexOfKey(007);
            Console.WriteLine(" The Index of 007 =" + myindex);
            Console.WriteLine(" Index of vlue of  ziavudeen" + sl.IndexOfValue("ziavudeen"));
            Console.WriteLine(" replace the value of key 003");
            sl.SetByIndex(003, "Geetha");

            Console.WriteLine(" ---SetByIndex() ---");
            IList mylist = sl.GetKeyList();

            foreach (DictionaryEntry item in sl)
            {
                Console.WriteLine(item.Key + "        " + item.Value);
            }

        }
    }
}
