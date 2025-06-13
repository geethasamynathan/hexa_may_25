
## ✅ What are Route Constraints?

Route constraints restrict the **format or values** of route parameters. They ensure only valid routes reach your action methods.

---

## 🔸 Common Route Constraints

| Constraint     | Description                                 | Example            |
|----------------|---------------------------------------------|--------------------|
| `int`          | Matches integer values                      | `{id:int}`         |
| `bool`         | Matches Boolean values                      | `{active:bool}`    |
| `datetime`     | Matches DateTime values                     | `{dob:datetime}`   |
| `decimal`      | Matches decimal values                      | `{amount:decimal}` |
| `double`       | Matches double values                       | `{rate:double}`    |
| `guid`         | Matches GUID values                         | `{id:guid}`        |
| `length(n)`    | Matches exact string length                 | `{code:length(5)}` |
| `minlength(n)` | Minimum string length                       | `{code:minlength(3)}` |
| `maxlength(n)` | Maximum string length                       | `{code:maxlength(8)}` |
| `range(a,b)`   | Matches numerical range                     | `{age:range(18,60)}` |
| `alpha`        | Alphabetic characters only                  | `{name:alpha}`     |
| `regex(x)`     | Matches regex pattern                       | `{postalcode:regex(^\\d{{6}}$)}` |

---

## ✅ Updated Controller with Route Constraints

```csharp
using Microsoft.AspNetCore.Mvc;
using SimpleWebApiDemo1.Models;
using SimpleWebApiDemo1.Repositories;

namespace SimpleWebApiDemo1.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET api/students/getall
        [HttpGet("getall")]
        public List<Student> GetAllStudents()
        {
            return _studentService.GetAllStudents();
        }

        // GET api/students/getbyid/5 (only if ID is int)
        [HttpGet("getbyid/{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        // GET api/students/searchbyname/John (only alphabets)
        [HttpGet("searchbyname/{name:alpha}")]
        public IActionResult GetStudentByName(string name)
        {
            var result = _studentService.GetAllStudents()
                                        .Where(s => s.Name.ToLower().Contains(name.ToLower()))
                                        .ToList();
            return Ok(result);
        }

        // GET api/students/age/25 (only between 18 and 60)
        [HttpGet("age/{age:range(18,60)}")]
        public IActionResult GetByAge(int age)
        {
            var result = _studentService.GetAllStudents()
                                        .Where(s => s.Age == age)
                                        .ToList();
            return Ok(result);
        }

        // POST api/students/create
        [HttpPost("create")]
        public IActionResult CreateStudent(Student student)
        {
            var id = _studentService.AddStudent(student);
            if (id == 0)
                return BadRequest();
            return Ok($"Student with ID {id} added.");
        }

        // PUT api/students/update/5
        [HttpPut("update/{id:int}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var result = _studentService.UpdateStudent(student);
            return Ok(result);
        }

        // DELETE api/students/delete/5
        [HttpDelete("delete/{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = _studentService.DeleteStudent(id);
            return Ok(result);
        }
    }
}
```

---

## ✅ Summary

### 🔹 Advantages of Using Route Constraints

- Adds **validation at routing level**
- Reduces **unnecessary execution** of controller logic
- Improves **performance and routing precision**

### 🔹 When to Use

- When routes are ambiguous
- When expecting specific data types (e.g., `int`, `guid`)
- When enforcing format or range (e.g., `age:range(18,60)`)

---

## ✅ Example URLs

| Method                      | Route                               |
|----------------------------|--------------------------------------|
| Get all students           | `/api/students/getall`              |
| Get student by ID          | `/api/students/getbyid/5`           |
| Get student by name        | `/api/students/searchbyname/John`   |
| Get students by age        | `/api/students/age/22`              |
| Create new student         | `/api/students/create`              |
| Update student             | `/api/students/update/5`            |
| Delete student             | `/api/students/delete/5`            |

---