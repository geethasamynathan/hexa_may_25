using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
    }

    public class ListDemonstration
    {
      static  List<Employee> employeelist = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Parivalanvan", Gender = "Male", Salary = 34000 },
                new Employee() { Id = 2, Name = "Gokul", Gender = "Male", Salary = 35000 },
                new Employee() { Id = 3, Name = "Nithyasri", Gender = "Female", Salary = 36000 },
                new Employee() { Id = 4, Name = "Akshara", Gender = "Female", Salary = 37000 }
            };
        public static void GetAllEmployees()
        {
           

            foreach (var item in employeelist)
            {
                Console.WriteLine($" {item.Id} \t {item.Name} \t {item.Gender} \t {item.Salary}");
            }
        }
        public static void AddNewEMployee()
        {
            Console.WriteLine("Enter the Employee Id,Name,Gender,Salary");
            Employee employee = new Employee();
            employee.Id = Convert.ToInt32(Console.ReadLine());
            employee.Name = Console.ReadLine();
            employee.Gender = Console.ReadLine();
            employee.Salary = Convert.ToInt32(Console.ReadLine());
            employeelist.Add(employee);
        }
    }
}
