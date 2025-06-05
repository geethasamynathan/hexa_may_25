using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Interface_Segregation_Demo
{
    internal class InvestmentAccount : IInvestmentAccount
    {
        private decimal balance;
        private int shares;
        public void Buyshares(int numberOfShares)
        {
            shares += numberOfShares;
            Console.WriteLine($"Bought {numberOfShares} shares. \n Total Shares= {shares}");
        }

        public void CheckBalance(int accountNumber)
        {
            Console.WriteLine($"Current Balence ={balance} ");
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount:C} \n current Balance {balance:C}");
        }

        public void SellShares(int numberOfShares)
        {
            if(numberOfShares<=shares)
            {
                shares -= numberOfShares;
                Console.WriteLine($"Sold  {numberOfShares} shares. Total Shares {shares}");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew the {amount:C} \n Current Balance : {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
    }
}
