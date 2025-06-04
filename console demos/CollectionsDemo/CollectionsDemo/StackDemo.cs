using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    internal class StackDemo
    {
        public void Demo()
        {
            Stack stack1 = new Stack();
            stack1.Push("C#");
            stack1.Push("Web API");
            stack1.Push("React");
            stack1.Push("Angular");

            foreach (var item in stack1)
            {
                Console.WriteLine(item);
            }
            stack1.Pop();
            Console.WriteLine("After removed pop()");
            foreach (var item in stack1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("top item in stack " + stack1.Peek());
        }
             
    }
}
