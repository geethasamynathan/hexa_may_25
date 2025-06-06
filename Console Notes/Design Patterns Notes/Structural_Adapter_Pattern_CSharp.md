
# Adapter Pattern in C#

## 🟦 What is Adapter Pattern?

The **Adapter Pattern** is a **Structural Design Pattern** that allows objects with incompatible interfaces to work together. It acts as a **bridge** between two incompatible interfaces.

---

## ✅ When to Use?
- When you want to **reuse existing code** but its interface is **incompatible** with the current system.
- When you want to integrate a **third-party** or **legacy** class with your new code.
- When you want to **decouple** your system from external libraries or systems.

---

## ✅ Why to Use?
- Promotes **code reusability**.
- Avoids rewriting or modifying existing legacy classes.
- Supports the **Open/Closed Principle** (extend behavior without modifying original code).

---

## 🚫 Without Adapter – Problem

### Scenario: You have a modern billing system, but you must integrate a legacy payment system.

```csharp
// Modern client expects this
public interface IPaymentProcessor
{
    void Pay(decimal amount);
}

// Legacy class with different method
public class LegacyBank
{
    public void MakePayment(string account, decimal amount)
    {
        Console.WriteLine($"LegacyBank: Paying {amount} from {account}");
    }
}

// Client code
public class Checkout
{
    public void CompletePurchase(IPaymentProcessor processor, decimal amount)
    {
        processor.Pay(amount); // Can't call LegacyBank directly
    }
}
```

⛔ **Problem**: `LegacyBank` cannot be used without changing `Checkout`.

---

## ✅ With Adapter Pattern – Solution

### Implement Adapter to make `LegacyBank` compatible.

```csharp
// Adapter
public class LegacyBankAdapter : IPaymentProcessor
{
    private readonly LegacyBank _legacyBank;
    private readonly string _account;

    public LegacyBankAdapter(string account)
    {
        _legacyBank = new LegacyBank();
        _account = account;
    }

    public void Pay(decimal amount)
    {
        _legacyBank.MakePayment(_account, amount);
    }
}

// Usage
class Program
{
    static void Main()
    {
        IPaymentProcessor processor = new LegacyBankAdapter("123-ABC");
        Checkout checkout = new Checkout();
        checkout.CompletePurchase(processor, 500);
    }
}
```

### ✅ Output:
```
LegacyBank: Paying 500 from 123-ABC
```

---

## 🔻 Drawback (Without Adapter)
- Tight coupling to the **legacy system**
- Difficult to switch or update implementations
- Need to **modify working code** to integrate a new/old system

---

## ✅ How Adapter Pattern Overcomes It

| Issue (Without Adapter) | Solution (With Adapter) |
|--------------------------|-------------------------|
| Code rewrite needed      | No code change, just add Adapter |
| Tight coupling           | Adapter decouples dependencies |
| Hard to test/mock        | Interfaces support mocking |

---

## 🎯 Real-World Analogy

**Charger Adapter**: You have a US plug, but the socket is Indian. Instead of changing your device, you use an **adapter** to make it work.

---

## ✅ Summary

| Feature             | Adapter Pattern Benefit                  |
|---------------------|------------------------------------------|
| Purpose             | Bridge incompatible interfaces           |
| Usage               | Legacy code, third-party integration     |
| Benefit             | Reusability, decoupling, extensibility   |
