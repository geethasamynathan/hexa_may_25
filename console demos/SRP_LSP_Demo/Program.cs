using SRP_LSP_Demo;

IFruit fruit = new Orange();

Console.WriteLine(" Color of Orange " + fruit.GetColor());
fruit = new Apple();

Console.WriteLine(" Color of Apple " + fruit.GetColor());

Console.ReadLine();