
# 🔗 Bridge Pattern in C#

## 🔍 Definition
The **Bridge Pattern** decouples an abstraction from its implementation so that the two can vary independently.

---

## ✅ When to Use
- When you want to avoid a permanent binding between abstraction and implementation.
- When both abstraction and implementation should be extensible.
- When changes in implementation shouldn't affect the client code.

---

## 🧠 Real-world Example: Remote Control and Devices

A `RemoteControl` (Abstraction) can work with multiple `Devices` (TV, Radio, etc.). Instead of binding a remote to a specific device, we use the Bridge Pattern to separate them.

---

## 👨‍💻 Step 1: Device Interface (Implementor)

```csharp
public interface IDevice
{
    void TurnOn();
    void TurnOff();
    void SetVolume(int level);
}
```

---

## 👨‍💻 Step 2: Concrete Devices

```csharp
public class TV : IDevice
{
    public void TurnOn() => Console.WriteLine("TV is ON");
    public void TurnOff() => Console.WriteLine("TV is OFF");
    public void SetVolume(int level) => Console.WriteLine($"TV volume set to {level}");
}

public class Radio : IDevice
{
    public void TurnOn() => Console.WriteLine("Radio is ON");
    public void TurnOff() => Console.WriteLine("Radio is OFF");
    public void SetVolume(int level) => Console.WriteLine($"Radio volume set to {level}");
}
```

---

## 👨‍💻 Step 3: RemoteControl (Abstraction)

```csharp
public class RemoteControl
{
    protected IDevice device;

    public RemoteControl(IDevice device)
    {
        this.device = device;
    }

    public virtual void TurnOn() => device.TurnOn();
    public virtual void TurnOff() => device.TurnOff();
    public virtual void SetVolume(int level) => device.SetVolume(level);
}
```

---

## 👨‍💻 Step 4: Advanced Remote (Refined Abstraction)

```csharp
public class AdvancedRemoteControl : RemoteControl
{
    public AdvancedRemoteControl(IDevice device) : base(device) { }

    public void Mute() => device.SetVolume(0);
}
```

---

## 👨‍💻 Step 5: Client Code

```csharp
class Program
{
    static void Main(string[] args)
    {
        IDevice tv = new TV();
        RemoteControl remote1 = new RemoteControl(tv);
        remote1.TurnOn();
        remote1.SetVolume(25);

        IDevice radio = new Radio();
        AdvancedRemoteControl remote2 = new AdvancedRemoteControl(radio);
        remote2.TurnOn();
        remote2.SetVolume(10);
        remote2.Mute();
    }
}
```

---

## 🖨️ Sample Output

```
TV is ON
TV volume set to 25
Radio is ON
Radio volume set to 10
Radio volume set to 0
```

---

## 🧠 Why This is a Bridge Pattern

| Element                  | Role                                      |
|--------------------------|-------------------------------------------|
| `RemoteControl`          | Abstraction                               |
| `AdvancedRemoteControl`  | Refined abstraction                       |
| `IDevice`                | Implementor interface                     |
| `TV`, `Radio`            | Concrete implementations                  |

---

## ✅ Benefits

- Separates interface from implementation.
- You can add new `Remotes` or `Devices` independently.
- Improves code **flexibility** and **maintainability**.

