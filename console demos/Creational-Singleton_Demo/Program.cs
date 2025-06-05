// See https://aka.ms/new-console-template for more information
using Creational_Singleton_Demo;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");


var config1 = new Configuration();
Console.WriteLine(config1.Setting);
var config2 = new Configuration();
Console.WriteLine(config2.Setting);
Console.ReadLine();