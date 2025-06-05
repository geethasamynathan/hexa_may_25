using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Interface_Segregation_Demo
{
    internal class SavingsAccount : IBasicAccount
    {
        private decimal balance;
        public void CheckBalance(int accountNumber)
        {
            Console.WriteLine($"Current Balence ={balance} ");
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine("Deposited" + amount.ToString("C", new CultureInfo("en-in"))); 
               Console.WriteLine("\n current Balance " + balance.ToString("C", new CultureInfo("en-in")));
        }

        public void Withdraw(decimal amount)
        {
            if(amount <=balance)
            {
                balance-=amount;
                Console.WriteLine("Withdrew the "+amount.ToString
                    ("C",new CultureInfo("en-Us")));
                    Console.WriteLine($"\n Current Balance : {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
    }
}
