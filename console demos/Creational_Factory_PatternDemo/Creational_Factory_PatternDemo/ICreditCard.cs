using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Factory_PatternDemo
{
    public interface ICreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }

    public class MoneyBack : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 3000;
        }

        public string GetCardType()
        {
            return "MoneyBack";
        }

        public int GetCreditLimit()
        {
            return 45000;
        }
    }
    public class Titanium : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 5000;
        }

        public string GetCardType()
        {
            return "Titanium card";
        }

        public int GetCreditLimit()
        {
            return 145000;
        }
    }

}
