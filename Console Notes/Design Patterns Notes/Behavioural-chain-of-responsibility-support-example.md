
# 🔗 Chain of Responsibility Pattern in C#

## 📘 Definition
The **Chain of Responsibility** pattern allows a request to pass through a chain of handlers. Each handler decides either to process the request or pass it to the next handler in the chain.

---

## ✅ Real-world Example: Support Ticket System

### Scenario:
We simulate a support system with:
- **Level 1 Support**
- **Level 2 Support**
- **Manager Support**

Each level decides whether it can handle a request based on the issue type.

---

## 👨‍💻 Step 1: Define Abstract Handler

```csharp
public abstract class SupportHandler
{
    protected SupportHandler nextHandler;

    public void SetNext(SupportHandler next)
    {
        nextHandler = next;
    }

    public abstract void HandleRequest(string issueType);
}
```

---

## 👨‍💻 Step 2: Create Concrete Handlers

```csharp
public class Level1Support : SupportHandler
{
    public override void HandleRequest(string issueType)
    {
        if (issueType == "Password Reset")
        {
            Console.WriteLine("Level 1 Support: Handled password reset.");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(issueType);
        }
    }
}

public class Level2Support : SupportHandler
{
    public override void HandleRequest(string issueType)
    {
        if (issueType == "Software Bug")
        {
            Console.WriteLine("Level 2 Support: Handled software bug.");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(issueType);
        }
    }
}

public class ManagerSupport : SupportHandler
{
    public override void HandleRequest(string issueType)
    {
        Console.WriteLine($"Manager: Handling issue - {issueType}");
    }
}
```

---

## 👨‍💻 Step 3: Client Code

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Setup chain
        SupportHandler level1 = new Level1Support();
        SupportHandler level2 = new Level2Support();
        SupportHandler manager = new ManagerSupport();

        level1.SetNext(level2);
        level2.SetNext(manager);

        // Simulate requests
        level1.HandleRequest("Password Reset");
        level1.HandleRequest("Software Bug");
        level1.HandleRequest("Refund Request");
    }
}
```

---

## 🖨️ Output

```
Level 1 Support: Handled password reset.
Level 2 Support: Handled software bug.
Manager: Handling issue - Refund Request
```

---

## 🧠 Why This is a Chain of Responsibility

| Concept                  | Explanation                                                |
|--------------------------|------------------------------------------------------------|
| **Handlers**             | Level1Support, Level2Support, ManagerSupport               |
| **Next handler logic**   | Each handler decides whether to handle or pass the request |
| **Dynamic flow**         | You can add/remove handlers without changing the caller    |
| **Decoupling**           | The client (`Main`) doesn’t know who will handle the request |

---

## ✅ Summary

- Useful when multiple handlers may process a request.
- Promotes **loose coupling** and **flexibility**.
- Commonly used in **middleware**, **logging**, **support systems**, etc.
