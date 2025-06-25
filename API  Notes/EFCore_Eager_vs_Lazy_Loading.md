# 🎓 Eager Loading vs Lazy Loading in EF Core (ASP.NET Core Web API)

When working with relational databases in Entity Framework Core, you often have navigation properties (i.e., relationships). Choosing when to load related data gives rise to two strategies:

---

## 🟢 1. Eager Loading

### ✅ What is it?
Eager loading loads related data **along with the main entity** using a **single database query**.

### 🔧 Syntax:
```csharp
var students = context.Students.Include(s => s.Courses).ToList();
```

### ✅ Use Case:
- You **know** you’ll need related data and want to **reduce round-trips to the database**.

### 📦 Example:

#### Models:
```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Course> Courses { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
}
```

#### Controller:
```csharp
[HttpGet]
public IActionResult GetStudents()
{
    var data = _context.Students.Include(s => s.Courses).ToList();
    return Ok(data);
}
```

---

## 🟠 2. Lazy Loading

### ✅ What is it?
Lazy loading loads related data **only when you access it in code** — not during the initial query.

### ⚠️ Requirements:
- Install Lazy Loading Proxies
- Navigation properties must be marked `virtual`

### 🔧 Setup:

#### Install package:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Proxies
```

#### Configure in `Program.cs`:
```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("YourConnectionString")
           .UseLazyLoadingProxies());
```

#### Model:
```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Course> Courses { get; set; } // Virtual is required
}
```

#### Controller:
```csharp
[HttpGet("{id}")]
public IActionResult GetStudent(int id)
{
    var student = _context.Students.FirstOrDefault(s => s.Id == id);

    var courses = student.Courses; // Triggers separate query

    return Ok(new {
        StudentName = student.Name,
        CourseCount = courses.Count()
    });
}
```

---

## 🔁 Comparison Table

| Feature          | Eager Loading                          | Lazy Loading                             |
|------------------|----------------------------------------|-------------------------------------------|
| When data loads  | Immediately with main query            | On first access to navigation property    |
| Performance      | Fewer queries, but potentially large   | Many small queries, possible N+1 issue    |
| Setup            | Uses `.Include()`                      | Requires `virtual` + proxies              |
| Use Case         | Needed data always                     | Conditionally accessed data               |

---

## ❗ When to Use What?

| Scenario | Use |
|----------|-----|
| You need related data always | **Eager Loading** |
| You may not always need related data | **Lazy Loading** |
| Performance is critical | Prefer Eager with `.Select()` or Explicit Loading |

---

