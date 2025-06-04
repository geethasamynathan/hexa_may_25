# 📝 Assignment Questions on Hashtable and ArrayList in C#

---

## 🔸 1. Hashtable: Store and Retrieve Student Records

**Question:**  
Create a `Hashtable` to store student roll numbers and names. Add at least 5 records. Display all records.

```csharp
Hashtable students = new Hashtable();
students.Add(101, "Anjali");
students.Add(102, "Rahul");
students.Add(103, "Sneha");
students.Add(104, "Karan");
students.Add(105, "Neha");

foreach (DictionaryEntry entry in students)
{
    Console.WriteLine($"Roll No: {entry.Key}, Name: {entry.Value}");
}
```

---

## 🔸 2. ArrayList: Manage a List of Products

**Question:**  
Create an `ArrayList` and add 5 product names to it. Display all items.

```csharp
ArrayList products = new ArrayList();
products.Add("Mouse");
products.Add("Keyboard");
products.Add("Monitor");
products.Add("Laptop");
products.Add("Printer");

foreach (string product in products)
{
    Console.WriteLine($"Product: {product}");
}
```

---

## 🔸 3. Hashtable: Search for a Key and Update

**Question:**  
Search for a key in the hashtable. If found, update its value.

```csharp
if (students.ContainsKey(103))
{
    students[103] = "Sneha Reddy";
    Console.WriteLine("Updated successfully.");
}
else
{
    Console.WriteLine("Student not found.");
}
```

---

## 🔸 4. ArrayList: Remove Items by Index and Value

**Question:**  
Remove an item at index 2 and another item by value.

```csharp
products.RemoveAt(2); // Removes "Monitor"
products.Remove("Mouse");

foreach (string product in products)
{
    Console.WriteLine(product);
}
```

---

## 🔸 5. Hashtable: Count and Clear

**Question:**  
Print the total number of entries in the hashtable and then clear all.

```csharp
Console.WriteLine($"Total entries: {students.Count}");
students.Clear();
Console.WriteLine("All entries cleared.");
```

---

## 🔸 6. ArrayList: Sort and Reverse

**Question:**  
Sort and reverse an ArrayList of numbers.

```csharp
ArrayList numbers = new ArrayList() { 20, 5, 35, 10, 15 };
numbers.Sort();       // Sort ascending
numbers.Reverse();    // Then reverse to descending

foreach (int num in numbers)
{
    Console.WriteLine(num);
}
```

---

## 🔸 7. Hashtable: Try to Add Duplicate Key

**Question:**  
What happens if you try to add a duplicate key to a hashtable?

```csharp
try
{
    students.Add(101, "New Name");  // This will throw an exception
}
catch (ArgumentException)
{
    Console.WriteLine("Duplicate key not allowed.");
}
```

---

## 🔸 8. ArrayList: Insert at Specific Index

**Question:**  
Insert a product at index 1.

```csharp
products.Insert(1, "Tablet");

foreach (string p in products)
{
    Console.WriteLine(p);
}
```

---

## 🔸 9. Hashtable: Print Only Keys and Only Values

**Question:**  
Print just the keys, then just the values.

```csharp
Console.WriteLine("Keys:");
foreach (var key in students.Keys)
{
    Console.WriteLine(key);
}

Console.WriteLine("Values:");
foreach (var value in students.Values)
{
    Console.WriteLine(value);
}
```

---

## 🔸 10. ArrayList: Check if Item Exists

**Question:**  
Check if "Laptop" exists in the list.

```csharp
if (products.Contains("Laptop"))
{
    Console.WriteLine("Laptop is in the list.");
}
else
{
    Console.WriteLine("Laptop not found.");
}
```