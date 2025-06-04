# 📌 Hashtable in C#

## What is a Hashtable?

A **Hashtable** is a collection of key-value pairs, where **each key is unique**. It belongs to the `System.Collections` namespace and is used when you want to **quickly look up values based on keys**.

```csharp
Hashtable ht = new Hashtable();
ht["id"] = 101;
ht["name"] = "John";
```

---

## 🔍 Differences Between Hashtable and ArrayList

| Feature              | Hashtable                        | ArrayList                      |
|----------------------|----------------------------------|--------------------------------|
| Structure            | Key-Value pairs                  | Index-based collection         |
| Key uniqueness       | Keys must be unique              | No keys, just values           |
| Lookup Time          | Fast (O(1) on average)           | Slower (O(n)) for search       |
| Type Safety (non-generic) | Not type-safe                | Not type-safe                  |
| Suitable For         | Mapping and dictionary-like use | Storing lists of items         |

---

## 🛒 Real-World Example: Shopping Cart

```csharp
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Hashtable cart = new Hashtable();

        // Add items
        cart.Add("P1001", "Laptop");
        cart.Add("P1002", "Mouse");
        cart.Add("P1003", "Keyboard");

        // Display all items
        Console.WriteLine("🛒 Shopping Cart Contents:");
        foreach (DictionaryEntry item in cart)
        {
            Console.WriteLine($"Product Code: {item.Key}, Name: {item.Value}");
        }

        // Check if a key exists
        Console.WriteLine("\n🔍 Check if 'P1002' exists:");
        Console.WriteLine(cart.ContainsKey("P1002") ? "Yes, it's in the cart." : "Nope.");

        // Check if a value exists
        Console.WriteLine("\n🔍 Check if 'Monitor' is in cart:");
        Console.WriteLine(cart.ContainsValue("Monitor") ? "Found!" : "Not Found!");

        // Remove an item
        Console.WriteLine("\n🗑 Removing 'P1002'...");
        cart.Remove("P1002");

        // Try to access removed item
        Console.WriteLine("\n🎯 Accessing removed item 'P1002':");
        if (cart["P1002"] == null)
            Console.WriteLine("Item not found.");
        else
            Console.WriteLine(cart["P1002"]);

        // Update an existing item
        Console.WriteLine("\n✏️ Updating 'P1001' to 'Gaming Laptop'");
        cart["P1001"] = "Gaming Laptop";

        // Display updated cart
        Console.WriteLine("\n✅ Updated Cart:");
        foreach (DictionaryEntry item in cart)
        {
            Console.WriteLine($"Product Code: {item.Key}, Name: {item.Value}");
        }

        // Clear the cart
        Console.WriteLine("\n🧹 Clearing the cart...");
        cart.Clear();

        Console.WriteLine("\n🛒 Items after clear:");
        Console.WriteLine(cart.Count == 0 ? "Cart is empty." : "Cart still has items.");
    }
}
```

---

## 🔧 Hashtable Key Methods & Properties

| Method / Property     | Description |
|-----------------------|-------------|
| `Add(key, value)`     | Adds an item |
| `Remove(key)`         | Removes the item with the specified key |
| `ContainsKey(key)`    | Checks if the key exists |
| `ContainsValue(value)`| Checks if the value exists |
| `Clear()`             | Removes all entries |
| `Count`               | Gets the number of items |
| Indexer `ht[key]`     | Access or assign a value by key |
| `Keys`, `Values`      | Get collections of keys or values |

---

## 📌 Notes

- Non-generic: Use `Dictionary<TKey, TValue>` in modern C# for type safety.
- Not thread-safe: Use `Hashtable.Synchronized()` if needed.