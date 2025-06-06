
# 🔌 Adapter Pattern in C#

The **Adapter Pattern** is a **structural design pattern** that allows incompatible interfaces to work together. It acts like a **bridge** between two incompatible systems, converting one interface into another that the client expects.

---

## 💡 Real-World Analogy
> Imagine you have a **European plug** but the socket in your house is **Indian-style**. You use a **plug adapter** to connect the European plug to the Indian socket. The adapter doesn't change how electricity works—it just makes the connection compatible.

---

## ✅ When to Use
- You want to use an existing class, but its interface does not match the one you need.
- You want to integrate a third-party or legacy component without modifying its source.

---

## 🛠️ C# Real-World Example: Payment Gateway Adapter

Suppose your application uses a common interface `IPaymentGateway`, but a third-party service `PaypalService` uses a different method.

---

### 👇 Step-by-Step Code

#### 1. Target Interface (What the system expects)
```csharp
public interface IPaymentGateway
{
    void ProcessPayment(decimal amount);
}
```

#### 2. Adaptee (The incompatible class)
```csharp
public class PaypalService
{
    public void MakePaypalPayment(double value)
    {
        Console.WriteLine($"Paid {value} using PayPal.");
    }
}
```

#### 3. Adapter (Makes `PaypalService` compatible with `IPaymentGateway`)
```csharp
public class PaypalAdapter : IPaymentGateway
{
    private readonly PaypalService _paypalService;

    public PaypalAdapter(PaypalService paypalService)
    {
        _paypalService = paypalService;
    }

    public void ProcessPayment(decimal amount)
    {
        // Convert decimal to double if necessary
        _paypalService.MakePaypalPayment((double)amount);
    }
}
```

#### 4. Client Code
```csharp
class Program
{
    static void Main()
    {
        IPaymentGateway payment = new PaypalAdapter(new PaypalService());
        payment.ProcessPayment(1500.75m);
    }
}
```

---

## 🧠 Explanation

- The client only knows about `IPaymentGateway`.
- The third-party `PaypalService` doesn't implement `IPaymentGateway`.
- `PaypalAdapter` wraps `PaypalService` and translates the `ProcessPayment` call to the `MakePaypalPayment` method.
- This allows the application to **use PayPal without altering its core logic**.

---

## 🎯 Key Benefits
- Promotes **loose coupling**
- Enables **reusability** of existing code
- **Separates concerns** between system and third-party implementation
