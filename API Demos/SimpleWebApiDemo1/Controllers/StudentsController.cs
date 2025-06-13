using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApiDemo1.Models;
using SimpleWebApiDemo1.Repositories;
using System.Net;

namespace SimpleWebApiDemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            
            _studentService = studentService;
        }
        //[HttpGet("All")]
        //[HttpGet("AllStudents")]
        //[HttpGet("GetAllStudents")]
        [HttpGet("api/old-students")]
        [HttpGet("api/stu")]
        public  List<Student> GetStudents()
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

        [HttpGet("Search")]
        public IActionResult searchStudent([FromQuery] StudentSearch studentSearch)
        {
            var result=_studentService.SearchStudents(studentSearch);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        //[HttpGet("age/{age:range(18,60)}")]
        //public List<Student> GetStudents(int age)
        //{
        //    try
        //    {
        //        return _studentService.GetStudentByAge(age);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [HttpGet("getbyid/{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var student=_studentService.GetStudent(id);
                if(student == null)
                {
                    return NotFound();
                }
                else
                return Ok(student);
            }
            catch (Exception ex)           {

                throw new Exception(ex.Message);
            }
        }

       // [HttpGet("searchByName/{name:alpha}")]
       // public IActionResult GetStudentByName(string name)
       // {
       //     try {
       //         var student = _studentService.GetStudentsByName(name);
       //         if(student == null)
       //         {
       //             return NotFound(name);
       //         }
       //         else
       //         {
       //             return Ok(student);
       //         }

       //     }
       //     catch(Exception ex)
       //     {
       //         throw new Exception(ex.Message);
       //     }
       // }
       //// [HttpGet("searchByName/{name:alpha}")]
       // //[HttpGet("Gender/{gender}/City/{city}")]
       // [HttpGet("SearchByGenderCity")]
       // public IActionResult GetStudentsByGenderAndCity([FromQuery]string? gender,[FromQuery]string? city)
       // {
       //     try
       //     {
       //         var students = _studentService.GetStudentByGenderAndCity(gender,city);
       //         if (students == null)
       //         {
       //             return NotFound($"No students Found with {gender} in City {city}");
       //         }
       //         else
       //         {
       //             return Ok(students);
       //         }

       //     }
       //     catch (Exception ex)
       //     {
       //         throw new Exception(ex.Message);
       //     }
       // }
        [HttpPost("create")]
        public IActionResult NewStudent(Student student)
        {
           var id= _studentService.AddStudent(student);
            if(id == 0)
            {
                return BadRequest();
            }
            return Ok($"Student with {id} added");
        }

        [HttpPut("update/{id}")]
        public IActionResult Put(int id,Student student)
        {
          var result= _studentService.UpdateStudent(student);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result= _studentService.DeleteStudent(id);
            return Ok(result);
        }
    }
}
