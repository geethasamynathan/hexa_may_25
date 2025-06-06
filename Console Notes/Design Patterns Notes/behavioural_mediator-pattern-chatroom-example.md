
# 🧩 Mediator Pattern in C#

## 🔄 Definition
The **Mediator Pattern** defines an object that encapsulates how a set of objects interact. It promotes loose coupling by keeping objects from referring to each other explicitly.

---

## ✅ Real-world Example: Chat Room

### Scenario:
A `ChatRoom` acts as a mediator that handles message communication between multiple `User` objects. Users do not talk to each other directly.

---

## 👨‍💻 Step 1: Mediator Interface

```csharp
public interface IChatMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
}
```

---

## 👨‍💻 Step 2: Concrete Mediator – ChatRoom

```csharp
public class ChatRoom : IChatMediator
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in users)
        {
            if (user != sender)
            {
                user.Receive(message, sender.Name);
            }
        }
    }
}
```

---

## 👨‍💻 Step 3: Colleague Class – User

```csharp
public class User
{
    public string Name { get; }
    private IChatMediator chatMediator;

    public User(string name, IChatMediator chatMediator)
    {
        Name = name;
        this.chatMediator = chatMediator;
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        chatMediator.SendMessage(message, this);
    }

    public void Receive(string message, string from)
    {
        Console.WriteLine($"{Name} receives from {from}: {message}");
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
        IChatMediator chatRoom = new ChatRoom();

        User alice = new User("Alice", chatRoom);
        User bob = new User("Bob", chatRoom);
        User charlie = new User("Charlie", chatRoom);

        chatRoom.AddUser(alice);
        chatRoom.AddUser(bob);
        chatRoom.AddUser(charlie);

        alice.Send("Hello everyone!");
        bob.Send("Hi Alice!");
    }
}
```

---

## 🖨️ Output

```
Alice sends: Hello everyone!
Bob receives from Alice: Hello everyone!
Charlie receives from Alice: Hello everyone!

Bob sends: Hi Alice!
Alice receives from Bob: Hi Alice!
Charlie receives from Bob: Hi Alice!
```

---

## 🧠 Why This is a Mediator Pattern

| Concept        | Explanation |
|----------------|-------------|
| **Mediator**   | `ChatRoom` centralizes all communication. |
| **Colleagues** | `User` instances use the mediator and do not reference each other. |
| **Loose Coupling** | Users can be added/removed without modifying other classes. |

---

## ✅ Summary

- Mediator Pattern simplifies complex communication between classes.
- Promotes **loose coupling** and **centralized communication control**.
- Useful in scenarios like chat apps, UI component coordination, and traffic control systems.
