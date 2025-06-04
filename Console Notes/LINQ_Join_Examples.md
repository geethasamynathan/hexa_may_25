
# LINQ Join Examples with Product and Supplier in C#

## 🔷 Step 1: Product Class (Given)
```csharp
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Category { get; set; }

    static List<Product> products = new List<Product>() {
        new Product(){ProductId=1,Name="Mouse",Description="Wireless",Price=1300,Category="Electronics"},
        new Product(){ProductId=2,Name="Keyboard",Description="Wireless",Price=3220,Category="Electronics"},
        new Product(){ProductId=3,Name="Laptop",Description="HD and Touch",Price=87000,Category="Electronics"},
        new Product(){ProductId=4,Name="Cooling Pad",Description="test",Price=2000,Category="Electronics"},
        new Product(){ProductId=5,Name="Monitor",Description="LED",Price=6000,Category="Electronics"},
        new Product(){ProductId=6,Name="projector",Description="Wired",Price=1700,Category="Electronics"},
        new Product(){ProductId=7,Name="Pencil",Description="Color pencil",Price=170,Category="Stationary"},
        new Product(){ProductId=8,Name="Scale",Description="long size",Price=100, Category = "Stationary"},
    };
}
```

## 🔷 Step 2: Supplier Class
```csharp
public class Supplier
{
    public int SupplierId { get; set; }
    public string SupplierName { get; set; }
    public string Category { get; set; }
}
```

## 🔷 Step 3: Sample Supplier Data
```csharp
List<Supplier> suppliers = new List<Supplier>()
{
    new Supplier { SupplierId = 1, SupplierName = "Electro World", Category = "Electronics" },
    new Supplier { SupplierId = 2, SupplierName = "Office Station", Category = "Stationary" },
    new Supplier { SupplierId = 3, SupplierName = "Tech Hub", Category = "Electronics" }
};
```

---

## 🔹 1. Inner Join on Category
```csharp
var result = from p in products
             join s in suppliers on p.Category equals s.Category
             select new
             {
                 ProductName = p.Name,
                 Supplier = s.SupplierName
             };

foreach (var item in result)
{
    Console.WriteLine($"{item.ProductName} - {item.Supplier}");
}
```

---

## 🔹 2. Left Outer Join
```csharp
var leftJoin = from s in suppliers
               join p in products on s.Category equals p.Category into prodGroup
               from pg in prodGroup.DefaultIfEmpty()
               select new
               {
                   Supplier = s.SupplierName,
                   Product = pg != null ? pg.Name : "No Product"
               };

foreach (var item in leftJoin)
{
    Console.WriteLine($"{item.Supplier} supplies: {item.Product}");
}
```

---

## 🔹 3. Group Join
```csharp
var groupJoin = from s in suppliers
                join p in products on s.Category equals p.Category into productGroup
                select new
                {
                    Supplier = s.SupplierName,
                    Products = productGroup
                };

foreach (var g in groupJoin)
{
    Console.WriteLine($"{g.Supplier} supplies:");
    foreach (var p in g.Products)
    {
        Console.WriteLine($" - {p.Name}");
    }
}
```

---

## 🔹 4. Join with Anonymous Type + Custom Message
```csharp
var customJoin = from p in products
                 join s in suppliers on p.Category equals s.Category
                 where p.Price > 1000
                 select new
                 {
                     Message = $"{s.SupplierName} provides {p.Name} for ₹{p.Price}"
                 };

foreach (var item in customJoin)
{
    Console.WriteLine(item.Message);
}
```

---

## 🔹 5. Join with Filtering by Category and Price
```csharp
var filteredJoin = from p in products
                   join s in suppliers on p.Category equals s.Category
                   where p.Category == "Electronics" && p.Price < 5000
                   select new
                   {
                       Product = p.Name,
                       Price = p.Price,
                       Supplier = s.SupplierName
                   };

foreach (var item in filteredJoin)
{
    Console.WriteLine($"{item.Product} ({item.Price}) - Supplied by {item.Supplier}");
}
```

---

## 🧾 Summary Table

| LINQ Join Type         | Description                                           |
|------------------------|-------------------------------------------------------|
| Inner Join             | Only matching entries from both collections           |
| Left Outer Join        | All from left, with optional right side               |
| Group Join             | Groups right-side items under each left-side item     |
| Join + Filter          | Adds `where` to limit results                         |
| Join + Anonymous Type  | Custom output format using `select new {}`            |
