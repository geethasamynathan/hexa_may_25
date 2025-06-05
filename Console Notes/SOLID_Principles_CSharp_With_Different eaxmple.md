
# SOLID Principles in C#

**SOLID** is an acronym that represents five principles for writing clean, maintainable, and scalable object-oriented code.

---

## 🔵 What is SOLID?

- **S** – Single Responsibility Principle (SRP)
- **O** – Open/Closed Principle (OCP)
- **L** – Liskov Substitution Principle (LSP)
- **I** – Interface Segregation Principle (ISP)
- **D** – Dependency Inversion Principle (DIP)

---

## 🟢 1. Single Responsibility Principle (SRP)

**Definition**: A class should have only one reason to change.

### ❌ Bad Example
```csharp
public class BankAccount
{
    public void Deposit(decimal amount) { }
    public void Withdraw(decimal amount) { }
    public void PrintStatement() { } // Printing is a different responsibility
}
```

### ✅ Refactored
```csharp
public class BankAccount
{
    public void Deposit(decimal amount) { }
    public void Withdraw(decimal amount) { }
}

public class StatementPrinter
{
    public void Print(BankAccount account) { }
}
```

**Real-world analogy**: A cashier shouldn’t also handle accounting reports — that’s the accountant’s job.

---

## 🟢 2. Open/Closed Principle (OCP)

**Definition**: Software entities should be **open for extension** but **closed for modification**.

### ✅ Example
```csharp
public abstract class Notification
{
    public abstract void Send(string message);
}

public class EmailNotification : Notification
{
    public override void Send(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class SmsNotification : Notification
{
    public override void Send(string message)
    {
        Console.WriteLine($"SMS sent: {message}");
    }
}
```

**Real-world analogy**: A universal charger can support more plugs without altering its internal logic.

---

## 🟢 3. Liskov Substitution Principle (LSP)

**Definition**: Derived classes must be substitutable for their base classes without breaking behavior.

### ❌ Violation Example
```csharp
public class Account
{
    public virtual void Withdraw(decimal amount) { }
}

public class FixedDepositAccount : Account
{
    public override void Withdraw(decimal amount)
    {
        throw new Exception("Cannot withdraw from Fixed Deposit");
    }
}
```

### ✅ Better Approach
```csharp
public abstract class WithdrawableAccount
{
    public abstract void Withdraw(decimal amount);
}

public class SavingsAccount : WithdrawableAccount
{
    public override void Withdraw(decimal amount)
    {
        Console.WriteLine("Withdraw from savings");
    }
}
```

**Real-world analogy**: A vehicle subclass like `Airplane` should not break if used where a `Vehicle` is expected.

---

## 🟢 4. Interface Segregation Principle (ISP)

**Definition**: Clients should not be forced to depend on interfaces they do not use.

### ❌ Bad Interface
```csharp
public interface IAccount
{
    void Deposit();
    void Withdraw();
    void GenerateLoan(); // Not applicable to all accounts
}
```

### ✅ Refactored Interfaces
```csharp
public interface IAccount
{
    void Deposit();
    void Withdraw();
}

public interface ILoanAccount
{
    void GenerateLoan();
}
```

**Real-world analogy**: A debit card doesn’t need to implement credit card loan functions.

---

## 🟢 5. Dependency Inversion Principle (DIP)

**Definition**: High-level modules should not depend on low-level modules. Both should depend on abstractions.

### ❌ Violation Example
```csharp
public class Report
{
    private EmailSender _emailSender = new EmailSender();

    public void SendReport()
    {
        _emailSender.Send("Report");
    }
}
```

### ✅ Refactored
```csharp
public interface IMessageSender
{
    void Send(string message);
}

public class EmailSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}

public class Report
{
    private readonly IMessageSender _sender;

    public Report(IMessageSender sender)
    {
        _sender = sender;
    }

    public void SendReport()
    {
        _sender.Send("Report content");
    }
}
```

**Real-world analogy**: A printer should work regardless of which computer is connected, using a standard USB interface.

---

## ✅ Summary Table

| Principle | Description | Benefit |
|----------|-------------|---------|
| SRP | One class = one responsibility | Easy maintenance |
| OCP | Open for extension, closed for modification | Scalable |
| LSP | Subtypes should behave like base types | Reliable inheritance |
| ISP | Small, specific interfaces | Flexible design |
| DIP | Depend on abstractions, not concretes | Loosely coupled code |

---

## 🔁 Additional Examples for Each SOLID Principle

### 🔹 Single Responsibility Principle (SRP)

#### Example 1: Logger Separation
```csharp
public class Logger
{
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

public class PaymentProcessor
{
    private Logger _logger = new Logger();
    
    public void ProcessPayment()
    {
        // Process
        _logger.Log("Payment processed");
    }
}
```

#### Example 2: Separate Validation Class
```csharp
public class OrderValidator
{
    public bool Validate(Order order)
    {
        return order.Amount > 0;
    }
}
```

#### Example 3: Invoice Management
```csharp
public class Invoice
{
    public void CreateInvoice() { }
}

public class InvoicePrinter
{
    public void PrintInvoice() { }
}
```

---

### 🔹 Open/Closed Principle (OCP)

#### Example 1: Tax Calculation by Region
```csharp
public abstract class TaxCalculator
{
    public abstract decimal Calculate(decimal amount);
}

public class IndiaTax : TaxCalculator
{
    public override decimal Calculate(decimal amount) => amount * 0.18M;
}

public class USATax : TaxCalculator
{
    public override decimal Calculate(decimal amount) => amount * 0.10M;
}
```

#### Example 2: Shape Area Calculation
```csharp
public abstract class Shape
{
    public abstract double Area();
}

public class Circle : Shape
{
    public double Radius { get; set; }
    public override double Area() => Math.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public override double Area() => Width * Height;
}
```

#### Example 3: Payment Gateways
```csharp
public abstract class PaymentMethod
{
    public abstract void Pay(decimal amount);
}

public class CreditCard : PaymentMethod
{
    public override void Pay(decimal amount) => Console.WriteLine("Paid with Credit Card");
}

public class PayPal : PaymentMethod
{
    public override void Pay(decimal amount) => Console.WriteLine("Paid with PayPal");
}
```

---

### 🔹 Liskov Substitution Principle (LSP)

#### Example 1: Bird vs Penguin
```csharp
public abstract class Bird
{
    public abstract void Fly();
}

public class Sparrow : Bird
{
    public override void Fly() => Console.WriteLine("Flying");
}

public class Penguin // Cannot fly, should not derive Bird
{
    public void Swim() => Console.WriteLine("Swimming");
}
```

#### Example 2: Vehicle Drive Method
```csharp
public abstract class Vehicle
{
    public abstract void StartEngine();
}

public class Car : Vehicle
{
    public override void StartEngine() => Console.WriteLine("Car engine started");
}
```

#### Example 3: Employee Salary Calculator
```csharp
public abstract class Employee
{
    public abstract decimal GetSalary();
}

public class FullTimeEmployee : Employee
{
    public override decimal GetSalary() => 50000;
}

public class PartTimeEmployee : Employee
{
    public override decimal GetSalary() => 20000;
}
```

---

### 🔹 Interface Segregation Principle (ISP)

#### Example 1: Printer Functions
```csharp
public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Scan();
}
```

#### Example 2: Restaurant Service
```csharp
public interface IWaiter
{
    void TakeOrder();
}

public interface IChef
{
    void CookFood();
}
```

#### Example 3: Authentication Interfaces
```csharp
public interface ILogin
{
    void Login(string user, string password);
}

public interface IRegister
{
    void Register(string user, string password);
}
```

---

### 🔹 Dependency Inversion Principle (DIP)

#### Example 1: Database Service Abstraction
```csharp
public interface IDatabase
{
    void Save(string data);
}

public class SqlDatabase : IDatabase
{
    public void Save(string data) => Console.WriteLine("Saved to SQL");
}

public class BusinessService
{
    private IDatabase _db;
    public BusinessService(IDatabase db) { _db = db; }

    public void SaveData(string data) => _db.Save(data);
}
```

#### Example 2: Email Notification System
```csharp
public interface INotifier
{
    void Notify(string message);
}

public class EmailNotifier : INotifier
{
    public void Notify(string message) => Console.WriteLine($"Email: {message}");
}
```

#### Example 3: Payment Processor
```csharp
public interface IPaymentGateway
{
    void Pay(decimal amount);
}

public class Stripe : IPaymentGateway
{
    public void Pay(decimal amount) => Console.WriteLine("Paid via Stripe");
}
```

---
