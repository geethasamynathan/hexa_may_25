
# LINQ Methods in C# with Product & Supplier Example

## 📘 Class Definitions

```csharp
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
}

public class Supplier
{
    public int SupplierId { get; set; }
    public string SupplierName { get; set; }
    public string Category { get; set; }
}
```

---

## ✅ Sample Data

```csharp
List<Product> products = new List<Product>() {
    new Product(){ProductId=1,Name="Mouse",Quantity=2,Description="Wireless",Price=1300,Category="iball"},
    new Product(){ProductId=2,Name="Keyboard",Quantity=12,Description="Wireless",Price=3220,Category="iball"},
    new Product(){ProductId=3,Name="Laptop",Quantity=22,Description="HD and Touch",Price=87000,Category="Hp"},
    new Product(){ProductId=4,Name="Cooling Pad",Quantity=32,Description="test",Price=2000,Category="Gamerz"},
    new Product(){ProductId=5,Name="Monitor",Quantity=42,Description="LED",Price=6000,Category="Hp"},
    new Product(){ProductId=6,Name="projector",Quantity=12,Description="Wired",Price=1700,Category="Hp"},
    new Product(){ProductId=7,Name="Pencil",Quantity=62,Description="Color pencil",Price=170,Category="Stationary"},
    new Product(){ProductId=8,Name="Scale",Quantity=42,Description="long size",Price=100, Category = "Stationary"},
};

List<Supplier> suppliers = new List<Supplier>()
{
    new Supplier(){SupplierId = 1,SupplierName="iball",Category="iball"},
    new Supplier(){SupplierId = 2,SupplierName="Hp",Category="Hp"},
    new Supplier(){SupplierId = 3,SupplierName="DOMS",Category="Stationary"},
    new Supplier(){SupplierId = 4,SupplierName="cooling fan",Category="Gamerz"},
};
```

---

## 🔹 LINQ Query Examples

### First & FirstOrDefault
```csharp
var firstExpensiveProduct = products.First(p => p.Price > 5000);
var firstCheapProduct = products.FirstOrDefault(p => p.Price < 200);
```

### Last & LastOrDefault
```csharp
var lastHpProduct = products.Last(p => p.Category == "Hp");
var lastSonyProduct = products.LastOrDefault(p => p.Category == "Sony");
```

### Single & SingleOrDefault
```csharp
var onlyProjector = products.Single(p => p.Name == "projector");
var onlyScanner = products.SingleOrDefault(p => p.Name == "scanner");
```

### Any & All
```csharp
bool anyStationary = products.Any(p => p.Category == "Stationary");
bool allCostly = products.All(p => p.Price > 100);
```

### Aggregate: Sum, Count, Min, Max, Average
```csharp
int totalPrice = products.Sum(p => p.Price);
int totalCount = products.Count();
int maxPrice = products.Max(p => p.Price);
int minPrice = products.Min(p => p.Price);
double avgPrice = products.Average(p => p.Price);
```

### Distinct
```csharp
var uniqueCategories = products.Select(p => p.Category).Distinct();
```

### Union
```csharp
var allNames = products.Select(p => p.Name).Union(suppliers.Select(s => s.SupplierName));
```

### Intersect
```csharp
var commonCategories = products.Select(p => p.Category).Intersect(suppliers.Select(s => s.Category));
```

### Except
```csharp
var productOnlyCategories = products.Select(p => p.Category).Except(suppliers.Select(s => s.Category));
```

### Skip & SkipWhile
```csharp
var skipFirst3 = products.Skip(3);
var skipWhileCheap = products.SkipWhile(p => p.Price < 2000);
```

### Take & TakeWhile
```csharp
var firstTwo = products.Take(2);
var takeWhileCheap = products.TakeWhile(p => p.Price < 2000);
```
