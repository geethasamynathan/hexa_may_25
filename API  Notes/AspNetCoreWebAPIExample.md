# ASP.NET Core Web API – Complete Tutorial

## ✅ What is ASP.NET Core Web API?

**ASP.NET Core Web API** is a framework for building **HTTP-based RESTful services** using ASP.NET Core. It allows you to expose **data** and **functionality** over HTTP in a **platform-independent** manner. It is ideal for building **microservices**, **mobile backends**, **web apps**, or **third-party integrations**.

---

## ✅ When to Use Web API?

Use ASP.NET Core Web API when you:

- Want to expose data over HTTP for clients like mobile apps, SPAs, or third-party services.
- Need to create a backend service for web or mobile apps.
- Are building **microservices** or **serverless** APIs.
- Want to implement **RESTful CRUD operations** (Create, Read, Update, Delete).

---

## ✅ Why Use Web API?

- **Cross-platform**: Runs on Windows, Linux, and macOS.
- **Lightweight and Fast**: Built on top of high-performance Kestrel web server.
- **Flexible Routing** and HTTP verb support.
- **Built-in Dependency Injection**.
- **Secure and Scalable** with built-in middleware for authentication and logging.

---

## ✅ Step-by-Step Example: Create a Simple ASP.NET Core Web API

We’ll build a **Student API** that supports basic CRUD operations.

---

### 🔹 Step 1: Create a New Project

In **Visual Studio 2022** or using CLI:

```bash
dotnet new webapi -n StudentApi
cd StudentApi
```

---

### 🔹 Step 2: Define the Model

`Models/Student.cs`

```csharp
namespace StudentApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
    }
}
```

---

### 🔹 Step 3: Create a Repository (In-Memory)

`Repository/StudentRepository.cs`

```csharp
using StudentApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentApi.Repository
{
    public class StudentRepository
    {
        private static List<Student> students = new()
        {
            new Student { Id = 1, Name = "Arjun", Course = "C#" },
            new Student { Id = 2, Name = "Meera", Course = "Azure" }
        };

        public List<Student> GetAll() => students;
        public Student GetById(int id) => students.FirstOrDefault(s => s.Id == id);
        public void Add(Student student) => students.Add(student);
        public void Update(Student student)
        {
            var index = students.FindIndex(s => s.Id == student.Id);
            if (index != -1) students[index] = student;
        }
        public void Delete(int id) => students.RemoveAll(s => s.Id == id);
    }
}
```

---

### 🔹 Step 4: Register the Repository

`Program.cs`

```csharp
builder.Services.AddSingleton<StudentRepository>();
```

---

### 🔹 Step 5: Create the Controller

`Controllers/StudentController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Repository;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _repo;
        public StudentController(StudentRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _repo.GetById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _repo.Add(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            if (id != student.Id) return BadRequest();
            _repo.Update(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return NoContent();
        }
    }
}
```

---

### 🔹 Step 6: Test the API

Run the app and test endpoints using **Postman** or **Swagger**:

| HTTP Method | Endpoint            | Description        |
|-------------|---------------------|--------------------|
| GET         | `/api/student`      | Get all students   |
| GET         | `/api/student/1`    | Get by ID          |
| POST        | `/api/student`      | Add new student    |
| PUT         | `/api/student/1`    | Update student     |
| DELETE      | `/api/student/1`    | Delete student     |

---

## ✅ Explanation

| Component  | Description |
|------------|-------------|
| Model      | Represents the data structure (Student). |
| Repository | Manages in-memory storage. Acts like a database. |
| Controller | Handles HTTP requests and sends responses. |
| DI         | Injects repository for testability. |
| Swagger    | Auto-generated UI for testing endpoints. |

---