
# ✅ Observer Pattern Example in C# – Stock Price Notifier

## 🔍 Scenario
We have a `Stock` class (Subject) whose price can change. Observers like `MobileApp` and `WebApp` want to be notified whenever the stock price changes.

---

## 👨‍💻 Step 1: Interfaces

```csharp
public interface IObserver
{
    void Update(decimal price);
}

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
```

---

## 👨‍💻 Step 2: Concrete Subject – Stock

```csharp
public class Stock : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private decimal price;

    public void RegisterObserver(IObserver observer) => observers.Add(observer);
    public void RemoveObserver(IObserver observer) => observers.Remove(observer);

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(price);
        }
    }

    public void SetPrice(decimal newPrice)
    {
        Console.WriteLine($"\nStock: Price changed to {newPrice:C}");
        price = newPrice;
        NotifyObservers();
    }
}
```

---

## 👨‍💻 Step 3: Concrete Observers

```csharp
public class MobileApp : IObserver
{
    public void Update(decimal price)
    {
        Console.WriteLine($"📱 Mobile App: New stock price is {price:C}");
    }
}

public class WebApp : IObserver
{
    public void Update(decimal price)
    {
        Console.WriteLine($"💻 Web App: New stock price is {price:C}");
    }
}
```

---

## 👨‍💻 Step 4: Client Code

```csharp
class Program
{
    static void Main(string[] args)
    {
        Stock appleStock = new Stock();

        MobileApp mobile = new MobileApp();
        WebApp web = new WebApp();

        appleStock.RegisterObserver(mobile);
        appleStock.RegisterObserver(web);

        appleStock.SetPrice(135.50m);
        appleStock.SetPrice(137.75m);

        appleStock.RemoveObserver(web);

        appleStock.SetPrice(140.00m);
    }
}
```

---

## 🖨️ Sample Output

```
Stock: Price changed to $135.50
📱 Mobile App: New stock price is $135.50
💻 Web App: New stock price is $135.50

Stock: Price changed to $137.75
📱 Mobile App: New stock price is $137.75
💻 Web App: New stock price is $137.75

Stock: Price changed to $140.00
📱 Mobile App: New stock price is $140.00
```

---

## 🧠 Why This is an Observer Pattern

| Concept             | In This Example                |
|---------------------|--------------------------------|
| **Subject**         | `Stock`                        |
| **Observer**        | `MobileApp`, `WebApp`          |
| **Notification**    | `NotifyObservers()` method     |
| **Loose Coupling**  | `Stock` doesn’t know who the observers are specifically — just that they implement `IObserver` |

---

## ✅ Summary

- Observer Pattern allows multiple objects to watch a subject and get updated on state changes.
- Helps build loosely coupled, event-driven systems.
