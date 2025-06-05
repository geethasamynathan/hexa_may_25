
# 🛠️ Creating and Using a Shared DLL Assembly in C# (.NET Core Console App)

## ✅ Scenario: InvoiceLib - A Shared Library for Invoice Operations

---

## 📁 Step 1: Create a Class Library Project (Shared DLL)

```bash
dotnet new classlib -n InvoiceLib
```

> This creates a shared project that compiles to `InvoiceLib.dll`

---

## ✏️ Step 2: Add Logic to `InvoiceLib`

### 📄 `InvoiceCalculator.cs`
```csharp
using System;

namespace InvoiceLib
{
    public class InvoiceCalculator
    {
        private static int invoiceCounter = 1000;

        public decimal CalculateTotal(decimal amount, decimal taxRatePercent)
        {
            decimal tax = amount * taxRatePercent / 100;
            return amount + tax;
        }

        public decimal ApplyDiscount(decimal amount, decimal discountPercent)
        {
            decimal discount = amount * discountPercent / 100;
            return amount - discount;
        }

        public string GenerateInvoiceNumber()
        {
            invoiceCounter++;
            return $"INV{invoiceCounter}";
        }

        public string GetInvoiceSummary(decimal baseAmount, decimal taxRate, decimal discountRate)
        {
            decimal discounted = ApplyDiscount(baseAmount, discountRate);
            decimal total = CalculateTotal(discounted, taxRate);
            return $"Subtotal: ₹{baseAmount}\n" +
                   $"Discount ({discountRate}%): ₹{baseAmount - discounted}\n" +
                   $"Tax ({taxRate}%): ₹{total - discounted}\n" +
                   $"Total Payable: ₹{total}";
        }
    }
}
```

---

## 📁 Step 3: Create the Consumer Console App

```bash
dotnet new console -n InvoiceApp
```

---

## 🔗 Step 4: Add Reference to the Shared DLL

```bash
cd InvoiceApp
dotnet add reference ../InvoiceLib/InvoiceLib.csproj
```

---

## ✏️ Step 5: Use Shared Library in Console App

### 📄 `Program.cs`
```csharp
using System;
using InvoiceLib;

namespace InvoiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InvoiceCalculator calc = new InvoiceCalculator();

            Console.WriteLine("Enter base amount:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter tax rate (%):");
            decimal tax = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter discount rate (%):");
            decimal discount = Convert.ToDecimal(Console.ReadLine());

            string invoiceNumber = calc.GenerateInvoiceNumber();
            string summary = calc.GetInvoiceSummary(amount, tax, discount);

            Console.WriteLine($"
Invoice Number: {invoiceNumber}");
            Console.WriteLine("----- Invoice Summary -----");
            Console.WriteLine(summary);
        }
    }
}
```

---

## ▶️ Step 6: Build and Run the Application

```bash
dotnet build
dotnet run --project InvoiceApp
```

---

## 📦 Output Example

```
Enter base amount:
2000
Enter tax rate (%):
18
Enter discount rate (%):
10

Invoice Number: INV1001
----- Invoice Summary -----
Subtotal: ₹2000
Discount (10%): ₹200
Tax (18%): ₹324
Total Payable: ₹2124
```

---

## 🔄 Why This is a Shared DLL?

- `InvoiceLib.dll` can be reused in:
  - Billing apps
  - POS systems
  - Reporting dashboards
- Any `.NET Core` project can reference it using:
```bash
dotnet add reference path/to/InvoiceLib.csproj
```
