// See https://aka.ms/new-console-template for more information
using SOLID_Interface_Segregation_Demo;

Console.WriteLine("Hello, World!");


IBasicAccount savings=new SavingsAccount();
savings.Deposit(19000);
savings.Withdraw(3000);
savings.CheckBalance(1);

IInvestmentAccount account=new InvestmentAccount();
account.Deposit(23000);
account.Buyshares(3);
account.SellShares(2);
account.Withdraw(1000);
Console.ReadLine();