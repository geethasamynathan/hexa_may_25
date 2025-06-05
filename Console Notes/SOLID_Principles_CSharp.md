
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
