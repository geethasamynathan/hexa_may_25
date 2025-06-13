# ✅ Routing in ASP.NET Core Web API

Routing is the process of mapping **HTTP requests** to the correct **controller action method**.  
In ASP.NET Core, routing determines which endpoint should handle the request based on the **URL pattern** and **HTTP method** (`GET`, `POST`, etc.).

---

## ✅ Types of Routing

| Routing Type        | Description |
|---------------------|-------------|
| **Conventional Routing** | Defined in `Program.cs` or `Startup.cs`, follows a URL pattern like `"{controller=Home}/{action=Index}/{id?}"`. Common in MVC. |
| **Attribute Routing** | Applied directly to controller and action methods using attributes like `[Route("api/students")]`, `[HttpGet("id")]`. Common in Web API. |

---

## ✅ Your Code Uses: Attribute Routing

### 🔷 Example of Attribute Routing:

```csharp
[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    [HttpGet]                 // Matches: GET api/students
    public List<Student> GetStudents();

    [HttpGet("id")]           // Matches: GET api/students/id?value=1 (❌ Incorrect usage!)
    public IActionResult Get(int id);

    [HttpPost]                // Matches: POST api/students
    public IActionResult NewStudent(Student student);

    [HttpPut("id")]           // Matches: PUT api/students/id?value=1
    public IActionResult Put(int id, Student student);

    [HttpDelete("id")]        // Matches: DELETE api/students/id?value=1
    public IActionResult Delete(int id);
}
```

---

### ❗ Issue in Above Code:
The use of `"id"` as a fixed string leads to incorrect routing. It should be changed to capture the actual ID from the URL path.

```csharp
[HttpGet("{id}")]
[HttpPut("{id}")]
[HttpDelete("{id}")]
```

These match:

- `GET api/students/1`
- `PUT api/students/1`
- `DELETE api/students/1`

---

## ✅ Corrected Attribute Routing Example

```csharp
[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    [HttpGet]                      // GET api/students
    public List<Student> GetStudents() { ... }

    [HttpGet("{id}")]              // GET api/students/1
    public IActionResult Get(int id) { ... }

    [HttpPost]                     // POST api/students
    public IActionResult NewStudent(Student student) { ... }

    [HttpPut("{id}")]              // PUT api/students/1
    public IActionResult Put(int id, Student student) { ... }

    [HttpDelete("{id}")]           // DELETE api/students/1
    public IActionResult Delete(int id) { ... }
}
```

---

## ✅ Example of Conventional Routing (for comparison)

### 🔹 In `Program.cs`:

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=GetStudents}/{id?}");
```

---

### 🔹 Then in your Controller:

```csharp
public class StudentsController : Controller
{
    public IActionResult GetStudents()         // GET /Students/GetStudents
    public IActionResult Get(int id)           // GET /Students/Get?id=1
    public IActionResult NewStudent(Student s) // POST /Students/NewStudent
}
```

---

## ✅ Summary

- **Attribute Routing** gives you more control and flexibility over each route.
- **Conventional Routing** is simpler and fits better in traditional MVC apps.