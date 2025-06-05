using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_LSP_Demo
{
    public class Apple:IFruit
    {
        public string GetColor()
        {
            return "Red";
        }
    }
}
