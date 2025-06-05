using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Interface_Segregation_Demo
{
    //Fat interface
    //public interface IAccount
    //{

    //    void Withdraw(decimal amount);
    //    void Deposit(decimal amount);
    //    void CheckBalance(int accountNumber);
    //    void Buyshares(int numberOfShares);
    //    void SellShares(int numberOfShares);

    //}

    public interface IBasicAccount {
        void Withdraw(decimal amount);
        void Deposit(decimal amount);
        void CheckBalance(int accountNumber);
    }
    public interface IInvestmentAccount:IBasicAccount
    {
        void Buyshares(int numberOfShares);
        void SellShares(int numberOfShares);
    }

}
