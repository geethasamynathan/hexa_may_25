
# IEnumerable and IEnumerator in C#

## 🔷 What is `IEnumerable` in C#?

- `IEnumerable` is an interface that allows **iteration over a collection** using a `foreach` loop.
- It is **read-only** — you can only **traverse** the collection, not modify it.
- Found in:
  - `System.Collections` for non-generic collections
  - `System.Collections.Generic` for generic collections

### ✅ Common Use Case:
You implement `IEnumerable` when you want your custom class to be **iterable** using `foreach`.

### Example:
```csharp
using System;
using System.Collections;
using System.Collections.Generic;

public class FruitCollection : IEnumerable<string>
{
    private List<string> fruits = new List<string> { "Apple", "Banana", "Cherry" };

    public IEnumerator<string> GetEnumerator()
    {
        return fruits.GetEnumerator();  // Uses List's built-in enumerator
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();  // Non-generic implementation
    }
}

class Program
{
    static void Main()
    {
        var fruits = new FruitCollection();

        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }
    }
}
```

---

## 🔷 What is `IEnumerator` in C#?

- `IEnumerator` is used to **iterate through a collection manually**.
- It has two key members:
  - `MoveNext()` – advances to the next element.
  - `Current` – gets the current element.
  - `Reset()` – moves the pointer back to before the first element (rarely used).

### Example:
```csharp
using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> colors = new List<string> { "Red", "Green", "Blue" };
        IEnumerator<string> enumerator = colors.GetEnumerator();

        while (enumerator.MoveNext())
        {
            string color = enumerator.Current;
            Console.WriteLine(color);
        }
    }
}
```

---

## 🔁 Key Differences

| Feature           | `IEnumerable`                      | `IEnumerator`                          |
|------------------|------------------------------------|----------------------------------------|
| Purpose           | Makes a class iterable             | Iterates over items in a collection    |
| Methods           | `GetEnumerator()`                  | `MoveNext()`, `Current`, `Reset()`     |
| Use with `foreach`| Yes                                | No (used internally by `foreach`)      |
| Modification      | No modification allowed            | No modification allowed                |

---

## 📌 Summary

- `IEnumerable` lets your collection be used in a `foreach` loop.
- `IEnumerator` performs the **step-by-step iteration** internally.
- You return an `IEnumerator` from `IEnumerable.GetEnumerator()`.
