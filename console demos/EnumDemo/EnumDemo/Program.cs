

using EnumDemo;

Order order = new Order() {
    OrderId=1001,
    CustomerName="Tina",
   Status=OrderStatus.Shipped
};
order.DisplayOrder();
Console.WriteLine("Update the Status");
Console.WriteLine("1.Pending \n2.Processing\n 3.Shipped\n 4.Delivered\n5.Cancelled");
Console.WriteLine("Enter the Choice (1-5)");
int choice;
if (int.TryParse(Console.ReadLine(), out choice) && Enum.IsDefined(typeof(OrderStatus), choice))
{
    order.Status = (OrderStatus)choice;
    Console.WriteLine("Order Status Updated successfully");
}
else
{
    Console.WriteLine("Invalid Choice selection");
}
order.DisplayOrder();


