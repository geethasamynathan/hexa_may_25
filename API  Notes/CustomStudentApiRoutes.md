
# ASP.NET Core Web API – Custom Route Attribute Example

This markdown provides an updated example of an ASP.NET Core Web API controller using **custom route names** for each HTTP method using the `Route` attribute.

---

## ✅ Custom Routing in Controller

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
            try
            {
                return _studentService.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET api/students/getbyid/1
        [HttpGet("getbyid/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = _studentService.GetStudent(id);
                if (student == null)
                    return NotFound();
                return Ok(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        // PUT api/students/update/1
        [HttpPut("update/{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var result = _studentService.UpdateStudent(student);
            return Ok(result);
        }

        // DELETE api/students/delete/1
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = _studentService.DeleteStudent(id);
            return Ok(result);
        }
    }
}
```

---

## ✅ Endpoint Summary

| Action              | HTTP Method | URL                            |
|---------------------|-------------|---------------------------------|
| Get all students    | GET         | `/api/students/getall`         |
| Get by ID           | GET         | `/api/students/getbyid/1`      |
| Create new student  | POST        | `/api/students/create`         |
| Update student      | PUT         | `/api/students/update/1`       |
| Delete student      | DELETE      | `/api/students/delete/1`       |

---

## ✅ Benefits of Custom Named Routes

- Improves readability and self-documentation of APIs
- Easier for consumers to understand and use
- Useful for versioning or grouped operations